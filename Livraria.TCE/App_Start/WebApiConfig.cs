using Livraria.TCE.IoC;
using Livraria.TCE.Repository;
using Livraria.TCE.Repository.Interfaces;
using ProductStore.IoC;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace Livraria.TCE
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            // registrar dependencias
            var container = new UnityContainer();
            RegistroDependencia.RegistrarDependencias(container);
            config.DependencyResolver = new UnityResolver(container);
           
            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
