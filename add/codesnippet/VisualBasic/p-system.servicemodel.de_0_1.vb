			' svcDesc is a ServiceDescription.
			svcDesc = serviceHost.Description
			Dim configName As String = svcDesc.ConfigurationName
			Console.WriteLine("Configuration name: {0}", configName)