
Imports System
Imports System.ServiceModel
Imports System.Collections.Generic
Imports System.Text
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Channels

Namespace Service
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

			' Enable MEX.
			Dim smb As New ServiceMetadataBehavior()
			smb.HttpGetEnabled = True
			serviceHost.Description.Behaviors.Add(smb)

			serviceHost.Open()

			Dim icl As IChannelListener = serviceHost.ChannelDispatchers(0).Listener
			Dim dispatcher As New ChannelDispatcher(icl)
			Console.WriteLine("servicehost has {0} ChannelDispatchers", serviceHost.ChannelDispatchers.Count)
			Dim dispatchers As ChannelDispatcherCollection = serviceHost.ChannelDispatchers

			For Each disp As ChannelDispatcher In dispatchers
				Console.WriteLine("Binding name: " & disp.BindingName)
			Next disp

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
