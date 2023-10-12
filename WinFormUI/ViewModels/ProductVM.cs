using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormUI.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryId { get; set; }

        public override string ToString()
        {
            return $"{ProductName}, Price => {UnitPrice:C2}, Category => {CategoryName}";
        }
    }
}
