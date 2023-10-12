using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Options
{
    public class CategoryMap : BaseMap<Category>
    {
        //Veritabanına kayıt yaparken güncellemek istediğimiz yerleri burada yapıyoruz.
        public CategoryMap()
        {
            Property(h=>h.CategoryName).HasColumnName("CTName");
        }
    }
}
