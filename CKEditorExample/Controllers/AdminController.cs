using System;
using System.Web.Mvc;
using CKEditorExample.Core.Security.Attributes;

namespace CKEditorExample.Controllers
{
    public class AdminController : Controller
    {
        [AdminOnly]
        public ActionResult Index()
        {
            return View();
        }
    }
}
