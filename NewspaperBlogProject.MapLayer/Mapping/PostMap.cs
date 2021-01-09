using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperBlogProject.MapLayer.Mapping
{
   public class PostMap : BaseMap<Post>
    {

        public PostMap()
        {
            Property(x => x.Content).IsRequired();
            Property(x => x.Header).IsRequired();

            HasRequired(x => x.Category).WithMany(x => x.Posts).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);


            HasMany(x => x.Comments).WithRequired(x => x.Post).HasForeignKey(x => x.PostId).WillCascadeOnDelete(false);

            HasMany(x => x.Likes).WithRequired(x => x.Post).HasForeignKey(x => x.PostId).WillCascadeOnDelete(false);
        }
    }
}
