//<snippet0>
using System;
using System.Collections;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Security.Samples
{
    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            Console.WriteLine("Starting....");
            t.Run();
        }

        private void Run()
        {
            //<snippet1>
            // First procedure:
            // create a WSHttpBinding that uses Windows credentials and message security
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;
            //</snippet1>

            //<snippet2>
            // 2nd Procedure:
            // Use the binding in a service
            // Create the Type instances for later use and the URI for
            // the base address.
            Type contractType = typeof(ICalculator);
            Type serviceType = typeof(Calculator);
            Uri baseAddress = new
                Uri("http://localhost:8036/SecuritySamples/");

            // Create the ServiceHost and add an endpoint, then start
            // the service.
            ServiceHost myServiceHost =
                new ServiceHost(serviceType, baseAddress);
            myServiceHost.AddServiceEndpoint
                (contractType, myBinding, "secureCalculator");

            //enable metadata
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myServiceHost.Description.Behaviors.Add(smb);

            myServiceHost.Open();
            //</snippet2>
            Console.WriteLine("Listening");
            Console.WriteLine("Press Enter to close the service");
            Console.ReadLine();
            myServiceHost.Close();
        }
    }

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
    }

    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }
}
//</snippet0>
