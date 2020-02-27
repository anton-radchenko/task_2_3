using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Models
{
    public class ReviewViewModel
    {
       public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Text { get; set; }

    }
}