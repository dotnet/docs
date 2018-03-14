using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace Samples
{
    public class Test
    {
        static void Main()
        {
            Service s = new Service();
            s.Nego();            
        }
    }

    public class Service
    {
        internal void Nego()
        {
            //<snippet1>
            WSHttpBinding b = new WSHttpBinding();
            // By default, the WSHttpBinding uses Windows authentication 
            // and Message mode.
            b.Security.Message.NegotiateServiceCredential = false;
            //</snippet1>

            //<snippet6>
            Uri httpUri = new Uri("http://localhost:8000/");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpUri);
            sh.Credentials.WindowsAuthentication.AllowAnonymousLogons = true;
            //</snippet6>

            sh.AddServiceEndpoint(typeof(ICalculator), b, "Calculator");
            ServiceMetadataBehavior sb = new ServiceMetadataBehavior();
            sb.HttpGetEnabled = true;
            sb.HttpGetUrl = httpUri;
            sh.Description.Behaviors.Add(sb);
            sh.Open();
            Console.WriteLine("Open");
            Console.ReadLine();
        }
    }

    public class Client
    {
        private void IncorrectReturn()
        {
            //<snippet2>
            CalculatorClient cc = new
                CalculatorClient("WSHttpBinding_ICalculator");            
            cc.ClientCredentials.UserName.UserName = GetUserName(); // wrong!
            cc.ClientCredentials.UserName.Password = GetPassword(); // wrong!
            //</snippet2>
        }

        private void CorrectReturn()
        {
            //<snippet3>
            CalculatorClient cc = new 
                CalculatorClient("WSHttpBinding_ICalculator");
            // This code returns the WindowsClientCredential type.            
            cc.ClientCredentials.Windows.ClientCredential.UserName = GetUserName();
            cc.ClientCredentials.Windows.ClientCredential.Password = GetPassword();
            //</snippet3>
        }

        private void DisallowNTLM()
        {
            //<snippet4>
            CalculatorClient cc = new 
                CalculatorClient("WSHttpBinding_ICalculator");
            cc.ClientCredentials.Windows.AllowNtlm = false;
            //</snippet4>
        }

        private void AnonymousDisabled()
        {
            //<snippet5>
            CalculatorClient cc =
                new CalculatorClient("WSHttpBinding_ICalculator");
            cc.ClientCredentials.Windows.AllowedImpersonationLevel =
            System.Security.Principal.TokenImpersonationLevel.Anonymous;
            //</snippet5>
        }

        private string GetUserName()
        {
            return "blah";
        }

        private string GetPassword()
        {
            return "Blah";
        }
    }

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);

        [OperationContract]
        double Multiply(double a, double b);
    }

    public class Calculator : ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Multiply(double a, double b)
        {
            return a * b;
        }
    }
   

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
    {

        public CalculatorClient()
        {
        }

        public CalculatorClient(string endpointConfigurationName)
            :
                base(endpointConfigurationName)
        {
        }

        public CalculatorClient(string endpointConfigurationName, string remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(endpointConfigurationName, remoteAddress)
        {
        }

        public CalculatorClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress)
            :
                base(binding, remoteAddress)
        {
        }

        public double Add(double a, double b)
        {
            return base.Channel.Add(a, b);
        }

        public double Multiply(double a, double b)
        {
            return base.Channel.Multiply(a, b);
        }
    }

}