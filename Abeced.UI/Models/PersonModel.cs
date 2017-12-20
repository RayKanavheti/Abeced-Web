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
    /// Person Model
    /// </summary>
    public class PersonModel 
    {
        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName { set; get; }
        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { set; get; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { set; get; }
        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email { set; get; }
        /// <summary>
        /// Gets or sets the age group.
        /// </summary>
        /// <value>
        /// The age group.
        /// </value>
        public string AgeGroup { set; get; }
        /// <summary>
        /// Gets or sets the sign up date.
        /// </summary>
        /// <value>
        /// The sign up date.
        /// </value>
        public DateTime SignUpDate { set; get; }
        /// <summary>
        /// Gets or sets the last login date.
        /// </summary>
        /// <value>
        /// The last login date.
        /// </value>
        public DateTime LastLoginDate { set; get; }
        /// <summary>
        /// Gets or sets the cards count.
        /// </summary>
        /// <value>
        /// The cards count.
        /// </value>
        public int CardsCount { set; get; }
        /// <summary>
        /// Gets or sets the login count.
        /// </summary>
        /// <value>
        /// The login count.
        /// </value>
        public int LoginCount { set; get; }
        /// <summary>
        /// Gets or sets the invitations sent.
        /// </summary>
        /// <value>
        /// The invitations sent.
        /// </value>
        public int InvitationsSent { set; get; }
    }
}