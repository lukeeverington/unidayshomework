using Ninject;
using Ninject.Web.Common.WebHost;
using System.Web.Mvc;
using System.Web.Routing;
using UnidaysHomework.NinjectModules;

namespace UnidaysHomework
{
    public class MvcApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel(new WebModule(), new ServicesModule(), new DataModule(), new PasswordHashingModule());
            return kernel;
        }
    }
}
