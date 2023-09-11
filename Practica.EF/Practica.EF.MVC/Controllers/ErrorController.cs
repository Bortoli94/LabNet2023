using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practica.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult ViewError(string message)
        {
            ViewBag.Message = message;  
            return View();
        }
    }
}