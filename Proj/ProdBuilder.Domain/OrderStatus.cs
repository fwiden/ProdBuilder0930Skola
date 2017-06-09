using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildCar.Domain.Models
{
    public enum OrderStatus
    {
            NewOrder = 1,
            UnderConstruction = 2,
            ReadyForDelivery = 3,
            Delivered = 4
        
    }
}
