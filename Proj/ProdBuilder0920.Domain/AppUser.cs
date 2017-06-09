using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProdBuilder0920.Domain
{
    public class AppUser : IdentityUser
    {
        [Required, StringLength(255)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, StringLength(255)]
        public string LastName { get; set; }

        [Required, StringLength(255)]
        public string CompanyName { get; set; }

        [Required, StringLength(255)]
        public string DeliveryAdress { get; set; }
    }
}