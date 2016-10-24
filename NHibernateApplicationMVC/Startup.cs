using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NHibernateApplicationMVC.Startup))]
namespace NHibernateApplicationMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
