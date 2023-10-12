using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class OrderMap : BaseMap<Order>
    {
        public OrderMap()
        {
            Property(h => h.ShippedAddress).HasColumnName("CustomerAddress");
        }
    }
}
