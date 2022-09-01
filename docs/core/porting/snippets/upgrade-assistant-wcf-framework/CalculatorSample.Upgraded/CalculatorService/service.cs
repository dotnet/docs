//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Threading.Tasks;
using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using CoreWCF.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorSample
{
    // Define a service contract.
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        double Divide(double n1, double n2);
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1}). Return: {2}", n1, n2, result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1}). Return: {2}", n1, n2, result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1}). Return: {2}", n1, n2, result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1}). Return: {2}", n1, n2, result);
            return result;
        }


        // Host the service within console application.
        public static async Task Main()
        {
            var builder = WebApplication.CreateBuilder();

            // Set up port (previously this was done in configuration,
            // but CoreWCF requires it be done in code)
            builder.WebHost.UseNetTcp(8090);
            builder.WebHost.ConfigureKestrel(options =>
            {
                options.ListenAnyIP(8080);
                
            });

            // Add CoreWCF services to the ASP.NET Core app's DI container
            builder.Services.AddServiceModelServices()
                            .AddServiceModelConfigurationManagerFile("wcf.config")
                            .AddServiceModelMetadata()
                            .AddTransient<CalculatorSample.CalculatorService>();

            var app = builder.Build();

            // Enable getting metadata/wsdl
            var serviceMetadataBehavior = app.Services.GetRequiredService<ServiceMetadataBehavior>();
            serviceMetadataBehavior.HttpGetEnabled = true;
            serviceMetadataBehavior.HttpGetUrl = new Uri("http://localhost:8080/CalculatorSample/metadata");

            // Configure CoreWCF endpoints in the ASP.NET Core hosts
            app.UseServiceModel(serviceBuilder =>
            {
                serviceBuilder.AddService<CalculatorSample.CalculatorService>(serviceOptions => 
                {
                    serviceOptions.DebugBehavior.IncludeExceptionDetailInFaults = true;
                });

                serviceBuilder.ConfigureServiceHostBase<CalculatorSample.CalculatorService>(serviceHost =>
                {

                });

            });
            
            await app.StartAsync();
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();
            await app.StopAsync();
        }
    }
}

