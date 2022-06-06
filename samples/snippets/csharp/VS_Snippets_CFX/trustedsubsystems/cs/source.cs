using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Description;
using System.Configuration;

namespace Windows.Communication.Foundation.Samples
{

    public class Test
    {
        private Test() { }
        static void Main()
        {
            Console.WriteLine("Hello");
            Console.ReadLine();
        }

        private class Snippets
        {
            private void Snippet1()
            {
                //<snippet1>
                Uri baseAddress = new Uri("http://localhost:8000/FacadeService");
                using (ServiceHost myServiceHost = new ServiceHost(typeof(CalculatorService), baseAddress))
                {
                    WSHttpBinding binding = new WSHttpBinding();
                    binding.Security.Mode = SecurityMode.Message;
                    binding.Security.Message.ClientCredentialType =
                        MessageCredentialType.UserName;
                    myServiceHost.AddServiceEndpoint(typeof(CalculatorService), binding, string.Empty);
                    myServiceHost.Open();
                    // Wait for calls.
                    myServiceHost.Close();
                }
                //</snippet1>
            }
        }
    }

    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://Microsoft.ServiceModel.Samples")]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Add", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/AddResponse")]
        double Add(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Subtract", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/SubtractResponse")]
        double Subtract(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Multiply", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/MultiplyResponse")]
        double Multiply(double n1, double n2);

        [System.ServiceModel.OperationContractAttribute(Action = "http://Microsoft.ServiceModel.Samples/ICalculator/Divide", ReplyAction = "http://Microsoft.ServiceModel.Samples/ICalculator/DivideResponse")]
        double Divide(double n1, double n2);
    }

    public class CalculatorService : ICalculator
    {
        public double Add(double n1, double n2) { return n1 + n2; }

        public double Subtract(double n1, double n2) { return n1 - n2; }

        public double Divide(double n1, double n2) { return n1 * n2; }

        // <snippet2>
        public double Multiply(double n1, double n2)
        {
            // Create the binding.
            BindingElementCollection bindingElements = new BindingElementCollection();
            bindingElements.Add(SecurityBindingElement.CreateUserNameOverTransportBindingElement());
            bindingElements.Add(new WindowsStreamSecurityBindingElement());
            bindingElements.Add(new TcpTransportBindingElement());
            CustomBinding backendServiceBinding = new CustomBinding(bindingElements);

            // Create the endpoint address.
            EndpointAddress ea = new
                EndpointAddress("http://contoso.com:8001/BackendService");

            // Call the back-end service.
            CalculatorClient client = new CalculatorClient(backendServiceBinding, ea);
            client.ClientCredentials.UserName.UserName = ServiceSecurityContext.Current.PrimaryIdentity.Name;
            double result = client.Multiply(n1, n2);
            client.Close();

            return result;
        }
        // </snippet2>
    }
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class CalculatorClient : System.ServiceModel.ClientBase<Windows.Communication.Foundation.Samples.ICalculator>, Windows.Communication.Foundation.Samples.ICalculator
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

        public double Add(double n1, double n2)
        {
            return base.Channel.Add(n1, n2);
        }

        public double Subtract(double n1, double n2)
        {
            return base.Channel.Subtract(n1, n2);
        }

        public double Multiply(double n1, double n2)
        {
            return base.Channel.Multiply(n1, n2);
        }

        public double Divide(double n1, double n2)
        {
            return base.Channel.Divide(n1, n2);
        }
    }
}
