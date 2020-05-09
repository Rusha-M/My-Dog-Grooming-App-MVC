using MyDogGroomingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDogGroomingApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About(Client client)
        {
            ViewBag.Message = "Your Application descripton page";
            return View();
        }

        public ActionResult Contact(Client client)
        {
            ViewBag.Message = "Your Contact Page";
            return View();
        }
    }
}