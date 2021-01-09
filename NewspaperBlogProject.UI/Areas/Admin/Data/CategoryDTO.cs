using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewspaperBlogProject.UI.Areas.Admin.Data
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage="You must to type into category name")]
        public string Name { get; set; }
    }
}