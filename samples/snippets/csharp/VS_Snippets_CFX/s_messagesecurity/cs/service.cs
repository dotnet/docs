using System;
using System.Configuration;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    interface ICalculator
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

    class CalculatorService : ICalculator
    {

        public double Add(double n1, double n2)
        {
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            double result = n1 + n2;
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            double result = n1 - n2;
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            double result = n1 * n2;
            return result;
        }

        public double Divide(double n1, double n2)
        {
            Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name);
            double result = n1 / n2;
            return result;
        }

        // <Snippet1>
        static void Main()
        {
            // Get base address from appsettings in configuration.
            Uri baseAddress = new Uri("http://localhost:8000/servicemodelsamples/service");

            // Create a ServiceHost for the CalculatorService type and provide the base address.
            using (ServiceHost serviceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
            {
                //Open the ServiceHostBase to create listeners and start listening for messages.
                serviceHost.Open();

                // The service can now be accessed.
                Console.WriteLine("Service started at {0}", serviceHost.BaseAddresses[0]);
                Console.WriteLine("Press ENTER to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                serviceHost.Close();
            }
        }
        // </Snippet1>
    }
}
