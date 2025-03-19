//<snippet0>
using System.Security.Permissions;
using System;
using System.Collections.Generic;
using System.IO;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using System.Threading;
using System.Web.Security;
//</snippet0>

namespace Samples
{
    public class Test
    {
        public static void Run()
        {
            Uri baseUri = new Uri("http://ServiceModelSamples");

            //<snippet3>
            //<snippet1>
            ServiceHost myServiceHost = new ServiceHost(typeof(Calculator), baseUri);
            ServiceAuthorizationBehavior myServiceBehavior =
                myServiceHost.Description.Behaviors.Find<ServiceAuthorizationBehavior>();
            myServiceBehavior.PrincipalPermissionMode =
                PrincipalPermissionMode.UseAspNetRoles;
            //</snippet1>
            //<snippet5>
            MyServiceAuthorizationManager sm = new MyServiceAuthorizationManager();
            myServiceBehavior.ServiceAuthorizationManager = sm;
            //</snippet5>
            //</snippet3>
            //<snippet11>
            RoleProvider myCustomRoleProvider = myServiceBehavior.RoleProvider;
            //</snippet11>
        }
    }

    public class Calculator
    {
        //<snippet2>
        // Only members of the CalculatorClients group can call this method.
        [PrincipalPermission(SecurityAction.Demand, Role = "Users")]
        public double Add(double a, double b)
        {
            return a + b;
        }
        //</snippet2>

        //<snippet10>
        // Only a client authenticated with a valid certificate that has the
        // specified subject name and thumbprint can call this method.
        [PrincipalPermission(SecurityAction.Demand,
             Name = "CN=ReplaceWithSubjectName; 123456712345677E8E230FDE624F841B1CE9D41E")]
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        //</snippet10>

        //<snippet4>
        // Only a client authenticated with a valid certificate that has the
        // specified thumbprint can call this method.
        [PrincipalPermission(SecurityAction.Demand,
             Name = "; 123456712345677E8E230FDE624F841B1CE9D41E")]
        public double Divide(double a, double b)
        {
            return a * b;
        }
        //</snippet4>

        //<snippet9>
        [PrincipalPermission(SecurityAction.Demand, Role = "AspCustomRole")]
        public double Subtract(double a, double b)
        {
            return a * b;
        }
        //</snippet9>

        //<snippet13>
        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")]
        public string ReadFile(string fileName)
        {
            // Code not shown.
            return "Not implemented";
        }
        //</snippet13>
    }

    //<snippet6>
    public class MyServiceAuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            // Extract the action URI from the OperationContext. Match this against the claims
            // in the AuthorizationContext.
            string action = operationContext.RequestContext.RequestMessage.Headers.Action;
            Console.WriteLine($"action: {action}");

            // Iterate through the various claim sets in the AuthorizationContext.
            foreach (ClaimSet cs in operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets)
            {
                // Examine only those claim sets issued by System.
                if (cs.Issuer == ClaimSet.System)
                {
                    // Iterate through claims of type "http://example.org/claims/allowedoperation".
                    foreach (Claim c in cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty))
                    {
                        // Write the claim resource to the console.
                        Console.WriteLine("resource: {0}", c.Resource.ToString());

                        // If the claim resource matches the action URI, then return true to allow access.
                        if (action == c.Resource.ToString())
                            return true;
                    }
                }
            }

            // If this point is reached, return false to deny access.
            return false;
        }
    }
    //</snippet6>
}

//<snippet14>
//<snippet7>
namespace TestPrincipalPermission
{
    class PrincipalPermissionModeWindows
    {

        [ServiceContract]
        interface ISecureService
        {
            [OperationContract]
            string Method1();
        }

        class SecureService : ISecureService
        {
            [PrincipalPermission(SecurityAction.Demand, Role = "everyone")]
            public string Method1()
            {
                return String.Format("Hello, \"{0}\"", Thread.CurrentPrincipal.Identity.Name);
            }
        }

        public void Run()
        {
            Uri serviceUri = new Uri(@"http://localhost:8006/Service");
            ServiceHost service = new ServiceHost(typeof(SecureService));
            service.AddServiceEndpoint(typeof(ISecureService), GetBinding(), serviceUri);
            service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles;
            service.Open();

            EndpointAddress sr = new EndpointAddress(
                serviceUri, EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name));
            ChannelFactory<ISecureService> cf = new ChannelFactory<ISecureService>(GetBinding(), sr);
            ISecureService client = cf.CreateChannel();
            Console.WriteLine("Client received response from Method1: {0}", client.Method1());
            ((IChannel)client).Close();
            Console.ReadLine();
            service.Close();
        }

        public static Binding GetBinding()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            return binding;
        }
    }
}
//</snippet7>

//<snippet8>
namespace CustomMode
{
    public class Test
    {
        public static void Main()
        {
            try
            {
                ShowPrincipalPermissionModeCustom ppwm = new ShowPrincipalPermissionModeCustom();
                ppwm.Run();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Error: {exc.Message}");
                Console.ReadLine();
            }
        }
    }

    class ShowPrincipalPermissionModeCustom
    {
        [ServiceContract]
        interface ISecureService
        {
            [OperationContract]
            string Method1(string request);
        }

        [ServiceBehavior]
        class SecureService : ISecureService
        {
            [PrincipalPermission(SecurityAction.Demand, Role = "everyone")]
            public string Method1(string request)
            {
                return String.Format("Hello, \"{0}\"", Thread.CurrentPrincipal.Identity.Name);
            }
        }

        public void Run()
        {
            // <snippet20>
            Uri serviceUri = new Uri(@"http://localhost:8006/Service");
            ServiceHost service = new ServiceHost(typeof(SecureService));
            service.AddServiceEndpoint(typeof(ISecureService), GetBinding(), serviceUri);
            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            service.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;
            service.Open();
            // </snippet20>

            EndpointAddress sr = new EndpointAddress(
                serviceUri, EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name));
            ChannelFactory<ISecureService> cf = new ChannelFactory<ISecureService>(GetBinding(), sr);
            ISecureService client = cf.CreateChannel();
            Console.WriteLine("Client received response from Method1: {0}", client.Method1("hello"));
            ((IChannel)client).Close();
            Console.ReadLine();
            service.Close();
        }

        public static Binding GetBinding()
        {
            WSHttpBinding binding = new WSHttpBinding(SecurityMode.Message);
            binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows;
            return binding;
        }

        class CustomAuthorizationPolicy : IAuthorizationPolicy
        {
            string id = Guid.NewGuid().ToString();

            public string Id
            {
                get { return this.id; }
            }

            public ClaimSet Issuer
            {
                get { return ClaimSet.System; }
            }

            public bool Evaluate(EvaluationContext context, ref object state)
            {
                object obj;
                if (!context.Properties.TryGetValue("Identities", out obj))
                    return false;

                IList<IIdentity> identities = obj as IList<IIdentity>;
                if (obj == null || identities.Count <= 0)
                    return false;

                context.Properties["Principal"] = new CustomPrincipal(identities[0]);
                return true;
            }
        }

        class CustomPrincipal : IPrincipal
        {
            IIdentity identity;
            public CustomPrincipal(IIdentity identity)
            {
                this.identity = identity;
            }

            public IIdentity Identity
            {
                get { return this.identity; }
            }

            public bool IsInRole(string role)
            {
                return true;
            }
        }
    }
}
//</snippet8>
//</snippet14>