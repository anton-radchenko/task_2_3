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
    public class RoleRepository : IRepository<Role>
    {
        private BlogContext db;

        public RoleRepository(BlogContext context)
        {
            db = context;
        }

        public void Create(Role item)
        {
            db.Roles.Add(item);
        }

        public void Delete(int id)
        {
            Role item = db.Roles.Find(id);
            if (item != null)
                db.Roles.Remove(item);
        }

        public Role Find(int id)
        {
            return db.Roles.Find(id);
        }

        public IEnumerable<Role> FindAll()
        {
            return db.Roles;
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void SoftDelete(int id)
        {
            Role item = db.Roles.Find(id);
            if (item != null)
                item.IsDeleted = true;
            Update(item);
        }
    }
}
