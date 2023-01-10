using System;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel;
using System.Security.Principal;
using System.Security.Permissions;

namespace SnippetsPart1
{
    interface IHelloService
    {
        string Hello(string message);
    }

    internal class Test
    {
        static void Main() { }
    }

    //<snippet1>
    [ServiceContract]
    public interface IHelloContract
    {
        [OperationContract]
        string Hello(string message);
    }

    public class HelloService : IHelloService
    {
        [OperationBehavior(Impersonation = ImpersonationOption.Required)]
        public string Hello(string message)
        {
            return "hello";
        }
    }

    //</snippet1>
}

namespace SnippetsPart2
{
    interface IHelloService
    {
        string Hello(string message);
    }

    //<snippet2>
    public class HelloService : IHelloService
    {
        [OperationBehavior]
        public string Hello(string message)
        {
            WindowsIdentity callerWindowsIdentity =
            ServiceSecurityContext.Current.WindowsIdentity;
            if (callerWindowsIdentity == null)
            {
                throw new InvalidOperationException
               ("The caller cannot be mapped to a WindowsIdentity");
            }
            using (callerWindowsIdentity.Impersonate())
            {
                // Access a file as the caller.
            }
            return "Hello";
        }
    }
    //</snippet2>

    interface IEcho
    {
        void SayHello();
    }

    internal class MoreSnippets
    {
        private void ServiceAuthorizationBehaviorStuff()
        {
            Uri myUri = new Uri("hello");
            Uri[] addresses = new Uri[] { myUri };
            Type c = typeof(HelloService);
            ServiceHost serviceHost = new ServiceHost(c, addresses );

            //<snippet3>
            // Code to create a ServiceHost not shown.
            ServiceAuthorizationBehavior MyServiceAuthoriationBehavior =
                serviceHost.Description.Behaviors.Find<ServiceAuthorizationBehavior>();
            MyServiceAuthoriationBehavior.ImpersonateCallerForAllOperations = true;
            //</snippet3>

            //<snippet4>
            ChannelFactory<IEcho> cf = new ChannelFactory<IEcho>("EchoEndpoint");
            cf.Credentials.Windows.AllowedImpersonationLevel  =
                System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //</snippet4>
        }

        private void BuildStuff()
        {
            //<snippet5>
            ChannelFactory<IEcho> cf = new
            ChannelFactory<IEcho>("EchoEndpoint");
            cf.Credentials.Windows.AllowedImpersonationLevel =
                System.Security.Principal.TokenImpersonationLevel.Impersonation;
            //</snippet5>
        }
    }
}
