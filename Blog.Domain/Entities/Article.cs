using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Keyword> Keywords { get; set; }
        public bool IsDeleted { get; set; }
        

    }
}
