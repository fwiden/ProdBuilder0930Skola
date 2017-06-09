using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProdBuilder0920.data
{
    public class Package
    {

        public Package()
        {
            PartTypes= new List<PartType>();
        }
       
        [Required]
        [Key]
        public int  PackageId  { get; set; }

        public string PackageName { get; set; }

        public string PackageDescription { get; set; }
        public int PackageStartPrice { get; set; }

        //public int PackageFinalPrice { get; set; }
       
        public string PackageProductionCode { get; set; }

        public string  ImageUrl { get; set; }

        [Required]
        public List<PartType> PartTypes { get; set; }

        [Required]
        public int PartTypeId { get; set; }

        [Required]
        public PackageSeries PackageSeries { get; set; }

        [Required]
        public int PackageSeriesId { get; set; }




    }
}
