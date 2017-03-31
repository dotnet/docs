// <SNIPPET1>
using System;
using System.Threading;
using System.Security;
using System.Security.Policy;
using System.Security.Permissions;

namespace AppDomainSnippets
{
	class ADSetAppDomainPolicy
	{
		static void Main(string[] args)
		{
			// Create a new application domain.
			AppDomain domain = System.AppDomain.CreateDomain("MyDomain");
			
			// Create a new AppDomain PolicyLevel.
			PolicyLevel polLevel = PolicyLevel.CreateAppDomainLevel();
			// Create a new, empty permission set.
			PermissionSet permSet = new PermissionSet(PermissionState.None);
			// Add permission to execute code to the permission set.
			permSet.AddPermission
				(new SecurityPermission(SecurityPermissionFlag.Execution));
			// Give the policy level's root code group a new policy statement based
			// on the new permission set.
			polLevel.RootCodeGroup.PolicyStatement = new PolicyStatement(permSet);
			// Give the new policy level to the application domain.
			domain.SetAppDomainPolicy(polLevel);
			
			// Try to execute the assembly.
			try
			{
				// This will throw a PolicyException if the executable tries to
				// access any resources like file I/O or tries to create a window.
				domain.ExecuteAssembly("Assemblies\\MyWindowsExe.exe");
			}
			catch(PolicyException e)
			{
				Console.WriteLine("PolicyException: {0}", e.Message);
			}

			AppDomain.Unload(domain);
		}
	}
}
// </SNIPPET1>