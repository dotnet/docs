//  <SNIPPET1>
using System;
using System.Reflection;
using System.Security.Policy;

class ADAppendPrivatePath
{
	public static void Main()
	{
		//Create evidence for new appdomain.
		Evidence adevidence = AppDomain.CurrentDomain.Evidence;

		//Create the new application domain.
		AppDomain domain = AppDomain.CreateDomain("MyDomain", adevidence);

		//Display the current relative search path.
		Console.WriteLine("Relative search path is: " + domain.RelativeSearchPath);

		//Append the relative path.
		String Newpath = "www.code.microsoft.com";
		domain.AppendPrivatePath(Newpath);

		//Display the new relative search path.
		Console.WriteLine("Relative search path is: " + domain.RelativeSearchPath);

		//Clear the private search path.
		domain.ClearPrivatePath();

		//Display the new relative search path.
		Console.WriteLine("Relative search path is now: " + domain.RelativeSearchPath);

 
		AppDomain.Unload(domain);	
	}
}
//  </SNIPPET1>




