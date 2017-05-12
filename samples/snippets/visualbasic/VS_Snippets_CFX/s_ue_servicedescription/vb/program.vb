
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ServiceModel
Imports System.ServiceModel.Description

Namespace ServiceDescriptionSnippet
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
			' Use Default constructor
			Dim sd As New ServiceDescription()
			' </Snippet1>

			' <Snippet2>
			' Create ServiceDescription from a collection of service endpoints
			Dim endpoints As New List(Of ServiceEndpoint)()
			Dim conDescr As New ContractDescription("ICalculator")
			Dim endpointAddress As New EndpointAddress("http://localhost:8001/Basic")
			Dim ep As New ServiceEndpoint(conDescr, New BasicHttpBinding(), endpointAddress)
			endpoints.Add(ep)
			Dim sd2 As New ServiceDescription(endpoints)
			' </Snippet2>

			' <Snippet3>
			' Iterate through the list of behaviors in the ServiceDescription
			Dim svcDesc As ServiceDescription = serviceHost.Description
			Dim sbCol As KeyedByTypeCollection(Of IServiceBehavior) = svcDesc.Behaviors
			For Each behavior As IServiceBehavior In sbCol
				Console.WriteLine("Behavior: {0}", CType(behavior, Object).ToString())
			Next behavior
			' </Snippet3>

			' <Snippet4>
			' svcDesc is a ServiceDescription.
			svcDesc = serviceHost.Description
			Dim configName As String = svcDesc.ConfigurationName
			Console.WriteLine("Configuration name: {0}", configName)
			' </Snippet4>

			' <Snippet5>
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
			' </Snippet5>

			' <Snippet6>
            Dim name = svcDesc.Name
			Console.WriteLine("Service Description name: {0}", name)
			' </Snippet6>

			' <Snippet7>
            Dim namespc = svcDesc.Namespace
			Console.WriteLine("Service Description namespace: {0}", namespc)
			' </Snippet7>

			' <Snippet8>
			Dim serviceType As Type = svcDesc.ServiceType
			Console.WriteLine("Service Type: {0}", serviceType.ToString())
			' </Snippet8>

			' <Snippet9>
			' Instantiate a service description specifying a service object
			' Note: Endpoints collection and other properties will be null since 
			' we have not specified them
			Dim svcObj As New CalculatorService()
			Dim sd3 As ServiceDescription = ServiceDescription.GetService(svcObj)
            Dim serviceName = sd3.Name
			Console.WriteLine("Service name: {0}", serviceName)
			' </Snippet9>

			' </Snippet0>

		End Sub
	End Class
End Namespace
