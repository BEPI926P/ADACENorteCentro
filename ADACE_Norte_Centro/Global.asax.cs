using System.Web;
using System.Web.Http;

namespace ADACE_Norte_Centro
{
    public class Global : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
