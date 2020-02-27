using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class ProfileController : Controller
    {
        UnitOfWork unitOfWork;
        public ProfileController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult Index()
        {
            ViewBag.Genders = new string[] { "Мужской", "Женский" };
            ViewBag.Languages = new string[] { "English", "Українська", "Русский", "Deutsch", "Other" };
            return View();
        }
        [HttpGet]
        public ActionResult ProfileResult()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProfileResult(User user, List<string> languages)
            {
            if (languages==null)
            {
                languages = new List<string>();
            }
            user.Languages = languages;
            if (ModelState.IsValid)
            {
                unitOfWork.Roles.Create(user);
                unitOfWork.Save();
                return View(user);
            }
                return View("Index");
        }
    }
}