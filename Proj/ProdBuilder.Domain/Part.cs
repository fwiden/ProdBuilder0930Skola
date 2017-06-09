using System;
using System.ComponentModel.DataAnnotations;

namespace BuildCar.Domain.Models
{
    public class Part
    {
        

        [Required]
        [Key]
        public int PartId  { get; set; }

        [Required]
        public int PartTypeId { get; set; }

        [Required]
        public PartType PartType { get; set; }

        [Required]
        public string PartProductionCode { get; set; }
       

        [Required,MaxLength(100)]
        public string PartDescription { get; set; }

        [Required]
        public int PartPrice { get; set; }

        [Required]
        public DateTime PartDeliverytime { get; set; }

        public string PartImageUrl { get; set; }
       

    }
}
