// <snippet1>
using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

using System.Security.Principal;

using System.ServiceModel;
// </snippet1>
namespace Microsoft.ServiceModel.Samples
{
    // Define a service contract.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
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
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]

    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
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

        // <snippet2>
        // <snippet3>

        public class CustomUserNameValidator : UserNamePasswordValidator
        {
            // </snippet3>
            // <snippet4>
            // This method validates users. It allows in two users, test1 and test2
            // with passwords 1tset and 2tset respectively.
            // This code is for illustration purposes only and
            // must not be used in a production environment because it is not secure.
            public override void Validate(string userName, string password)
            {
                if (null == userName || null == password)
                {
                    throw new ArgumentNullException();
                }

                if (!(userName == "test1" && password == "1tset") && !(userName == "test2" && password == "2tset"))
                {
                    // This throws an informative fault to the client.
                    throw new FaultException("Unknown Username or Incorrect Password");
                    // When you do not want to throw an informative fault to the client,
                    // throw the following exception.
                    // throw new SecurityTokenException("Unknown Username or Incorrect Password");
                }
            }
            // </snippet4>
        }
        // </snippet2>

        // Host the service within this EXE console application.
        public static void Main()
        {
            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService)))
            {
                // Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("The service is running in the following account: {0}", WindowsIdentity.GetCurrent().Name);
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
