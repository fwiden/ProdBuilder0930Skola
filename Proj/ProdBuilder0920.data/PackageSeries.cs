using System.ComponentModel.DataAnnotations;

namespace ProdBuilder0920.data
{
    public class PackageSeries
    {
        [Required, Key]
        public string PackageSeriesId { get; set; }

        public string PackageSeriesName { get; set; }

       
    }
}
