	public class DerivedFactory : ServiceHostFactory 
	{ 

		protected override ServiceHost CreateServiceHost( Type t, Uri[] baseAddresses ) 
		{ 
			return new DerivedHost( t, baseAddresses ); 
		}

		//Then in the CreateServiceHost method, we can do all of the
		//things that we can do in a self-hosted case:
		public override ServiceHostBase CreateServiceHost
				(string service, Uri[] baseAddresses)

		{

			// The service parameter is ignored here because we know our service.
			ServiceHost serviceHost = new ServiceHost(typeof(HelloService),
				baseAddresses);
			return serviceHost;

		}

	}