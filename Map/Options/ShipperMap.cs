using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class ShipperMap : BaseMap<Shipper>
    {
        public ShipperMap()
        {
            Property(h => h.CompanyName).HasColumnName("Name");
        }
    }
}
