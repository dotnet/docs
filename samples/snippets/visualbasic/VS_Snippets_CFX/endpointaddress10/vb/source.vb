Imports System
Imports System.IO
Imports System.ServiceModel
Imports System.Runtime.Serialization

Namespace Microsoft.ServiceModel.Samples

	' Define a service contract.
	<ServiceContract(Namespace := "http://Microsoft.ServiceModel.Samples")> _
	Public Interface ICalculator
		<OperationContract> _
		Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
	End Interface

	' Implement the service contract.
	Public Class CalculatorService
		Implements ICalculator
		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
            Dim result = n1 + n2
			Console.WriteLine("Received Add({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			Return result
		End Function

		Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
            Dim result = n1 - n2
			Console.WriteLine("Received Subtract({0},{1})", n1, n2)
			Console.WriteLine("Return: {0}", result)
			Return result
		End Function


		Public Shared Sub Main()
			' <Snippet1>
			' Create an EndpointAddress with a specified address.
			Dim epa1 As New EndpointAddress("http://localhost/ServiceModelSamples")
			Console.WriteLine("The URI of the EndpointAddress is {0}:", epa1.Uri)
			Console.WriteLine()

			'Initialize an EndpointAddress10 from the endpointAddress.
			Dim epa10 As EndpointAddress10 = EndpointAddress10.FromEndpointAddress(epa1)

			'Serialize and then deserializde the Endpoint10 type.

			'Convert the EndpointAddress10 back into an EndpointAddress.
			Dim epa2 As EndpointAddress = epa10.ToEndpointAddress()

			Console.WriteLine("The URI of the EndpointAddress is still {0}:", epa2.Uri)
			Console.WriteLine()
			' </Snippet1>

		End Sub
	End Class
End Namespace

