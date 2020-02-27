using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog.WebUI.Models;
using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using Blog.Domain.Entities;

namespace Blog.WebUI.Controllers
{
    public class HomeController : Controller
    {

        static Random random = new Random();
        IArticleService articleService;
        IPollService pollService;

        public HomeController(IArticleService _articleService, IPollService _pollService)
        {
            articleService = _articleService;
            pollService = _pollService;

        }

        public ActionResult Index(int page = 1)
        {
            int pageSize = 3;

            IEnumerable<ArticleDTO> articles = articleService.FindArticles();
            //PollDTO poll = pollService.GetRandomPoll();
            PollDTO poll = pollService.GetRandomPoll();
            PollDTO poll1 = pollService.FindPoll(1);
            IEnumerable<PollDTO> polls = pollService.FindPolls();
            List<ArticleDTO> articlePerPages = articles.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = articles.Count() };
            HomeViewModel model = new HomeViewModel { PageInfo = pageInfo, Articles = articlePerPages.ToList(), Poll = poll };
            return View(model);
        }
        public ActionResult Article(int id)
        {
            ArticleDTO article = new ArticleDTO();
            try
            {
                article = articleService.FindArticle(id);
               
            }
            catch (Exception)
            {
                return HttpNotFound();
            }
            
           
            return View(article);
        }

        [HttpPost]
        public ActionResult Vote(PollDTO poll, string vote)
        {
            var pl = pollService.FindPoll(poll.PollId);
            foreach (var item in pl.Answers)
            {
                if (item.Text == vote)
                {
                    item.AddVote();
                    pollService.UpdateAnswer(item);
                    pollService.Save();
                    break;
                }
            }
            return RedirectToAction("Index");

        }

        public ActionResult FindArticles(int keywordId)
        {
            var articles = articleService.FindArticles(keywordId);
            return View(articles);
        }


    }
}