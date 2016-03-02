using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TheGreatQuiz.Startup))]
namespace TheGreatQuiz
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
