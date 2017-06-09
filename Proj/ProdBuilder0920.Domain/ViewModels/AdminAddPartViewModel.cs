using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProdBuilder0920.Domain.ViewModels
{
   public class AdminAddPartViewModel
    {
        public AdminAddPartViewModel()
        {
            SelectListItems = new List<SelectListItem>();
        }

        [Required]
        [Key]
        public int PartId { get; set; }

        [Required]
        public string PartManufacturer { get; set; }

        [Required]
        public string PartModelName { get; set; }

        [Required]
        public int PartTypeId { get; set; }

        public PartType PartType { get; set; }

        [Required]
        public string PartProductionCode { get; set; }


        [Required, MaxLength(100)]
        public string PartDescription { get; set; }

        [Required]
        public int PartPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime PartDeliverytime { get; set; }

        public string PartImageUrl { get; set; }

        public List<PartType> PartTypes { get; set; }

        public int PartTypess { get; set; }

        public List<SelectListItem> SelectListItems { get; set; }


    }
}
