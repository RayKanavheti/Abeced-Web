using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;
using System.Xml;
using System.Xml.Linq;
//using Abeced;


namespace Abeced.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    /// <summary>
    /// Mvc Application : System Web Http Application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// The _daily message
        /// </summary>
        public string _dailymessage; // the global private variable

        /// <summary>
        /// Gets the daily message file.
        /// </summary>
        /// <value>
        /// The daily message file.
        /// </value>
        //internal string DailyMessageFile // the global controlled variable
        //{
        //    get
        //    {
        //        if (String.IsNullOrEmpty(_dailymessage))
        //        {
        //            Abeced.Data.Repository.IRepository _repos = new Abeced.Data.Repository.Repository();
        //            string str = _repos.GetMessageOfDay();
        //            _dailymessage = !String.IsNullOrEmpty(str) ? str : "When there’s no point to your actions, there’s no energy within you to take those actions..";
        //        }
        //        return _dailymessage;
        //    }
        //}
        /// <summary>
        /// Application the start.
        /// </summary>
        protected void Application_Start()
        {
            if (String.IsNullOrEmpty(Globals.MessageOD))
            {
                Abeced.Data.Repository.IRepository _repos = new Abeced.Data.Repository.Repository();
                Globals.MessageOD = _repos.GetMessageOfDay();
            }
            Application["DailyMessageFile"] = Globals.MessageOD;
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
        }


    }
}