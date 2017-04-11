// <SNIPPET1>
using System;
using System.Security.Principal;
using System.Threading;

class ADPrincipal
{
	static void Main(string[] args)
	{
		// Create a new thread with a generic principal.
		Thread t = new Thread(new ThreadStart(PrintPrincipalInformation));
		t.Start();
		t.Join();

		// Set the principal policy to WindowsPrincipal.
		AppDomain currentDomain = AppDomain.CurrentDomain;
		currentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
			
		// The new thread will have a Windows principal representing the
		// current user.
		t = new Thread(new ThreadStart(PrintPrincipalInformation));
		t.Start();
		t.Join();

		// Create a principal to use for new threads.
		IIdentity identity = new GenericIdentity("NewUser");
		IPrincipal principal = new GenericPrincipal(identity, null);
		currentDomain.SetThreadPrincipal(principal);
			
		// Create a new thread with the principal created above.
		t = new Thread(new ThreadStart(PrintPrincipalInformation));
		t.Start();
		t.Join();
		
		// Wait for user input before terminating.
		Console.ReadLine();
	}

	static void PrintPrincipalInformation()
	{
		IPrincipal curPrincipal = Thread.CurrentPrincipal;
		if(curPrincipal != null)
		{
			Console.WriteLine("Type: " + curPrincipal.GetType().Name);
			Console.WriteLine("Name: " + curPrincipal.Identity.Name);
			Console.WriteLine("Authenticated: " +
				curPrincipal.Identity.IsAuthenticated);
			Console.WriteLine();
		}
	}
}
// </SNIPPET1>
