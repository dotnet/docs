
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.
// <snippet1>
using System;

using System.ServiceModel.Description;
using System.Configuration;
using System.ServiceModel;
using System.Security.Principal;
using System.IdentityModel.Claims; 
using System.IdentityModel.Policy; 
using System.IdentityModel.Tokens; 
using System.IdentityModel.Selectors;
using System.Threading;

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
    // Added code to write output to the console window
    public class CalculatorService : ICalculator
    {
		static void DisplayIdentityInformation()
		{
			Console.WriteLine("\t\tThread Identity            :{0}", WindowsIdentity.GetCurrent().Name);
			Console.WriteLine("\t\tThread Impersonation level :{0}", WindowsIdentity.GetCurrent().ImpersonationLevel);
			Console.WriteLine("\t\thToken                     :{0}", WindowsIdentity.GetCurrent().Token.ToString());
			return;
		}

// <snippet2>
		[OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
			DisplayIdentityInformation();
			return result;
        }
// </snippet2>
        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
			Console.WriteLine("Before impersonating");
			DisplayIdentityInformation();
			using (ServiceSecurityContext.Current.WindowsIdentity.Impersonate())
			{
				// Make a system call in the caller's context and ACLs 
				// on the system resource are enforced in the caller's context. 
				Console.WriteLine("Impersonating the caller imperatively");
				DisplayIdentityInformation();
			}
			Console.WriteLine("After reverting");
			DisplayIdentityInformation();
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }


        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get base address from appsettings in configuration.
            Uri baseAddress = new Uri(ConfigurationManager.AppSettings["baseAddress"]);

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                serviceHost.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseWindowsGroups;
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();
				
                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
				Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }

    }

}
// </snippet1>