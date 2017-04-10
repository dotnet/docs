
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Channels

Namespace Service
	<ServiceContract(Namespace := "http://Microsoft.ServiceModel.Samples")> _
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

	' Service class which implements the service contract.
	' <Snippet0>
	<ServiceBehavior(AddressFilterMode := AddressFilterMode.Prefix)> _
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
	End Class

	' </Snippet0>

End Namespace
