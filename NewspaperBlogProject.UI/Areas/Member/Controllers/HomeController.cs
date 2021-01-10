using NewspaperBlogProject.DataAccessLayer.Repositories.Concrete.EfRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewspaperBlogProject.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {
        EfPostRepository _postRepository;

        public HomeController() => _postRepository = new EfPostRepository();

        // GET: Member/Home
        public ActionResult Index()
        {
            return View(_postRepository.GetActive().OrderByDescending(x => x.CreateDate));
        }
    }
}