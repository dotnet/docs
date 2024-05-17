using System;
using System.ServiceModel;
using System.Security.Cryptography.X509Certificates;

namespace Samples
{
    public class Test
    {
        public static void Main()
        {
            try
            {
                Test t = new Test();
                //t.TcpMessageWithCredentialWindows();
                t.AllConfig();
            }
            catch (System.Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.ReadLine();
            }
        }
        private void AllConfig()
        {
            ServiceHost sh = new ServiceHost(typeof(Calculator));
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
        }

        private void MakeTransportBinding()
        {
            //<snippet5>
            //<snippet1>
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Transport;
            //</snippet1>
            b.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;
            //</snippet5>
        }
        private void MakeMessageBinding()
        {
            //<snippet6>
            //<snippet2>
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.Message;
            //</snippet2>
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            //</snippet6>
        }

        private void TransportWithMessageBinding()
        {
            //<snippet3>
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.TransportWithMessageCredential;
            //</snippet3>
        }

        private void SetModeViaConstructor()
        {
            //<snippet4>
            WSHttpBinding b = new WSHttpBinding(SecurityMode.Message);
            //</snippet4>
        }

        private void HttpMessageWithCredential()
        {
            //<snippet7>
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Mode = SecurityMode.TransportWithMessageCredential;
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

            // The SSL certificate is bound to port 8006 using the HttpCfg.exe tool.
            Uri httpsAddress = new Uri("https://localMachineName:8006/base");
            ServiceHost sh = new ServiceHost(typeof(Calculator), httpsAddress);
            sh.AddServiceEndpoint(typeof(ICalculator), b, "HttpsCalculator");
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            //</snippet7>
        }

        private void TcpMessageWithCredential()
        {
            //<snippet8>
            NetTcpBinding b = new NetTcpBinding(SecurityMode.TransportWithMessageCredential);
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            Uri netTcpAddress = new Uri("net.tcp://baseAddress");
            ServiceHost sh = new ServiceHost(typeof(Calculator), netTcpAddress);
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine, StoreName.My,
                X509FindType.FindByIssuerName, "Contoso.com");
            sh.AddServiceEndpoint(typeof(ICalculator), b, "TcpCalculator");
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            //</snippet8>
        }

        private void TcpMessageWithCredentialWindows()
        {
            //<snippet9>
            NetTcpBinding b = new NetTcpBinding(SecurityMode.TransportWithMessageCredential);
            b.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
            Uri netTcpAddress = new Uri("net.tcp://Tcp");
            ServiceHost sh = new ServiceHost(typeof(Calculator), netTcpAddress);
            sh.Credentials.ServiceCertificate.SetCertificate(
                StoreLocation.LocalMachine, StoreName.My,
                X509FindType.FindByIssuerName, "Contoso.com");
            sh.AddServiceEndpoint(typeof(ICalculator), b, "TcpCalculator");
            sh.Open();
            Console.WriteLine("Listening");
            Console.ReadLine();
            //</snippet9>
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
