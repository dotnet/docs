using System;
using System.Runtime.Remoting;

namespace RemoteClient
{
	class Client
	{
		static void Main(string[] args) {
			
			Client client = new Client();
			client.RunSnippet();
		}

		public void RunSnippet() {
			
			// <Snippet1>
			// Create a remote version of TempConverter.Converter.
			TempConverter.Converter converter1 =
					(TempConverter.Converter) Activator.GetObject(
					typeof(TempConverter.Converter),
					"http://localhost:8085/TempConverter");
			
			// Create a local version of TempConverter.Converter.
			TempConverter.Converter converter2 = new TempConverter.Converter();

			// Returns true, converter1 is remote and in a different appdomain.
			System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(
									converter1); 

			// Returns false, converter2 is local and running in this appdomain.
			System.Runtime.Remoting.RemotingServices.IsObjectOutOfAppDomain(
									converter2); 

			// Returns true, converter1 is remote and in a different context.
			System.Runtime.Remoting.RemotingServices.IsObjectOutOfContext(
									converter1);

			// Returns false, converter2 is local and running in this context.
			System.Runtime.Remoting.RemotingServices.IsObjectOutOfContext(
									converter2);
			// </Snippet1>		
	
			// Print those function calls.
			System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.
				IsObjectOutOfAppDomain(converter1)); 
			System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.
				IsObjectOutOfAppDomain(converter2)); 

			System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.
				IsObjectOutOfContext(converter1)); 
			System.Console.WriteLine("{0}", System.Runtime.Remoting.RemotingServices.
				IsObjectOutOfContext(converter2)); 
		}
	}
}

namespace TempConverter{

public class Converter : MarshalByRefObject{

	}
}
