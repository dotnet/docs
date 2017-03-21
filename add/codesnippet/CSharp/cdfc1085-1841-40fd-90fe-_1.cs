		public override ServiceHostBase CreateServiceHost
				(string service, Uri[] baseAddresses)

		{

			// The service parameter is ignored here because we know our service.
			ServiceHost serviceHost = new ServiceHost(typeof(HelloService),
				baseAddresses);
			return serviceHost;

		}