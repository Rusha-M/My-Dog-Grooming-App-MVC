using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDogGroomingApp.Models
{
    public class Service
    {
        const double DiscountPercentage = 0.25;//% of discount
        public static string[] DicountTypes
        {
            get
            {
                return new string[] { "Discount included", "No discount applied " };
            }
        }
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        public int NoOfDogs { get; set; }
        [Display(Name ="Price (€)")]

        // redundancy type i.e. geographical or redundant
        
        public String promotion { get; set; }
        public double Price { get; set; }
        [Display(Name = " Discount %")]
        public double discount
        {
            get
            {
                double charge = 0;
                if (promotion == "No discount applied")
                {
                    if (NoOfDogs <= 1)
                    {
                        return Price;
                    }
                }
                else if (NoOfDogs > 1)
                {
                    charge = Math.Round(1- Price* DiscountPercentage /2);
                }
                return charge;
            }
        }
        public Service()
        {

        }
    }
    public class CartService : Service
    {
        public int Quantity { get; set; }
    }
}