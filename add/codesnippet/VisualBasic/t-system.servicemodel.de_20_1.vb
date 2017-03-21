			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			' Enable Mex
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			serviceHost.Open()

			' Use Default constructor
			Dim sd As New ServiceDescription()

			' Create ServiceDescription from a collection of service endpoints
			Dim endpoints As New List(Of ServiceEndpoint)()
			Dim conDescr As New ContractDescription("ICalculator")
			Dim endpointAddress As New EndpointAddress("http://localhost:8001/Basic")
			Dim ep As New ServiceEndpoint(conDescr, New BasicHttpBinding(), endpointAddress)
			endpoints.Add(ep)
			Dim sd2 As New ServiceDescription(endpoints)

			'// <Snippet3>
			'// Iterate through the list of behaviors in the ServiceDescription
			Dim svcDesc As ServiceDescription = serviceHost.Description
			Dim sbCol As KeyedByTypeCollection(Of IServiceBehavior) = svcDesc.Behaviors
			For Each behavior As IServiceBehavior In sbCol
				Console.WriteLine("Behavior: {0}", CType(behavior, Object).ToString())
			Next behavior

			' svcDesc is a ServiceDescription.
			svcDesc = serviceHost.Description
			Dim configName As String = svcDesc.ConfigurationName
			Console.WriteLine("Configuration name: {0}", configName)

			' Iterate through the endpoints contained in the ServiceDescription
			Dim sec As ServiceEndpointCollection = svcDesc.Endpoints
			For Each se As ServiceEndpoint In sec
				Console.WriteLine("Endpoint:")
				Console.WriteLine(Constants.vbTab & "Address: {0}", se.Address.ToString())
				Console.WriteLine(Constants.vbTab & "Binding: {0}", se.Binding.ToString())
				Console.WriteLine(Constants.vbTab & "Contract: {0}", se.Contract.ToString())
				Dim behaviors As KeyedByTypeCollection(Of IEndpointBehavior) = se.Behaviors
				For Each behavior As IEndpointBehavior In behaviors
					Console.WriteLine("Behavior: {0}", CType(behavior, Object).ToString())
				Next behavior
			Next se

            Dim name = svcDesc.Name
			Console.WriteLine("Service Description name: {0}", name)

            Dim namespc = svcDesc.Namespace
			Console.WriteLine("Service Description namespace: {0}", namespc)

			Dim serviceType As Type = svcDesc.ServiceType
			Console.WriteLine("Service Type: {0}", serviceType.ToString())

			' Instantiate a service description specifying a service object
			' Note: Endpoints collection and other properties will be null since 
			' we have not specified them
			Dim svcObj As New CalculatorService()
			Dim sd3 As ServiceDescription = ServiceDescription.GetService(svcObj)
            Dim serviceName = sd3.Name
			Console.WriteLine("Service name: {0}", serviceName)
