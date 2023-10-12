using Entities.Enums;
using System;

namespace Entities.Models
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
            DataStatus = DataStatus.Inserted;
        }
    }
}
