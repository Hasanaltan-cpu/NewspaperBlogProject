using NewspaperBlogProject.DataAccessLayer.Repositories.Concrete.EfRepositories;
using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using NewspaperBlogProject.EntityLayer.Enums;
using NewspaperBlogProject.UI.Areas.Admin.Data;
using NewspaperBlogProject.UI.Areas.Admin.Data.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewspaperBlogProject.UI.Areas.Admin.Controllers
{
    public class PostController : Controller
    {

        EfPostRepository _postRepo;
        EfCategoryRepository _categoryRepo;
        EfAppUserRepository _appUserRepo;
        public PostController()
        {
            _postRepo = new EfPostRepository();
            _categoryRepo = new EfCategoryRepository();
            _appUserRepo = new EfAppUserRepository();
        }
        // GET: Admin/Post
        public ActionResult Create()
        {
            AddPostVM model = new AddPostVM()
            {
                Categories = _categoryRepo.GetActive(),
                AppUsers = _appUserRepo.GetDefault(x => x.Role != Role.member)
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Post data)
        {
            _postRepo.Add(data);
            return Redirect("/Admin/Post/List");
        }

        public ActionResult Update(int id)
        {
            Post post = _postRepo.GetById(id);
            UpdatePostVM data = new UpdatePostVM();
            data.PostDTO.Id = post.Id;
            data.PostDTO.Header = post.Header;
            data.PostDTO.Content = post.Content;
            data.PostDTO.ImagePath = post.ImagePath;
            data.Categories = _categoryRepo.GetActive();
            data.AppUsers = _appUserRepo.GetDefault(x => x.Role != Role.member);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(PostDTO data)
        {
            Post post = _postRepo.GetById(data.Id);
            post.Header = data.Header;
            post.Content = data.Content;
            post.CategoryId = data.CategoryId;
            post.AppUserId = data.AppUserId;
            post.Status = Status.Active;
            post.UpdateDate = DateTime.Now;
            _postRepo.Update(post);
            return Redirect("/Admin/Post/List");
        }
        public ActionResult List()
        {
            return View(_postRepo.GetActive());
        }


        public ActionResult Delete(int id)
        {
            _postRepo.Remove(id);
            return Redirect("/Admin/Post/List");
        }

    }
}