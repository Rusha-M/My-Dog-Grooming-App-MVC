using MyDogGroomingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDogGroomingApp.Controllers
{
    public class ClientRegController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Client client)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Confirm", client);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Confirm(Client client)
        {
            return View(client);
        }
        
    }
}