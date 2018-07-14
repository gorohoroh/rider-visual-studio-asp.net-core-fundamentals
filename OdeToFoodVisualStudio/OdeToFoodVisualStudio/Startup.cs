using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFoodVisualStudio.Data;
using OdeToFoodVisualStudio.Services;
using System;

namespace OdeToFoodVisualStudio
{
    public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // RDVS: Rider's completion works better with this generic method as it additionally adds the parentheses; additionally, VS overlaps the completion list inside the generic brackets
            // with with parameter info
            services.AddSingleton<IGreeter, Greeter>(); // singleton scope
            services.AddDbContext<OdeToFoodDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("OdeToFood")));
            services.AddScoped<IRestaurantData, SqlRestaurantData>(); // per-HTTP-request lifeime
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // RDVS: RewriteOptions suggested as FQN in Visual Studio's completion: Scott had to erase the FQN part and import namespace with a quick action
            app.UseRewriter(new RewriteOptions().AddRedirectToHttpsPermanent());
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                // Configuration sources by descending priority: 1. command-line parameter, 2. environment variable, 3. appsettings.json (enables storing dev settings in appsettings.json and overriding them in production wtih environment variables for example)

                // RDVS: doesn't look like there's an action to add a new comment (there are actions to comment/decomment existing code; and to add documentation comment)
                // RDVS: VS create from usage isn't quite on par right now: given the undeclared IGreeter interface in method parameteres and the below line that uses an undeclared method,
                // <strike>1. You must create the interface from usage first, and only then can you create the method - so there's no chaining in Create from Usage;</strike> - same in Rider :(
                // 2. The created symbol doesn't get focus: both when it's created in a separate file and when it's created in the same file
                // 3. Roslyn doesn't infer that the generated method should return a string, not an object

                var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Not found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index/4
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");

        }
    }
   
}
