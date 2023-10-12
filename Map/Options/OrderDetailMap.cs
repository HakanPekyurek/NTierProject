using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class OrderDetailMap : BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            Ignore(h => h.Id);
            HasKey(h => new
            {
                h.OrderId,
                h.ProductId
            }); 
        }
    }
}
