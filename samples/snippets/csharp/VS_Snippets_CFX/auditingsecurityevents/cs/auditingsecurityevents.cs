
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace="http://Microsoft.ServiceModel.Samples")]
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

    // Service class that implements the service contract.
    // Added code to write output to the console window.
    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine($"Received Add({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine($"Received Subtract({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine($"Received Multiply({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine($"Received Divide({n1},{n2})");
            Console.WriteLine($"Return: {result}");
            return result;
        }

        // Host the service within this EXE console application.
        //<snippet1>
        public static void Main()
        {
            // Get base address from appsettings in configuration.
            Uri baseAddress = new Uri(ConfigurationManager.
                AppSettings["baseAddress"]);

            // Create a ServiceHost for the CalculatorService type
            // and provide the base address.
            using (ServiceHost serviceHost = new
                ServiceHost(typeof(CalculatorService), baseAddress))
            {
                //<snippet4>
                //<snippet3>
                //<snippet2>
                // Create a new auditing behavior and set the log location.
                ServiceSecurityAuditBehavior newAudit =
                    new ServiceSecurityAuditBehavior();
                newAudit.AuditLogLocation =
                    AuditLogLocation.Application;
                //</snippet2>
                newAudit.MessageAuthenticationAuditLevel =
                    AuditLevel.SuccessOrFailure;
                newAudit.ServiceAuthorizationAuditLevel =
                    AuditLevel.SuccessOrFailure;
                //</snippet3>
                newAudit.SuppressAuditFailure = false;
                //</snippet4>
                //<snippet5>
                // Remove the old behavior and add the new.
                serviceHost.Description.
                    Behaviors.Remove<ServiceSecurityAuditBehavior>();
                serviceHost.Description.Behaviors.Add(newAudit);
                //</snippet5>
                // Open the ServiceHostBase to create listeners
                // and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }
        //</snippet1>
    }
}
