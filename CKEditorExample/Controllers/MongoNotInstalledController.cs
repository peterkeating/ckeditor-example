using System.Web.Mvc;

namespace CKEditorExample.Controllers
{
    public class MongoNotInstalledController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
