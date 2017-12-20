using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
//using Abeced.UI.Filters;
using Abeced.Data;
using Abeced.Data.Repository;
using Abeced.UI.Models;
using Abeced.UI.Helpers;


namespace Abeced.UI.Controllers
{
    /// <summary>
    /// AccountController
    /// </summary>
    [Authorize]
    //[InitializeSimpleMembership]
    public class AccountController : Controller
    {
        /// <summary>
        /// Gets or sets the forms service.
        /// </summary>
        /// <value>
        /// The forms service.
        /// </value>
        public IFormsAuthenticationService FormsService { get; set; }
        /// <summary>
        /// Gets or sets the membership service.
        /// </summary>
        /// <value>
        /// The membership service.
        /// </value>
        public IMembershipService MembershipService { get; set; }
        /// <summary>
        /// Initializes the specified request context.
        /// </summary>
        /// <param name="requestContext">The request context.</param>
        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        //
        // GET: /Account/Login

        /// <summary>
        /// Logins the specified return URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login

        /// <summary>
        /// Logins the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && Membership.ValidateUser(model.UserName, model.Password))// persistCookie: model.RememberMe))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                IRepository _repos = new Repository();
                Person p = _repos.GetPerson(model.UserName);
                Session["firstname"] = p.Firstname;
                Session["lastname"] = p.Lastname;
                return RedirectToLocal("Index", model.UserName);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        //
        // POST: /Account/LogOff

        /// <summary>
        /// Logs the off.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            //WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Registers the success.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult RegisterSuccess()
        {
            return View();
        }

        //
        // POST: /Account/Register

        /// <summary>
        /// Registers the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    MembershipCreateStatus createStatus;                        
                    Membership.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                    IRepository _repos = new Repository();
                    Person p = new Person
                    {
                        Firstname = model.FirstName,
                        Lastname = model.LastName,
                        AgeGroup = model.AgeGroup,
                        EducLevel = model.EducLevel,
                        Email = model.Email,
                        Occupation = model.Occupation,
                        Sex = model.Sex,
                        Title = model.Title,
                        Userid = model.UserName,
                        UserPreferencesXml = "4"

                    };

                    if (createStatus.ToString() == "Success")
                    {
                        _repos.SaveOrUpdate(p);
                        return RedirectToAction("RegisterSuccess", "Account");
                    }
                    else
                    {
                        ModelState.AddModelError("", createStatus.ToString());
                        //throw new MembershipCreateUserException();
                    }
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/Disassociate

        /// <summary>
        /// Disassociates the specified provider.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="providerUserId">The provider user identifier.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Disassociate(string provider, string providerUserId)
        {
            string ownerAccount = OAuthWebSecurity.GetUserName(provider, providerUserId);
            ManageMessageId? message = null;

            // Only disassociate the account if the currently logged in user is the owner
            if (ownerAccount == User.Identity.Name)
            {
                // Use a transaction to prevent the user from deleting their last login credential
                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.Serializable }))
                {
                    bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
                    if (hasLocalAccount || OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name).Count > 1)
                    {
                        OAuthWebSecurity.DeleteAccount(provider, providerUserId);
                        scope.Complete();
                        message = ManageMessageId.RemoveLoginSuccess;
                    }
                }
            }

            return RedirectToAction("Manage", new { Message = message });
        }

        //
        // GET: /Account/Manage

        /// <summary>
        /// Manages the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Your password has been changed."
                : message == ManageMessageId.SetPasswordSuccess ? "Your password has been set."
                : message == ManageMessageId.RemoveLoginSuccess ? "The external login was removed."
                : "";
            ViewBag.HasLocalPassword = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.ReturnUrl = Url.Action("Manage");
            return View();
        }

        //
        // POST: /Account/Manage

        /// <summary>
        /// Manages the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(LocalPasswordModel model)
        {
            bool hasLocalAccount = OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            ViewBag.HasLocalPassword = hasLocalAccount;
            ViewBag.ReturnUrl = Url.Action("Manage");
            if (hasLocalAccount)
            {
                if (ModelState.IsValid)
                {
                    // ChangePassword will throw an exception rather than return false in certain failure scenarios.
                    bool changePasswordSucceeded;
                    try
                    {
                        changePasswordSucceeded = WebSecurity.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword);
                    }
                    catch (Exception)
                    {
                        changePasswordSucceeded = false;
                    }

                    if (changePasswordSucceeded)
                    {
                        return RedirectToAction("Manage", new { Message = ManageMessageId.ChangePasswordSuccess });
                    }
                    else
                    {
                        ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                    }
                }
            }
            else
            {
                // User does not have a local password so remove any validation errors caused by a missing
                // OldPassword field
                ModelState state = ModelState["OldPassword"];
                if (state != null)
                {
                    state.Errors.Clear();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        WebSecurity.CreateAccount(User.Identity.Name, model.NewPassword);
                        return RedirectToAction("Manage", new { Message = ManageMessageId.SetPasswordSuccess });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e);
                    }
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin

        /// <summary>
        /// Externals the login.
        /// </summary>
        /// <param name="provider">The provider.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            return new ExternalLoginResult(provider, Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback

        /// <summary>
        /// Externals the login callback.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ExternalLoginCallback(string returnUrl)
        {
            AuthenticationResult result = OAuthWebSecurity.VerifyAuthentication(Url.Action("ExternalLoginCallback", new { ReturnUrl = returnUrl }));
            if (!result.IsSuccessful)
            {
                return RedirectToAction("ExternalLoginFailure");
            }

            if (OAuthWebSecurity.Login(result.Provider, result.ProviderUserId, createPersistentCookie: false))
            {
                return RedirectToLocal(returnUrl);
            }

            if (User.Identity.IsAuthenticated)
            {
                // If the current user is logged in add the new account
                OAuthWebSecurity.CreateOrUpdateAccount(result.Provider, result.ProviderUserId, User.Identity.Name);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                // User is new, ask for their desired membership name
                string loginData = OAuthWebSecurity.SerializeProviderUserId(result.Provider, result.ProviderUserId);
                ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(result.Provider).DisplayName;
                ViewBag.ReturnUrl = returnUrl;
                return View("ExternalLoginConfirmation", new RegisterExternalLoginModel { UserName = result.UserName, ExternalLoginData = loginData });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation

        /// <summary>
        /// Externals the login confirmation.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLoginConfirmation(RegisterExternalLoginModel model, string returnUrl)
        {
            string provider = null;
            string providerUserId = null;

            if (User.Identity.IsAuthenticated || !OAuthWebSecurity.TryDeserializeProviderUserId(model.ExternalLoginData, out provider, out providerUserId))
            {
                return RedirectToAction("Manage");
            }

            if (ModelState.IsValid)
            {
                // Insert a new user into the database
                using (UsersContext db = new UsersContext())
                {
                    UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.ToLower() == model.UserName.ToLower());
                    // Check if user already exists
                    if (user == null)
                    {
                        // Insert name into the profile table
                        db.UserProfiles.Add(new UserProfile { UserName = model.UserName });
                        db.SaveChanges();

                        OAuthWebSecurity.CreateOrUpdateAccount(provider, providerUserId, model.UserName);
                        OAuthWebSecurity.Login(provider, providerUserId, createPersistentCookie: false);

                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("UserName", "User name already exists. Please enter a different user name.");
                    }
                }
            }

            ViewBag.ProviderDisplayName = OAuthWebSecurity.GetOAuthClientData(provider).DisplayName;
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // GET: /Account/ExternalLoginFailure

        /// <summary>
        /// Externals the login failure.
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        /// <summary>
        /// Externals the logins list.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        [AllowAnonymous]
        [ChildActionOnly]
        public ActionResult ExternalLoginsList(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return PartialView("_ExternalLoginsListPartial", OAuthWebSecurity.RegisteredClientData);
        }

        /// <summary>
        /// Removes the external logins.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public ActionResult RemoveExternalLogins()
        {
            ICollection<OAuthAccount> accounts = OAuthWebSecurity.GetAccountsFromUserName(User.Identity.Name);
            List<ExternalLogin> externalLogins = new List<ExternalLogin>();
            foreach (OAuthAccount account in accounts)
            {
                AuthenticationClientData clientData = OAuthWebSecurity.GetOAuthClientData(account.Provider);

                externalLogins.Add(new ExternalLogin
                {
                    Provider = account.Provider,
                    ProviderDisplayName = clientData.DisplayName,
                    ProviderUserId = account.ProviderUserId,
                });
            }

            ViewBag.ShowRemoveButton = externalLogins.Count > 1 || OAuthWebSecurity.HasLocalAccount(WebSecurity.GetUserId(User.Identity.Name));
            return PartialView("_RemoveExternalLoginsPartial", externalLogins);
        }

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        /// <summary>
        /// Changes the password.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [Authorize]
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

        //
        // GET: /Account/ChangePasswordSuccess

        /// <summary>
        /// Changes the password success.
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        /// <summary>
        /// Passwords the reset.
        /// </summary>
        /// <returns></returns>
        public ActionResult PasswordReset()
        {
            //if (!MembershipService.PasswordResetEnabled) throw new Exception("Password reset is not allowed\r\n");
            return View();
        }

        /// <summary>
        /// Passwords the reset.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="captchaValid">if set to <c>true</c> [captcha valid].</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Password reset is not allowed\r\n</exception>
        [HttpPost]
        //[RecaptchaControlMvc.CaptchaValidatorAttribute] 
        //public ActionResult PasswordReset(string userName, bool captchaValid)
        public ActionResult PasswordReset(string userName, bool captchaValid = true)
        {
            userName = userName.ToUpper();
            //if (!captchaValid)
            //{
            //    ModelState.AddModelError("", "You did not type the verification word correctly. Please try again.");
            //    return Json(new { rtnmsg = "cerr" }, JsonRequestBehavior.AllowGet);
            //}
            //else
            {
                if (!MembershipService.PasswordResetEnabled) throw new Exception("Password reset is not allowed\r\n");
                if (Membership.GetUser(userName) == null)
                    return Json(new { rtnmsg = false }, JsonRequestBehavior.AllowGet);
                if (MembershipService.RequiresQuestionAndAnswer)
                {
                    return RedirectToAction("QuestionAndAnswer", new { userName = userName });
                }
                else
                {
                    try
                    {
                        IRepository _repos = new Repository();
                        MembershipUser u = Membership.GetUser(userName);
                        if (u == null)
                            return Json(new { savans = "invaliduser" }, JsonRequestBehavior.AllowGet);
                        //email user with reset link
                        Mailer mail = new Mailer();
                        PasswordReset newlink = new PasswordReset();
                        newlink.Email = u.Email;
                        newlink.Email = userName;
                        newlink.Reqtime = DateTime.Now;
                        newlink.Requestid = Guid.NewGuid().ToString();
                        newlink.Isvalid = true;

                        _repos.Save(newlink);

                        string baseUrl = string.Format("{0}://{1}{2}",
                            Request.Url.Scheme, Request.Url.Authority, Url.Content("~")) +
                            "Account/PasswordResetConfirm?gid=" + newlink.Requestid;

                        //MembershipService.ResetPassword(userName, GetLoginUrl());
                        EmailNewPassword(baseUrl, u.Email);
                        return JavaScript("window.location = '" + Url.Action("PasswordResetFinal") + "'");
                    }
                    catch
                    {
                        return Json(new { savans = "error" }, JsonRequestBehavior.AllowGet);
                    }
                    //return RedirectToAction("PasswordResetFinal", new { userName = userName });
                }
            }
            //return View();
        }

        /// <summary>
        /// Passwords the reset confirm.
        /// </summary>
        /// <param name="gid">The id.</param>
        /// <returns></returns>
        public ActionResult PasswordResetConfirm(string gid)
        {
            ViewData["gid"] = gid;
            if (gid == null)
                //return JavaScript("window.location = '" + Url.Action("PasswordReset") + "'");
                return RedirectToActionPermanent("PasswordReset");

            IRepository _repos = new Repository();
            PasswordReset rstreq = _repos.GetResetRequest(gid);
            if ((DateTime.Now.Subtract(rstreq.Reqtime)).Hours > 2 || !rstreq.Isvalid)
                //return JavaScript("window.location = '" + Url.Action("PasswordResetExpire") + "'");
                return RedirectToActionPermanent("PasswordResetExpire");

            return View();
        }

        /// <summary>
        /// Passwords the reset confirm.
        /// </summary>
        /// <param name="gid">The gid.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PasswordResetConfirm(string gid, ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (gid == null)
                    return JavaScript("window.location = '" + Url.Action("PasswordReset") + "'");
                try
                {
                    IRepository _repos = new Repository();
                    PasswordReset rstreq = _repos.GetResetRequest(gid);
                    if ((DateTime.Now.Subtract(rstreq.Reqtime)).Hours > 2)
                        return JavaScript("window.location = '" + Url.Action("PasswordResetExpire") + "'");

                    MembershipUser u = Membership.GetUser(rstreq.Email);
                    if (u == null)
                        return Json(new { savans = "invaliduser" }, JsonRequestBehavior.AllowGet);
                    string oldPass = u.ResetPassword();
                    u.ChangePassword(oldPass, model.NewPassword);
                    rstreq.Isvalid = false;
                    _repos.SaveOrUpdate(rstreq);
                    return Json(new { savans = "success" }, JsonRequestBehavior.AllowGet);

                }

                catch
                {

                }
            }
            return View();
        }

        /// <summary>
        /// Passwords the reset expire.
        /// </summary>
        /// <returns></returns>
        public ActionResult PasswordResetExpire()
        {
            return View();
        }


        // **************************************
        // URL: /Account/PasswordResetFinal
        // **************************************
        /// <summary>
        /// Passwords the reset final.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Password reset is not allowed\r\n</exception>
        public ActionResult PasswordResetFinal(string userName)
        {
            if (!MembershipService.PasswordResetEnabled) throw new Exception("Password reset is not allowed\r\n");
            return View();
        }

        // **************************************
        // URL: /Account/QuestionAndAnswer
        // **************************************
        /// <summary>
        /// Questions the and answer.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Password reset is not allowed\r\n</exception>
        public ActionResult QuestionAndAnswer(string userName)
        {
            if (!MembershipService.PasswordResetEnabled) throw new Exception("Password reset is not allowed\r\n");
            ViewData["UserName"] = userName;
            ViewData["Question"] = MembershipService.GetUserQuestion(userName);
            return View();
        }

        /// <summary>
        /// Questions the and answer.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="answer">The answer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Password reset is not allowed\r\n</exception>
        [HttpPost]
        public ActionResult QuestionAndAnswer(string userName, string answer)
        {
            if (!MembershipService.PasswordResetEnabled) throw new Exception("Password reset is not allowed\r\n");
            MembershipService.ResetPassword(userName, answer, GetLoginUrl());
            return RedirectToAction("PasswordResetFinal", new { userName = userName });
        }

        /// <summary>
        /// Gets the login URL.
        /// </summary>
        /// <returns></returns>
        private string GetLoginUrl()
        {
            string thisUrl = Request.Url.AbsoluteUri;
            string baseUrl = thisUrl.Substring(0, thisUrl.LastIndexOf('/'));
            return baseUrl + "/LogOn";
        }

        /// <summary>
        /// Emails the new password.
        /// </summary>
        /// <param name="link">The link.</param>
        /// <param name="email">The email.</param>
        private void EmailNewPassword(string link, string email)
        {
            Mailer mail = new Mailer();

            string mailMsg = "Please use the link below to reset your password \n\n" +
                             "{RESET_LINK}  \n\n " +

                             "If you did not request this information please ignore the message, ";
            string msgTitle = "Password Reset Request";
            string mailSign = "\n Abeced Admin";
            string mailFrom = "danielkwofie@gmail.com";
            string clientIPAddress = System.Web.HttpContext.Current.Request.UserHostAddress;
            //string clientIPAddress = HttpRequest.UserHostAddress;
            //mailMsg = mailMsg.Replace("{PASSWD}", password);

            mailMsg = mailMsg.Replace("{RESET_LINK}", link);

            mailMsg = mailMsg + " \n" + mailSign + "\n \n";
            mail.SendMail(msgTitle, mailMsg, mailFrom, email);

        }

        //public ActionResult ChangePassword()
        //{
        //    return View();
        //}

        //[OutputCache(NoStore = true, Duration = 0)]
        //public ActionResult ChangePasswordSuccess()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult ChangePassword(ChangePasswordModel model)
        //{
        //    if (ModelState.IsValid)
        //    {

        //         ChangePassword will throw an exception rather
        //         than return false in certain failure scenarios.
        //        bool changePasswordSucceeded;
        //        try
        //        {
        //            MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true /* userIsOnline */);
        //            changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
        //        }
        //        catch (Exception)
        //        {
        //            changePasswordSucceeded = false;
        //        }

        //        if (changePasswordSucceeded)
        //        {
        //            return RedirectToAction("ChangePasswordSuccess");
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
        //        }
        //    }

        //     If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        #region Helpers
        /// <summary>
        /// Redirects to local.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {               
                if (Roles.IsUserInRole("User"))
                {
                    return RedirectToAction("Dashboard", "App");
                }
                else  if (Roles.IsUserInRole("Administrator"))
                {
                    return RedirectToAction("Dashboard", "App");
                }

                else
                    return RedirectToAction("Dashboard", "App");
            }
        }

        /// <summary>
        /// Redirects to local.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl, string username)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                if (Roles.IsUserInRole(username,"Administrator"))
                {
                    return RedirectToAction("Dashboard", "App");
                }
                else if (Roles.IsUserInRole(username,"User"))
                {
                    return RedirectToAction("Dashboard", "App");
                }

                else
                    return RedirectToAction("Dashboard", "App");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ManageMessageId
        {
            /// <summary>
            /// The change password success
            /// </summary>
            ChangePasswordSuccess,
            /// <summary>
            /// The set password success
            /// </summary>
            SetPasswordSuccess,
            /// <summary>
            /// The remove login success
            /// </summary>
            RemoveLoginSuccess,
        }

        /// <summary>
        /// 
        /// </summary>
        internal class ExternalLoginResult : ActionResult
        {
            public ExternalLoginResult(string provider, string returnUrl)
            {
                Provider = provider;
                ReturnUrl = returnUrl;
            }

            public string Provider { get; private set; }
            public string ReturnUrl { get; private set; }

            public override void ExecuteResult(ControllerContext context)
            {
                OAuthWebSecurity.RequestAuthentication(Provider, ReturnUrl);
            }
        }

        /// <summary>
        /// Errors the code to string.
        /// </summary>
        /// <param name="createStatus">The create status.</param>
        /// <returns></returns>
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion

        #region Services
        // The FormsAuthentication type is sealed and contains static members, so it is difficult to
        // unit test code that calls its members. The interface and helper class below demonstrate
        // how to create an abstract wrapper around such a type in order to make the AccountController
        // code unit testable.

        //public override MembershipUser GetUser(string username, bool userIsOnline)
        //{
        //    ConnectionStringSettings connectionString = ConfigurationManager.ConnectionStrings["WitsEtd"];
        //    OdbcConnection conn = new OdbcConnection(connectionString);
        //    OdbcCommand cmd = new OdbcCommand("SELECT PKID, Username, Email, PasswordQuestion," +
        //         " Comment, IsApproved, IsLockedOut, CreationDate, LastLoginDate," +
        //         " LastActivityDate, LastPasswordChangedDate, LastLockedOutDate," +
        //         " IsSubscriber, CustomerID" +
        //         " FROM Users  WHERE Username = ? AND ApplicationName = ?", conn);

        //    cmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
        //    cmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

        //    OdbcMembershipUser u = null;
        //    OdbcDataReader reader = null;

        //    try
        //    {
        //        conn.Open();

        //        reader = cmd.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            reader.Read();
        //            u = GetUserFromReader(reader);

        //            if (userIsOnline)
        //            {
        //                OdbcCommand updateCmd = new OdbcCommand("UPDATE Users  " +
        //                          "SET LastActivityDate = ? " +
        //                          "WHERE Username = ? AND Applicationname = ?", conn);

        //                updateCmd.Parameters.Add("@LastActivityDate", OdbcType.DateTime).Value = DateTime.Now;
        //                updateCmd.Parameters.Add("@Username", OdbcType.VarChar, 255).Value = username;
        //                updateCmd.Parameters.Add("@ApplicationName", OdbcType.VarChar, 255).Value = pApplicationName;

        //                updateCmd.ExecuteNonQuery();
        //            }
        //        }

        //    }
        //    catch (OdbcException e)
        //    {
        //        if (WriteExceptionsToEventLog)
        //        {
        //            WriteToEventLog(e, "GetUser(String, Boolean)");

        //            throw new ProviderException(exceptionMessage);
        //        }
        //        else
        //        {
        //            throw e;
        //        }
        //    }
        //    finally
        //    {
        //        if (reader != null) { reader.Close(); }

        //        conn.Close();
        //    }

        //    return u;
        //}

        /// <summary>
        /// IMembershipService Interface
        /// </summary>
        public interface IMembershipService
        {
            /// <summary>
            /// Gets the minimum length of the password.
            /// </summary>
            /// <value>
            /// The minimum length of the password.
            /// </value>
            int MinPasswordLength { get; }

            // Hector was here
            /// <summary>
            /// Gets a value indicating whether [password reset enabled].
            /// </summary>
            /// <value>
            /// <c>true</c> if [password reset enabled]; otherwise, <c>false</c>.
            /// </value>
            bool PasswordResetEnabled { get; }
            /// <summary>
            /// Gets a value indicating whether [requires question and answer].
            /// </summary>
            /// <value>
            /// <c>true</c> if [requires question and answer]; otherwise, <c>false</c>.
            /// </value>
            bool RequiresQuestionAndAnswer { get; }

            /// <summary>
            /// Validates the user.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="password">The password.</param>
            /// <returns></returns>
            bool ValidateUser(string userName, string password);

            // Hector was here
            /// <summary>
            /// Creates the user.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="password">The password.</param>
            /// <param name="email">The email.</param>
            /// <param name="question">The question.</param>
            /// <param name="answer">The answer.</param>
            /// <returns></returns>
            MembershipCreateStatus CreateUser(string userName, string password, string email, string question, string answer);

            /// <summary>
            /// Changes the password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="oldPassword">The old password.</param>
            /// <param name="newPassword">The new password.</param>
            /// <returns></returns>
            bool ChangePassword(string userName, string oldPassword, string newPassword);

            // Hector was here
            /// <summary>
            /// Resets the password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="answer">The answer.</param>
            /// <param name="loginUrl">The login URL.</param>
            void ResetPassword(string userName, string answer, string loginUrl);
            /// <summary>
            /// Resets the password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="loginUrl">The login URL.</param>
            void ResetPassword(string userName, string loginUrl);
            /// <summary>
            /// Gets the user question.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <returns></returns>
            string GetUserQuestion(string userName);
        }

        /// <summary>
        /// AccountMembershipService inherists IMembershipService
        /// </summary>
        public class AccountMembershipService : IMembershipService
        {
            private readonly MembershipProvider _provider;

            /// <summary>
            /// Initializes a new instance of the <see cref="AccountMembershipService"/> class.
            /// </summary>
            public AccountMembershipService()
                : this(null)
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="AccountMembershipService"/> class.
            /// </summary>
            /// <param name="provider">The provider.</param>
            public AccountMembershipService(MembershipProvider provider)
            {
                _provider = provider ?? Membership.Provider;
            }

            /// <summary>
            /// Gets a value indicating whether [password reset enabled].
            /// </summary>
            /// <value>
            /// <c>true</c> if [password reset enabled]; otherwise, <c>false</c>.
            /// </value>
            public bool PasswordResetEnabled
            {
                get
                {
                    return _provider.EnablePasswordReset;
                }
            }

            /// <summary>
            /// Gets a value indicating whether [requires question and answer].
            /// </summary>
            /// <value>
            /// <c>true</c> if [requires question and answer]; otherwise, <c>false</c>.
            /// </value>
            public bool RequiresQuestionAndAnswer
            {
                get
                {
                    return _provider.RequiresQuestionAndAnswer;
                }
            }

            /// <summary>
            /// Gets the minimum length of the password.
            /// </summary>
            /// <value>
            /// The minimum length of the password.
            /// </value>
            public int MinPasswordLength
            {
                get
                {
                    return _provider.MinRequiredPasswordLength;
                }
            }

            /// <summary>
            /// Validates the user.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="password">The password.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentException">
            /// Value cannot be null or empty.;userName
            /// or
            /// Value cannot be null or empty.;password
            /// </exception>
            public bool ValidateUser(string userName, string password)
            {
                if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
                if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");

                return _provider.ValidateUser(userName, password);
            }

            /// <summary>
            /// Creates the user.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="password">The password.</param>
            /// <param name="email">The email.</param>
            /// <param name="question">The question.</param>
            /// <param name="answer">The answer.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentException">
            /// Value cannot be null or empty.;userName
            /// or
            /// Value cannot be null or empty.;password
            /// or
            /// Value cannot be null or empty.;email
            /// or
            /// Value cannot be null or empty.;question
            /// or
            /// Value cannot be null or empty.;answer
            /// </exception>
            public MembershipCreateStatus CreateUser(string userName, string password, string email, string question, string answer)
            {
                if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
                if (String.IsNullOrEmpty(password)) throw new ArgumentException("Value cannot be null or empty.", "password");
                if (String.IsNullOrEmpty(email)) throw new ArgumentException("Value cannot be null or empty.", "email");

                if (_provider.RequiresQuestionAndAnswer)
                {
                    if (String.IsNullOrEmpty(question)) throw new ArgumentException("Value cannot be null or empty.", "question");
                    if (String.IsNullOrEmpty(answer)) throw new ArgumentException("Value cannot be null or empty.", "answer");
                }

                MembershipCreateStatus status;
                _provider.CreateUser(userName, password, email, question, answer, true, null, out status);
                return status;
            }

            /// <summary>
            /// Changes the password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="oldPassword">The old password.</param>
            /// <param name="newPassword">The new password.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentException">
            /// Value cannot be null or empty.;userName
            /// or
            /// Value cannot be null or empty.;oldPassword
            /// or
            /// Value cannot be null or empty.;newPassword
            /// </exception>
            public bool ChangePassword(string userName, string oldPassword, string newPassword)
            {
                if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");
                if (String.IsNullOrEmpty(oldPassword)) throw new ArgumentException("Value cannot be null or empty.", "oldPassword");
                if (String.IsNullOrEmpty(newPassword)) throw new ArgumentException("Value cannot be null or empty.", "newPassword");

                // The underlying ChangePassword() will throw an exception rather
                // than return false in certain failure scenarios.
                try
                {
                    MembershipUser currentUser = _provider.GetUser(userName, true /* userIsOnline */);
                    return currentUser.ChangePassword(oldPassword, newPassword);
                }
                catch (ArgumentException)
                {
                    return false;
                }
                catch (MembershipPasswordException)
                {
                    return false;
                }
            }

            /// <summary>
            /// Gets the user question.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <returns></returns>
            /// <exception cref="System.Exception">User name not found</exception>
            public string GetUserQuestion(string userName)
            {
                MembershipUser user = _provider.GetUser(userName, false);
                if (user == null)
                {
                    throw new Exception("User name not found");
                }
                else
                {
                    return user.PasswordQuestion;
                }
            }

            /// <summary>
            /// Resets the password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="answer">The answer.</param>
            /// <param name="loginUrl">The login URL.</param>
            /// <exception cref="System.Exception">User name not found</exception>
            public void ResetPassword(string userName, string answer, string loginUrl)
            {
                MembershipUser user = _provider.GetUser(userName, false);
                if (user == null)
                {
                    throw new Exception("User name not found");
                }
                else
                {
                    // Reset the password.
                    string newPassword = _provider.ResetPassword(userName, answer);

                    // At this point the account has a new randomly generated password.
                    // This is typically a very strong password but almost impossible for 
                    // user to type correctly.
                    //
                    // The code below changes the new password to a human friendly password
                    // (but also much less secure one.) Use this code at your own risk.
                    string friendlyPassword = GenerateHumanFriendlyPassword();
                    _provider.ChangePassword(userName, newPassword, friendlyPassword);

                    // E-mail the new password to the user.
                    EmailNewPassword(userName, friendlyPassword, user.Email, loginUrl);
                }
            }

            /// <summary>
            /// Resets the password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="loginUrl">The login URL.</param>
            /// <exception cref="System.Exception">User name not found</exception>
            public void ResetPassword(string userName, string loginUrl)
            {
                MembershipUser user = _provider.GetUser(userName, false);
                if (user == null)
                {
                    throw new Exception("User name not found");
                }
                else
                {
                    string newPassword = user.ResetPassword();
                    //string friendlyPassword = GenerateHumanFriendlyPassword();
                    string friendlyPassword = Guid.NewGuid().ToString().Split('-')[0];
                    //string friendlyPassword = Membership.GeneratePassword(8, 1);
                    _provider.ChangePassword(userName, newPassword, friendlyPassword);
                    EmailNewPassword(userName, friendlyPassword, user.Email, loginUrl);
                }
            }

            /// <summary>
            /// Emails the new password.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="password">The password.</param>
            /// <param name="email">The email.</param>
            /// <param name="loginUrl">The login URL.</param>
            private void EmailNewPassword(string userName, string password, string email, string loginUrl)
            {
                
                Mailer mail = new Mailer();

                string mailMsg = "Please use the link below to reset your password \n\n" +
                             "{RESET_LINK}  \n\n " +

                             "If you did not request this information please ignore the message, ";
                string msgTitle = "Password Reset Request";
                string mailSign = "\n Abeced Admin";
                string mailFrom = "danielkwofie@gmail.com";
                string clientIPAddress = System.Web.HttpContext.Current.Request.UserHostAddress;

                //string clientIPAddress = HttpRequest.UserHostAddress;
                mailMsg = mailMsg.Replace("{PASSWD}", password);
                mailMsg = mailMsg.Replace("{IP_ADDRESS}", clientIPAddress);

                mailMsg = mailMsg + " \n" + mailSign + "\n \n";
                mail.SendMail(msgTitle, mailMsg, mailFrom, email);

                //string message = string.Format("Your user name is {0}\r\n", userName);
                //message += string.Format("Your password is {0}\r\n", password);
                //message += "\r\n";
                //message += string.Format("To login go to {0}\r\n", loginUrl);

                //string mailTo = Membership.Provider.GetUser(userName, false).Email;
                //string subject = "Your new password";

                //// TODO: You need to replace this with your own e-mail code,
                //// something along the lines of MyUtilities.EMail.Send(mailTo, subject, message)
                //// for now we just fake the e-mail action by logging the message to a text file. 
                //string tempFile = System.Web.HttpContext.Current.Server.MapPath("~/emaillog.txt");
                ////Server.MapPath("emaillog.txt");
                //string tempLogMessage = string.Format("to: {0}\r\nsubject: {1}\r\nmessage: {2}\r\n\r\n", mailTo, subject, message);
                //System.IO.File.AppendAllText(tempFile, tempLogMessage);
            }

            /// <summary>
            /// Generates the human friendly password.
            /// </summary>
            /// <returns></returns>
            private string GenerateHumanFriendlyPassword()
            {
                string[] passwordRoots = { "Pennsylvania", "Missouri", "Kansas", "Washington", "Alabama",
            "California", "Portland", "Texas", "Nebraska", "Wisconsin" };

                Random r = new Random(DateTime.Now.Millisecond);
                int random = r.Next(10, 1000);
                int root = random % 10;
                return passwordRoots[root] + random.ToString();
            }





        }

        /// <summary>
        /// IFormsAuthenticationService Interface
        /// </summary>
        public interface IFormsAuthenticationService
        {
            /// <summary>
            /// Signs the in.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="createPersistentCookie">if set to <c>true</c> [create persistent cookie].</param>
            void SignIn(string userName, bool createPersistentCookie);
            /// <summary>
            /// Signs the out.
            /// </summary>
            void SignOut();
        }

        /// <summary>
        /// FormsAuthenticationService
        /// </summary>
        public class FormsAuthenticationService : IFormsAuthenticationService
        {
            /// <summary>
            /// Signs the in.
            /// </summary>
            /// <param name="userName">Name of the user.</param>
            /// <param name="createPersistentCookie">if set to <c>true</c> [create persistent cookie].</param>
            /// <exception cref="System.ArgumentException">Value cannot be null or empty.;userName</exception>
            public void SignIn(string userName, bool createPersistentCookie)
            {
                if (String.IsNullOrEmpty(userName)) throw new ArgumentException("Value cannot be null or empty.", "userName");

                FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            }

            /// <summary>
            /// Signs the out.
            /// </summary>
            public void SignOut()
            {
                FormsAuthentication.SignOut();
            }
        }
        #endregion
    }
}
