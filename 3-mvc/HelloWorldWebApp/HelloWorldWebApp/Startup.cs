using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloWorldWebApp
{

    // controller will take responsibility for handling some subset of request to the app
    // (usually based upon the URL)
    // if i want a user to be able to access pages like /account/myprofile, /account/browse
    // catalog/purchase, maybe i would have an AccountController and a CatalogControler.

    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // teach asp.net about controllers
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            // here we plug in "middleware" in some order to the request processing pipeline of ASP.NET Core
            // in order, which will have a chance to look at and maybe respond to every incoming HTTP request

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});

            //for every rewuest, just respond with hello world html
            //app.Run(async context =>
            //{
            //    context.Response.StatusCode = 200;
            //    context.Response.ContentType = "text/html";
            //    await context.Response.WriteAsync("<!DOCTYPE html><html><head></head><body>Hello World</body></html>");
            //});

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // c# supports anonomus types like new (prop = "a", prop2 = 1)
                // we can set up multiple routs, each one will give a rule for a certain pattern of URL
                // that can decide what the controller and action are
                endpoints.MapControllerRoute("hello-route", "hello", new { controller = "Hello", action = "Hello1"});
                // for each request, it starts witht he first rout and if that dosent match, it tries each suceding one in order
                // if you pull the controller or action directly from the pattern, you don't need any default for it
                endpoints.MapControllerRoute("default", "{controller}/{action}");
            });

        }
    }
}
