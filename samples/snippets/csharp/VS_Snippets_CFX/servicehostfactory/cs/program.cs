// Program.cs
// Snippet for ServiceHostFactory
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Collections.Generic;
using System.Text;

namespace CS
{
	interface IHelloService
	{
		string Hello(string message);
	}



	[ServiceContract]
	public interface IHelloContract
	{
		[OperationContract]
				string Hello(string message);
	}

	public class HelloService : IHelloService
	{
		[OperationBehavior(Impersonation = ImpersonationOption.Required)]
		public string Hello(string message)
		{
			return "hello";
		}
	}
	
	public class DerivedHost : ServiceHost 
	{ 

		public DerivedHost( Type t, params Uri[] baseAddresses ) : 
						base( t, baseAddresses ) {} 


		protected override void OnOpening() 
		{ 
			// add code here 
		} 

		// <Snippet1>
		static void Main()
		{
			ServiceHostFactory factory = new ServiceHostFactory();
		}
		// </Snippet1>

	} 

	// <Snippet0>
	public class DerivedFactory : ServiceHostFactory 
	{ 

		protected override ServiceHost CreateServiceHost( Type t, Uri[] baseAddresses ) 
		{ 
			return new DerivedHost( t, baseAddresses ); 
		}

		//Then in the CreateServiceHost method, we can do all of the
		//things that we can do in a self-hosted case:
		// <Snippet3>
		public override ServiceHostBase CreateServiceHost
				(string service, Uri[] baseAddresses)

		{

			// The service parameter is ignored here because we know our service.
			ServiceHost serviceHost = new ServiceHost(typeof(HelloService),
				baseAddresses);
			return serviceHost;

		}
		// </Snippet3>

	}
	// </Snippet0>

	
	//To use this factory instead of the default factory,
	//provide the type name in the @ServiceHost directive as follows:

	//<% @ServiceHost Factory="DerivedFactory" Service="MyService" %> 

}
