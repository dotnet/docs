//<snippet0>
using System;
using System.Collections.Generic;
using System.ServiceModel;
//<snippet0>
using System.Security.Permissions;
using System.ServiceModel.Description;
using System.Security.Principal;

namespace Client
{
    class Test
    {
        static void Main(string[] args)
        {
            Test t = new Test();
            t.UnsecuredHttp();
            //t.UnsecuredTcp();

        }

        private void UnsecuredHttp()
        {
            //<snippet1>
            // Create an instance of the BasicHttpBinding. 
            // By default, there is no security.
            BasicHttpBinding myBinding = new BasicHttpBinding();

            // Create the address string, or get it from configuration.
            string httpUri = "http://localhost/Calculator";

            // Create an endpoint address with the address.
            EndpointAddress myEndpoint = new EndpointAddress(httpUri);

            // Create an instance of the WCF client. The client
            // code was generated using the Svcutil.exe tool.
            CalculatorClient cc = new CalculatorClient(myBinding, myEndpoint);
            try
            {
                cc.Open();
                // Begin using the calculator.
                Console.WriteLine(cc.Divide(100, 2));

                // Close the client.
                cc.Close();
            }
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }
            //</snippet1>
        }
        private void UnsecuredTcp()
        {
            //<snippet2>
            // Create an instance of the NetTcpBinding and set the
            // security mode to none.
            NetTcpBinding myBinding = new NetTcpBinding();
            myBinding.Security.Mode = SecurityMode.None;

            // Create the address string, or get it from configuration.
            string tcpUri = "net.tcp://machineName:8008/Calculator";

            // Create an endpoint address with the address.
            EndpointAddress myEndpointAddress = new EndpointAddress(tcpUri);

            // Create an instance of the WCF client. The client
            // code was generated using the Svcutil.exe tool.
            CalculatorClient cc = new CalculatorClient(myBinding, myEndpointAddress);
            try
            {
                cc.Open();
                //</snippet2>
                // Begin using the calculator.
                Console.WriteLine(cc.Divide(100, 2));

                // Close the client.
                cc.Close();
            }
            catch (TimeoutException tex)
            {
                Console.WriteLine(tex.Message);
                cc.Abort();
            }
            catch (CommunicationException cex)
            {
                Console.WriteLine(cex.Message);
                cc.Abort();
            }
            finally
            {
                Console.WriteLine("Closed the client");
                Console.ReadLine();
            }
        }
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute()]
    public interface ICalculator
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Divide", ReplyAction = "http://tempuri.org/ICalculator/DivideResponse")]
        double Divide(double a, double b);

        [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/CalculateTax", ReplyAction = "http://tempuri.org/ICalculator/CalculateTaxResponse")]
        double CalculateTax(double a);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ICalculatorChannel : ICalculator, System.ServiceModel.IClientChannel
    {
    }

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

        public double Divide(double a, double b)
        {
            return base.Channel.Divide(a, b);
        }

        public double CalculateTax(double a)
        {
            return base.Channel.CalculateTax(a);
        }
    }

}
