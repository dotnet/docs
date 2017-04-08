//<Snippet1>
using System;
using System.Collections;
using System.Text;
using System.Security.Policy;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Runtime.Hosting;

namespace ActivationContextSample
{
    public class Program : MarshalByRefObject
    {
        [SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy=true)]
        public static void Main(string[] args)
        {
            //<Snippet2>
            // Get the AppDomainManager from the current domain.
            AppDomainManager domainMgr = AppDomain.CurrentDomain.DomainManager;
            // Get the ApplicationActivator from the AppDomainManager.
            ApplicationActivator appActivator = domainMgr.ApplicationActivator;
            Console.WriteLine("Assembly qualified name from the application activator.");
            Console.WriteLine(appActivator.GetType().AssemblyQualifiedName);
            //</Snippet2>
            //<Snippet3>
            //<Snippet4>
            // Get the ActivationArguments from the SetupInformation property of the domain.
            ActivationArguments activationArgs = AppDomain.CurrentDomain.SetupInformation.ActivationArguments;
            //</Snippet3>
            // Get the ActivationContext from the ActivationArguments.
            ActivationContext actContext = activationArgs.ActivationContext;
            Console.WriteLine("The ActivationContext.Form property value is: " +
                activationArgs.ActivationContext.Form);
            //</Snippet4>
            Console.Read();
        }
	[SecurityPermission(SecurityAction.LinkDemand, ControlDomainPolicy=true)]
        public void Run()
        {
            Main(new string[] { });
            Console.ReadLine();
        }
    }
}
//</Snippet1>



