//<Snippet1>
// To replace the default AppDomainManager, identify  the 
// replacement assembly and replacement type in the 
// APPDOMAIN_MANAGER_ASM and APPDOMAIN_MANAGER_TYPE  
// environment variables. For example:
// set APPDOMAIN_MANAGER_TYPE=library.TestAppDomainManager
// set APPDOMAIN_MANAGER_ASM=library, Version=1.0.0.0, Culture=neutral, PublicKeyToken=f1368f7b12a08d72

using System;
using System.Collections;
using System.Net;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Security.Principal;
using System.Threading;
using System.Runtime.InteropServices;

[assembly: System.Security.AllowPartiallyTrustedCallersAttribute()]

namespace MyNamespace
{
    [GuidAttribute("F4D15099-3407-4A7E-A607-DEA440CF3891")]
    [SecurityPermissionAttribute(SecurityAction.LinkDemand, 
        Flags = SecurityPermissionFlag.Infrastructure)]
    [SecurityPermissionAttribute(SecurityAction.InheritanceDemand, 
        Flags = SecurityPermissionFlag.Infrastructure)]
    public class MyAppDomainManager : AppDomainManager
    {
        private HostSecurityManager mySecurityManager = null;

        public MyAppDomainManager()
        {
            Console.WriteLine(" My AppDomain Manager ");
            mySecurityManager = AppDomain.CurrentDomain.CreateInstanceAndUnwrap(
                "CustomSecurityManager, Version=1.0.0.3, Culture=neutral, " +
                "PublicKeyToken=5659fc598c2a503e", 
                "MyNamespace.MySecurityManager") as HostSecurityManager;
            Console.WriteLine(" Custom Security Manager Created.");
        }

        //<Snippet2>
        public override void InitializeNewDomain(AppDomainSetup appDomainInfo)
        {
            Console.Write("Initialize new domain called:  ");
            Console.WriteLine(AppDomain.CurrentDomain.FriendlyName);
            InitializationFlags = 
                AppDomainManagerInitializationOptions.RegisterWithHost;
        }
        //</Snippet2>

        //<Snippet3>
        public override HostSecurityManager HostSecurityManager
        {
            get
            {
                return mySecurityManager;
            }
        }
        //</Snippet3>
    }
}
//</Snippet1>
