using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.Domain.Concrete
{
    public class ArticleRepository : IRepository<Article>
    {
        private BlogContext db;

        public ArticleRepository(BlogContext context)
        {
            db = context;
        }

        public void Create(Article item)
        {
            item.Date = DateTime.Now;
            db.Articles.Add(item);
        }

        public void Delete(int id)
        {
            Article item = db.Articles.Find(id);
            if (item != null)
                db.Articles.Remove(item);
        }

        public Article Find(int id)
        {
            return db.Articles.Find(id);
        }

        public IEnumerable<Article> FindAll()
        {
            return db.Articles.Include(x => x.Keywords).Where(a=>a.IsDeleted==false);
        }

        public List<Article> FindByKeyword(int keywordId)
        {
            var articles = db.Articles.ToList();
            List<Article> res = new List<Article>();
            foreach (var article in articles)
            {
                foreach (var keyword in article.Keywords)
                {
                    if (keyword.KeywordId==keywordId)
                    {
                        res.Add(article);
                        break;
                    }
                }
            }
            return res;
            #region
            //List<Article> articles = db.Articles.Include(x => x.Keywords).ToList();
            //var temp = db.Articles.SelectMany(a => a.Keywords, (a, k) => new { Article = a, Keyword = k });

            //var temp1 = db.Articles.SelectMany(a => a.Keywords.Where(k=>k.KeywordId == keywordId), (a, k) => new { Article = a, Keyword = k }).ToList();

            //var tamp1list = temp1.ToList();

            //var qwerwr = temp.ToList();

            //var result = from a in db.Articles
            //             from k in a.Keywords where k.KeywordId == keywordId select k;
            //var qwer = result.ToList();

            #endregion
        }

        public void Update(Article item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void SoftDelete(int id)
        {
            Article item = db.Articles.Find(id);
            if (item != null)
                item.IsDeleted = true;
            Update(item);
        }
    }
}
