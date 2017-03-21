			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			' Enable Mex
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			serviceHost.Open()

			Dim cd0 As New ContractDescription("ICalculator")
			Dim cd1 As New ContractDescription("ICalculator", "http://www.tempuri.org")
			Dim cd2 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator))
			Dim calcSvc As New CalculatorService()
			Dim cd3 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator), calcSvc)
			Dim cd4 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator), GetType(CalculatorService))
			Dim cd As ContractDescription = serviceHost.Description.Endpoints(0).Contract

			Console.WriteLine("Displaying information for contract: {0}", cd.Name.ToString())

			Dim behaviors As KeyedByTypeCollection(Of IContractBehavior) = cd.Behaviors
			Console.WriteLine(Constants.vbTab & "Display all behaviors:")
			For Each behavior As IContractBehavior In behaviors
				Console.WriteLine(Constants.vbTab + Constants.vbTab + CType(behavior, Object).ToString())
			Next behavior

			Dim type As Type = cd.CallbackContractType

			Dim configName As String = cd.ConfigurationName
			Console.WriteLine(Constants.vbTab & "Configuration name: {0}", configName)

			Dim contractType As Type = cd.ContractType
			Console.WriteLine(Constants.vbTab & "Contract type: {0}", contractType.ToString())

			Dim hasProtectionLevel As Boolean = cd.HasProtectionLevel
			If hasProtectionLevel Then
				Dim protectionLevel As ProtectionLevel = cd.ProtectionLevel
				Console.WriteLine(Constants.vbTab & "Protection Level: {0}", protectionLevel.ToString())
			End If


			Dim name As String = cd.Name
			Console.WriteLine(Constants.vbTab & "Name: {0}", name)

			Dim namespc As String = cd.Namespace
			Console.WriteLine(Constants.vbTab & "Namespace: {0}", namespc)

			Dim odc As OperationDescriptionCollection = cd.Operations
			Console.WriteLine(Constants.vbTab & "Display Operations:")
			For Each od As OperationDescription In odc
				Console.WriteLine(Constants.vbTab + Constants.vbTab + od.Name)
			Next od

			Dim sm As SessionMode = cd.SessionMode
			Console.WriteLine(Constants.vbTab & "SessionMode: {0}", sm.ToString())

			Dim inheretedContracts As Collection(Of ContractDescription) = cd.GetInheritedContracts()
			Console.WriteLine(Constants.vbTab & "Inherited Contracts:")
			For Each contractdescription As ContractDescription In inheretedContracts
				Console.WriteLine(Constants.vbTab + Constants.vbTab + contractdescription.Name)
			Next contractdescription

			Console.WriteLine("The service is ready.")
			Console.WriteLine("Press <ENTER> to terminate service.")
			Console.WriteLine()
			Console.ReadLine()

			' Close the ServiceHostBase to shutdown the service.
			serviceHost.Close()