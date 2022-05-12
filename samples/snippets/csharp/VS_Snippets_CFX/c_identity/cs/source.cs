using System;
using System.IO;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Security.Permissions;
using System.ServiceModel.Security.Tokens;

namespace IdentityExample
{
    public class Test
    {
        static void Main()
        {
            try
            {
                Test t = new Test();
                t.Run();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
        }

        private void Run()
        {
            Uri baseAddress = new Uri("http://localhost:8088/base");
            Type contract = typeof(Calculator);
            Type iContract = typeof(ICalculator);
            ServiceHost myServiceHost = new ServiceHost(contract, baseAddress);
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            myServiceHost.Description.Behaviors.Add(smb);
            //<snippet5>
            ServiceEndpoint ep = myServiceHost.AddServiceEndpoint(
                            typeof(ICalculator),
                            new WSHttpBinding(),
                            String.Empty);
            EndpointAddress myEndpointAdd = new EndpointAddress(new Uri("http://localhost:8088/calc"),
                 EndpointIdentity.CreateDnsIdentity("contoso.com"));
            ep.Address = myEndpointAdd;
            //</snippet5>
            myServiceHost.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            myServiceHost.Close();
        }

        private void CreateBinding()
        {
            //<snippet8>
            CustomBinding binding = new CustomBinding();
            // The following binding exposes a DNS identity.
            binding.Elements.Add(SecurityBindingElement.
                CreateSecureConversationBindingElement(
                SecurityBindingElement.
                CreateIssuedTokenForSslBindingElement(
                new IssuedSecurityTokenParameters())));

            // The following element requires a UPN or SPN identity.
            binding.Elements.Add(new WindowsStreamSecurityBindingElement());
            binding.Elements.Add(new TcpTransportBindingElement());
            //</snippet8>
        }
    }
    [ServiceContract]
    interface ICalculator
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
