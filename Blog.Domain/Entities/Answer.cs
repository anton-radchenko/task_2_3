using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public int Amount { get; set; }
        public int? PollId { get; set; }
        public virtual Poll Poll { get; set; }
        public bool IsDeleted { get; set; }
        public void AddVote()
        {
            Amount++;
        }
    }
}
