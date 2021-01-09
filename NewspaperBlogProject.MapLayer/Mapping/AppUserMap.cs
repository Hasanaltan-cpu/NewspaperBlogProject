using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewspaperBlogProject.MapLayer.Mapping
{
    public class AppUserMap : BaseMap<AppUser>
    {
        public AppUserMap()
        {
            Property(x => x.FirstName).HasMaxLength(30).IsRequired();
            Property(x => x.LastName).HasMaxLength(30).IsRequired();
            Property(x => x.UserName).HasMaxLength(30).IsRequired();
            Property(X => X.Password).HasMaxLength(30).IsRequired();
            Property(x => x.Role).IsRequired();


            HasMany(x => x.Posts).WithRequired(x => x.AppUser).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);

            HasMany(x => x.Comments).WithRequired(x => x.AppUser).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);

            HasMany(x => x.Likes).WithRequired(x => x.AppUser).HasForeignKey(x => x.AppUserId).WillCascadeOnDelete(false);
        }
    }
}
