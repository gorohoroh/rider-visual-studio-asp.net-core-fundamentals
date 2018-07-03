using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFoodRider
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
//            if (env.IsDevelopment())
//            {    
//                app.UseDeveloperExceptionPage();
//            }

            app.Use(next =>
            {
                // RDVS: Rider's completion doesn't expect an identifier after the async keyword, so it starts to suggest weird classes,
                // and this is where completion on space hurts: I wanted to type "context" but completion triggered on Space and inserted the unwanted ContextBoundObject  
                return async context =>
                {
                    // RDVS: again bad completion on unresolved symbol: wanted to use undeclared "logger" to add it as parameter later, but got Logger<> completed instead
                    logger.LogInformation("Request incoming");
                    if (context.Request.Path.StartsWithSegments("/mym"))
                    {
                        await context.Response.WriteAsync("Hit!!!");
                        logger.LogInformation("Request handled");
                    }
                    else
                    {
                        await next(context);
                        logger.LogInformation("Response outgoing");
                    }
                };
            });

            app.UseWelcomePage(new WelcomePageOptions()
            {
                Path = "/wp"
            });
            
            app.Run(async (context) =>
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}