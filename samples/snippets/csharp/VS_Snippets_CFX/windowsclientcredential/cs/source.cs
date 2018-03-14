using System;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.ServiceModel.Description;
using System.Security.Cryptography.X509Certificates;

namespace Example
{
    public class Test
    {
        static void Main()
        {
            Test t = new Test();
            t.Snippet1();
            
        }


        private void Snippet1()
        {
            //<snippet1>
            // Create a service host.
            EndpointAddress ea = new EndpointAddress("http://localhost/Calculator");
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            b.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            
            // Create a client. The code is not shown here. See the WCF samples
            // for an example of the CalculatorClient code.

            CalculatorClient cc = new CalculatorClient(b, ea);
            // Get a reference to the Windows client credential object.
            WindowsClientCredential winCred= cc.ClientCredentials.Windows;
            Console.WriteLine("AllowedImpersonationLevel: {0}", 
                winCred.AllowedImpersonationLevel);
            Console.WriteLine("AllowNtlm: {0}", winCred.AllowNtlm);
            Console.WriteLine("Domain: {0}", winCred.ClientCredential.Domain);

            Console.ReadLine();
            // Change the AllowedImpersonationLevel.
            winCred.AllowedImpersonationLevel = 
                System.Security.Principal.TokenImpersonationLevel.Impersonation;

            Console.WriteLine("Changed AllowedImpersonationLevel: {0}", 
                winCred.AllowedImpersonationLevel);
            Console.ReadLine();
            // Open the calculator and use it.
            //cc.Open();
            //Console.WriteLine(cc.Add(11, 11));

            //// Close the client.
            //cc.Close();
            //</snippet1>

        }

        //<snippet2>
        private void Snippet2()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                client.ClientCredentials.Windows.ClientCredential.UserName = "test";
                client.ClientCredentials.Windows.ClientCredential.Password = "password";
            }
        }
        //</snippet2>

        //<snippet3>
        private void Snippet3()
        {
            using (CalculatorClient client = new CalculatorClient())
            {
                client.ClientCredentials.Windows.ClientCredential = new NetworkCredential("test user", "password");
            }
        }
        //</snippet3>
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName = "ICalculator")]
public interface ICalculator
{

    [System.ServiceModel.OperationContractAttribute(Action = "http://tempuri.org/ICalculator/Add", ReplyAction = "http://tempuri.org/ICalculator/AddResponse")]
    double Add(double a, double b);
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
}
