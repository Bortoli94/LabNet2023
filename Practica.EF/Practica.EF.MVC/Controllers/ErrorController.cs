using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ViewError(string message, string value)
        {
            ViewBag.Message = message;
            ViewBag.Value = value;
            return View();
        }
    }
}