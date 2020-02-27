using Blog.BLL.DTO;
using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.BLL.Abstract
{
    public interface IArticleService
    {
        void AddArticle(ArticleDTO articleDTO);

        ArticleDTO FindArticle(int? id);

        IEnumerable<ArticleDTO> FindArticles();
        List<ArticleDTO> FindArticles(int keywordId);

        IEnumerable<Keyword> FindKeywords();


        Keyword FindKeyword(int? id);
        void AddKeyword(Keyword keyword);
        void DeleteArticle(int articleId);
        void EditArticle(ArticleDTO articleDTO);
        void Dispose();
        void Save();
    }
}
