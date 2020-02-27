using Blog.Domain.Concrete;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        ArticleRepository Articles { get; }
        KeywordRepository Keywords { get; }
        ReviewRepository Reviews { get; }
        RoleRepository Roles { get; }
        PollRepository Polls { get; }
        AnswerRepository Answers { get; }
        void Save();
    }
}
