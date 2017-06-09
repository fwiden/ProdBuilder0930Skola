using System;
using System.ComponentModel.DataAnnotations;

namespace ProdBuilder0920.Domain
{
    public class Part
    {
        public int PartID { get; set; }

        [Required]
        public string PartManufacturer { get; set; }

        [Required]
        public string PartModelName { get; set; }

        [Required]
        public int PartTypeId { get; set; }
       
        public PartType PartType { get; set; }

        [Required]
        public string PartProductionCode { get; set; }

        [Required,MaxLength(100)]
        public string PartDescription { get; set; }

        [Required]
        public int PartPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime PartDeliverytime { get; set; }

        public string PartImageUrl { get; set; }

    }
}
