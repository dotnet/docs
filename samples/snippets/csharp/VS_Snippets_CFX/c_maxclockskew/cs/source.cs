using System;
using System.ServiceModel;
using System.Security.Permissions;
//using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
//using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security.Tokens;

namespace Examples
{
    public class Program
    {
        static void Main()
        {
            Program p = new Program();
            p.Run();
        }

        //<snippet1>
        // This method returns a custom binding created from a WSHttpBinding. Alter the method
        // to use the appropriate binding for your service, with the appropriate settings.
        public static Binding CreateCustomBinding(TimeSpan clockSkew)
        {
            WSHttpBinding standardBinding = new WSHttpBinding(SecurityMode.Message, true);
            CustomBinding myCustomBinding = new CustomBinding(standardBinding);
            SymmetricSecurityBindingElement security =
                myCustomBinding.Elements.Find<SymmetricSecurityBindingElement>();
            security.LocalClientSettings.MaxClockSkew = clockSkew;
            security.LocalServiceSettings.MaxClockSkew = clockSkew;
            // Get the System.ServiceModel.Security.Tokens.SecureConversationSecurityTokenParameters
            SecureConversationSecurityTokenParameters secureTokenParams =
                (SecureConversationSecurityTokenParameters)security.ProtectionTokenParameters;
            // From the collection, get the bootstrap element.
            SecurityBindingElement bootstrap = secureTokenParams.BootstrapSecurityBindingElement;
            // Set the MaxClockSkew on the bootstrap element.
            bootstrap.LocalClientSettings.MaxClockSkew = clockSkew;
            bootstrap.LocalServiceSettings.MaxClockSkew = clockSkew;
            return myCustomBinding;
        }

        private void Run()
        {
            // Create a custom binding using the method defined above. The MaxClockSkew is set to 30 minutes.
            Binding customBinding= CreateCustomBinding(TimeSpan.FromMinutes(30));

            // Create a ServiceHost instance, and add a metadata endpoint.
            // NOTE  When using Visual Studio, you must run as administrator.
            Uri baseUri = new Uri("http://localhost:1008/");
            ServiceHost sh = new ServiceHost(typeof(Calculator), baseUri);

            // Optional. Add a metadata endpoint. The method is defined below.
            AddMetadataEndpoint(ref sh);

            // Add an endpoint using the binding, and open the service.
            sh.AddServiceEndpoint(typeof(ICalculator), customBinding, "myCalculator");

            sh.Open();
            Console.WriteLine("Listening...");
            Console.ReadLine();
        }

        private void AddMetadataEndpoint(ref ServiceHost sh)
        {
            Uri mex = new Uri(@"http://localhost:1001/metadata/");
            ServiceMetadataBehavior sm = new ServiceMetadataBehavior();
            sm.HttpGetEnabled = true;
            sm.HttpGetUrl = mex;
            sh.Description.Behaviors.Add(sm);
        }

        //</snippet1>

        private void PrintValue(Binding b)
        {
            BindingElementCollection bec = b.CreateBindingElements();
            SymmetricSecurityBindingElement sbe = (SymmetricSecurityBindingElement)bec.Find<SecurityBindingElement>();
            Console.WriteLine("skew {0}", sbe.LocalServiceSettings.MaxClockSkew.ToString());

            SecureConversationSecurityTokenParameters secureTokenParams =
                (SecureConversationSecurityTokenParameters)sbe.ProtectionTokenParameters;
            SecurityBindingElement bootstrap = secureTokenParams.BootstrapSecurityBindingElement;
            Console.WriteLine("skew 2 {0}", bootstrap.LocalServiceSettings.MaxClockSkew.ToString());
        }
    }

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int a, int b);
    }

    public class Calculator : ICalculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
