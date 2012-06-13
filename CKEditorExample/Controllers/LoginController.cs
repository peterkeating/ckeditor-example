using System;
using System.Web.Mvc;
using CKEditorExample.ViewModels.Login;
using CKEditorExample.Core.Service;
using CKEditorExample.Core.Security;

namespace CKEditorExample.Controllers
{
    public class LoginController : Controller
    {
        private const string LoginFailedFeedback = "Unable to login, have another go.";

        private ISessionAuthentication _sessionAuthentication;
        private IUserService _userService;

        private string ReturnUrl
        {
            get
            {
                return (String.IsNullOrEmpty(Request.QueryString["ReturnUrl"])) ? "/" : Request.QueryString["ReturnUrl"];
            }
        }

        public LoginController(ISessionAuthentication sessionAuthentication, IUserService userService)
        {
            _sessionAuthentication = sessionAuthentication;
            _userService = userService;
        }

        /// <summary>
        /// Gets the view & its data organised for a failed
        /// login, giving feedback to the user.
        /// </summary>
        /// <returns>The login form.</returns>
        private ViewResult FailedLogin(LoginViewModel model)
        {
            ViewData["Feedback"] = LoginFailedFeedback;
            return View(model);
        }

        /// <summary>
        /// Presents the login for to the user.
        /// </summary>
        /// <returns>Login page.</returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Attempts to authenticate credentials.
        /// </summary>
        /// <param name="model">Credentials entered by a user.</param>
        /// <returns>Redirects the user to the home page if successful, 
        /// otherwise they are returned to the login form and given 
        /// failure feedback.</returns>
        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            var user = _userService.ByUsernameAndPassword(model.Username, model.Password);

            if (user == null)
                return FailedLogin(model);

            _sessionAuthentication.Start(user, model.RememberMe);

            return Redirect(ReturnUrl);
        }
    }
}
