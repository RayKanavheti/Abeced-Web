using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Abeced.UI.Helpers;
using Abeced.UI.Models;
using Abeced.Data;
using Abeced.Data.Repository;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;


namespace Abeced.UI.Controllers
{
    /// <summary>
    /// User Controller for User management
    /// </summary>
    [Authorize]
    public class UsersController : Controller
    {
        //
        // GET: /User/

        /// <summary>
        /// Index of this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// The User profile.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyProfile()
        {
            IRepository _repos = new Repository();
            Person p = _repos.GetPerson(User.Identity.Name);
            RegisterModel model = new RegisterModel
            {
                UserName = User.Identity.Name,
                AgeGroup = p.AgeGroup,
                EducLevel = p.EducLevel,
                Email = p.Email,
                FirstName = p.Firstname,
                LastName = p.Lastname,
                Occupation = p.Occupation,
                Sex = p.Sex,
                NumOfCards = Convert.ToInt32(p.UserPreferencesXml),
                Title = p.Title
            };
            return View(model);
        }

        /// <summary>
        /// The User profile.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult MyProfile(RegisterModel model)
        {
            IRepository _repos = new Repository();
            Person p = _repos.GetPerson(User.Identity.Name);
            p.AgeGroup = model.AgeGroup;
            //p.Address = model.;
            p.Email = model.Email;
            p.Firstname = model.FirstName;
            p.Lastname = model.LastName;
            p.Occupation = model.Occupation;
            p.Title = model.Title;
            p.UserPreferencesXml = model.NumOfCards.ToString();
            _repos.SaveOrUpdate(p);
            return View();
        }


        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }


        /// <summary>
        /// Changes the password success.
        /// </summary>
        /// <returns></returns>
        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }


        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        /// <summary>
        /// Adds the card.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCard()
        {
            return PartialView();
        }

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <returns></returns>
        public ActionResult AddCategory()
        {
            return PartialView();
        }

        /// <summary>
        /// User cards.
        /// </summary>
        /// <returns></returns>
        public ActionResult MyCards()
        {
            return View();
        }

        /// <summary>
        /// Adds the category.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCategory(CategoryModel model)
        {
            IRepository _repos = new Repository();
            LookupCategory lkcat = new LookupCategory();

            try
            {
                lkcat = _repos.GetCategory(model.ParentId);
                if (lkcat == null)
                {
                    lkcat = new LookupCategory();
                    lkcat.Catid = Guid.NewGuid().ToString();
                    lkcat.CatTitle = model.ParentId;
                    lkcat.Lastupdate = DateTime.Now;
                    _repos.Save(lkcat);
                }
                LookupSubcategory msg = _repos.GetSubCategory(model.CategoryTitle);
                if (msg == null)
                {
                    msg = new LookupSubcategory
                    {
                        Subcatid = Guid.NewGuid().ToString(),
                        CatTitle = model.CategoryTitle,
                        Lastupdate = DateTime.Now,
                        LookupCategory = lkcat
                    };

                    _repos.Save(msg);
                }

                if (model.SubCategoryTitle != null)
                {
                    LookupSubcategory msg2 = new LookupSubcategory
                    {
                        Subcatid = Guid.NewGuid().ToString(),
                        CatTitle = model.SubCategoryTitle,
                        Lastupdate = DateTime.Now,
                        LookupCategory = lkcat,
                        LookupSubcategoryMember = msg
                    };
                    _repos.Save(msg2);
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

        /// <summary>
        /// Adds the card.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddCard(FlashCardModel model)
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
        /// Edits the card.
        /// </summary>
        /// <param name="cardid">The category id.</param>
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
                FactSheet = fls.Factsheet,
                SubjectArea = fls.Category,
                UploadedBy = fls.UploadedBy
            };
            return PartialView(model);
        }

        /// <summary>
        /// Edits the card.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditCard(FlashCardModel model)
        {
            IRepository _repos = new Repository();
            try
            {
                Flashcard fls = _repos.GetFlashCard(model.CardId);
                fls.Question = model.Question;
                fls.Answer = model.Answer;
                fls.Factsheet = model.FactSheet;
                //TODO add image and audio

                _repos.SaveOrUpdate(fls);
                return Json(new { rtnmsg = "success" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { rtnmsg = "error" }, JsonRequestBehavior.AllowGet);
            }
        }


        /********************* Begin Flash Card Functions *************/

        /// <summary>
        /// Gets the category list.
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
        /// Gets the subject list.
        /// </summary>
        /// <param name="catid">The catid.</param>
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
        /// <param name="u">The user id.</param>
        /// <returns></returns>
        private static IEnumerable<FlashCardModel> GetCardList(string u)
        {
            IRepository repos = new Repository();
            IList<Flashcard> _sc = repos.GetFlashCardList(u);

            return _sc.Select(fc => new FlashCardModel
            {
                CardId = fc.Identification,
                Question = fc.Question,
                Answer = fc.Answer,
                FactSheet = fc.Factsheet,
                Approved = fc.Approved.HasValue ? fc.Approved.Value : false
            });
        }

        /// <summary>
        /// Gets the card list  - data source.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        public ActionResult GetCardList_Read([DataSourceRequest] DataSourceRequest request)
        {

            return Json(GetCardList(User.Identity.Name).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
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
        /// Gets all category.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllCategory()
        {
            IRepository _repos = new Repository();
            IList<LookupCategory> catg = new List<LookupCategory>();

            catg = _repos.GetCategoryList(false);

            return Json(catg.Select(c => new { catid = c.Catid, catname = c.CatTitle }), JsonRequestBehavior.AllowGet);

        }

    }
}
