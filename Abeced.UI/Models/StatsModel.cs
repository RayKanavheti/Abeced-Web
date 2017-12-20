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
    /// Statistics Model
    /// </summary>
    public class StatsModel
    {
        /// <summary>
        /// Gets or sets the cards pending approve.
        /// </summary>
        /// <value>
        /// The cards pending approve.
        /// </value>
        public int CardsPendingApprove { set; get; }
        /// <summary>
        /// Gets or sets the cards approved.
        /// </summary>
        /// <value>
        /// The cards approved.
        /// </value>
        public int CardsApproved { set; get; }
        /// <summary>
        /// Gets or sets my card count.
        /// </summary>
        /// <value>
        /// My card count.
        /// </value>
        public int MyCardCount { set; get; }
        /// <summary>
        /// Gets or sets all cards.
        /// </summary>
        /// <value>
        /// All cards.
        /// </value>
        public int AllCards { set; get; }
    }
}