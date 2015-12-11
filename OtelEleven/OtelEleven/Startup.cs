using Microsoft.Owin;
using Owin;
using OtelEleven.Models;
[assembly: OwinStartupAttribute(typeof(OtelEleven.Startup))]
namespace OtelEleven
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            dbContext db = new dbContext();
            db.Database.CreateIfNotExists();
            ConfigureAuth(app);
        }
    }
}
