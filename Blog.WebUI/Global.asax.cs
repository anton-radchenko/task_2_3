using Ninject;
using Ninject.Modules;
using System.Web.Mvc;
using Blog.BLL.Infrastructure;
using Blog.WebUI.Util;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Web.Mvc;


namespace Blog.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            NinjectModule blogModule = new BlogModule();
            NinjectModule serviceModule = new ServiceModule();
            var kernel = new StandardKernel(blogModule, serviceModule);
            kernel.Unbind<ModelValidatorProvider>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            
        }
    }
}
