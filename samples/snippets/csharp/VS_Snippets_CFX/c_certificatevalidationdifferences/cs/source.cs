using System;
using System.Xml;
using System.Collections;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Net;
using System.Net.Security;
using System.Runtime.Serialization;
using System.Xml.Schema;

public class Test
{
    public static void Main()
    {
        try
        {
            Test t = new Test();
            t.Run();
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Message: {exc.Message}");
            Console.ReadLine();
        }
        finally
        {
            Console.WriteLine("\n \n Done");
            Console.ReadLine();
        }
    }
    private void Run()
    {
        //<snippet1>
        ServicePointManager.ServerCertificateValidationCallback +=
            new RemoteCertificateValidationCallback(ValidateServerCertificate);
        //</snippet1>
    }

    //<snippet2>
    public static bool ValidateServerCertificate(
      object sender,
      X509Certificate certificate,
      X509Chain chain,
      SslPolicyErrors sslPolicyErrors)
    //</snippet2>
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;

        Console.WriteLine($"Certificate error: {sslPolicyErrors}");

        // Do not allow this client to communicate with unauthenticated servers.
        return false;
    }

    private void CreateServiceHost()
    {
        ServiceHost myServiceHost=new ServiceHost(typeof(Calculator));

        //<snippet3>
        myServiceHost.Credentials.ClientCertificate.Authentication.
            CertificateValidationMode=
            X509CertificateValidationMode.PeerOrChainTrust;

        myServiceHost.Credentials.ClientCertificate.Authentication.
            RevocationMode=X509RevocationMode.Offline;
        //</snippet3>
    }

    private void CreateClient() {
        CalculatorClient myClient= new CalculatorClient();
        //<snippet4>
        myClient.ClientCredentials.ServiceCertificate.
            Authentication.CertificateValidationMode=
            X509CertificateValidationMode.PeerOrChainTrust;
        myClient.ClientCredentials.ServiceCertificate.Authentication.
            RevocationMode = X509RevocationMode.Offline;
        //</snippet4>
    }

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double Add(double a, double b);
    }

    public class Calculator:ICalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
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
