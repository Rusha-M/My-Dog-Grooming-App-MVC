using MyDogGroomingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyDogGroomingApp.Controllers
{
    public class ServiceController : Controller
    {
        private static List<Service> services
             = new List<Service>() { new Service {Code = "001", Description = "Wash and Dry", Price  = 30 },
                                 new Service {Code = "002", Description = "Dry Cut", Price  = 40 },
                                 new Service {Code = "003", Description = "Wash, Cut and Dry", Price  = 50 },
                                 new Service {Code = "101", Description = "Nail Trim", Price  = 5 },
                                 new Service {Code = "102", Description = "Anal Glands", Price  = 5 },
                                 new Service {Code = "103", Description = "Tick Removal", Price  = 5 },
                                 new Service {Code = "104", Description = "MediBath", Price  = 5 },

         };
        // empty cart
        private static Cart cart = new Cart();

        // GET: Services
        // Total price for all services added to cart
        public ActionResult Index_O()
        {
            ViewBag.TotalPrice = cart.CalculateTotalPrice();
            return View(services);
        }


        // add to cart
        public ActionResult Add(string code)
        {
            try
            {
                foreach (var service in services)
                {
                    if (service.Code == code)
                       
                    {
                        cart.AddService(service);
                        break;
                    }
                }
                return RedirectToAction("Index_O");
            }
            catch
            {
                return View();
            }
        }

        ////delete item from the cart
        public ActionResult Remove(string code)
        {
            try
            {
                foreach (var service in services)
                {
                    if (service.Code == code)
                    {
                        cart.RemoveService(service);
                        break;
                    }
                }
                return RedirectToAction("Index_O");
            }
            catch
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Calculate()
        {
            ViewBag.DiscountType = new SelectList(Service.DicountTypes);
            return View();
        }
        [HttpPost]
        public ActionResult Calculate(Service service)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("CalculateConfirm", service);
            }
            else
            {
                return View();
            }
        }

         // process data
        public ActionResult CalculateConfirm(Service service)
        {
            ViewBag.DiscountType = new SelectList(Service.DicountTypes);
            return View(service);
        }

     
    }
}
    
