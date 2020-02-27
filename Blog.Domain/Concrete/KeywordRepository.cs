using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Blog.Domain.Concrete
{
    public class KeywordRepository : IRepository<Keyword>
    {
        private BlogContext db;

        public KeywordRepository(BlogContext context)
        {
            db = context;
        }
        public void Create(Keyword item)
        {
            db.Keywords.Add(item);
        }

        public void Delete(int id)
        {
            Keyword item = db.Keywords.Find(id);
            if (item != null)
                db.Keywords.Remove(item);
        }

        public Keyword Find(int id)
        {
            return db.Keywords.Find(id);
        }

        public IEnumerable<Keyword> FindAll()
        {
            return db.Keywords;
        }

        public void Update(Keyword item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void SoftDelete(int id)
        {
            Keyword item = db.Keywords.Find(id);
            if (item != null)
                item.IsDeleted = true;
            Update(item);
        }
    }
}
