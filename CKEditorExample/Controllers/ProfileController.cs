using System;
using System.Web.Mvc;

namespace CKEditorExample.Controllers
{
    public class ProfileController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}
