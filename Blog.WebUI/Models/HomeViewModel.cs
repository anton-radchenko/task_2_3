using Blog.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class HomeViewModel
    {
        public List<ArticleDTO> Articles { get; set; }
        public PollDTO Poll { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}