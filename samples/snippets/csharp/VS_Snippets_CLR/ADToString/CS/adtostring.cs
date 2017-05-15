//  <SNIPPET1>
using System;
using System.Reflection;
using System.Security.Policy;
class ADSetup
{
	public static void Main()
	{
		// Create application domain setup information
		AppDomainSetup domaininfo = new AppDomainSetup();
		
		//Create evidence for the new appdomain from evidence of the current application domain
		Evidence adevidence = AppDomain.CurrentDomain.Evidence;

		// Create appdomain
		AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence, domaininfo);

		// Write out application domain information
		Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
		Console.WriteLine("child domain: " + domain.FriendlyName);
		Console.WriteLine("child domain name using ToString:" + domain.ToString());
		Console.WriteLine();
		
		AppDomain.Unload(domain);
	
	}
	
}
//  </SNIPPET1>
