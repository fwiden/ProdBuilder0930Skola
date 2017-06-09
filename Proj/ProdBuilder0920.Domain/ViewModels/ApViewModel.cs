using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ProdBuilder0920.Domain.ViewModels
{
    public class ApViewModel
    {
        [Required]
        [Key]
        public int PartId { get; set; }

        [Required]
        public string PartManufacturer { get; set; }

        [Required]
        public string PartModelName { get; set; }

        [Required]
        [HiddenInput]
        public int PartTypeId { get; set; }
        
        [Required]
        public string PartProductionCode { get; set; }

        [Required, MaxLength(255)]
        public string PartDescription { get; set; }

        [Required]
        public int PartPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime PartDeliverytime { get; set; }

        public string PartImageUrl { get; set; }

    }
}
