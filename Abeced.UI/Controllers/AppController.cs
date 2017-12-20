using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Web.Mvc;
using System.Web.Security;
using Abeced.Data;
using Abeced.Data.Repository;
using Abeced.UI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.IO;
using System.Globalization;

namespace Abeced.UI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    public class AppController : Controller
    {
        // GET: Study
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Dashboard()
        {
            //TODO
            /*
             * Craete and asyn function to gether stats on login
             * 
             */ 
            IRepository _repos = new Repository();
            MyStatsModel model = new MyStatsModel();
            IList<Cardsession> user_session = new List<Cardsession>();
            IList<CardRevision> user_revisions = _repos.GetUserRevisionList(User.Identity.Name);
            IList<Flashcard> mycvards = _repos.GetMyFlashCards(User.Identity.Name);
            IList<Cardsession> pendr_session = new List<Cardsession>();

            if(Session["firstname"] ==null)
            {
                Person p = _repos.GetPerson(User.Identity.Name);
                Session["firstname"] = p.Firstname;
                Session["lastname"] = p.Lastname;
            }

            user_session = _repos.GetUserSessionList(User.Identity.Name);
            //Person p = _repos.GetPerson(User.Identity.Name);
            //ViewBag.Fname = p.Firstname;
            //ViewBag.Lname = p.Lastname;

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
            //IList<CardRevision> = user_session.Select(x => x.CardRevisionList.Where(y => y.Completed == true)).ToList();
            model.RevisionCount = pendr_session.Count();
            model.PendingSessonCount = user_revisions.Where(x => x.Completed != true).Count();
            model.MyCardCount = mycvards.Count();
            model.CardStats = user_session.OrderByDescending(m=>m.CompletedDate).Select(x => new CardStatsModel
            {
                 CategoryName = Abeced.UI.Controllers.FlashController.GetCategoryNames(x.Category)[1], CourseName = Abeced.UI.Controllers.FlashController.GetCategoryNames(x.Category)[0],
                  NumberOfCards=x.Cardscount.Value,  FinishTime = x.CompletedDate, CorrectCards = x.Cardscount.Value

            }).Take(3).ToList();
            //model.UserCardSession = user_session.OrderByDescending(x=>x.CompletedDate).Take(3).ToList();
            return View(model);

        }
    }
}