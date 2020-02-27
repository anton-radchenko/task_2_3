using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Keyword
    {
        public int KeywordId { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Please enter tag name!")]
        public string Name { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public bool IsDeleted { get; set; }
    }
}
