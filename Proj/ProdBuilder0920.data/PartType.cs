using System.ComponentModel.DataAnnotations;

namespace ProdBuilder0920.data
{
    public class PartType
    {
        [Required]
        [Key]
        public int PartTypeId { get; set; }

        [Required]
         public string PartTypeName { get; set; }

         //public string PartTypeProdCode { get; set; }

        [Required]
         public int PackageId { get; set; }

    }
}
