using System;
using System.ComponentModel.DataAnnotations;

namespace ProdBuilder0920.Domain
{
    public class Order
    {
        public int OrderID { get; set; }
        
        public string OrderNr { get; set; }
        
        public int OrderlSum { get; set; }

        public DateTime OrderPlaced { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime OrderDeliveryDate { get; set; }
        
        public OrderStatus? OrderStatus { get; set; }

        [Required]
        public string UsernameCustomer { get; set; }
        
        [Required]    //[Key, ForeignKey("Package")]
        public int PackageId { get; set; }
       
        public Package Package { get; set; }
    }
}