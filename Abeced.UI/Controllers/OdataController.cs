using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Services;
using System.IO;
using System.Web.Http.Routing;

namespace Abeced.UI.Controllers
{
    /// <summary>
    /// Web service for data manipulation
    /// </summary>
    public class OdataController : ApiController
    {

        /// <summary>
        /// Reads the XML file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <returns>string contents</returns>
        private string ReadXMLFile(string file)
        {
            try
            {
                //using;
                StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath(("~/App_Data/" + file+ ".xml")));
                string line;
                line = sr.ReadToEnd();
                return line;
            }
            catch (Exception)
            {
                return "The xml file could not be read.";
            }
        }

       // GET api/<controller>/5
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public string Get(string id)
        {
            //HttpContext.Current.Response.ContentType = "text/xml";
            return ReadXMLFile(id);
            //return Request.CreateResponse(HttpStatusCode.OK, ReadXMLFile(id), Configuration.Formatters.XmlFormatter);
        }

        /// <summary>
        /// Gets the media.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetMedia")]
        public HttpResponseMessage GetMedia(string file, string type)
        {
            var path = String.Format("{0}{1}", HttpContext.Current.Server.MapPath(@"~/App_Data/flashcardmedia/audio/"), file);

            try
            {
                var responseStream = new MemoryStream();
                using (Stream fileStream = File.Open(path, FileMode.Open))
                {
                    fileStream.CopyTo(responseStream);
                    fileStream.Close();
                    responseStream.Position = 0;
                }
                var response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StreamContent(responseStream)
                };

                response.Content.Headers.Add("content-type", "audio/basic");
                response.Headers.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue()
                {
                    Private = true
                };

                response.Content.Headers.Expires = null;
                response.Headers.Pragma.Clear();

                response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                {
                    FileName = file
                };

                return response;
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, e.Message);
            }
        }

        /*
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };

        }

        

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
         */
    }
}