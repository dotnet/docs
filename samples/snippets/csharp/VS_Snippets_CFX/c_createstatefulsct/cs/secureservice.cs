using System;
using System.Collections;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
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
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the Type instances for later use and the Uri for
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
            SecurityBindingElement security = SecurityBindingElement.CreateMutualCertificateBindingElement();

            // Use a secure session and specify that stateful SecurityContextToken security tokens are used.
            security = SecurityBindingElement.CreateSecureConversationBindingElement(security, false);

            // Specify whether derived keys are needed.
            security.SetKeyDerivation(true);

            // Create the custom binding.
            CustomBinding myBinding = new CustomBinding(security, new HttpTransportBindingElement());

            // Create the Type instances for later use and the Uri for
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
