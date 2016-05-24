using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace WeatherMicroservice
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                var latString = context.Request.Query["lat"].FirstOrDefault();
                var longString = context.Request.Query["long"].FirstOrDefault();

                var latitude = latString.TryParse();
                var longitude = longString.TryParse();

                if (latitude.HasValue && longitude.HasValue)
                {
                    var forecast = new List<WeatherReport>();
                    for (var days = 1; days < 6; days++)
                    {
                        forecast.Add(new WeatherReport(latitude.Value, longitude.Value, days));
                    }

                    var json = JsonConvert.SerializeObject(forecast, Formatting.Indented);
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync(json);
                }
                else
                {
                    await context.Response.WriteAsync($"Retrieving Weather for lat: {latitude}, long: {longitude}");
                }
            });
        }

        // Entry point for the application.

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder() 
                .UseKestrel() 
                .UseIISIntegration() 
                .UseStartup<Startup>() 
                .UseUrls("http://0.0.0.0:80")
                .Build(); 
 
           host.Run(); 
            
        } 
    }
}
