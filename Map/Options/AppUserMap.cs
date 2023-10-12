using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            HasOptional(h => h.Profile).WithRequired(h => h.AppUser);
        }
    }
}
