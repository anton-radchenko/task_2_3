using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public int Amount { get; set; }
        public int? PollId { get; set; }

        public void AddVote()
        {
            Amount++;
        }
    }
}
