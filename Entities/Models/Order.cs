using System.Collections.Generic;


namespace Entities.Models
{
    public class Order : BaseEntity
    {
        public int ShippedAddress { get; set; }
        public int AppUserId { get; set; }
        public int ShipperId { get; set; }

        public AppUser AppUser { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public Shipper Shipper { get; set; }

    }
}
