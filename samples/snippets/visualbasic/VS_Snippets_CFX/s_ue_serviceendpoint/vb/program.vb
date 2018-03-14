
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Description


Namespace ServiceEndpointSnippets
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
			Snippet.Snippet5()
			' <Snippet0>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			' <Snippet1>
			Dim cd As New ContractDescription("Calculator")
			Dim svcEndpoint As New ServiceEndpoint(cd)
			' </Snippet1>

			' <Snippet3>                       
			Dim endpnt As ServiceEndpoint = serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			Console.WriteLine("Address: {0}", endpnt.Address)
			' </Snippet3>

			' Enable Mex
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			serviceHost.Open()
		' </Snippet0>

		End Sub
	End Class
End Namespace
