using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Abeced.UI.Controllers
{
    
    /// <summary>
    /// Home Controller
    /// </summary>
    public class HomeController : Controller
    {
          
               
            
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            /*if(String.IsNullOrEmpty(Globals.MessageOD))
            {
                Abeced.Data.Repository.IRepository _repos = new Abeced.Data.Repository.Repository();
                Globals.MessageOD = _repos.GetMessageOfDay();
            }*/
            if (Request.IsAuthenticated && Session["firstname"] == null )
            {
                Abeced.Data.Repository.IRepository _repos = new Abeced.Data.Repository.Repository();
                Abeced.Data.Person p = _repos.GetPerson(User.Identity.Name);
                Session["firstname"] = p.Firstname;
                Session["lastname"] = p.Lastname;
            }

            return View();
        }

        /// <summary>
        /// Abouts this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        /// <summary>
        /// Contact Page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Tests this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Test()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
