using Blog.BLL.Abstract;
using Blog.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.WebUI.Util
{
    public class BlogModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
            Bind<IPollService>().To<PollService>();
        }
    }
}   