using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NguyenDucHuy_Bigschool.Startup))]
namespace NguyenDucHuy_Bigschool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
