using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class ArticleDTO
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public List<Keyword> Keywords { get; set; }
        public string PreviewText
        {
            get
            {
                if (Text.Length >=200)
                {
                return Text.Substring(0, 200);
                }
                else
                {
                    return Text;
                }
            }
        }

    }
}
