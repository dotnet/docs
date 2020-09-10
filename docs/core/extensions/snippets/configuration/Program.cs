using System;
using Microsoft.Extensions.Hosting;

namespace ConfigurationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static void CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
    }
}
