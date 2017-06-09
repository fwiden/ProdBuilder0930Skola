using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProdBuilder0920.Domain.ViewModels
{
    public class AdminAddPackageViewModel
    {
        public AdminAddPackageViewModel()
        {
            SelectListItems=new List<SelectListItem>();
        }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int PackageID { get; set; }

        [Required]
        public string PackageName { get; set; }

        public string PackageDescription { get; set; }

        [Required]
        public int PackageStartPrice { get; set; }

        [Required]
        public string PackageProductionCode { get; set; }

        public string PackageImageUrl { get; set; }

        public int PackageSeriess {get; set; }

        public List<SelectListItem> SelectListItems { get; set; }

        //[HiddenInput(DisplayValue = false)]
        //public int PackageSeriesId { get; set; }

    }
}