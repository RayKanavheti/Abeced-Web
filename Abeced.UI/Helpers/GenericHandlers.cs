using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.IO;

namespace Abeced.UI.Helpers
{
    public class GenericHandlers
    {
    }

    public class XMLHandler : System.Web.IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            context.Response.Write(ReadXMLFile());
        }

        private string ReadXMLFile() {
        try {
            //using;
            StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(("~/App_Data/" 
                                + (HttpContext.Current.Request.QueryString["name"] + ".xml"))));
            string line;
            line = sr.ReadToEnd();
            return line;
        }
        catch (Exception e) {
            return "The xml file could not be read.";
        }
    }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}