using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProdBuilder0920.Domain
{
    public class PartType
    {
        public PartType()
        {
            Parts= new List<Part>();
        }
        
        public int PartTypeID { get; set; }

        [Required]
        public string PartTypeName { get; set; }
        
        public Package Package { get; set; }

        public int PackageId { get; set; }

        public string PartTypeImageUrl { get; set; } 
        
        //public string PartTypeProdCode { get; set; }
        public List<Part> Parts { get; set; }

    }
}
