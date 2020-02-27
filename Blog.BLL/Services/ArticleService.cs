using Blog.BLL.Abstract;
using Blog.BLL.DTO;
using System;
using System.Collections.Generic;
using Blog.Domain.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Blog.Domain.Entities;
using Blog.BLL.Infrastructure;

namespace Blog.BLL.Services
{
    public class ArticleService : IArticleService
    {
        IUnitOfWork Database { get; set; }
        IMapper mapperArticle = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();

        public ArticleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void AddArticle(ArticleDTO articleDTO)
        {
            if (articleDTO.Name == null)
            {
                throw new ValidationException("Article name is empty", "");
            }
            if (articleDTO.Text == null)
            {
                throw new ValidationException("Article text is empty", "");
            }
            Article article = new Article { Name = articleDTO.Name, Date = articleDTO.Date, Text = articleDTO.Text, Keywords = articleDTO.Keywords };
            Database.Articles.Create(article);
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public ArticleDTO FindArticle(int? id)
        {
            if (id == null)
                throw new ValidationException("Article id not set", "");
            var article = Database.Articles.Find(id.Value);
            if (article == null)
                throw new ValidationException("Article not found", "");

            return new ArticleDTO { Name = article.Name, ArticleId = article.ArticleId, Date = article.Date, Text = article.Text, Keywords = article.Keywords.ToList() };
        }

        public IEnumerable<ArticleDTO> FindArticles()
        {
            //var mapperArticle = new MapperConfiguration(cfg => cfg.CreateMap<Article, ArticleDTO>()).CreateMapper();
            return mapperArticle.Map<IEnumerable<Article>, List<ArticleDTO>>(Database.Articles.FindAll());
        }

        public IEnumerable<Keyword> FindKeywords()
        {
            return Database.Keywords.FindAll();
        }
        public void Save()
        {
            Database.Save();
        }

        public Keyword FindKeyword(int? id)
        {
            if (id == null)
                throw new ValidationException("Keyword id not set", "");
            var keyword = Database.Keywords.Find(id.Value);
            if (keyword == null)
                throw new ValidationException("Keyword not found", "");
            return keyword;
        }

        public List<ArticleDTO> FindArticles(int keywordId)
        {
            var articles = Database.Articles.FindByKeyword(keywordId).Where(a => a.IsDeleted == false);

            return mapperArticle.Map<IEnumerable<Article>, List<ArticleDTO>>(articles);
        }

        public void AddKeyword(Keyword keyword)
        {
            Database.Keywords.Create(keyword);
        }

        public void DeleteArticle(int articleId)
        {
            Database.Articles.SoftDelete(articleId);
        }

        public void EditArticle(ArticleDTO articleDTO)
        {
            var mapperArticle = new MapperConfiguration(cfg => cfg.CreateMap<ArticleDTO, Article>()).CreateMapper();
            var art = mapperArticle.Map<ArticleDTO, Article>(articleDTO);
            Database.Articles.Update(art);
        }
    }
}
