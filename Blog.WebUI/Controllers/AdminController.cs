using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Blog.Domain.Entities;
using Blog.WebUI.Models;

namespace Blog.WebUI.Controllers
{
    public class AdminController : Controller
    {
        IArticleService articleService;

        public AdminController(IArticleService _articleService)
        {
            articleService = _articleService;
        }
        public ActionResult Index()
        {
            var tagList = articleService.FindKeywords().ToList();
            var articleList = articleService.FindArticles().ToList();
            AdminViewModel model = new AdminViewModel() { Keywords = tagList, Articles =articleList };
            return View(model);
        }

        public ActionResult AddArticle(AdminViewModel model)
        {
            List<Keyword> keywords = new List<Keyword>();
            if (model.KeywordsList != null)
            {
                foreach (var item in model.KeywordsList)
                {
                    try
                    {
                        keywords.Add(articleService.FindKeyword(Convert.ToInt32(item)));
                    }
                    catch (Exception)
                    {
                        return HttpNotFound();
                    }

                }
                model.articleDTO.Keywords = keywords;
            }
            articleService.AddArticle(model.articleDTO);
            articleService.Save();
            return RedirectToAction("Index");
        }
        public ActionResult AddTag(Keyword keyword)
        {
            articleService.AddKeyword(keyword);
            articleService.Save();

            return RedirectToAction("Index");
        }
        public ActionResult DeleteArticle(AdminViewModel model)
        {
            foreach (var articleId in model.ArticleList)
            {
                articleService.DeleteArticle(Convert.ToInt32(articleId));
            }
            articleService.Save();
            return RedirectToAction("Index");
        }
        //public ActionResult EditArticleForm(AdminViewModel model)
        //{
        //    var article = articleService.FindArticle(model.articleDTO.ArticleId);
        //    return View(article);
        //}
        //public ActionResult EditArticle(ArticleDTO articleDTO)
        //{
        //    articleService.EditArticle(articleDTO);
        //    articleService.Save();
        //    return RedirectToAction("Index");
        //}

    }
}