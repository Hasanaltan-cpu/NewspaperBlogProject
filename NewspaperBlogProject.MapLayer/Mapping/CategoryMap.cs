using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperBlogProject.MapLayer.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.Name).IsRequired();


            HasMany(x => x.Posts).WithRequired(x => x.Category).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);

        }
    }
}
