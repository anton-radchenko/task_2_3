using Blog.Domain.Abstract;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Concrete
{
    public class ReviewRepository : IRepository<Review>
    {
        private BlogContext db;

        public ReviewRepository(BlogContext context)
        {
            db = context;
        }

        public void Create(Review item)
        {
            item.Date = DateTime.Now;
            db.Reviews.Add(item);
           
        }

        public void Delete(int id)
        {
            Review item = db.Reviews.Find(id);
            if (item != null)
                db.Reviews.Remove(item);
        }

        public Review Find(int id)
        {
            return db.Reviews.Find(id);
        }

        public IEnumerable<Review> FindAll()
        {
            return db.Reviews;
        }

        public void Update(Review item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void SoftDelete(int id)
        {
            Review item = db.Reviews.Find(id);
            if (item != null)
                item.IsDeleted = true;
            Update(item);
        }
    }
}
