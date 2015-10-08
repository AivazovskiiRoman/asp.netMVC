using System.Web.Http;

namespace WebApplication1.App_Start
{
    public class WebApiConfig : ApiController
    {
        // GET api/<controller>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

    }
}