using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using Blog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.WebUI.Controllers
{
    public class GuestController : Controller
    {
        UnitOfWork unitOfWork;

        public GuestController()
        {
            unitOfWork = new UnitOfWork();
        }
        // GET: Guest
        public ActionResult Index(int page =1)
        {
            int pageSize = 3;
            var reviews = unitOfWork.Reviews.FindAll().ToList();
            List<Review> reviewsPerPages = reviews.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = reviews.Count };
            ReviewListViewModel model = new ReviewListViewModel { PageInfo = pageInfo, Reviews = reviewsPerPages, };

            return View(model);
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Review review)
        {
            unitOfWork.Reviews.Create(review);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }



        
    }
}