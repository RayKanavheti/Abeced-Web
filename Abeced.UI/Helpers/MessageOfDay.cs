using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Web;
using System.Net.Mail;

using System.Data;


namespace Abeced.UI.Helpers
{

    public class MessageOfDay
    {
        public string message { set; get; }
        public string GetMessageOfDay()
        {
            Abeced.Data.Repository.IRepository _repos = new Abeced.Data.Repository.Repository();
            return _repos.GetMessageOfDay();
        }
    }
}