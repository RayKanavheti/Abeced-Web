using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using System.Web.Security;

namespace Abeced.UI.Models
{
    /// <summary>
    /// System Admin Model
    /// </summary>
    public class SystemAdminModel
    {
        /// <summary>
        /// Gets or sets the cards pending approve.
        /// </summary>
        /// <value>
        /// The cards pending approve.
        /// </value>
        public int CardsPendingApprove { set; get; }
    }

    /// <summary>
    /// Message Of Day Model
    /// </summary>
    public class MessageOfDayModel
    {
        public string Id { set; get; }
        /// <summary>
        /// Gets or sets the day.
        /// </summary>
        /// <value>
        /// The day.
        /// </value>
        [Required]
        public DateTime Day { set; get; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [Required]
        public string Message { set; get; }
    }
}