
Imports System
Imports System.Collections.ObjectModel
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.Net.Security

Namespace Server
	<ServiceContract()> _
	Public Interface ICalculator
		<OperationContract> _
		Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double

		<OperationContract> _
		Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double

		<OperationContract> _
		Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double

		<OperationContract> _
		Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
	End Interface

	Public Class CalculatorService
		Implements ICalculator
		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
			Return n1 + n2
		End Function

		Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
			Return n1 - n2
		End Function

		Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
			Return n1 * n2
		End Function

		Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
			Return n1 / n2
		End Function

		Public Shared Sub Main()
			' <Snippet0>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			' Enable Mex
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			serviceHost.Open()

			' <Snippet1>
			Dim cd0 As New ContractDescription("ICalculator")
			' </Snippet1>
			' <Snippet2>
			Dim cd1 As New ContractDescription("ICalculator", "http://www.tempuri.org")
			' </Snippet2>
			' <Snippet13>
			Dim cd2 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator))
			' </Snippet13>
			' <Snippet14>
			Dim calcSvc As New CalculatorService()
			Dim cd3 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator), calcSvc)
			' </Snippet14>
			' <Snippet15>
			Dim cd4 As ContractDescription = ContractDescription.GetContract(GetType(ICalculator), GetType(CalculatorService))
			' </Snippet15>
			Dim cd As ContractDescription = serviceHost.Description.Endpoints(0).Contract

			Console.WriteLine("Displaying information for contract: {0}", cd.Name.ToString())

			' <Snippet3>
			Dim behaviors As KeyedByTypeCollection(Of IContractBehavior) = cd.Behaviors
			Console.WriteLine(Constants.vbTab & "Display all behaviors:")
			For Each behavior As IContractBehavior In behaviors
				Console.WriteLine(Constants.vbTab + Constants.vbTab + CType(behavior, Object).ToString())
			Next behavior
			' </Snippet3>

			' <Snippet4>
			Dim type As Type = cd.CallbackContractType
			' </Snippet4>

			' <Snippet5>
			Dim configName As String = cd.ConfigurationName
			Console.WriteLine(Constants.vbTab & "Configuration name: {0}", configName)
			' </Snippet5>

			' <Snippet6>
			Dim contractType As Type = cd.ContractType
			Console.WriteLine(Constants.vbTab & "Contract type: {0}", contractType.ToString())
			' </Snippet6>

			' <Snippet7>
			Dim hasProtectionLevel As Boolean = cd.HasProtectionLevel
			If hasProtectionLevel Then
				' <Snippet11>
				Dim protectionLevel As ProtectionLevel = cd.ProtectionLevel
				Console.WriteLine(Constants.vbTab & "Protection Level: {0}", protectionLevel.ToString())
				' </Snippet11>
			End If
			' </Snippet7>


			' <Snippet8>
			Dim name As String = cd.Name
			Console.WriteLine(Constants.vbTab & "Name: {0}", name)
			' </Snippet8>

			' <Snippet9>
			Dim namespc As String = cd.Namespace
			Console.WriteLine(Constants.vbTab & "Namespace: {0}", namespc)
			' </Snippet9>

			' <Snippet10>
			Dim odc As OperationDescriptionCollection = cd.Operations
			Console.WriteLine(Constants.vbTab & "Display Operations:")
			For Each od As OperationDescription In odc
				Console.WriteLine(Constants.vbTab + Constants.vbTab + od.Name)
			Next od
			' </Snippet10>

			' <Snippet12>
			Dim sm As SessionMode = cd.SessionMode
			Console.WriteLine(Constants.vbTab & "SessionMode: {0}", sm.ToString())
			' </Snippet12>

			' <Snippet16>
			Dim inheretedContracts As Collection(Of ContractDescription) = cd.GetInheritedContracts()
			Console.WriteLine(Constants.vbTab & "Inherited Contracts:")
			For Each contractdescription As ContractDescription In inheretedContracts
				Console.WriteLine(Constants.vbTab + Constants.vbTab + contractdescription.Name)
			Next contractdescription
			' </Snippet16>

			Console.WriteLine("The service is ready.")
			Console.WriteLine("Press <ENTER> to terminate service.")
			Console.WriteLine()
			Console.ReadLine()

			' Close the ServiceHostBase to shutdown the service.
			serviceHost.Close()
			' </Snippet0>
		End Sub
	End Class
End Namespace
