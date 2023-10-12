using System.Collections.Generic;


namespace Entities.Models
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int? CategoryId { get; set; }


        public Category Category { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
