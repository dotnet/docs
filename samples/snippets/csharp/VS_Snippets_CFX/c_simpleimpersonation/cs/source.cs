using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security.Tokens;
using System.Security.Permissions;
namespace ProxySample
{

    public class Test
    {
        static void Main()
        {
        }

        private void Impersonation()
        {
        }

        private void ClientCode()
        {
            //<snippet1>
            CalculatorClient client = new CalculatorClient("CalculatorEndpoint");
            client.ClientCredentials.Windows.AllowedImpersonationLevel =
                System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //</snippet1>
        }

        public interface ICalculator
        {

            [System.ServiceModel.OperationContractAttribute(ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign, Action = "http://tempuri.org/ICalculator/Add", ReplyAction = "http://tempuri.org/ICalculator/AddResponse")]
            double Add(double n1, double n2);
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
        public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
        {
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
        public class CalculatorClient : System.ServiceModel.ClientBase<ICalculator>, ICalculator
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
        }
    }
}

namespace ClientSample
{
    using System.ServiceModel;

    [ServiceContract]
    interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
    }

    public class Calculator : ICalculator
    {
        //<snippet2>
        [OperationBehavior(Impersonation=ImpersonationOption.Required)]
        public double Add(double a, double b)
        {
            return a + b;
        }
        //</snippet2>
    }
}
