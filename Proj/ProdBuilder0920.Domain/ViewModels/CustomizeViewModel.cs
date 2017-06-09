using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdBuilder0920.Domain.ViewModels
{
    public class CustomizeViewModel
    {
        public CustomizeViewModel()
        {
            Parts=new List<Part>();
        }


        public List<Part> Parts { get; set; }
    }
}
