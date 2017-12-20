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
    /// Admin Controller
    /// Handles administrative task such user management, system maintenance etc
    /// </summary>
    [Authorize]
    
    public class AdminController : Controller
    {
        private static readonly string[] _validImageTypes = new string[] { "image/png", "image/jpg", "image/jpeg", "image/gif" };
        /*********Functions **********/

        //public IEnumerable<CategoryModel> GetAllTree()
        //{
        //    AbecedDataContext db = new AbecedDataContext(); 
        //    var query = from row in db.LookupSubcategory.ToList()
        //                select new CategoryModel

        //                {
        //                    CatId=row.Subcatid,
        //                    CategoryTitle = row.CatTitle,
        //                    ParentId = row.LookupCategory.Catid,

        //                    subCategories = (from cat in row.LookupSubcategoryList.ToList()

        //                                     select new CategoryModel
        //                                     {

        //                                     })

        //                };

        //}

        /***** ENd functions *********/

        public ActionResult TreeView()
        {
            return View();
        }

        public ActionResult TreeView2()
        {
            return View();
        }
        /// <summary>
        /// Indexes this instance. Admin home 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            IRepository _repos = new Repository();
            StatsModel model = new StatsModel();
            IList<Flashcard> allcards = _repos.GetFlashCardList();
            model.AllCards = allcards.Count();
            model.CardsApproved = allcards.Where(x => x.Approved == true).Count();
            model.CardsPendingApprove = allcards.Where(x => x.Approved != true).Count();
            //string msgg = HttpContext.Application["DailyMessageFile"].ToString();
            return View(model);
        }

        /// <summary>
        /// Manages the users.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult ManageUsers()
        {
            IRepository _repos = new Repository();
            IList<Flashcard> allcards = _repos.GetFlashCardList();
            ViewBag.AllCards = allcards.Count();
            ViewBag.CardsApproved = allcards.Where(x => x.Approved == true).Count();
            ViewBag.CardsPendingApprove = allcards.Where(x => x.Approved != true).Count();

            return View();
        }

        /// <summary>
        /// Messages of the day function.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult MessageOfDay()
        {
            return View();
        }

        /// <summary>
        /// Adds Messages of the day.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult AddMsgOfDay()
        {
            return PartialView();
        }

        /// <summary>
        /// Adds Messages of the day.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddMsgOfDay(MessageOfDayModel model)
        {
            try
            {
                IRepository _repos = new Repository();
                Messageofday mod = new Messageofday
                {
                    Identification= Guid.NewGuid().ToString(),
                    Entryby = User.Identity.Name,
                    Entrydate = DateTime.Now,
                    Msgdate = model.Day,
                    Msgtext = model.Message

                };

                _repos.SaveOrUpdate(mod);

                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
        
        /*
         * public ActionResult AddMsgOfDay(MessageOfDayModel model)
        {
            try
            {
                XDocument XmlMsg = new XDocument();

                //get the xmlfile
                using (var reader = new StreamReader(Server.MapPath("~/App_Data/dailymessage.xml")))
                {
                    XmlMsg = XDocument.Load(reader);
                }
                //string tempMylFile = Server.MapPath("~/App_Data/dailymessage.xml"); // Path.Combine(Path.GetDirectoryName(Assembly.GetAssembly(typeof(LDLL.License)).Location), "dailymessage.xml");                                  

                
                //XElement xmlDoc = XElement.Load(tempMylFile);

                //var q = (from b in xmlDoc.Elements("message")
                //         where b.Attribute("day").Value == DateTime.Now.ToShortDateString()
                //         select b).FirstOrDefault();

                XElement XMsg = new XElement("message", new XAttribute("day", model.Day.ToShortDateString()));
                XMsg.Value = model.Message;

                XmlMsg.Element("messages").Add(XMsg);
                using (var writer = new StreamWriter(Server.MapPath("~/App_Data/dailymessage.xml")))
                {
                    XmlMsg.Save(writer);
                }
                //XmlMsg.Save(Server.MapPath("~/App_Data/dailymessage.xml"));

                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception)
            {
                return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
        * 
        */
        /// <summary>
        /// Edits Messages  of the day.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMsgOfDay(string id)
        {
            
            try
            {
                IRepository repos = new Repository();
                Messageofday msgod = repos.GetMessageOfDay(id); 
                MessageOfDayModel model = new MessageOfDayModel();
                model.Day = msgod.Msgdate;
                model.Message = msgod.Msgtext;
                model.Id = msgod.Identification;
                                
                return PartialView(model);
            }
            catch (Exception)
            {
                return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
            }

            
        }

        /// <summary>
        /// Edits Messages of the  day.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditMsgOfDay(MessageOfDayModel model)
        {
            try
            {
                IRepository repos = new Repository();
                Messageofday msgod = repos.GetMessageOfDay(model.Id);
                msgod.Msgdate = model.Day;
                msgod.Msgtext =model.Message;
                repos.SaveOrUpdate(msgod);

                //string tempMylFile = Server.MapPath("~/App_Data/dailymessage.xml");

                //if (!System.IO.File.Exists(tempMylFile))
                //{
                //    return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
                //}
                //string sss = Convert.ToDateTime(model.Day).ToShortDateString();

                //XDocument document = XDocument.Load(tempMylFile);
                //document.Element("messages").Elements().Where(e => e.Attribute("day").Value.Equals(sss))
                //    .Select(e => e).Single().Value = model.Message;
                ////document.Element("message").Value = model.Message;
                //document.Save(Server.MapPath("~/App_Data/dailymessage.xml"));
                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Deletes Message of the day.
        /// </summary>
        /// <param name="day">The day.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public JsonResult DeleteMOD(string id)
        {
            try
            {
                IRepository repos = new Repository();
                Messageofday msgod = repos.GetMessageOfDay(id);
                repos.DeleteObject(msgod);

                //string tempMylFile = Server.MapPath("~/App_Data/dailymessage.xml");

                //if (!System.IO.File.Exists(tempMylFile))
                //{
                //    return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
                //}
                //string sss = Convert.ToDateTime(day).ToShortDateString();

                //XDocument document = XDocument.Load(tempMylFile);
                //document.Element("messages").Elements().Where(e => e.Attribute("day").Value.Equals(sss))
                //    .Select(e => e).Single().Remove();

                ////XElement xmlDoc = XElement.Load(tempMylFile);

                ////var q = ( from b in xmlDoc.Elements("message")
                ////         where b.Attribute("day").Value == DateTime.Now.ToShortDateString()
                ////         select b).FirstOrDefault();
                //document.Save(Server.MapPath("~/App_Data/dailymessage.xml"));
                return Json(new { delans = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// Manages the categories.
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageCategory()
        {
            IRepository _repos = new Repository();
            IList<Flashcard> allcards = _repos.GetFlashCardList();
            ViewBag.AllCards = allcards.Count();
            ViewBag.CardsApproved = allcards.Where(x => x.Approved == true).Count();
            ViewBag.CardsPendingApprove = allcards.Where(x => x.Approved != true).Count();

            return View();
        }

        /// <summary>
        /// Manages the cards.
        /// </summary>
        /// <returns></returns>
        public ActionResult ManageCards()
        {
            IRepository _repos = new Repository();
            IList<Flashcard> allcards = _repos.GetFlashCardList();
            ViewBag.AllCards = allcards.Count();
            ViewBag.CardsApproved = allcards.Where(x => x.Approved == true).Count();
            ViewBag.CardsPendingApprove = allcards.Where(x => x.Approved != true).Count();

            return View();
        }

        /// <summary>
        /// Pendings the cards list.
        /// </summary>
        /// <returns></returns>
        public ActionResult PendingCards()
        {
            IRepository _repos = new Repository();
            IList<Flashcard> allcards = _repos.GetFlashCardList();
            ViewBag.AllCards = allcards.Count();
            ViewBag.CardsApproved = allcards.Where(x => x.Approved == true).Count();
            ViewBag.CardsPendingApprove = allcards.Where(x => x.Approved != true).Count();

            return View();
        }

        /// <summary>
        /// Approves pending cards.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult ApproveCards()
        {
            return PartialView();
        }

        /// <summary>
        /// Approves pending cards.
        /// </summary>
        /// <param name="selectedIds">The selected ids.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult ApproveCards(string[] selectedIds)
        {
            string saveinfo = "";
            IRepository _repos = new Repository();
           // Supervison sup = new Supervison();
            try
            {
                foreach (var idx in selectedIds)
                {

                    Flashcard fls = _repos.GetFlashCard(idx);
                    fls.Approved = true;
                    fls.Approvedby = User.Identity.Name;
                    fls.ApprovedDate = DateTime.Now;
                    _repos.SaveOrUpdate(fls);
                    saveinfo = "success";
                }
            }
            catch (Exception)
            {
                saveinfo = "fail";
            }

            return Json(new { saveans = saveinfo }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Adds new category.
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult AddCategory()
        {
            return PartialView();
        }

        /// <summary>
        /// Adds new category.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult AddCategory(CategoryModel model)
        {
            IRepository _repos = new Repository();
            LookupCategory lkcat = new LookupCategory();
            LookupSubcategory sublkcat = new LookupSubcategory();

            try
            {
                if (model.CatType == 1)
                {
                    if (model.CatLevel == 0) //lvl 1
                    {
                        lkcat = _repos.GetCategory(model.ParentId);
                        sublkcat = new LookupSubcategory
                        {
                            Subcatid = Guid.NewGuid().ToString(),
                            CatTitle = model.CategoryTitle,
                            Lastupdate = DateTime.Now,
                            LookupCategory = lkcat,
                            CatLevel = 1,
                            CatImage = "Content/assets/course_bg2.jpg"
                        };
                        _repos.Save(sublkcat);

                    }
                    else if (model.CatLevel != 0) //lvl 2 or 3
                    {
                        sublkcat = _repos.GetSubCategory(model.ParentId);
                        LookupSubcategory scat = new LookupSubcategory
                        {
                            Subcatid = Guid.NewGuid().ToString(),
                            CatTitle = model.CategoryTitle,
                            Lastupdate = DateTime.Now,
                            LookupCategory = sublkcat.LookupCategory,
                            LookupSubcategoryMember = sublkcat,
                            CatLevel = 2,
                            CatImage = "Content/assets/course_bg2.jpg"
                        };
                        _repos.Save(scat);
                    }
                }
                else  //catType ==0 - Parent Cat
                {
                    lkcat = new LookupCategory();
                    lkcat.Catid = Guid.NewGuid().ToString();
                    lkcat.CatTitle = model.CategoryTitle;
                    lkcat.Lastupdate = DateTime.Now;
                    lkcat.CatImg = "Content/assets/abeced_sprite.png";
                    _repos.Save(lkcat);
                }

                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                //if (e.InnerException.Message.Contains("duplicate key value violates unique constraint"))
                //    return Json(new { rtnmsg = "pkerror" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Adds new course.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddCourse()
        {
            return PartialView();
        }

        /// <summary>
        /// Adds new course.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult AddCourse(CategoryModel model, IEnumerable<HttpPostedFileBase> Cfiles)
        {
            IRepository _repos = new Repository();
            LookupCategory lkcat = new LookupCategory();
            LookupSubcategory sublkcat = new LookupSubcategory();

            try
            {
               if (model.CatLevel != 0) //lvl 1 or 2
                    {
                        sublkcat = _repos.GetSubCategory(model.ParentId);
                    LookupSubcategory scat = new LookupSubcategory
                    {
                        Subcatid = Guid.NewGuid().ToString(),
                        CatTitle = model.CategoryTitle,
                        Lastupdate = DateTime.Now,
                        LookupCategory = sublkcat.LookupCategory,
                        LookupSubcategoryMember = sublkcat,
                        CatLevel = 3,
                        CourseLength = 0,
                        LearnerCount = 0,
                        Tags = model.CategoryTags,
                        CatImage = "Content/assets/course_bg2.jpg"
                    };

                    // The Name of the Upload component is "files"
                    if (Cfiles != null)
                    {
                        foreach (var file in Cfiles)
                        {
                            // Some browsers send file names with full path.
                            // We are only interested in the file name. 
                            //rename to cardid here
                            var fileName = Path.GetFileName(file.FileName);//msg.Identification.Replace("-","");
                            fileName = scat.Subcatid.Replace("-", "") + "." + fileName.Split('.')[1];
                            var physicalPath = "";
                            if (_validImageTypes.Contains(file.ContentType))
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/Content/assets"), fileName);
                                scat.CatImage = "Content/assets/" + fileName;
                                file.SaveAs(physicalPath);
                            }
                        }

                        //TempData["UploadedFiles"] = GetFileInfo(Quesfiles);
                    }
                    _repos.Save(scat);
                    }
                
                              
                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                //if (e.InnerException.Message.Contains("duplicate key value violates unique constraint"))
                //    return Json(new { rtnmsg = "pkerror" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Adds a new card.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult AddCard()
        {
            return PartialView();
        }

        /// <summary>
        /// Adds the card.
        /// </summary>
        /// <param name="model">The Card model.</param>
        /// <param name="Quesfiles">The question files.</param>
        /// <param name="Ansfiles">The answer files.</param>
        /// <param name="Factfiles">The fact sheet file.</param>
        /// <returns></returns>        
        [HttpPost]
        [Authorize]
        public ActionResult AddCard(FlashCardModel model, IEnumerable<HttpPostedFileBase> Quesfiles, 
            IEnumerable<HttpPostedFileBase> Ansfiles, IEnumerable<HttpPostedFileBase> Factfiles)
        {
            IRepository _repos = new Repository();
            try
            {
                    Flashcard msg = new Flashcard
                    {
                        Identification = Guid.NewGuid().ToString(),
                        Factsheet = model.FactSheet,
                        Answer = model.Answer,
                        Question = model.Question,
                        UploadedBy = User.Identity.Name,
                        Approved = false,
                        UploadDate = DateTime.Now,
                        Category = model.SubjectArea

                    };

                    // The Name of the Upload component is "files"
                    if (Quesfiles != null)
                    {
                        foreach (var file in Quesfiles)
                        {
                            // Some browsers send file names with full path.
                            // We are only interested in the file name. 
                            //rename to cardid here
                            var fileName = Path.GetFileName(file.FileName);//msg.Identification.Replace("-","");
                            fileName = "ques_" + msg.Identification.Replace("-", "") + "." + fileName.Split('.')[1];
                            var physicalPath = "";
                            if (_validImageTypes.Contains(file.ContentType))
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/image"), fileName);
                                msg.QuestionImage = "flashcardmedia/image/"+fileName;
                            }
                            else  //we know is mp3 from client validation restriction
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/audio"), fileName);
                                msg.QuestionAudio = "flashcardmedia/audio/" + fileName ;
                            }
                            
                            file.SaveAs(physicalPath);
                        }

                        //TempData["UploadedFiles"] = GetFileInfo(Quesfiles);
                    }

                    if (Ansfiles != null)
                    {
                        foreach (var file in Ansfiles)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            fileName = "ans_" + msg.Identification.Replace("-", "") + "." + fileName.Split('.')[1];
                            var physicalPath = "";
                            if (_validImageTypes.Contains(file.ContentType))
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/image"), fileName);
                                msg.AnswerImage = "flashcardmedia/image/" + fileName;
                            }
                            else  //we know is mp3 from client validation restriction
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/audio"), fileName);
                                msg.AnswerAudio = "flashcardmedia/audio/" + fileName ;
                            }

                            file.SaveAs(physicalPath);
                        }

                    }

                    if (Factfiles != null)
                    {
                        foreach (var file in Factfiles)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            fileName = "fact_" + msg.Identification.Replace("-", "") + "." + fileName.Split('.')[1];
                            var physicalPath = "";
                            if (_validImageTypes.Contains(file.ContentType))
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/image"), fileName);
                                msg.FactImage = "flashcardmedia/image/" + fileName;
                            }
                            else  //we know is mp3 from client validation restriction
                            {
                                physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/audio"), fileName);
                                msg.FactAudio = "flashcardmedia/audio/" + fileName ;
                            }

                            file.SaveAs(physicalPath);
                        }

                    }


                    _repos.Save(msg);
                    return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);
               
            }
            catch (Exception)
            {
                //if (e.InnerException.Message.Contains("duplicate key value violates unique constraint"))
                //    return Json(new { rtnmsg = "pkerror" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the file information.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns></returns>
        private IEnumerable<string> GetFileInfo(IEnumerable<HttpPostedFileBase> files)
        {
            return
                from a in files
                where a != null
                select string.Format("{0} ({1} bytes)", Path.GetFileName(a.FileName), a.ContentLength);
        }

        /// <summary>
        /// Edits the card.
        /// </summary>
        /// <param name="cardid">The cardid.</param>
        /// <returns></returns>
        public ActionResult EditCard(string cardid)
        {
            IRepository _repos = new Repository();
            Flashcard fls = _repos.GetFlashCard(cardid);

            FlashCardModel model = new FlashCardModel
            {
                CardId = fls.Identification,
                Question = fls.Question,
                Answer = fls.Answer,
                AnswerAudio = fls.AnswerAudio,
                AnswerImage = fls.AnswerImage,
                QuestionAudio = fls.QuestionAudio,
                QuestionImage = fls.QuestionImage,
                FactAudio = fls.FactAudio,
                FactImage = fls.FactImage,
                FactSheet = fls.Factsheet,
                SubjectArea = fls.Category,
                UploadedBy = fls.UploadedBy
            };
            ViewData["pcat"] = _repos.GetParentCategory(model.SubjectArea);
            return PartialView(model);
        }

        /// <summary>
        /// Edits the card.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="Quesfiles">The quesfiles.</param>
        /// <param name="Ansfiles">The ansfiles.</param>
        /// <param name="Factfiles">The factfiles.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCard(FlashCardModel model, IEnumerable<HttpPostedFileBase> Quesfiles,
            IEnumerable<HttpPostedFileBase> Ansfiles, IEnumerable<HttpPostedFileBase> Factfiles)
        {
            IRepository _repos = new Repository();
            try
            {
                Flashcard msg = _repos.GetFlashCard(model.CardId);
                msg.Question = model.Question;
                msg.Answer = model.Answer;
                msg.Factsheet = model.FactSheet;
                msg.Category = model.SubjectArea;
                msg.UploadDate = DateTime.Now;
                //TODO add image and audio
                // The Name of the Upload component is "files"
                if (Quesfiles != null)
                {
                    foreach (var file in Quesfiles)
                    {
                        // Some browsers send file names with full path.
                        // We are only interested in the file name. 
                        //rename to cardid here
                        var fileName = Path.GetFileName(file.FileName);//msg.Identification.Replace("-","");
                        fileName = "ques_" + msg.Identification.Replace("-", "") + "." + fileName.Split('.')[1];
                        var physicalPath = "";
                        if (_validImageTypes.Contains(file.ContentType))
                        {
                            physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/image"), fileName);
                            msg.QuestionImage = "flashcardmedia/image/" + fileName;
                        }
                        else  //we know is mp3 from client validation restriction
                        {
                            physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/audio"), fileName);
                            msg.QuestionAudio = "flashcardmedia/audio/" + fileName;
                        }

                        file.SaveAs(physicalPath);
                    }

                    //TempData["UploadedFiles"] = GetFileInfo(Quesfiles);
                }

                if (Ansfiles != null)
                {
                    foreach (var file in Ansfiles)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        fileName = "ans_" + msg.Identification.Replace("-", "") + "." + fileName.Split('.')[1];
                        var physicalPath = "";
                        if (_validImageTypes.Contains(file.ContentType))
                        {
                            physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/image"), fileName);
                            msg.AnswerImage = "flashcardmedia/image/" + fileName;
                        }
                        else  //we know is mp3 from client validation restriction
                        {
                            physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/audio"), fileName);
                            msg.AnswerAudio = "flashcardmedia/audio/" + fileName;
                        }

                        file.SaveAs(physicalPath);
                    }

                }

                if (Factfiles != null)
                {
                    foreach (var file in Factfiles)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        fileName = "fact_" + msg.Identification.Replace("-", "") + "." + fileName.Split('.')[1];
                        var physicalPath = "";
                        if (_validImageTypes.Contains(file.ContentType))
                        {
                            physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/image"), fileName);
                            msg.FactImage = "flashcardmedia/image/" + fileName;
                        }
                        else  //we know is mp3 from client validation restriction
                        {
                            physicalPath = Path.Combine(Server.MapPath("~/flashcardmedia/audio"), fileName);
                            msg.FactAudio = "flashcardmedia/audio/" + fileName;
                        }

                        file.SaveAs(physicalPath);
                    }

                }


                _repos.SaveOrUpdate(msg);
                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Edits the category.
        /// </summary>
        /// <param name="catid">The catid.</param>
        /// <param name="s">The s.</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        public ActionResult EditCategory( string catid, string s)
        {
            
            IRepository _repos = new Repository();
            LookupCategory cat = new LookupCategory();

            LookupSubcategory sub = new LookupSubcategory();
            CategoryModel model = null;

            if (s == "1")
            {
                sub = _repos.GetSubCategory(catid);
                if (sub != null)
                {
                    cat = _repos.GetCategory(sub.LookupCategory.Catid);
                    model = new CategoryModel
                    {
                        CategoryTitle = sub != null ? sub.CatTitle : "",
                        CatId =  sub.Subcatid ,
                        SubCatId = sub.Subcatid ,
                        SubCategoryTitle = sub.CatTitle ,
                        CatLevel = sub.CatLevel.GetValueOrDefault(),
                        ParentId = sub.LookupSubcategoryMember != null ? sub.LookupSubcategoryMember.Subcatid : "",
                        CatType = 1
                    };
                }
            }
            else
            {
                cat = _repos.GetCategory(catid);
                model = new CategoryModel
                {
                    CategoryTitle = cat != null ? cat.CatTitle : "",
                    CatId = cat != null ? cat.Catid : "",
                    SubCatId = cat != null ? cat.Catid : "",
                    SubCategoryTitle = cat != null ? cat.CatTitle: "" ,
                    CatLevel = 0,
                    ParentId = "",
                    CatType = 0
                };
            }
            

            return PartialView(model);
        }

        /// <summary>
        /// Edits the category.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public ActionResult EditCategory(CategoryModel model)
        {
            IRepository _repos = new Repository();
            LookupCategory lkcat = new LookupCategory();
            LookupSubcategory sublkcat = new LookupSubcategory();

            try
            {
                if (model.CatType == 1)
                {
                    if (model.CatLevel == 0) //lvl 1
                    {
                        lkcat = _repos.GetCategory(model.ParentId);
                        sublkcat = new LookupSubcategory
                        {
                            Subcatid = Guid.NewGuid().ToString(),
                            CatTitle = model.CategoryTitle,
                            Lastupdate = DateTime.Now,
                            LookupCategory = lkcat,
                            CatLevel = 1,
                            CatImage = "Content/assets/course_bg2.jpg"
                        };
                        _repos.SaveOrUpdate(sublkcat);

                    }
                    else if (model.CatLevel != 0) //lvl 2 or 3
                    {
                        sublkcat = _repos.GetSubCategory(model.ParentId);
                        LookupSubcategory scat = new LookupSubcategory
                        {
                            Subcatid = Guid.NewGuid().ToString(),
                            CatTitle = model.CategoryTitle,
                            Lastupdate = DateTime.Now,
                            LookupCategory = sublkcat.LookupCategory,
                            LookupSubcategoryMember = sublkcat,
                            CatLevel = 2,
                            CatImage = "Content/assets/course_bg2.jpg"
                        };
                        _repos.SaveOrUpdate(scat);
                    }
                }
                else  //catType ==0 - Parent Cat
                {
                    lkcat = new LookupCategory();
                    lkcat.Catid = Guid.NewGuid().ToString();
                    lkcat.CatTitle = model.CategoryTitle;
                    lkcat.Lastupdate = DateTime.Now;
                    lkcat.CatImg = "Content/assets/abeced_sprite.png";
                    _repos.SaveOrUpdate(lkcat);
                }

                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                //if (e.InnerException.Message.Contains("duplicate key value violates unique constraint"))
                //    return Json(new { rtnmsg = "pkerror" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
        }




        /********************* Begin Flash Card Functions *************/

        /// <summary>
        /// Gets the category listing.
        /// </summary>
        /// <returns></returns>
        
        public JsonResult GetCategoryList()
        {
            IRepository _repos = new Repository();
            IList<LookupCategory> sch = new List<LookupCategory>();

            sch = _repos.GetCategoryList();

            return Json(sch.Select(c => new { catid = c.Catid, ctitle = c.CatTitle }), JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Gets the category listing.
        /// </summary>
        /// <returns></returns>

        public JsonResult GetCategoryListH()
        {
            IRepository _repos = new Repository();
            IList<LookupCategory> sch = new List<LookupCategory>();
            List<Abeced.Data.LookupCategory> catmm = _repos.GetCategoryList().OrderBy(m => m.CatTitle).ToList();

            // Project the results to avoid JSON serialization errors
            var result = catmm.Select(cat => new
            {
                Id = cat.Catid,
                Name = cat.CatTitle,
                CatLevel = 0,
                HasChildren = cat.LookupSubcategoryList.Where(m => m.LookupCategory == cat && m.CatLevel == 1).Any(),
                Children = cat.LookupSubcategoryList.Where(m => m.LookupCategory == cat && m.CatLevel == 1).Select(sc => new
                {
                    Id = sc.Subcatid,
                    Name = sc.CatTitle,
                    CatLevel = 1,
                    HasChildren = sc.LookupSubcategoryList.Where(m => m.LookupSubcategoryMember == sc && m.CatLevel == 2).Any(),
                    Children = sc.LookupSubcategoryList.Where(m => m.LookupSubcategoryMember == sc && m.CatLevel == 2).Select(sc2 => new
                    {
                        Id = sc2.Subcatid,
                        Name = sc2.CatTitle,
                        CatLevel = 2,
                        HasChildren = false
                    })
                })
            }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);

            //sch = _repos.GetCategoryList();

            //return Json(sch.Select(c => new { catid = c.Catid, ctitle = c.CatTitle }), JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Gets the subject list.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <returns></returns>
        
        public JsonResult GetSubjectList(string catid)
        {
            IRepository _repos = new Repository();
            IList<LookupSubcategory> sch = new List<LookupSubcategory>();

            sch = _repos.GetSubCategoryList(catid);

            return Json(sch.Select(c => new { scatid = c.Subcatid, sctitle = c.CatTitle }), JsonRequestBehavior.AllowGet);

        }

        /// <summary>
        /// Gets the card list.
        /// </summary>
        /// <returns>json object containing subject lis</returns>
        
        private static IEnumerable<FlashCardModel> GetCardList()
        {
            IRepository repos = new Repository();
            IList<Flashcard> _sc = repos.GetFlashCardList();

            return _sc.Select(fc => new FlashCardModel
            {
                CardId = fc.Identification,
                Question = fc.Question,
                Answer = fc.Answer,
                FactSheet = fc.Factsheet,
                QuestionAudio = fc.QuestionAudio,
                AnswerAudio = fc.AnswerAudio,
                FactAudio = fc.FactAudio,
                SubjectArea = fc.Category,
                Approved = fc.Approved.HasValue?fc.Approved.Value:false
            });
        }

        private static IEnumerable<FlashCardModel> GetCardList(string cid)
        {
            IRepository repos = new Repository();
            IList<Flashcard> _sc = repos.GetFlashCardList(0,cid);

            return _sc.Select(fc => new FlashCardModel
            {
                CardId = fc.Identification,
                Question = fc.Question,
                Answer = fc.Answer,
                FactSheet = fc.Factsheet,
                QuestionAudio = fc.QuestionAudio,
                AnswerAudio = fc.AnswerAudio,
                FactAudio = fc.FactAudio,
                SubjectArea = fc.Category,
                Approved = fc.Approved.HasValue ? fc.Approved.Value : false
            });
        }

        /// <summary>
        /// Gets the pending card list.
        /// </summary>
        /// <returns>list of pending cards</returns>
        
        private static IEnumerable<FlashCardModel> GetPCardList()
        {
            IRepository repos = new Repository();
            IList<Flashcard> _sc = repos.GetPendingFlashCardList();

            return _sc.Select(fc => new FlashCardModel
            {
                CardId = fc.Identification,
                Question = fc.Question,
                Answer = fc.Answer,
                FactSheet = fc.Factsheet,
                SubjectArea = fc.Category,
                UploadedBy = fc.UploadedBy,
                Approved = fc.Approved.HasValue ? fc.Approved.Value : false
            });
        }

        /// <summary>
        /// Gets the card list_ read.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>json object of cards</returns>
        [Authorize]
        public ActionResult GetCardList_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetCardList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCardListFilter_Read([DataSourceRequest] DataSourceRequest request,string id)
        {

            return Json(GetCardList(id).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the pending card list_ read.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        
        public ActionResult GetPCardList_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetPCardList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the card.
        /// </summary>
        /// <param name="CardId">The card identifier.</param>
        /// <returns></returns>
        public JsonResult DeleteCard(string CardId)
        {
            IRepository _repos = new Repository();
            Flashcard fls = new Flashcard();

            fls = _repos.GetFlashCard(CardId);

            if (fls != null)
            {
                try
                {
                    _repos.DeleteObject(fls);
                    return Json(new { delans = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                }

            }
            return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the category.
        /// </summary>
        /// <param name="CatId">The category identifier.</param>
        /// <returns></returns>
        public JsonResult DeleteCategory(string CatId)
        {
            IRepository _repos = new Repository();
            LookupCategory fls = new LookupCategory();

            fls = _repos.GetCategory(CatId);

            if (fls != null)
            {
                try
                {
                    _repos.DeleteObject(fls);
                    return Json(new { delans = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                }

            }
            return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the sub category.
        /// </summary>
        /// <param name="CatId">The category identifier.</param>
        /// <returns></returns>
        public JsonResult DeleteSubCategory(string CatId)
        {
            IRepository _repos = new Repository();
            LookupSubcategory fls = new LookupSubcategory();

            fls = _repos.GetSubCategory(CatId);

            if (fls != null)
            {
                try
                {
                    IList<Flashcard> fcards = _repos.GetAllFlashCardList(CatId);
                    if (fcards.Count != 0)
                    {
                        _repos.DeleteCards(CatId);
                        _repos.DeleteObject(fls);
                    }
                    else
                    {
                        _repos.DeleteObject(fls);
                    }
                    return Json(new { delans = true }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {

                }

            }
            return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Deletes the audio of the specified card.
        /// </summary>
        /// <param name="CardId">The card identifier.</param>
        /// <param name="audiofile">The audiofile.</param>
        /// <returns></returns>
        public JsonResult DeleteCardAudio(string CardId, string audiofile)
        {
            IRepository _repos = new Repository();
            Flashcard fls = new Flashcard();
            var physicalPath = Path.Combine(Server.MapPath("~/"), audiofile);

            try
            {
                fls = _repos.GetFlashCard(CardId);
                if (audiofile.Contains("ques"))
                {
                    fls.QuestionAudio = null;
                }
                else if (audiofile.Contains("ans"))
                {
                    fls.AnswerAudio = null;
                }
                else if (audiofile.Contains("fact"))
                {
                    fls.FactAudio = null;
                }
                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }
                _repos.SaveOrUpdate(fls);
                return Json(new { delans = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Deletes the image of the specified card.
        /// </summary>
        /// <param name="CardId">The card identifier.</param>
        /// <param name="imagefile">The imagefile.</param>
        /// <returns></returns>
        public JsonResult DeleteCardImage(string CardId, string imagefile)
        {
            IRepository _repos = new Repository();
            Flashcard fls = new Flashcard();
            var physicalPath = Path.Combine(Server.MapPath("~/"), imagefile);

            try
            {
                fls = _repos.GetFlashCard(CardId);
                if (imagefile.Contains("ques"))
                {
                    fls.QuestionImage = null;
                }
                else if (imagefile.Contains("ans"))
                {
                    fls.AnswerImage = null;
                }
                else if (imagefile.Contains("fact"))
                {
                    fls.FactImage = null;
                }
                if (System.IO.File.Exists(physicalPath))
                {
                    System.IO.File.Delete(physicalPath);
                }
                _repos.SaveOrUpdate(fls);
                return Json(new { delans = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { delans = false }, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// Gets all category.
        /// </summary>
        /// <returns>Json list </returns>
        [Authorize]
        public JsonResult GetAllCategory(string id)
        {
            IRepository _repos = new Repository();
            IList<LookupSubcategory> catg = new List<LookupSubcategory>();

            if (id == null)
            {
                catg = _repos.GetSubCategoryList(false);
            }
            else
            {
                catg = _repos.GetSubCategoryList(false).Where(m=>m.LookupCategory.Catid==id).ToList();
            }

            return Json(catg.Select(c => new { catid = c.Subcatid, catname=c.CatTitle }), JsonRequestBehavior.AllowGet);

        }



        /// <summary>
        /// Cats the index.
        /// </summary>
        /// <param name="cid">The category id.</param>
        /// <returns></returns>
        public JsonResult CatIndex(string cid)
        {
            IRepository _repos = new Repository();
            IList<LookupCategory> catg = new List<LookupCategory>();
            catg = _repos.GetCategoryList();
            var catgory = from e in catg
                            //where (cid.HasValue ? e.Catid.Equals(cid) : e.Catid == null)
                            select new
                            {
                                cid = e.Catid,
                                catname = e.CatTitle,
                                hasChildren = e.LookupSubcategoryList.Any()
                            };

            return Json(catgory, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the category list.
        /// </summary>
        /// <returns>IEnumerable list</returns>
        private static IEnumerable<CategoryModel> GetCatgList()
        {
            IRepository repos = new Repository();
            IList<LookupCategory> _sc = repos.GetCategoryList();

            return _sc.Select(fc => new CategoryModel
            {
                CatId = fc.Catid,
                CategoryTitle = fc.CatTitle,
                
            });
        }

        /// <summary>
        /// Gets the category list - data source for control.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ActionResult GetCatgList_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetCatgList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the sub category list.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <returns></returns>
        private static IEnumerable<CategoryModel> GetSubCatList(string catid)
        {
            IRepository repos = new Repository();
            IList<LookupSubcategory> _sc = repos.GetSubCategoryList(catid);
            
            return _sc.Select(fc => new CategoryModel
            {
                SubCatId = fc.Subcatid,
                CatId = fc.Subcatid,
                CategoryTitle = fc.CatTitle,
                SubCategoryTitle = fc.CatTitle,
                NumOfCards = repos.GetFlashCardCount(fc.Subcatid)

            });
        }

        /// <summary>
        /// Gets the sub category list -data source for control.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ActionResult GetSubCatList_Read(string catid, [DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetSubCatList(catid).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Gets the MSG list.
        /// </summary>
        /// <returns></returns>
        private static IEnumerable<MessageOfDayModel> GetMsgList()
        {
            IRepository repos = new Repository();
            IList<Messageofday> _sc = repos.MessageOfDayList();

            return _sc.Select(fc => new MessageOfDayModel
            {
                Day = fc.Msgdate.Date, Message = fc.Msgtext, Id = fc.Identification

            });
        }

        /// <summary>
        /// Gets the MSG of day list_ read.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ActionResult GetMsgOfDayList_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetMsgList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Gets the parent category.
        /// </summary>
        /// <param name="catid">The category id.</param>
        /// <returns></returns>
        private string GetParentCat(string catid)
        {
            string pcat = null;
            IRepository _repo = new Repository();
            pcat = _repo.GetParentCategory(catid,true).Catid;

            return pcat;
        }

        //public JsonResult Employees(string cid)
        //{
        //    var dataContext = new AbecedDataContext();

        //    var employees = from e in dataContext.LookupSubcategory
        //                    where (cid.HasValue ? e.LookupCategory.Catid.Equals(cid) : e.LookupCategory.Catid == null)
        //                    select new
        //                    {
        //                        cid = e.LookupCategory.Catid,
        //                        catname = e.LookupCategory.CatTitle,
        //                        hasChildren = e.LookupCategory.LookupSubcategoryList.Any()
        //                    };

        //    return Json(employees, JsonRequestBehavior.AllowGet);
        //}

       /******************USER MANAGEMENT ***************************************/

        /// <summary>
        /// Gets the user list.
        /// </summary>
        /// <returns>user listing</returns>
        private static IEnumerable<PersonModel> GetUserList()
        {
            IRepository repos = new Repository();
            IList<Person> _sc = repos.GetAllPersons();

            return _sc.Select(fc => new PersonModel
            {
                UserName = fc.Userid,
                AgeGroup = fc.AgeGroup,
                Email = fc.Email,
                FirstName = fc.Firstname,
                LastName = fc.Lastname,
                CardsCount = repos.GetMyFlashCards(fc.Userid).Count(),
                SignUpDate = Membership.GetUser(fc.Userid).LastActivityDate,
                LastLoginDate = Membership.GetUser(fc.Userid).LastActivityDate,
                // LoginCount = Membership.GetUser(fc.Userid).LastActivityDate 

            });
        }

        /// <summary>
        /// Gets users - data source for grid control.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>User list</returns>
        public ActionResult GetUsers_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetUserList().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

    }
}
