using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyDogGroomingApp.Models
{
    public class Client
    {
        [Key]
        public Guid ClientID { get; set; }
        [Required]
        [Display(Name ="Customer Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Dog Name")]
        public string DogName { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Appointment Date")]
        public DateTime Date { get; set; }
        public Client()
        {

        }
    }
}