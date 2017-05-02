//  <SNIPPET1>
using System;
using System.Reflection;
using System.Security.Policy;

class ADGetAssemblies 
{

	public static void Main() 
	{
		AppDomain currentDomain = AppDomain.CurrentDomain;
		//Provide the current application domain evidence for the assembly.
		Evidence asEvidence = currentDomain.Evidence;
		//Load the assembly from the application directory using a simple name.

		//Create an assembly called CustomLibrary to run this sample.
		currentDomain.Load("CustomLibrary",asEvidence);

		//Make an array for the list of assemblies.
		Assembly[] assems = currentDomain.GetAssemblies();
	
		//List the assemblies in the current application domain.
		Console.WriteLine("List of assemblies loaded in current appdomain:");
			foreach (Assembly assem in assems)
				Console.WriteLine(assem.ToString());
	}
   
}
//  </SNIPPET1>