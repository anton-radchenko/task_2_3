using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Blog.Domain.Concrete
{
    public class PollRepository : IRepository<Poll>
    {
        private BlogContext db;

        public PollRepository(BlogContext context)
        {
            db = context;
        }
        public void Create(Poll item)
        {
            db.Polls.Add(item);
        }

        public void Delete(int id)
        {
            Poll item = db.Polls.Find(id);
            if (item != null)
                db.Polls.Remove(item);
        }

        public Poll Find(int id)
        {
            return db.Polls.Find(id);
        }

        public IEnumerable<Poll> FindAll()
        {
            return db.Polls.Include(x => x.Answers);
         
        }

        public void Update(Poll item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public int GetRecordsNumber()
        {
            int number = db.Polls.Count();
            return number;
        }
        public void SoftDelete(int id)
        {
            Poll item = db.Polls.Find(id);
            if (item != null)
                item.IsDeleted = true;
            Update(item);
        }
    }
}
