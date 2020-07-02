using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(RateLimited.Startup))]

namespace RateLimited
{
    public class Startup
    {
        public virtual void Configuration(IAppBuilder app)
        {
    
        }

    }
}
