using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Walle_WEB.UI.Interfaces;
using Walle_WEB.UI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

//using Walle_WEB.UI.Data;

namespace Walle_WEB.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddRazorPages();
            //services.AddServerSideBlazor();
            //services.AddHttpClient();

            //services.AddMvc();
            //services.AddRazorPages();
            //services.AddHttpClient();
            //services.AddServerSideBlazor();
            //services.AddSingleton<IPeelerService, PeleerService>();
            
            


            //services.AddHttpClient<IExpenseService, ExpenseService>(
            //   client => { client.BaseAddress = new Uri("https://localhost:44330"); });

            //services.AddMvc().AddNewtonsoftJson();
            services.AddRazorPages();
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });


            // Server Side Blazor doesn't register HttpClient by default
            if (!services.Any(x => x.ServiceType == typeof(HttpClient)))
            {
                // Setup HttpClient for server side in a client side compatible fashion
                services.AddScoped<HttpClient>(s =>
                {
                    // Creating the URI helper needs to wait until the JS Runtime is initialized, so defer it.      
                    var uriHelper = s.GetRequiredService<NavigationManager>();
                    return new HttpClient
                    {
                        BaseAddress = new Uri(uriHelper.BaseUri)
                    };
                });
            }

            services.AddHttpClient<IPeelerService, PeleerService>(
    client => { client.BaseAddress = new Uri("https://localhost:44337"); });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
