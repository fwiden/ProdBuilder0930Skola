using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCar.Domain.Models
{
    public class PackageSeries
    {
        [Required, Key]
        public string PackageSeriesId { get; set; }

        public string PackageSeriesName { get; set; }

       
    }
}
