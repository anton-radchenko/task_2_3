using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.Domain.Concrete
{
    public class AnswerRepository : IRepository<Answer>
    {
        private BlogContext db;

        public AnswerRepository(BlogContext context)
        {
            db = context;
        }
        public void Create(Answer item)
        {
            db.Answers.Add(item);
        }

        public void Delete(int id)
        {
            Answer item = db.Answers.Find(id);
            if (item != null)
                db.Answers.Remove(item);
        }

        public Answer Find(int id)
        {
            return db.Answers.Find(id);
        }

        public IEnumerable<Answer> FindAll()
        {
            return db.Answers;
        }
        public IEnumerable<Answer> FindByPoll(int? pollId)
        {
            var answers = from a in db.Answers
                          where a.PollId == pollId
                          select a;
            return answers;
        }
        public void Update(Answer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void AddVote(Answer item)
        {
            db.Answers.Find(item.AnswerId).AddVote();
        }

        public void SoftDelete(int id)
        {
            Answer item = db.Answers.Find(id);
            if (item != null)
                item.IsDeleted = true;
            Update(item);
        }
    }
}
