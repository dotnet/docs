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