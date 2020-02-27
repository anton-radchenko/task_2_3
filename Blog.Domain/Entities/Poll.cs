using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Blog.Domain.Entities
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Title { get; set; }
        public  ICollection<Answer> Answers {get;set;}
        public bool IsDeleted { get; set; }
        public Poll()
        {
            Answers = new List<Answer>();
        }
        public int GetTotalVotes()
        {
            int result = 0;
            foreach (var item in Answers)
            {
                result += item.Amount;
            }
            return result;
        }
    }
}
