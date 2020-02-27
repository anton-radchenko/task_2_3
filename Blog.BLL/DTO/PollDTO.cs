using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.BLL.DTO
{
    public class PollDTO
    {
        public int PollId { get; set; }
        public string Title { get; set; }
       // public List<AnswerDTO> Answers {get;set;}
        public List<Answer> Answers { get; set; }
    }
    
}
