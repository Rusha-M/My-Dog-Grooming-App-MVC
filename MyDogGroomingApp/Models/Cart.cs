using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MyDogGroomingApp.Models
{
    public class Cart
    {
        private List<CartService> services;
        public Cart()
        {
            services = new List<CartService>();
        }

        public void AddService(Service service)
        {
            var match = services.FirstOrDefault(i=>i.Code.ToUpper(CultureInfo.CurrentCulture)== service.Code.ToUpper(CultureInfo.CurrentCulture));
            if(match == null)
            {
                services.Add(new CartService() { Code = service.Code, Description = service.Description, Price = service.Price, Quantity = 1 });
            }
            else
            {
                match.Quantity++;
            }
        }
        public void RemoveService(Service service)
        {
            var match = services.FirstOrDefault(i => i.Code.ToUpper(CultureInfo.CurrentCulture) == service.Code.ToUpper(CultureInfo.CurrentCulture));
            if (match == null)
            {
                services.Remove(new CartService() { Code = service.Code, Description = service.Description, Price = service.Price, Quantity = -1 });
            }
            else
            {
                match.Quantity--;
            }
        }
        //public void UpdateService(Service service)
        //{
        //    var match = services.FirstOrDefault(i => i.Code.ToUpper(CultureInfo.CurrentCulture) == service.Code.ToUpper(CultureInfo.CurrentCulture));
        //    if (match == null)
        //    {
        //        services.Add(new CartService() { Code = service.Code, Description = service.Description, Price = service.Price, Quantity = 1 });
        //    }
        //    else
        //    {
        //        match.Quantity++;
        //    }
        //}

        // calculate total price of cart
        public double CalculateTotalPrice()
        {
            return services.Sum(service => service.Price * service.Quantity);
        }

        //add  discount promotion
        public void AddDiscount(Service noofDogs)
        {
            // code is unique
            var match = services.Where(i => i.NoOfDogs == noofDogs.discount);
            if (match != null)
            {
                services.Sum(services => services.Price * services.Quantity);
            }
            else
            {
                services.Sum(services => services.Price * (-services.Price * services.discount)/2);
            }
        }

    }
}