using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdBuilder0920.Domain
{
    public class PackageSeries
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageSeriesId { get; set; }

        [Required]
        public string PackageSeriesName { get; set; }
    }
}
