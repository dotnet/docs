using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

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
            //<snippet3>
            //<snippet4>
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            //</snippet3>
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;
            //</snippet4>

            // Create the Type instances for later use and the URI for
            // the base address.
            Type contractType = typeof(ICalculator);
            Type serviceType = typeof(Calculator);
            Uri baseAddress = new
                Uri("http://localhost:8036/serviceModelSamples/");

            // Create the ServiceHost and add an endpoint, then start
            // the service.
            ServiceHost myServiceHost =
                new ServiceHost(serviceType, baseAddress);
            myServiceHost.AddServiceEndpoint
                (contractType, myBinding, "secureCalculator");
            myServiceHost.Open();
            //</snippet1>
            Console.WriteLine("Listening");
            Console.WriteLine("Press Enter to close the service");
            Console.ReadLine();
            myServiceHost.Close();
        }
        private void Run2()
        {
            //<snippet2>
            //<snippet7>
            //<snippet6>
            //<snippet5>
            SecurityBindingElement security = SecurityBindingElement.CreateMutualCertificateBindingElement();
            //</snippet5>

            // Use a secure session.
            security = SecurityBindingElement.CreateSecureConversationBindingElement(security, true);
            //</snippet6>

            // Specify whether derived keys are required.
            security.SetKeyDerivation(true);
            //</snippet7>

            // Create the custom binding.
            CustomBinding myBinding = new CustomBinding(security, new HttpTransportBindingElement());

            // Create the Type instances for later use and the URI for
            // the base address.
            Type contractType = typeof(ICalculator);
            Type serviceType = typeof(Calculator);
            Uri baseAddress = new
                Uri("http://localhost:8036/serviceModelSamples/");

            // Create the ServiceHost and add an endpoint, then start
            // the service.
            ServiceHost myServiceHost =
                new ServiceHost(serviceType, baseAddress);
            myServiceHost.AddServiceEndpoint
                (contractType, myBinding, "secureCalculator");
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
