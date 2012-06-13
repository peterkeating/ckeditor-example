using System;
using System.Web.Mvc;
using CKEditorExample.ViewModels.Content;

namespace CKEditorExample.Controllers
{
    public class ContentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Submit(ContentViewModel model)
        {
            ViewBag.Text = model.Text;
            return View();
        }
    }
}
