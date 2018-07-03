using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFoodVisualStudio
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // RDVS: Rider's completion works better with this generic method as it additionally adds the parentheses; additionally, VS overlaps the completion list inside the generic brackets
            // with with parameter info
            services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            app.Use(next =>
            {
                return async context =>
                {
                    logger.LogInformation("Request incoming");
                    if(context.Request.Path.StartsWithSegments("/mym"))
                    {
                        // RDVS: VS completion breaks down after the await keyword - no longer suggests anything. Workaround: type a sync statement first, then add the "await" keyword
                        // Rider handles this just fine.
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

            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/wp"
            });
            
            app.Run(async (context) =>
            {
                // Configuration sources by descending priority: 1. command-line parameter, 2. environment variable, 3. appsettings.json (enables storing dev settings in appsettings.json and overriding them in production wtih environment variables for example)

                // RDVS: doesn't look like there's an action to add a new comment (there are actions to comment/decomment existing code; and to add documentation comment)
                // RDVS: VS create from usage isn't quite on par right now: given the undeclared IGreeter interface in method parameteres and the below line that uses an undeclared method,
                // <strike>1. You must create the interface from usage first, and only then can you create the method - so there's no chaining in Create from Usage;</strike> - same in Rider :(
                // 2. The created symbol doesn't get focus: both when it's created in a separate file and when it's created in the same file
                // 3. Roslyn doesn't infer that the generated method should return a string, not an object

                var greeting = greeter.GetMessageOfTheDay();

                await context.Response.WriteAsync(greeting);
            });
        }
    }
   
}
