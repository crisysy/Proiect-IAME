using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proiect_IAME.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Descriere proiect";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pagina de contact.";

            return View();
        }
    }
}