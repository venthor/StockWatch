using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;

namespace StockWatch
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<StockWatch.Services.ILog, StockWatch.Components.Logging.NLogger>();
            container.RegisterType<StockWatch.Services.IModelContext, StockWatch.Data.ModelContext>();
            container.RegisterType<StockWatch.Services.ModelService, StockWatch.Services.ModelService>();
            //container.RegisterType<StockWatch.Services.UserService, StockWatch.Services.UserService>();

            return container;
        }
    }
}