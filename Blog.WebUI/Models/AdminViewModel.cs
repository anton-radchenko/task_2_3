using Blog.BLL.DTO;
using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class AdminViewModel
    {
        public ArticleDTO articleDTO { get; set; }
        public List<ArticleDTO> Articles { get; set; }
        public int KeywordId { get; set; }
        public List<Keyword> Keywords{get;set;}
        public Keyword Keyword { get; set; }
        public string[] KeywordsList { get; set; }
        public string[] ArticleList { get; set; }
    }
}