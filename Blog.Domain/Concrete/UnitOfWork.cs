using Blog.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private BlogContext db = new BlogContext();
        private ArticleRepository articleRepository;
        private KeywordRepository keywordRepository;
        private ReviewRepository reviewrRepository;
        private RoleRepository roleRepository;
        private PollRepository pollRepository;
        private AnswerRepository answerRepository;
        private bool disposed = false;

        public ArticleRepository Articles
        {
            get
            {
                if (articleRepository == null)
                    articleRepository = new ArticleRepository(db);
                return articleRepository;
            }
        }

        public ReviewRepository Reviews
        {
            get
            {
                if (reviewrRepository == null)
                    reviewrRepository = new ReviewRepository(db);
                return reviewrRepository;
            }
        }

        public AnswerRepository Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(db);
                return answerRepository;
            }
        }

        public RoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;

            }
        }

        public PollRepository Polls
        {
            get
            {
                if (pollRepository == null)
                    pollRepository = new PollRepository(db);
                return pollRepository;

            }
        }

        public KeywordRepository Keywords
        {
            get
            {
                if (keywordRepository == null)
                    keywordRepository = new KeywordRepository(db);
                return keywordRepository;

            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
