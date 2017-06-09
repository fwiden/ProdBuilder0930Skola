using System.Data.Entity.Core.Objects;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using ProdBuilder0920.Service;
using Unity.Mvc5;

namespace ProdBuilder0920.web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IProductServiceRepository, ProductServiceRepository>();
            container.RegisterType<IProductService, ProductService>();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            // e.g. container.RegisterType<ITestService, TestService>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}