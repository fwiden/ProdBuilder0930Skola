using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProdBuilder0920.web.Models
{
    public class AppUser:IdentityUser
    {
        [Required, StringLength(255)]
        public string FirstName { get; set; }

        [Required, StringLength(255)]
        public string LastName { get; set; }

        [Required, StringLength(255)]
        public string CompanyName { get; set; }

        [Required, StringLength(255)]
        public string DeliveryAdress { get; set; }
    }
}