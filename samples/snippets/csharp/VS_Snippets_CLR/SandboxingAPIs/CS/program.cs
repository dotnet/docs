//<Snippet1>
using System;
using System.Collections;
using System.Diagnostics;
using System.Security;
using System.Security.Permissions;
using System.Security.Policy;
using System.Reflection;
using System.IO;

namespace SimpleSandboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the permission set to grant to other assemblies.
            // In this case we are granting the permissions found in the LocalIntranet zone.
            Evidence e = new Evidence();
            e.AddHostEvidence(new Zone(SecurityZone.Intranet));
            PermissionSet pset = SecurityManager.GetStandardSandbox(e);

            AppDomainSetup ads = new AppDomainSetup();
            // Identify the folder to use for the sandbox.
            ads.ApplicationBase = "C:\\Sandbox";
            // Copy the application to be executed to the sandbox.
            Directory.CreateDirectory("C:\\Sandbox");
            File.Copy("..\\..\\..\\HelloWorld\\bin\\debug\\HelloWorld.exe", "C:\\sandbox\\HelloWorld.exe", true);

            // Create the sandboxed domain.
            AppDomain sandbox = AppDomain.CreateDomain(
               "Sandboxed Domain",
               e,
               ads,
               pset,
               null);
            sandbox.ExecuteAssemblyByName("HelloWorld");
        }
    }
}

//</Snippet1>
