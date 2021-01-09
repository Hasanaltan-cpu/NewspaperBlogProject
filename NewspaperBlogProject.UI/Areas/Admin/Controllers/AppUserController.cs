using NewspaperBlogProject.DataAccessLayer.Repositories.Concrete.EfRepositories;
using NewspaperBlogProject.EntityLayer.Entities.Concrete;
using NewspaperBlogProject.UI.Areas.Admin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewspaperBlogProject.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {

        private EfAppUserRepository _repo;
        public AppUserController() => _repo = new EfAppUserRepository();


        [HttpGet]
        public ActionResult Create()
        {
           return  View();

        }
        // GET: Admin/AppUser

        [HttpPost]
        public ActionResult Create(AppUser data)
        {
            {
                      
                _repo.Add(data);
                return Redirect("/Admin/AppUser/List");
            }
        }

        public ActionResult List() => View(_repo.GetActive());

        public ActionResult Update(int id)
        {
            AppUser appUser = _repo.GetById(id);
            AppUserDTO model = new AppUserDTO();
            model.Id = appUser.Id;
            model.FirstName = appUser.FirstName;
            model.LastName = appUser.LastName;
            model.UserName = appUser.UserName;
            model.Password = appUser.Password;
            model.Role = appUser.Role;
            model.UserImage = appUser.UserImage;
            model.XSmallUserImage = appUser.XSmallUserImage;
            model.CruptedUserImage = appUser.CruptedUserImage;
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AppUserDTO model)
        {
            AppUser appUser = _repo.GetById(model.Id);
            appUser.FirstName = model.FirstName;
            appUser.LastName = model.LastName;
            appUser.UserName = model.UserName;
            appUser.Password = model.Password;
            appUser.Role = model.Role;
            _repo.Update(appUser);
            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult Delete(int id)
        {
            _repo.Remove(id);
            return Redirect("/Admin/AppUser/List");
        }

    }
}