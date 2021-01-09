using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperBlogProject.MapLayer.Mapping
{
    public class LikeMap : BaseMap<Like>
    {
        public LikeMap()
        {
            HasRequired(x => x.Post).WithMany(x => x.Likes).HasForeignKey(x => x.PostId).WillCascadeOnDelete(false);

            HasRequired(x => x.AppUser).WithMany(x => x.Likes).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
        }

    }
}
