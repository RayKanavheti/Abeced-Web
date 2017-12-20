using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.Resolvers;
using System.Web.Mvc;
using Abeced.Data;
using Abeced.Data.Repository;
using Abeced.UI.Helpers;
using Abeced.UI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abeced.UI.Controllers
{
    /// <summary>
    /// Controller for Flash Card. Implement functions to manupulate cards
    /// </summary>
    [Authorize]
    public class FlashController : AsyncController
    {
        private static int MIN_CARDS = 8;

        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IRepository _repos = new Repository();
            IList<LookupCategory> catg = new List<LookupCategory>();
            CategoryListModel model = new CategoryListModel();
            IList<Cardsession> revs = GetRevisions(User.Identity.Name);

            catg = _repos.GetCategoryList(false);

            model.Categories = catg.Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Catid

            }).OrderBy(n => n.CategoryTitle).ToList(); //.Sort(xx=>xx.CategoryTitle).;
            return View(model);
        }

        /// <summary>
        /// Finisheds the cards.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        /// <returns></returns>
        public ActionResult FinishedCards(string SessionId)
        {
            IRepository _repos = new Repository();
            CardRevision cardrev = _repos.GetRevision(SessionId);
            Cardsession cardsess = _repos.GetCardSession(cardrev.Cardsession.CsessionId);

            if (cardsess.Completed != true)
            {
                cardsess.Completed = true;
                cardsess.CompletedDate = DateTime.Now;
                cardsess.RevisedLevel = -10;
                cardrev.Revisionslist = "-10";
            }
            else
            {
                //check if this is a scheduled Revision
                if (ValidateRevision(cardsess, _repos))
                {
                    //revise levels are increasing integers except for same day revisions which are -ves -10 for 10minute..etc
                    cardsess.RevisedLevel = cardsess.RevisedLevel != -10 ? cardsess.RevisedLevel + 1 : 1;
                    cardrev.Revisionslist = cardsess.RevisedLevel.ToString();
                }
            }

            cardrev.Completed = true;
            cardrev.CompletedDate = DateTime.Now;
            cardsess.Lastupdate = DateTime.Now;

            _repos.SaveOrUpdate(cardsess);
            _repos.SaveOrUpdate(cardrev);

            return PartialView();
        }

        /// <summary>
        /// Cards the specified cid.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="sub">The sub.</param>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>

        public ActionResult FinishedQuiz(string SessionId)
        {
            return PartialView();
        }

        /// <summary>
        /// Cards the specified cid.
        /// </summary>
        /// <param name="cid">The cid.</param>
        /// <param name="sub">The sub.</param>
        /// <param name="sid">The sid.</param>
        /// <returns></returns>
        public ActionResult Card(string cid, string sub, string sid, string cards)
        {
            ViewData["cid"] = cid;
            ViewData["sub"] = sub;
            string[] selcards = cards.Split(',');
            IRepository _repos = new Repository();
            IList<Cardsession> user_session = _repos.GetUserSessionList(User.Identity.Name, cid);
            IList<Cardsession> pendr_session = new List<Cardsession>();
            IList<Cardsession> sameday_pend_session = new List<Cardsession>();
            IList<Cardsession> pending_rev = new List<Cardsession>();
            Cardsession pending_session = new Cardsession();
            Cardsession previous_session = new Cardsession();
            IList<Flashcard> cardAll = new List<Flashcard>();
            IList<Flashcard> previousCards = new List<Flashcard>();
            FlashCardSessionModel model = new FlashCardSessionModel();
            Person pers = _repos.GetPerson(User.Identity.Name);
            int numcards = 8;
            if (pers != null && Convert.ToInt16(pers.UserPreferencesXml) != 0)
                numcards = Convert.ToInt16(pers.UserPreferencesXml);

            List<string> revised_cards = new List<string>();

            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name, cid);
            IList<CardRevision> pending_revisions = new List<CardRevision>();
            IList<LookupRevisetime> rTime = new List<LookupRevisetime>();

            if (user_session.Count() != 0)
            {
                pending_revisions = user_revisions.Where(x => x.Completed != true).ToList();  //actual pending revisions
                pending_session = user_session.Where(x => x.Completed != true).SingleOrDefault();
                previous_session = user_session.Where(x => x.Completed == true).OrderByDescending(xx => xx.CompletedDate).FirstOrDefault();
                pending_rev = user_session.Where(x => x.Completed == true && x.RevisedLevel != 0).ToList();
                //rTime = _repos.GetRevisionTimeList();
                foreach (var rr in pending_rev)
                {
                    //CardRevision revs = rr.CardRevisionList.Where(y => y.Completed == true).OrderByDescending(x => x.CompletedDate).FirstOrDefault();
                    if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                    //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                    {
                        pendr_session.Add(rr);
                    }
                    else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                        (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative (DateTime.Now - rr.Lastupdate.Value).Minutes >= 10)
                    {
                        pendr_session.Add(rr);
                    }
                    else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && rr.RevisedLevel < 0)
                    {
                        sameday_pend_session.Add(rr);
                    }
                }
            }

            if (user_session.Count() != 0 && previous_session != null)
            {
                previousCards = _repos.GetFlashCardList(previous_session.CardsInSession.Split(',')); //todo check for duplicates
            }

            if (user_session.Count() != 0 && pending_revisions.Count() != 0)
            {
                pending_session = _repos.GetCardSession(pending_revisions.FirstOrDefault().Cardsession.CsessionId);
                List<string> pendingcard_ids = pending_session.CardsInSession.Split(',').Distinct().ToList();
                List<string> completed_ids = pending_session.CardRevisionList.Where(y => y.Completed != true).SingleOrDefault().CorrectCards != null ?
                    pending_session.CardRevisionList.Where(y => y.Completed != true).SingleOrDefault().CorrectCards.Split(',').ToList() : new List<string>();
                completed_ids = completed_ids.Distinct().ToList();
                string ask_later_ids = pending_session.AskLater;
                var askdict = ask_later_ids == null ? new Dictionary<string, string>() : ask_later_ids.Split(',').Select(x => x.Split(':'))
                    .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                    .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                List<string> never_ids = askdict.Where(x => x.Value == "0").Select(y => y.Key).ToList();  //remove the "ask never cards"
                //completed_ids.AddRange(never_ids);
                pendingcard_ids = pendingcard_ids.Except(completed_ids).ToList();
                pendingcard_ids = pendingcard_ids.Except(never_ids).ToList();
                cardAll = _repos.GetAllFlashCardList(cid, pendingcard_ids);   //todo restruct to my own and approved cards

                model.catid = cid;
                model.MsessId = pending_session.CsessionId;
                model.CompletedCards = completed_ids.Count(); //pending_session.Finishedcount.HasValue ? pending_session.Finishedcount.Value : 0;
                model.PercentComplete = 0; // (model.CompletedCards * 100) / cardAll.Count(); --fix later
                model.finishedCards = pending_session.Finishedcount.HasValue ? pending_session.Finishedcount.Value : 0;
                //if unfinished card is just 1, inculde at least to from completed ones.........
                if (cardAll.Count() != 0 && cardAll.Count() <= 2)
                {
                    cardAll.AddRange(_repos.GetAllFlashCardList(cid, completed_ids.Except(never_ids).ToList()).Take(3));
                }
                model.FlashCards = cardAll.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).ToList();

                if (previousCards.Count() == 0)
                {
                    previousCards = _repos.GetAllFlashCardList(cid, completed_ids.Except(never_ids).ToList());   //refill from completed cards if theere are no previous completed sessions
                }
                if (previousCards.Count() == 0 && user_session.Count() > 1)
                {
                    Cardsession xtrasess = user_session.Where(x => x.Completed == true && x.CsessionId != pending_session.CsessionId).FirstOrDefault();
                    completed_ids = xtrasess.CardsInSession.Split(',').ToList();
                    askdict = xtrasess.AskLater == null ? new Dictionary<string, string>() : xtrasess.AskLater.Split(',').Select(x => x.Split(':'))
                        .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                        .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                    never_ids = askdict.Where(x => x.Value == "0").Select(y => y.Key).ToList();  //remove the "ask never cards"

                    previousCards = _repos.GetAllFlashCardList(cid, completed_ids.Except(never_ids).ToList());
                }
                previousCards = previousCards.Except(cardAll, new FlashCardEqualityComparer()).ToList();
                model.RefillFlashCards = previousCards.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(MIN_CARDS).ToList();

                model.FlshStatus = "1"; //0-new set, 1-incomplte continue, 2 - revising
                //sid = pending_session.CardRevisionList.Where(y=>y.Completed !=true).Select(xx => xx.RevisionId).SingleOrDefault();
                sid = pending_revisions.FirstOrDefault().RevisionId;
            }
            //old sessions exist check for revision history  and draw out revision cards when necesarry
            else if (user_session.Count() != 0 && pending_revisions.Count() == 0 && (pendr_session.Count() != 0 || sameday_pend_session.Count() != 0))
            {
                bool sameday_pend = false;
                Cardsession rev_session = null;
                if (pendr_session.Count() == 0 && sameday_pend_session.Count() != 0)
                {
                    //model.SameDayPending = true;   
                    pendr_session = sameday_pend_session;
                    sameday_pend = true;
                }
                rev_session = pendr_session.OrderByDescending(x => x.RevisedLevel).FirstOrDefault();
                List<string> pendingcard_ids = rev_session.CardsInSession.Split(',').ToList();
                string ask_later_ids = rev_session.AskLater;
                var askdict = ask_later_ids == null ? new Dictionary<string, string>() : ask_later_ids.Split(',').Select(x => x.Split(':'))
                    .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                    .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                List<string> never_ids = askdict.Where(x => x.Value == "0").Select(y => y.Key).ToList();  //remove the "ask never cards"
                //completed_ids.AddRange(never_ids);
                cardAll = _repos.GetAllFlashCardList(cid, pendingcard_ids.Except(never_ids).ToList());   //todo restrict to my own and approved cards

                previous_session = user_session.Where(x => x.Completed == true && x.CsessionId != rev_session.CsessionId).OrderByDescending(xx => xx.CompletedDate).FirstOrDefault();
                if (previous_session != null)
                {
                    //extract never ask cards out
                    askdict = previous_session.AskLater == null ? new Dictionary<string, string>() : previous_session.AskLater.Split(',').Select(x => x.Split(':'))
                       .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                       .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                    never_ids = askdict.Where(x => x.Value == "0").Select(y => y.Key).ToList();

                    previousCards = _repos.GetAllFlashCardList(cid, previous_session.CardsInSession.Split(',').ToList().Except(never_ids).ToList());
                }
                else
                {
                    previousCards.Clear();
                }


                model.catid = cid;
                model.MsessId = rev_session.CsessionId;
                model.CompletedCards = 0;
                model.PercentComplete = 0.0;
                model.finishedCards = rev_session.Finishedcount.HasValue ? rev_session.Finishedcount.Value : 0;
                model.RepeatCards = rev_session.RevisedLevel;
                model.FlashCards = cardAll.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,

                }).ToList();

                model.RefillFlashCards = previousCards.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(MIN_CARDS).ToList();

                XDocument XmlCardSessions = new XDocument();
                model.TimeIn = DateTime.Now;
                sid = Guid.NewGuid().ToString();

                XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", sid)));
                XElement FlashNode = new XElement("FlashCards");
                XmlCardSessions.Element("CardSessions").Add(FlashNode);


                CardRevision CardRev = new CardRevision()
                {
                    RevisionId = sid,
                    Cardsession = rev_session,
                    XmlCarddetails = XmlCardSessions.ToString(),
                    TimeIn = DateTime.Now,
                    Userid = User.Identity.Name,
                    Category = cid,
                    UpdateDate = DateTime.Now
                };
                //object[] obj = new object[] { _csession, CardRev };
                if (cardAll.Count() != 0)
                    _repos.Save(CardRev);

                if (sameday_pend)
                    model.FlshStatus = "3";  //flag to alert user;
                else
                    model.FlshStatus = "2"; //0-new set, 1-incomplte continue, 2 - revising 3-same day revise before time is up
                model.MsessId = rev_session.CsessionId;

            }

            else  //no pending session in this category.. 1. Revise or start new
            {

                //IList<FlashCardModel> _mycards = new List<FlashCardModel>();

                List<string> card_ids = new List<string>();// rev_session.CardsInSession.Split(',').ToList();

                XDocument XmlCardSessions = new XDocument();

                //cardAll = _repos.GetAllFlashCardList(cid);
                cardAll = _repos.GetFlashCardList(selcards);
                //IList<Flashcard> cards = _repos.GetFlashCardList(numcards, cid);


                XDocument xmlSession = new XDocument();
                XElement FlashNode = null;
                CardRevision CardRev = new CardRevision();
                //get all revisions per session
                foreach (var sess in user_session)
                {
                    //TODO
                    //used this commented code instead
                    //revised_cards.Add(sess.CardsInSession);
                    card_ids.AddRange(sess.CardsInSession.Split(',').ToList());
                }

                //Get cardsd from previous session to fill up as needed
                cardAll = (from card in cardAll
                           where !(card_ids.Contains(card.Identification))
                           select card).ToList();

                //cardAll = (from card in cardAll
                //          where !(_mycards.Select(x => x.CardId).Contains(card.Identification))
                //          select card).ToList();

                var orderedByIDList = from i in selcards
                                      join o in cardAll
                                      on i equals o.Identification
                                      select o;

                model.catid = cid;
                model.CompletedCards = card_ids.Count();
                model.PercentComplete = 0.0;
                model.finishedCards = 0;
                model.FlashCards = orderedByIDList.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(numcards).ToList();

                model.RefillFlashCards = previousCards.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(MIN_CARDS).ToList();

                if (sid == null)
                {
                    sid = Guid.NewGuid().ToString();
                    model.TimeIn = DateTime.Now;

                    XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", sid)));
                    FlashNode = new XElement("FlashCards");
                    XmlCardSessions.Element("CardSessions").Add(FlashNode);

                    //Create a sessionand save the session info  
                    Cardsession _csession = new Cardsession()
                    {
                        CsessionId = Guid.NewGuid().ToString(),
                        Userid = User.Identity.Name,
                        Cardscount = model.FlashCards.Count(),
                        CardsInSession = String.Join(",", model.FlashCards.Select(x => x.CardId)),
                        Finishedcount = 0,
                        Category = cid,
                        RevisedLevel = -10,
                        TimeIn = DateTime.Now
                    };
                    CardRev = new CardRevision()
                    {
                        RevisionId = sid,
                        Cardsession = _csession,
                        XmlCarddetails = XmlCardSessions.ToString(),
                        TimeIn = DateTime.Now,
                        Userid = User.Identity.Name,
                        Category = cid,
                        UpdateDate = DateTime.Now
                    };
                    //object[] obj = new object[] { _csession, CardRev };
                    if (cardAll.Count() != 0)
                        _repos.Save(new object[] { _csession, CardRev });

                    model.FlshStatus = "0"; //0-new set, 1-incomplte continue, 2 - revising
                    model.MsessId = _csession.CsessionId;

                }
            }


            model.SessionId = sid;
            model.FlashCards.Shuffle();
            model.RefillFlashCards.Shuffle();

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="sub"></param>
        /// <param name="sid"></param>
        /// <param name="rid"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ActionResult Quiz(string cid, string sub, string sid, string rid)
        {
            ViewData["cid"] = cid;
            ViewData["sub"] = sub;
            IRepository _repos = new Repository();
            IList<Cardsession> user_session = new List<Cardsession>();
            IList<Flashcard> cardAll = new List<Flashcard>();
            FlashCardSessionModel model = new FlashCardSessionModel();
            int numcards = int.MaxValue;

            List<string> revised_cards = new List<string>();

            IList<CardRevision> user_revisions = new List<CardRevision>();
            IList<CardRevision> pending_revisions = new List<CardRevision>();
            IList<LookupRevisetime> rTime = new List<LookupRevisetime>();

            List<string> card_ids = new List<string>();

            XDocument XmlCardSessions = new XDocument();

            cardAll = _repos.GetAllFlashCardList(cid);


            XDocument xmlSession = new XDocument();
            XElement FlashNode = null;
            CardRevision CardRev = new CardRevision();
            //get all revisions per session
            foreach (var sess in user_session)
            {
                ///TODO
                ///used this commented code instead
                ///revised_cards.Add(sess.CardsInSession);
                card_ids.AddRange(sess.CardsInSession.Split(',').ToList());
            }

            //Get cardsd from previous session to fill up as needed
            cardAll = (from card in cardAll
                       where !(card_ids.Contains(card.Identification))
                       select card).ToList();

            model.catid = cid;
            model.CompletedCards = card_ids.Count();
            model.PercentComplete = 0.0;
            model.finishedCards = 0;
            model.FlashCards = cardAll.Select(x => new FlashCardModel
            {
                CardId = x.Identification,
                Question = x.Question,
                QuestionAudio = x.QuestionAudio,
                QuestionImage = x.QuestionImage,
                Answer = x.Answer,
                AnswerAudio = x.AnswerAudio,
                AnswerImage = x.AnswerImage,
                SubjectArea = x.Category,
                FactSheet = x.Factsheet,
                FactAudio = x.FactAudio,
                FactImage = x.FactImage,
            }).Take(numcards).ToList();

            model.RefillFlashCards = new List<FlashCardModel>();

            if (sid == null)
            {
                sid = Guid.NewGuid().ToString();
                model.TimeIn = DateTime.Now;

                XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", sid)));
                FlashNode = new XElement("FlashCards");
                XmlCardSessions.Element("CardSessions").Add(FlashNode);

                //Create a sessionand save the session info  
                Cardsession _csession = new Cardsession()
                {
                    CsessionId = Guid.NewGuid().ToString(),
                    Userid = User.Identity.Name,
                    Cardscount = model.FlashCards.Count(),
                    CardsInSession = String.Join(",", model.FlashCards.Select(x => x.CardId)),
                    Finishedcount = 0,
                    Category = cid,
                    RevisedLevel = -10,
                    TimeIn = DateTime.Now
                };
                CardRev = new CardRevision()
                {
                    RevisionId = sid,
                    Cardsession = _csession,
                    XmlCarddetails = XmlCardSessions.ToString(),
                    TimeIn = DateTime.Now,
                    Userid = User.Identity.Name,
                    Category = cid,
                    UpdateDate = DateTime.Now
                };

                model.FlshStatus = "0"; //0-new set, 1-incomplte continue, 2 - revising
                model.MsessId = _csession.CsessionId;

            }


            model.SessionId = sid;
            model.FlashCards.Shuffle();
            model.RefillFlashCards.Shuffle();

            return View(model);
        }
        /// <summary>
        /// Revises the card.
        /// </summary>
        /// <param name="cid">The cad id.</param>
        /// <param name="sub">The subject.</param>
        /// <param name="sid">The session id.</param>
        /// <returns></returns>
        public ActionResult ReviseCard(string cid, string sub, string sid)
        {
            ViewData["cid"] = cid;
            ViewData["sub"] = sub;
            IRepository _repos = new Repository();
            Cardsession user_session = _repos.GetCardSession(sid);
            IList<Cardsession> other_user_session = _repos.GetUserSessionList(User.Identity.Name, cid).Where(x => x.CsessionId != sid).ToList();
            //IList<Cardsession> pending_rev = new List<Cardsession>();
            //Cardsession pending_session = new Cardsession();
            Cardsession previous_session = new Cardsession();
            IList<Flashcard> cardAll = new List<Flashcard>();
            IList<Flashcard> previousCards = new List<Flashcard>();
            FlashCardSessionModel model = new FlashCardSessionModel();
            Person pers = _repos.GetPerson(User.Identity.Name);
            int numcards = 8;
            if (pers != null && Convert.ToInt16(pers.UserPreferencesXml) != 0)
                numcards = Convert.ToInt16(pers.UserPreferencesXml);

            List<string> revised_cards = new List<string>();
            IList<CardRevision> pending_revisions = new List<CardRevision>();
            string rsid = null;
            if (user_session != null)
            {
                pending_revisions = user_session.CardRevisionList.Where(x => x.Completed != true).ToList();
                //previousCards = _repos.GetFlashCardList(previous_session.CardsInSession.Split(',')); //todo check for duplicates
            }

            if (user_session != null)
            {
                bool sameday_pend = false;

                List<string> pendingcard_ids = user_session.CardsInSession.Split(',').ToList();
                string ask_later_ids = user_session.AskLater;
                var askdict = ask_later_ids == null ? new Dictionary<string, string>() : ask_later_ids.Split(',').Select(x => x.Split(':'))
                    .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                    .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                List<string> never_ids = askdict.Where(x => x.Value == "0").Select(y => y.Key).ToList();  //remove the "ask never cards"
                //completed_ids.AddRange(never_ids);
                cardAll = _repos.GetAllFlashCardList(cid, pendingcard_ids.Except(never_ids).ToList());   //todo restrict to my own and approved cards

                previous_session = other_user_session.Where(x => x.Completed == true).OrderByDescending(xx => xx.CompletedDate).FirstOrDefault();
                if (previous_session != null)
                {
                    //extract never ask cards out
                    askdict = previous_session.AskLater == null ? new Dictionary<string, string>() : previous_session.AskLater.Split(',').Select(x => x.Split(':'))
                       .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                       .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                    never_ids = askdict.Where(x => x.Value == "0").Select(y => y.Key).ToList();

                    previousCards = _repos.GetAllFlashCardList(cid, previous_session.CardsInSession.Split(',').ToList().Except(never_ids).ToList());
                }
                else
                {
                    previousCards.Clear();
                }


                model.catid = cid;
                model.MsessId = user_session.CsessionId;
                model.CompletedCards = 0;
                model.PercentComplete = 0.0;
                model.finishedCards = user_session.Finishedcount.HasValue ? user_session.Finishedcount.Value : 0;
                model.RepeatCards = user_session.RevisedLevel;
                model.FlashCards = cardAll.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,

                }).ToList();

                model.RefillFlashCards = previousCards.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(MIN_CARDS).ToList();

                XDocument XmlCardSessions = new XDocument();
                model.TimeIn = DateTime.Now;
                rsid = Guid.NewGuid().ToString();

                XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", rsid)));
                XElement FlashNode = new XElement("FlashCards");
                XmlCardSessions.Element("CardSessions").Add(FlashNode);
                CardRevision CardRev = null;

                if (pending_revisions.Count() != 0)
                {
                    CardRev = _repos.GetRevision(pending_revisions.FirstOrDefault().RevisionId);
                    CardRev.CorrectCards = "";
                    rsid = CardRev.RevisionId;
                }
                else
                {
                    CardRev = new CardRevision()
                    {
                        RevisionId = rsid,
                        Cardsession = user_session,
                        XmlCarddetails = XmlCardSessions.ToString(),
                        TimeIn = DateTime.Now,
                        Userid = User.Identity.Name,
                        Category = cid,
                        UpdateDate = DateTime.Now,
                    };
                }
                //object[] obj = new object[] { _csession, CardRev };
                if (cardAll.Count() != 0)
                    _repos.SaveOrUpdate(CardRev);

                if (sameday_pend)
                    model.FlshStatus = "3";  //flag to alert user;
                else
                    model.FlshStatus = "2"; //0-new set, 1-incomplte continue, 2 - revising 3-same day revise before time is up
                model.MsessId = user_session.CsessionId;

            }

            model.SessionId = rsid;
            model.FlashCards.Shuffle();
            model.RefillFlashCards.Shuffle();
            TempData["cid"] = cid;
            TempData["sid"] = sid;
            TempData["sub"] = sub;

            return View(model);
        }
        //public ActionResult ReviseCard(string cid, string sub, string sid, string rp)
        //{
        //    ViewData["cid"] = cid;
        //    ViewData["sub"] = sub;


        //    IRepository _repos = new Repository();

        //    CardRevision CardRev = _repos.GetRevision(sid);
        //    Cardsession mysessions = _repos.GetCardSession(CardRev.Cardsession.CsessionId);
        //    //CardRevision CardRev = mysessions.CardRevisionList.Where(x => x.Completed != true).FirstOrDefault();
        //    IList<Cardsession> user_session = _repos.GetUserSessionList(User.Identity.Name, cid).Where(x=>x.CsessionId !=mysessions.CsessionId).ToList();

        //    IList<Flashcard> previousCards = new List<Flashcard>();
        //    IList<Flashcard> mycards = _repos.GetFlashCardList(mysessions.CardsInSession.Split(','));

        //    if (user_session.Count() != 0 )
        //    {
        //        foreach(var ses in user_session)
        //            previousCards.AddRange(_repos.GetFlashCardList(ses.CardsInSession.Split(',')));
        //    }

        //    //IList<Cardsession> user_session = _repos.GetUserSessionList(User.Identity.Name);
        //    IList<FlashCardRevisionModel> _mycards = new List<FlashCardRevisionModel>();
        //    IList<FlashCardRevisionModel> _rpcards = new List<FlashCardRevisionModel>();

        //    FlashCardSessionModel model = new FlashCardSessionModel();

        //     //XDocument xmlSession = new XDocument();
        //     XDocument XmlCardSessions = new XDocument();
        //    //get all revisions data from xml
        //     /*if(CardRev != null)
        //     {
        //         XmlCardSessions = XDocument.Parse(CardRev.XmlCarddetails);
        //         {
        //             var q = (from b in XmlCardSessions.Descendants("CardSessions").Descendants("FlashCards").Descendants("FlashCard")
        //                      select new FlashCardRevisionModel
        //                      {
        //                          CardId = b.Attribute("id").Value,
        //                          CorrectAnswer = Convert.ToBoolean(b.Attribute("correct_ans").Value),
        //                          SessionId = CardRev.Cardsession.CsessionId,
        //                          //ElapseTime =
        //                          //RevisionOrder= 
        //                      }).ToList();

        //             //_mycards.AddRange(q);  //will contain id of all cards i have revised..
        //         }
        //         _rpcards = _mycards.Where(x => x.CorrectAnswer == false).ToList();

        //         //if (rp == "1")
        //         //{
        //         //    cardAll = (from card in cardAll
        //         //               where (_mycards.Where(xx => xx.SessionId == sid).OrderBy(y => y.CorrectAnswer).Select(x => x.CardId).Contains(card.Identification))
        //         //               select card).ToList();
        //         //}
        //         //else
        //         //{
        //         //    cardAll = (from card in cardAll
        //         //               where !(_rpcards.Select(x => x.CardId).Contains(card.Identification))
        //         //               select card).ToList();
        //         //}

        //     }*/
        //     //else
        //     {
        //         XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", sid)));
        //         XElement FlashNode = null; FlashNode = new XElement("FlashCards");

        //         //XmlFlashCard = new XElement("FlashCard", new XAttribute("id", cid), new XAttribute("correct_ans", ans),
        //         //    new XAttribute("elapse_time", "0"), new XAttribute("revision_order", "yes/no"));
        //         //FlashNode.Add(XmlFlashCard);
        //         //XmlCardSessions.Element("CardSessions").Add(FlashNode);

        //         CardRev = new CardRevision()
        //         {
        //             RevisionId = Guid.NewGuid().ToString(),
        //             Cardsession = mysessions,
        //             XmlCarddetails = XmlCardSessions.ToString(),
        //             Completed = false,
        //             TimeIn = DateTime.Now,
        //             Userid = User.Identity.Name,
        //             Category = cid,
        //             UpdateDate = DateTime.Now
        //         };
        //         _repos.Save(CardRev);
        //     }

        //    //create a new revision is there is non pending, otherwise continue from old

        //    model.SessionId = CardRev.RevisionId;
        //    model.TimeIn = CardRev.TimeIn;
        //    model.catid = mysessions.Category;
        //    model.CompletedCards = _mycards.Count();
        //    model.PercentComplete = 0.0;
        //    model.finishedCards = 0;
        //    model.FlashCards = mycards.Select(x => new FlashCardModel
        //    {
        //        CardId = x.Identification,
        //        Question = x.Question,
        //        Answer = x.Answer,
        //        SubjectArea = x.Category,
        //        FactSheet = x.Factsheet,
        //        FactAudio = x.FactAudio,
        //        FactImage = x.FactImage,
        //    }).ToList();

        //    model.RefillFlashCards = previousCards.Select(x => new FlashCardModel
        //    {
        //        CardId = x.Identification,
        //        Question = x.Question,
        //        Answer = x.Answer,
        //        SubjectArea = x.Category,
        //        FactSheet = x.Factsheet,
        //        FactAudio = x.FactAudio,
        //        FactImage = x.FactImage,
        //    }).Take(MIN_CARDS).ToList();

        //    model.MsessId = mysessions.CsessionId;
        //    //model.SessionId = sid;
        //    model.FlashCards.Shuffle();
        //    model.RefillFlashCards.Shuffle();

        //    return View(model);
        //}

        /// <summary>
        /// Get Cards based on the specified card revision and session id.
        /// </summary>
        /// <param name="cid">The revision id.</param>
        /// <param name="sub">The sub.</param>
        /// <param name="sid">The session id.</param>
        /// <param name="rp">The rp.</param>
        /// <returns></returns>
        public ActionResult ReviseCard2(string cid, string sub, string sid, string rp)
        {
            ViewData["cid"] = cid;
            ViewData["sub"] = sub;
            IRepository _repos = new Repository();
            IList<Cardsession> user_session = _repos.GetUserSessionList(User.Identity.Name);
            IList<FlashCardRevisionModel> _mycards = new List<FlashCardRevisionModel>();
            IList<FlashCardRevisionModel> _rpcards = new List<FlashCardRevisionModel>();

            IList<Flashcard> cardAll = _repos.GetAllFlashCardList(cid);
            //IList<Flashcard> cards = _repos.GetFlashCardList(3, cid);
            FlashCardSessionModel model = new FlashCardSessionModel();

            XDocument xmlSession = new XDocument();
            //get all revisions per session
            foreach (var sess in user_session)
            {
                foreach (var revise in sess.CardRevisionList)
                {
                    xmlSession = XDocument.Parse(revise.XmlCarddetails);
                    {
                        var q = (from b in xmlSession.Descendants("CardSessions").Descendants("FlashCards").Descendants("FlashCard")
                                 select new FlashCardRevisionModel
                                 {
                                     CardId = b.Attribute("id").Value,
                                     CorrectAnswer = Convert.ToBoolean(b.Attribute("correct_ans").Value),
                                     SessionId = revise.Cardsession.CsessionId,
                                     //ElapseTime =
                                     //RevisionOrder= 
                                 }).ToList();

                        _mycards.AddRange(q);  //will contain id of all cards i have revised..
                    }
                }
            }
            _rpcards = _mycards.Where(x => x.CorrectAnswer == false).ToList();

            if (rp == "1")
            {
                cardAll = (from card in cardAll
                           where (_mycards.Where(xx => xx.SessionId == sid).OrderBy(y => y.CorrectAnswer).Select(x => x.CardId).Contains(card.Identification))
                           select card).ToList();
            }
            else
                cardAll = (from card in cardAll
                           where !(_rpcards.Select(x => x.CardId).Contains(card.Identification))
                           select card).ToList();


            if (sid == null)
            {
                model.SessionId = Guid.NewGuid().ToString();
                model.TimeIn = DateTime.Now;

            }
            model.catid = cid;
            model.CompletedCards = _mycards.Count();
            model.FlashCards = cardAll.Select(x => new FlashCardModel
            {
                CardId = x.Identification,
                Question = x.Question,
                Answer = x.Answer,
                SubjectArea = x.Category,
                FactSheet = x.Factsheet,
                FactAudio = x.FactAudio,
                FactImage = x.FactImage,
            }).Take(12).ToList();

            return View(model);
        }

        /// <summary>
        /// Get Cards based on the specified card revision and session id.
        /// </summary>
        /// <param name="rid">The revision id.</param>
        /// <param name="sid">The session id.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Card(string rid, string sid)
        {
            IRepository _repos = new Repository();
            Cardsession _csession = _repos.GetCardSession(rid);
            CardRevision _rev_session = _repos.GetRevision(sid);

            try
            {
                if (_csession.Completed != true)
                {
                    _csession.TimeOut = DateTime.Now;
                    _csession.Completed = true;
                    _csession.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_csession);

                    _rev_session.Completed = true;
                    _rev_session.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_rev_session);
                }
                else
                {
                    _rev_session.Completed = true;
                    _rev_session.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_rev_session);
                }
            }
            catch
            {
            }
            return JavaScript("window.top.location.href ='/App/Dashboard';");
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Quiz(string rid, string sid)
        {
            IRepository _repos = new Repository();
            Cardsession _csession = _repos.GetCardSession(rid);
            CardRevision _rev_session = _repos.GetRevision(sid);

            try
            {
                if (_csession.Completed != true)
                {

                }
                else
                {
                    _rev_session.Completed = true;
                    _rev_session.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_rev_session);
                    _repos.DeleteObject(_rev_session, false);
                    return JavaScript("window.top.location.href ='" + Url.Action("QuizTopics") + "';");

                }
            }
            catch
            {
            }

            return JavaScript("print ''a'';");
            //return RedirectToAction("Index");
        }
        //public ActionResult Topics()
        //{
        //    IRepository _repos = new Repository();
        //    IList<LookupCategory> catg = new List<LookupCategory>();
        //    CategoryListModel model = new CategoryListModel();

        //    catg = _repos.GetCategoryList();

        //    model.Categories = catg.Select(x => new CategoryModel
        //    {
        //        CategoryTitle = x.CatTitle,
        //        CatId = x.Catid

        //    }).ToList();

        //    return View(model);
        //}

        /// <summary>
        /// Get Topicse based on the specified category .
        /// </summary>
        /// <param name="cid">The category id.</param>
        /// <returns></returns>
        public async Task<ActionResult> Topics(string cid)
        {
            IRepository _repos = new Repository();
            IList<LookupSubcategory> catg = new List<LookupSubcategory>();
            CategoryListModel model = new CategoryListModel();
            IList<Cardsession> user_session = new List<Cardsession>();
            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name);
            IList<Flashcard> mycvards = _repos.GetMyFlashCards(User.Identity.Name);
            IList<Cardsession> pendr_session = new List<Cardsession>();

            if (Request.IsAjaxRequest())
            {
                if (cid == null)
                {
                    cid = "0";
                }                
                    catg = await Task.Run(() =>
                    _repos.GetSubCategoryList(cid));

                model.Categories = catg.Where(y => y.CatLevel == 3).Select(x => new CategoryModel
                {
                    CategoryTitle = x.CatTitle,
                    CatId = x.Subcatid,
                    ParentId = x.LookupCategory.Catid,
                    ParentCatTile = x.LookupCategory.CatTitle,
                    CategoryImage = x.CatImage,
                    CategoryTags = x.Tags,
                    CourseDuration = x.CourseLength,
                    NumOfLearners = x.LearnerCount
                }).OrderBy(n => n.ParentId).OrderBy(n => n.CategoryTitle).ToList(); 
                                                                                    
                return PartialView("_CoursesList", model);
            }

            user_session = _repos.GetUserSessionList(User.Identity.Name);

            //todo better way of dealing with this
            foreach (var rr in user_session.Where(x => x.Completed == true && x.RevisedLevel != 0))
            {
                //CardRevision revs = rr.CardRevisionList.Where(y => y.Completed == true).OrderByDescending(x => x.CompletedDate).FirstOrDefault();
                if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                    (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative
                {
                    pendr_session.Add(rr);
                }
            }
            //IList<Cardsession> pendr_session = new List<Cardsession>();
            model.RevisionCount = pendr_session.Count();
            model.PendingSessonCount = user_revisions.Where(x => x.Completed != true).Count();
            model.MyCardCount = mycvards.Count();

            string mcid = cid;
            if (cid == null)
            {
                //mcid = "1";
                catg = _repos.GetSubCategoryList("0");
            }
            else
            {
                catg = _repos.GetSubCategoryList(mcid);
            }


            model.Categories = catg.Where(y=>y.CatLevel==3).Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Subcatid,
                ParentId = x.LookupCategory.Catid,
                ParentCatTile = x.LookupCategory.CatTitle,
                CategoryImage = x.CatImage,
                CategoryTags = x.Tags,
                CourseDuration = x.CourseLength,
                NumOfLearners = x.LearnerCount

                // }).OrderBy(xx => xx.CategoryTitle).ToList();
            }).OrderBy(n=>n.ParentId).OrderBy(n => n.CategoryTitle).ToList(); //.Sort(xx=>xx.CategoryTitle).;
                                                       // return View(model);

            model.McatId = cid;
            return View(model);
        }

        /// <summary>
        /// Get _CoursesList based on the specified category .
        /// </summary>
        /// <param name="cid">The category id.</param>
        /// <param name="type">The type of study.</param>
        /// <returns></returns>
        public ActionResult _CoursesList(string cid,string type="Card")
        {
            IRepository _repos = new Repository();
            IList<LookupSubcategory> catg = new List<LookupSubcategory>();
            CategoryListModel model = new CategoryListModel();
            if (cid == null || cid == "")
            {
                //mcid = "1";
                catg = _repos.GetSubCategoryList("0");
            }
            else
            {
                catg = _repos.GetSubCategoryList(cid);
            }
            //if (type == null) type = "Flash";
            model.AppType = type;
            model.Categories = catg.Where(y => y.CatLevel == 3).Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Subcatid,
                ParentId = x.LookupCategory.Catid,
                ParentCatTile = x.LookupCategory.CatTitle,
                CategoryImage = x.CatImage,
                CategoryTags = x.Tags,
                CourseDuration = x.CourseLength,
                NumOfLearners = x.LearnerCount

                // }).OrderBy(xx => xx.CategoryTitle).ToList();
            }).OrderBy(n => n.ParentId).OrderBy(n => n.CategoryTitle).ToList(); //.Sort(xx=>xx.CategoryTitle).;
                                                                                // return View(model);

            model.McatId = cid;
            return PartialView(model);
        }

        /*Generic topic handler */
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<ActionResult> GetTopics(string cid,string type="Card")
        {
            IRepository _repos = new Repository();
            IList<LookupSubcategory> catg = new List<LookupSubcategory>();
            CategoryListModel model = new CategoryListModel();
            IList<Cardsession> user_session = new List<Cardsession>();
            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name);
            IList<Flashcard> mycvards = _repos.GetMyFlashCards(User.Identity.Name);
            IList<Cardsession> pendr_session = new List<Cardsession>();

            model.AppType = type;

            if (Request.IsAjaxRequest())
            {
                if (cid == null || cid == "")
                {
                    cid = "0";
                }
                catg = await Task.Run(() =>
                _repos.GetSubCategoryList(cid));

                model.Categories = catg.Where(y => y.CatLevel == 3).Select(x => new CategoryModel
                {
                    CategoryTitle = x.CatTitle,
                    CatId = x.Subcatid,
                    ParentId = x.LookupCategory.Catid,
                    ParentCatTile = x.LookupCategory.CatTitle,
                    CategoryImage = x.CatImage,
                    CategoryTags = x.Tags,
                    CourseDuration = x.CourseLength,
                    NumOfLearners = x.LearnerCount
                }).OrderBy(n => n.ParentId).OrderBy(n => n.CategoryTitle).ToList();

                model.McatId = cid;
                return PartialView("_CoursesList", model);
            }

            user_session = _repos.GetUserSessionList(User.Identity.Name);

            //todo better way of dealing with this
            foreach (var rr in user_session.Where(x => x.Completed == true && x.RevisedLevel != 0))
            {
                //CardRevision revs = rr.CardRevisionList.Where(y => y.Completed == true).OrderByDescending(x => x.CompletedDate).FirstOrDefault();
                if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                    (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative
                {
                    pendr_session.Add(rr);
                }
            }
            //IList<Cardsession> pendr_session = new List<Cardsession>();
            model.RevisionCount = pendr_session.Count();
            model.PendingSessonCount = user_revisions.Where(x => x.Completed != true).Count();
            model.MyCardCount = mycvards.Count();

            string mcid = cid;
            if (cid == null)
                mcid = "0";
            catg = _repos.GetSubCategoryList(mcid);

            model.Categories = catg.Where(y => y.CatLevel == 3).Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Subcatid,
                ParentId = x.LookupCategory.Catid,
                ParentCatTile = x.LookupCategory.CatTitle,
                CategoryImage = x.CatImage,
                CategoryTags = x.Tags,
                CourseDuration = x.CourseLength,
                NumOfLearners = x.LearnerCount
            }).OrderBy(n => n.ParentId).OrderBy(n => n.CategoryTitle).ToList();

            /*model.Categories = catg.Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Subcatid

                // }).OrderBy(xx => xx.CategoryTitle).ToList();
            }).OrderBy(n => n.CategoryTitle).ToList(); //.Sort(xx=>xx.CategoryTitle).;
            // return View(model);
            */
            model.McatId = cid;
            return View(model);
        }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <returns>IEnumerable of category</returns>
        public ActionResult QuizTopics(string cid, string sid)
        {
            IRepository _repos = new Repository();
            IList<LookupSubcategory> catg = new List<LookupSubcategory>();
            CategoryListModel model = new CategoryListModel();
            IList<Cardsession> user_session = new List<Cardsession>();
            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name);
            IList<Flashcard> mycvards = _repos.GetMyFlashCards(User.Identity.Name);
            IList<Cardsession> pendr_session = new List<Cardsession>();

            user_session = _repos.GetUserSessionList(User.Identity.Name);

            //todo better way of dealing with this
            foreach (var rr in user_session.Where(x => x.Completed == true && x.RevisedLevel != 0))
            {
                //CardRevision revs = rr.CardRevisionList.Where(y => y.Completed == true).OrderByDescending(x => x.CompletedDate).FirstOrDefault();
                if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                    (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative
                {
                    pendr_session.Add(rr);
                }
            }
            //IList<Cardsession> pendr_session = new List<Cardsession>();
            model.RevisionCount = pendr_session.Count();
            model.PendingSessonCount = user_revisions.Where(x => x.Completed != true).Count();
            model.MyCardCount = mycvards.Count();

            if (cid == null)
                cid = "1";
            catg = _repos.GetSubCategoryList(cid);

            model.Categories = catg.Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Subcatid

                // }).OrderBy(xx => xx.CategoryTitle).ToList();
            }).OrderBy(n => n.CategoryTitle).ToList(); //.Sort(xx=>xx.CategoryTitle).;
                                                       // return View(model);

            model.McatId = cid;
            return View(model);
        }
        public static IEnumerable<CategoryModel> GetCat()
        {
            IRepository _repos = new Repository();
            IList<LookupCategory> _catg = new List<LookupCategory>();
            CategoryListModel model = new CategoryListModel();

            _catg = _repos.GetCategoryList();

            //model.Categories = catg.Select(x => new CategoryModel
            //{
            //    CategoryTitle = x.CatTitle,
            //    CatId = x.Catid

            //}).ToList();

            return _catg.Select(x => new CategoryModel
            {
                CategoryTitle = x.CatTitle,
                CatId = x.Catid,
                CategoryImage = x.CatImg

            }).OrderBy(n => n.CategoryTitle).ToList();
        }

        /// <summary>
        /// Saves the card.
        /// </summary>
        /// <param name="cid">The card id.</param>
        /// <param name="sid">The session id.</param>
        /// <param name="ans">The answer</param>
        /// <param name="done">done?.</param>
        /// <param name="fin">The finished.</param>
        /// <returns></returns>
        public JsonResult SaveCard(string cid, string sid, string ans, string done, string fin)
        {

            IRepository _repos = new Repository();
            XDocument XmlCardSessions = new XDocument();
            XElement FlashNode = null, XmlFlashCard = null;
            //string _xmlCardDAta = null;

            CardRevision CardRev = _repos.GetRevision(sid);
            if (CardRev != null)
            {
                //get the xml entry and update
                XmlCardSessions = XDocument.Parse(CardRev.XmlCarddetails);
                XmlFlashCard = new XElement("FlashCard", new XAttribute("id", cid), new XAttribute("correct_ans", ans),
                    new XAttribute("elapse_time", "yes/no"), new XAttribute("revision_order", "yes/no"), new XAttribute("repeat_after", "xdays"));

                XmlCardSessions.Element("CardSessions").Element("FlashCards").Add(XmlFlashCard);

                CardRev.XmlCarddetails = XmlCardSessions.ToString();

                CardRev.CorrectCards = CardRev.CorrectCards != null ? string.Concat(CardRev.CorrectCards, "," + cid) : cid;
                //
                _repos.SaveOrUpdate(CardRev);
            }

            else
            {

                XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", sid)));
                FlashNode = new XElement("FlashCards");
                XmlFlashCard = new XElement("FlashCard", new XAttribute("id", cid), new XAttribute("correct_ans", ans),
                    new XAttribute("elapse_time", "yes/no"), new XAttribute("revision_order", "yes/no"));

                FlashNode.Add(XmlFlashCard);
                XmlCardSessions.Element("CardSessions").Add(FlashNode);

                //Create a sessionand save the session info  
                Cardsession _csession = new Cardsession()
                {
                    CsessionId = Guid.NewGuid().ToString(),
                    Userid = User.Identity.Name,
                    TimeIn = DateTime.Now
                };
                CardRev = new CardRevision()
                {
                    RevisionId = sid,
                    Cardsession = _csession,
                    XmlCarddetails = XmlCardSessions.ToString(),
                    Userid = User.Identity.Name,
                    Category = cid,
                    UpdateDate = DateTime.Now
                };
                //object[] obj = new object[] { _csession, CardRev };
                _repos.Save(new object[] { _csession, CardRev });


            }

            //_repos.SaveOrUpdate(CardRev);
            return Json(new { res = true }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Asks me later.
        /// </summary>
        /// <param name="SessionId">The session identifier.</param>
        /// <param name="cardid">The cardid.</param>
        /// <param name="askafter">The askafter- predefined length.</param>
        /// <returns></returns>
        public JsonResult AskMeLater(string SessionId, string cardid, string askafter)
        {
            try
            {
                IRepository _repos = new Repository();
                CardRevision cardrev = _repos.GetRevision(SessionId);
                Cardsession cardsess = _repos.GetCardSession(cardrev.Cardsession.CsessionId);
                //ASK LATER Saved in this format ... cardid1:Num_of_Days1,cardid2:Num_of_Days2,...

                string ask_later_ids = cardsess.AskLater;
                var askdict = ask_later_ids == null ? new Dictionary<string, string>() : ask_later_ids.Split(',').Select(x => x.Split(':'))
                    .Where(x => x.Length > 1 && !String.IsNullOrEmpty(x[0].Trim()) && !String.IsNullOrEmpty(x[1].Trim()))
                    .ToDictionary(x => x[0].Trim(), x => x[1].Trim());
                if (!((Dictionary<string, string>)askdict).ContainsKey(cardid))
                    cardsess.AskLater = cardsess.AskLater != null ? cardsess.AskLater + "," + cardid + ":" + askafter : cardid + ":" + askafter;

                _repos.SaveOrUpdate(cardsess);
                return Json(new { res = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { res = false }, JsonRequestBehavior.AllowGet);
            }
        }


        /*************** BEGIN FACTS To MATCH *********/

        /// <summary>
        /// Begins the session.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="sub"></param>
        /// <param name="sid"></param>
        /// <param name="cards"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public ActionResult Fact(string cid, string sub, string sid, string cards)
        {
            ViewData["cid"] = cid;
            ViewData["sub"] = sub;
            string[] selcards = cards.Split(',');
            IRepository _repos = new Repository();
            IList<Cardsession> user_session = _repos.GetUserSessionList(User.Identity.Name, cid);
            IList<Cardsession> pendr_session = new List<Cardsession>();
            IList<Cardsession> sameday_pend_session = new List<Cardsession>();
            IList<Cardsession> pending_rev = new List<Cardsession>();
            Cardsession pending_session = new Cardsession();
            Cardsession previous_session = new Cardsession();
            IList<Flashcard> cardAll = new List<Flashcard>();
            IList<Flashcard> previousCards = new List<Flashcard>();
            FlashCardSessionModel model = new FlashCardSessionModel();
            Person pers = _repos.GetPerson(User.Identity.Name);
            int numcards = 8;
            if (pers != null && Convert.ToInt16(pers.UserPreferencesXml) != 0)
                numcards = Convert.ToInt16(pers.UserPreferencesXml);

            List<string> revised_cards = new List<string>();

            //IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name, cid);
            IList<CardRevision> pending_revisions = new List<CardRevision>();
            IList<LookupRevisetime> rTime = new List<LookupRevisetime>();


                //IList<FlashCardModel> _mycards = new List<FlashCardModel>();

                List<string> card_ids = new List<string>();// rev_session.CardsInSession.Split(',').ToList();

                XDocument XmlCardSessions = new XDocument();

                //cardAll = _repos.GetAllFlashCardList(cid);
                cardAll = _repos.GetFlashCardList(selcards);
                //IList<Flashcard> cards = _repos.GetFlashCardList(numcards, cid);


                XDocument xmlSession = new XDocument();
                XElement FlashNode = null;
                CardRevision CardRev = new CardRevision();
                //get all revisions per session
                foreach (var sess in user_session)
                {
                    //TODO
                    //used this commented code instead
                    //revised_cards.Add(sess.CardsInSession);
                    card_ids.AddRange(sess.CardsInSession.Split(',').ToList());
                }

                //cardAll = (from card in cardAll
                //          where !(_mycards.Select(x => x.CardId).Contains(card.Identification))
                //          select card).ToList();

                var orderedByIDList = from i in selcards
                                      join o in cardAll
                                      on i equals o.Identification
                                      select o;

                model.catid = cid;
                model.CompletedCards = card_ids.Count();
                model.PercentComplete = 0.0;
                model.finishedCards = 0;
                model.FlashCards = orderedByIDList.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(numcards).ToList();

                model.RefillFlashCards = previousCards.Select(x => new FlashCardModel
                {
                    CardId = x.Identification,
                    Question = x.Question,
                    QuestionAudio = x.QuestionAudio,
                    QuestionImage = x.QuestionImage,
                    Answer = x.Answer,
                    AnswerAudio = x.AnswerAudio,
                    AnswerImage = x.AnswerImage,
                    SubjectArea = x.Category,
                    FactSheet = x.Factsheet,
                    FactAudio = x.FactAudio,
                    FactImage = x.FactImage,
                }).Take(MIN_CARDS).ToList();

                if (sid == null)
                {
                    sid = Guid.NewGuid().ToString();
                    model.TimeIn = DateTime.Now;

                    XmlCardSessions = new XDocument(new XElement("CardSessions", new XAttribute("SID", sid)));
                    FlashNode = new XElement("FlashCards");
                    XmlCardSessions.Element("CardSessions").Add(FlashNode);

                    //Create a sessionand save the session info  
                    Cardsession _csession = new Cardsession()
                    {
                        CsessionId = Guid.NewGuid().ToString(),
                        Userid = User.Identity.Name,
                        Cardscount = model.FlashCards.Count(),
                        CardsInSession = String.Join(",", model.FlashCards.Select(x => x.CardId)),
                        Finishedcount = 0,
                        Category = cid,
                        RevisedLevel = -10,
                        TimeIn = DateTime.Now
                    };
                    CardRev = new CardRevision()
                    {
                        RevisionId = sid,
                        Cardsession = _csession,
                        XmlCarddetails = XmlCardSessions.ToString(),
                        TimeIn = DateTime.Now,
                        Userid = User.Identity.Name,
                        Category = cid,
                        UpdateDate = DateTime.Now
                    };
                    //object[] obj = new object[] { _csession, CardRev };
                    //if (cardAll.Count() != 0)
                    //    _repos.Save(new object[] { _csession, CardRev });

                    model.FlshStatus = "0"; //0-new set, 1-incomplte continue, 2 - revising
                    model.MsessId = _csession.CsessionId;

                }
            
            model.SessionId = sid;
            //model.FlashCards.Shuffle();
            //model.RefillFlashCards.Shuffle();

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        /// <remarks></remarks>

        [HttpPost]
        public ActionResult Fact(string rid, string sid, List<String> idss)
        {
            IRepository _repos = new Repository();
            Cardsession _csession = _repos.GetCardSession(rid);
            CardRevision _rev_session = _repos.GetRevision(sid);

            try
            {
                if (_csession.Completed != true)
                {
                    _csession.TimeOut = DateTime.Now;
                    _csession.Completed = true;
                    _csession.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_csession);

                    _rev_session.Completed = true;
                    _rev_session.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_rev_session);
                }
                else
                {
                    _rev_session.Completed = true;
                    _rev_session.CompletedDate = DateTime.Now;
                    _repos.SaveOrUpdate(_rev_session);
                }
            }
            catch
            {
            }
            return JavaScript("window.top.location.href ='" + Url.Action("GetTopics",new { type="Fact"}) + "';");
            //return RedirectToAction("Index");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public JsonResult GetData()
        {
            // InputStream contains the JSON object you've sent
            String jsonString = new System.IO.StreamReader(this.Request.InputStream).ReadToEnd();

            // Deserialize it to a dictionary
            var dic =
              Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, dynamic>>(jsonString);

            string result = "";

            result += dic["ids"];

            // You can even cast your object to their original type because of 'dynamic' keyword
            ///result += ", Age: " + (int)dic["age"];

            ///if ((bool)dic["married"])
             ///   result += ", Married";

            result=result.Trim('}'); result=result.Trim('{');
            result = result.Replace(": true", "").Replace("\r\n","").Replace(" ","").Replace("\"", "");

            //return result;
            return Json(new { res = result }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cid"></param>
        /// <param name="sub"></param>
        /// <param name="mcat"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public ActionResult SelectCards(string cid, string sub, string mcat,string type="Card")
        {
            ViewData["cid"] = cid;
            ViewData["sub"] = sub;
            ViewData["mcat"] = mcat;
            ViewData["type"] = type;
            //TODO
            /*
             * Craete and asyn function to gether stats on login
             * 
             */
            IRepository _repos = new Repository();
            CategoryListModel model = new CategoryListModel();
            IList<Cardsession> user_session = new List<Cardsession>();
            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name);
            IList<Flashcard> mycvards = _repos.GetMyFlashCards(User.Identity.Name);
            IList<Cardsession> pendr_session = new List<Cardsession>();

            user_session = _repos.GetUserSessionList(User.Identity.Name);
            //todo better way of dealing with this
            foreach (var rr in user_session.Where(x => x.Completed == true && x.RevisedLevel != 0))
            {
                //CardRevision revs = rr.CardRevisionList.Where(y => y.Completed == true).OrderByDescending(x => x.CompletedDate).FirstOrDefault();
                if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                    (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative
                {
                    pendr_session.Add(rr);
                }
            }
            //IList<Cardsession> pendr_session = new List<Cardsession>();
            ViewBag.RevisionCount = pendr_session.Count();
            ViewBag.PendingSessonCount = user_revisions.Where(x => x.Completed != true).Count();
            ViewBag.MyCardCount = mycvards.Count();
            return View();
            //return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="sid"></param>
        /// <returns></returns>
        public JsonResult GetMergedAudio(string ids,string sid)
        {
            try
            {


                IRepository _repos = new Repository();
                IList<Flashcard> cardAll = new List<Flashcard>();
                string[] selcards = ids.Split(',');
                cardAll = _repos.GetFlashCardList(selcards);
                string outputmp3 = Server.MapPath("~/flashcardmedia/downloads/" + sid.Replace("-", "") + ".mp3");

                List<string> c_audios_l = cardAll.Select(m => m.FactAudio).ToList();
                for (int i = 0; i < c_audios_l.Count(); i++)
                {
                    if(i%2==1)
                    {
                        c_audios_l.Insert(i, "audios/silence.mp3");
                    }
                }
                string[] c_audios = c_audios_l.ToArray();
                c_audios = Array.ConvertAll(c_audios, x => (Server.MapPath("~/" + x)));
                Combine(c_audios, outputmp3);

                //return outputmp3;
                return Json(new { result = true, fid = sid.Replace("-", "") + ".mp3" }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { result = false, fid =""}, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mp3Files"></param>
        /// <param name="mp3OuputFile"></param>
        public static void Combine(string[] mp3Files, string mp3OuputFile)
        {
            using (var w = new System.IO.BinaryWriter(System.IO.File.Create(mp3OuputFile)))
            {
                new List<string>(mp3Files).ForEach(f => w.Write(System.IO.File.ReadAllBytes(f)));
            }
        }

        public float GetAudioSize()
        {
            //var audioFile = await mp3FilesFolder.GetFileAsync("sound.mp3");
            //MusicProperties properties = await audioFile.Properties.GetMusicPropertiesAsync();
            //TimeSpan myTrackDuration = properties.Duration;
            return 0 ;
        }

        /// <summary>
        /// Gets the audio file.
        /// </summary>
        /// <param name="fileLocation">The file location.</param>
        /// <returns></returns>
        [HttpGet]
        public FileResult GetAudioFile(string fid,string cat)
        {
            var bytes = new byte[0];
            string fileLocation = Server.MapPath("~/flashcardmedia/downloads/" + fid);

            using (var fs = new System.IO.FileStream(fileLocation, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                var br = new System.IO.BinaryReader(fs);
                long numBytes = new System.IO.FileInfo(fileLocation).Length;
                bytes = br.ReadBytes((int)numBytes);
            }

            return File(bytes, "audio/mpeg", cat+"_facts.mp3");

        }

        /*************** END FACTS To MATCH ***********/
        public bool BeginSession()
        {
            IRepository _repos = new Repository();

            bool result = false;
            return result;
        }

        //TODO async callbacks to increase perfomance...
        /// <summary>
        /// Delete a session
        /// </summary>
        /// <param name="sessid">The sessid.</param>
        public static void DeleteSession(string sessid)
        {
            IRepository _repos = new Repository();

            CardRevision cardrev = _repos.GetRevision(sessid);
            Cardsession cardsess = _repos.GetCardSession(cardrev.Cardsession.CsessionId);

            if (cardrev != null)
            {
                try
                {
                    if (cardsess.CardRevisionList.Count() <= 1)
                    {
                        _repos.DeleteObject(cardsess);
                    }
                    else if (cardsess.CardRevisionList.Count() > 1)
                    {
                        _repos.DeleteObject(cardrev);
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        /// <summary>
        /// Deletes the session.
        /// </summary>
        /// <param name="sessid">The sessid.</param>
        /// <param name="reslt">if set to <c>true</c> [result].</param>
        /// <returns></returns>
        public JsonResult DeleteSession(string sessid, bool reslt = true)
        {
            IRepository _repos = new Repository();
            CardRevision cardrev = _repos.GetRevision(sessid);
            Cardsession cardsess = _repos.GetCardSession(cardrev.Cardsession.CsessionId);
            bool res = false;
            if (cardrev != null)
            {
                try
                {
                    if (cardsess.CardRevisionList.Count() <= 1)
                    {
                        _repos.DeleteObject(cardsess);
                    }
                    else if (cardsess.CardRevisionList.Count() > 1)
                    {
                        _repos.DeleteObject(cardrev);
                    }
                    res = true;
                }
                catch (Exception)
                {
                    res = false;
                }
            }
            return Json(new { delans = res }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the revise times list.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetReviseTimesList()
        {
            IRepository _repos = new Repository();
            IList<LookupRevisetime> sch = new List<LookupRevisetime>();

            sch = _repos.GetRevisionTimeList();

            return Json(sch.Select(c => new { reviseid = c.RepeatAfter, rtitle = c.RptDescription }), JsonRequestBehavior.AllowGet);

        }

        /************************ functions *********/

        /// <summary>
        /// Validates the revision.
        /// </summary>
        /// <param name="csess">The card session.</param>
        /// <param name="_repos">The data repos.</param>
        /// <returns></returns>
        private bool ValidateRevision(Cardsession csess, IRepository _repos)
        {
            bool valideRevise = false;
            if (csess.RevisedLevel != 0)
            {
                if ((DateTime.Now.Date != csess.CompletedDate.Value.Date) &&
                    ((DateTime.Now - csess.Lastupdate.Value).Days >= _repos.GetRevisionTime(csess.RevisedLevel).RepeatAfter))
                {
                    valideRevise = true;
                }
                else if ((DateTime.Now.Date == csess.CompletedDate.Value.Date) && (csess.RevisedLevel < 0) &&
                          (DateTime.Now - csess.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(csess.RevisedLevel).RepeatAfter))  // same day revise levels re negative
                {
                    valideRevise = true;
                }
            }
            return valideRevise;
        }

        /// <summary>
        /// Gets the revisions.
        /// </summary>
        /// <param name="userid">The userid.</param>
        /// <returns></returns>
        public static IList<Cardsession> GetRevisions(string userid)
        {

            IRepository _repos = new Repository();
            IList<Cardsession> user_session = _repos.GetUserSessionList(userid).Where(x => x.Completed == true && x.RevisedLevel != 0).ToList();

            IList<Cardsession> sameday_pend_session = new List<Cardsession>();
            List<Cardsession> pendr_session = new List<Cardsession>();

            //Cardsession pending_session = new Cardsession();
            //Cardsession previous_session = new Cardsession(); 
            //IList<Cardsession> pending_rev = new List<Cardsession>();
            //IList<CardRevision> cardrev = new List<CardRevision>();
            /*
                IList<Flashcard> cardAll = new List<Flashcard>();
                IList<Flashcard> previousCards = new List<Flashcard>();
                FlashCardSessionModel model = new FlashCardSessionModel();
             */

            Person pers = _repos.GetPerson(userid);
            List<string> revised_cards = new List<string>();

            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(userid);
            IList<LookupRevisetime> rTime = new List<LookupRevisetime>();

            //pending_revisions = user_revisions.Where(x => x.Completed != true).ToList();  //actual pending revisions
            //pending_session = user_session.Where(x => x.Completed != true).SingleOrDefault();
            //previous_session = user_session.Where(x => x.Completed == true).OrderByDescending(xx => xx.CompletedDate).FirstOrDefault();
            //pending_rev = user_session.Where(x => x.Completed == true && x.RevisedLevel != 0).ToList();
            //rTime = _repos.GetRevisionTimeList();
            foreach (var rr in user_session)
            {
                //CardRevision revs = rr.CardRevisionList.Where(y => y.Completed == true).OrderByDescending(x => x.CompletedDate).FirstOrDefault();
                if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                    (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative (DateTime.Now - rr.Lastupdate.Value).Minutes >= 10)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && rr.RevisedLevel < 0)
                {
                    sameday_pend_session.Add(rr);
                }
            }

            return pendr_session;
        }

        /// <summary>
        /// Get recommnded courses based on previous categories
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public static IList<Cardsession> GetRecommndedCourses(string userid)
        {

            IRepository _repos = new Repository();
            IList<Cardsession> user_session = _repos.GetUserSessionList(userid).Where(x => x.Completed == true && x.RevisedLevel != 0).ToList();

            IList<Cardsession> sameday_pend_session = new List<Cardsession>();
            List<Cardsession> pendr_session = new List<Cardsession>();

            Person pers = _repos.GetPerson(userid);
            List<string> revised_cards = new List<string>();

            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(userid);
            IList<LookupRevisetime> rTime = new List<LookupRevisetime>();
            IList <LookupCategory> lkup = new List<LookupCategory>();

            revised_cards.AddRange(user_revisions.Select(m => m.Category).ToList());
            foreach(var cc in revised_cards)
            {
                lkup.Add((_repos.GetSubCategory(cc,true)).LookupCategory);
            }

            foreach (var rr in user_session)
            {
                
                if ((DateTime.Now.Date != rr.CompletedDate.Value.Date) && ((DateTime.Now - rr.Lastupdate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))
                //if ((DateTime.Now - rr.CompletedDate.Value).Days >= _repos.GetRevisionTime(rr.RevisedLevel.ToString()).RepeatAfter)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && (rr.RevisedLevel < 0) &&
                    (DateTime.Now - rr.Lastupdate.Value).Minutes >= Math.Abs(_repos.GetRevisionTime(rr.RevisedLevel).RepeatAfter))  // same day revise elevels re negative (DateTime.Now - rr.Lastupdate.Value).Minutes >= 10)
                {
                    pendr_session.Add(rr);
                }
                else if ((DateTime.Now.Date == rr.CompletedDate.Value.Date) && rr.RevisedLevel < 0)
                {
                    sameday_pend_session.Add(rr);
                }
            }

            return pendr_session;
        }
        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <returns></returns>
        public static string GetCategoryName(string catid)
        {
            string catname = "";
            IRepository _repos = new Repository();
            LookupSubcategory lkup = _repos.GetSubCategory(catid);
            if (lkup != null)
                catname = lkup.CatTitle;

            return catname;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        public static IList<string> GetCategoryNames(string catid)
        {
            IList<string> catname = new List<string>();
            IRepository _repos = new Repository();
            LookupSubcategory lkup = _repos.GetSubCategory(catid,true);
            if (lkup != null)
            {
                catname.Add(lkup.CatTitle);
                catname.Add(lkup.LookupCategory.CatTitle);
            }

            return catname;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="init">If set to <see langword="true" />, then ; otherwise, .</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string GetCategoryName(string catid, bool init)
        {
            string catname = "";
            IRepository _repos = new Repository();
            LookupSubcategory lkup = _repos.GetSubCategory(catid);
            if (lkup != null)
                catname = lkup.CatTitle;

            return catname;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static int GetReviseTime(int i)
        {
            IRepository _repos = new Repository();
            return _repos.GetRevisionTime(i).RepeatAfter;
        }

        /************************end functions ******/
    }
    //comparator class for Flasjcard objects...
    /// <summary>
    /// FlashCardEqualityCompare, IEqualityComparer
    /// </summary>
    class FlashCardEqualityComparer : IEqualityComparer<Flashcard>
    {
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <param name="x">The first object of type <paramref name="x" /> to compare.</param>
        /// <param name="y">The second object of type <paramref name="y" /> to compare.</param>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        public bool Equals(Flashcard x, Flashcard y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.Identification.Equals(y.Identification);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public int GetHashCode(Flashcard obj)
        {
            return obj.Identification.GetHashCode();
        }
    }
}
