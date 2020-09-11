using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Console.Example
{
    class Program
    {
        static Task Main(string[] args) =>
            CreateHostBuilder(args).Build().RunAsync();

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args);
    }
    // Sample output:
    //   info: Microsoft.Hosting.Lifetime[0]
    //       Application started.Press Ctrl+C to shut down.
    //   info: Microsoft.Hosting.Lifetime[0]
    //       Hosting environment: Production
    //   info: Microsoft.Hosting.Lifetime[0]
    //       Content root path: .\configuration\bin\Debug\net5.0
}
