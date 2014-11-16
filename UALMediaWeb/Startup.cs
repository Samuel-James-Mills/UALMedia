using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UALMedia.Startup))]
namespace UALMedia
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
