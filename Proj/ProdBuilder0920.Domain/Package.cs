using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProdBuilder0920.Domain
{
    public class Package
    {
        public Package()
        {
            PartTypes= new List<PartType>();
        }
       
        [Required]
        public int  PackageID { get; set; }

        [Required]
        public string PackageName { get; set; }

        [Required]
        public string PackageDescription { get; set; }

        [Required]
        public int PackageStartPrice { get; set; }

        [Required]
        public string PackageProductionCode { get; set; }

        [Required]
        public string  PackageImageUrl { get; set; }

        public PackageSeries PackageSeries { get; set; }

        [Required]
        public int PackageSeriesId { get; set; }

        public List<PartType> PartTypes { get; set; }

    }
}
