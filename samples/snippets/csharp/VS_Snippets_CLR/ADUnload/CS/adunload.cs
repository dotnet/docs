//  <SNIPPET1>
using System;
using System.Reflection;
using System.Security.Policy;
class ADUnload
{
	public static void Main()
	{

		//Create evidence for the new appdomain.
		Evidence adevidence = AppDomain.CurrentDomain.Evidence;

 		// Create the new application domain.
 		AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence);

            	Console.WriteLine("Host domain: " + AppDomain.CurrentDomain.FriendlyName);
            	Console.WriteLine("child domain: " + domain.FriendlyName);
		// Unload the application domain.
		AppDomain.Unload(domain);

		try
		{
		Console.WriteLine();
		// Note that the following statement creates an exception because the domain no longer exists.
            	Console.WriteLine("child domain: " + domain.FriendlyName);
		}

		catch (AppDomainUnloadedException e)
		{
		Console.WriteLine("The appdomain MyDomain does not exist.");
		}
		
	}
	
}
//  </SNIPPET1>

