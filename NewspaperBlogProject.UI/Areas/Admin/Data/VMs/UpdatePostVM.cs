using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewspaperBlogProject.UI.Areas.Admin.Data.VMs
{
    public class UpdatePostVM
    {
        public UpdatePostVM()
        {
            AppUsers = new List<AppUser>();
            Categories = new List<Category>();
            PostDTO = new PostDTO();

        }
        public List<AppUser> AppUsers { get; set; }
        public List<Category> Categories { get; set; }

        public PostDTO PostDTO { get; set; }

    }
}