using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(TaskTracerApi.Startup))]

namespace TaskTracerApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           // ConfigureAuth(app);

               //+  HttpConfiguration config = new HttpConfiguration();
 
        ConfigureAuth(app);
 
        //WebApiConfig.Register(config);
        //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        //app.UseWebApi(config);

        }
    }
}
