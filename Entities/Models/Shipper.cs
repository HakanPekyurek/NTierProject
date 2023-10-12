using System.Collections.Generic;

namespace Entities.Models
{
    public class Shipper : BaseEntity
    {
        public string CompanyName { get; set; }

        public List<Order> Orders { get; set; }
    }
}
