//<Snippet1>
using System;
 
namespace SimpleSandboxing
{
    public class Worker : MarshalByRefObject
    {
        static void Main()
        {
            Worker w = new Worker();
            w.TestIsFullyTrusted();

            AppDomain adSandbox = GetInternetSandbox();
            w = (Worker) adSandbox.CreateInstanceAndUnwrap(
                               typeof(Worker).Assembly.FullName,
                               typeof(Worker).FullName);
            w.TestIsFullyTrusted();
        }

        public void TestIsFullyTrusted()
        {
            AppDomain ad = AppDomain.CurrentDomain;
            Console.WriteLine("\r\nApplication domain '{0}': IsFullyTrusted = {1}",
                                        ad.FriendlyName, ad.IsFullyTrusted);

            Console.WriteLine("   IsFullyTrusted = {0} for the current assembly",
                             typeof(Worker).Assembly.IsFullyTrusted);

            Console.WriteLine("   IsFullyTrusted = {0} for mscorlib",
                                        typeof(int).Assembly.IsFullyTrusted);
        }

        // ------------ Helper method ---------------------------------------
        static AppDomain GetInternetSandbox()
        {
            // Create the permission set to grant to all assemblies.
            System.Security.Policy.Evidence hostEvidence = new System.Security.Policy.Evidence();
            hostEvidence.AddHostEvidence(new System.Security.Policy.Zone(
                                                         System.Security.SecurityZone.Internet));
            System.Security.PermissionSet pset = 
                                System.Security.SecurityManager.GetStandardSandbox(hostEvidence);

            // Identify the folder to use for the sandbox.
            AppDomainSetup ads = new AppDomainSetup();
            ads.ApplicationBase = System.IO.Directory.GetCurrentDirectory();
 
            // Create the sandboxed application domain.
            return AppDomain.CreateDomain("Sandbox", hostEvidence, ads, pset, null); 
        }
    }
}

/* This example produces output similar to the following:

Application domain 'Example.exe': IsFullyTrusted = True
   IsFullyTrusted = True for the current assembly
   IsFullyTrusted = True for mscorlib

Application domain 'Sandbox': IsFullyTrusted = False
   IsFullyTrusted = False for the current assembly
   IsFullyTrusted = True for mscorlib
 */
//</Snippet1>