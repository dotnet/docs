using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CustomProvider.Example
{
    class Program
    {
        static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((_, configuration) =>
                {
                    configuration.Sources.Clear();

                    configuration.AddEntityConfiguration(
                        options => options.UseInMemoryDatabase("InMemoryDb"));

                    foreach ((string key, string value) in
                        configuration.Build().AsEnumerable().Where(t => t.Value is not null))
                    {
                        Console.WriteLine($"{key}={value}");
                    }
                });
        // Sample output:
        //    quote3=You can't stop the signal, Mal.
        //    quote2=I swallowed a bug.
        //    quote1=I aim to misbehave.
    }
}
