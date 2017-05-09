Imports System
Imports System.Configuration
Imports System.ServiceModel

Namespace Microsoft.ServiceModel.Samples
	<ServiceContract(Namespace := "http://Microsoft.ServiceModel.Samples")> _
	Friend Interface ICalculator
		<OperationContract> _
		Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double
		<OperationContract> _
		Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double
	End Interface

	Friend Class CalculatorService
		Implements ICalculator
		Public Function Add(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Add
			Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
			Dim result As Double = n1 + n2
			Return result
		End Function

		Public Function Subtract(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Subtract
			Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
			Dim result As Double = n1 - n2
			Return result
		End Function

		Public Function Multiply(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Multiply
			Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
			Dim result As Double = n1 * n2
			Return result
		End Function

		Public Function Divide(ByVal n1 As Double, ByVal n2 As Double) As Double Implements ICalculator.Divide
			Console.WriteLine("Called by {0}", ServiceSecurityContext.Current.PrimaryIdentity.Name)
			Dim result As Double = n1 / n2
			Return result
		End Function

		Shared Sub Main()
			' Create a ServiceHost for the CalculatorService type
			Using serviceHost As New ServiceHost(GetType(CalculatorService))
				'Open the ServiceHost to create listeners and start listening for messages.
				serviceHost.Open()

				' The service can now be accessed.
				Console.WriteLine("Service started at {0}", serviceHost.BaseAddresses(0))
				Console.WriteLine("Press ENTER to terminate service.")
				Console.WriteLine()
				Console.ReadLine()

				' Close the ServiceHost to shutdown the service.
				serviceHost.Close()
			End Using
		End Sub
	End Class
End Namespace
