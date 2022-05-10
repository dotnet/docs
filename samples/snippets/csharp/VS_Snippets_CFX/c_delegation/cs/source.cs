using System;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel;
using System.Security.Principal;
using System.Security.Permissions;

namespace SnippetsPart1
{
    [ServiceContract]
    interface IHelloService
    {
        [OperationContract]
        string Hello(string message);
    }

    internal class Test
    {
        static void Main() { }
    }

    [ServiceContract]
    public interface IHelloContract
    {
        [OperationContract]
        string Hello(string message);
    }
    //<snippet1>
    public class HelloService : IHelloService
    {
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public string Hello(string message)
        {
            WindowsIdentity callerWindowsIdentity = ServiceSecurityContext.Current.WindowsIdentity;
            if (callerWindowsIdentity == null)
            {
                throw new InvalidOperationException
                 ("The caller cannot be mapped to a Windows identity.");
            }
            using (callerWindowsIdentity.Impersonate())
            {
                EndpointAddress backendServiceAddress = new EndpointAddress("http://localhost:8000/ChannelApp");
                // Any binding that performs Windows authentication of the client can be used.
                ChannelFactory<IHelloService> channelFactory = new ChannelFactory<IHelloService>(new NetTcpBinding(), backendServiceAddress);
                IHelloService channel = channelFactory.CreateChannel();
                return channel.Hello(message);
            }
        }
    }
    //</snippet1>

    public class RunService
    {
        private void Run()
        {
            //<snippet2>
            // Create a binding that sets a certificate as the client credential type.
            WSHttpBinding b = new WSHttpBinding();
            b.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;

            // Create a service host that maps the certificate to a Windows account.
            Uri httpUri = new Uri("http://localhost/Calculator");
            ServiceHost sh = new ServiceHost(typeof(HelloService), httpUri);
            sh.Credentials.ClientCertificate.Authentication.MapClientCertificateToWindowsAccount = true;
            //</snippet2>
        }
    }
}
