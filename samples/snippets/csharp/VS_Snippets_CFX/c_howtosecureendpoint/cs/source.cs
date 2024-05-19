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
            //<snippet0>
            WSHttpBinding myBinding = new WSHttpBinding();
            myBinding.Security.Mode = SecurityMode.Message;
            myBinding.Security.Message.ClientCredentialType =
                MessageCredentialType.Windows;

            // Create the Type instances for later use and the URI for
            // the base address.
            Type contractType = typeof(ICalculator);
            Type serviceType = typeof(Calculator);
            Uri baseAddress = new
                Uri("http://localhost:8037/serviceModelSamples/");

            // Create the ServiceHost and add an endpoint.
            ServiceHost myServiceHost =
                new ServiceHost(serviceType, baseAddress);
            myServiceHost.AddServiceEndpoint
                (contractType, myBinding, "secureCalculator");
            //<snippet1>
            // Create a new metadata behavior object and set its properties to
            // create a secure endpoint.
            ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
            sb.HttpsGetEnabled = true;
            sb.HttpsGetUrl = new Uri("https://myMachineName:8036/myEndpoint");
            myServiceHost.Description.Behaviors.Add(sb);

            myServiceHost.Open();
            //</snippet1>
            // Use the GetHostEntry method to return the actual machine name.
            string machineName = System.Net.Dns.GetHostEntry("").HostName ;
            Console.WriteLine("Listening @ {0}:8037/serviceModelSamples/", machineName);
            Console.WriteLine("Press Enter to close the service");
            Console.ReadLine();
            myServiceHost.Close();
            //</snippet0>
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
