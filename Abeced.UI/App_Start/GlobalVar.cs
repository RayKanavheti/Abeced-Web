using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abeced.Data;
using System.Text;

namespace Abeced.UI
{
    /// <summary>
    /// 
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// The message od
        /// </summary>
        public static string MessageOD { set; get; }
        //{
        //    get
        //    {
        //        string str = "";
        //        if (String.IsNullOrEmpty(MessageOD))
        //        {
        //            Abeced.Data.Repository.IRepository _repos = new Abeced.Data.Repository.Repository();
        //            str = _repos.GetMessageOfDay();
        //            str = !String.IsNullOrEmpty(str) ? str : "When there’s no point to your actions, there’s no energy within you to take those actions..";
        //        }
        //        return str;
        //    }

        //}
    }
}