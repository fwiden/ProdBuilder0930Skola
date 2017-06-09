using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProdBuilder0920.Domain.ViewModels
{
   public class AdminAddParttypwViewModel
    {
       public AdminAddParttypwViewModel()
       {
           SelectListItems=new List<SelectListItem>();
       }
       
        [Required]
        public string PartTypeName { get; set; }

        public List<Package> Packages { get; set; }

       //public string PackageName { get; set; }

        [HiddenInput(DisplayValue= false)]
        public int PackageId { get; set; }

        public string PartTypeImageUrl { get; set; }

        public int Partss { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }

    }
}
