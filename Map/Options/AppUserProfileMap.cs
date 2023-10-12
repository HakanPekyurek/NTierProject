using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class AppUserProfileMap : BaseMap<AppUserProfile>
    {
        public AppUserProfileMap()
        {
            Property(h => h.FirstName).HasColumnName("Name");
        }
    }
}
