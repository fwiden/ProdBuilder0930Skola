using System;
using System.ComponentModel.DataAnnotations;



namespace ProdBuilder0920.data
{
    public class Order
    {
        [Required]
        [Key]
        public int OrderId { get; set; }
        
        public string OrderNr { get; set; }
        
        public int OrderlSum { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        
        public OrderStatus? OrderStatus { get; set; }


        //public  Type { get; set; };

        [Required]
        public int CustomerId { get; set; }

        
        [Required]
        //[Key, ForeignKey("Package")]
        public int PackageId { get; set; }

        [Required]
        public Package Package { get; set; }

    }
}