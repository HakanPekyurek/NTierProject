using Entities.Models;
using System.Data.Entity.ModelConfiguration;

namespace Map.Options
{
    public abstract class BaseMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        public BaseMap()
        {
            Property(h => h.UpdatedDate).HasColumnName("ModifiedDated");
        }
    }
}
