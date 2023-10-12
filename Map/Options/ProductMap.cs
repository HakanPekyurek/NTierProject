﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class ProductMap : BaseMap<Product>
    {
        public ProductMap()
        {
            Property(h => h.UnitPrice).HasColumnType("money");
        }
    }
}
