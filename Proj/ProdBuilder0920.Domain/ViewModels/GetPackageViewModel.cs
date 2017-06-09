using System.Collections.Generic;

namespace ProdBuilder0920.Domain.ViewModels
{
    public class GetPackageViewModel
    {
        public GetPackageViewModel()
        {
            Packages = new List<Package>();
            Parts = new List<Part>();
            PartTypes =new List<PartType>();
            PackageSeries= new List<PackageSeries>();

        }

        public List<Package> Packages { get; set; }
        public List<Part> Parts { get; set; }
        public List<PartType> PartTypes { get; set; }
        public List<PackageSeries> PackageSeries { get; set; }
    }
}
