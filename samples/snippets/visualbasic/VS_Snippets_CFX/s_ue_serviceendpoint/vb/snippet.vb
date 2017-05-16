
Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Description


Namespace ServiceEndpointSnippets
	Friend Class MyEndpointBehavior
		Implements IEndpointBehavior
		#Region "IEndpointBehavior Members"

		Public Sub AddBindingParameters(ByVal endpoint As ServiceEndpoint, ByVal bindingParameters As System.ServiceModel.Channels.BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		Public Sub ApplyClientBehavior(ByVal endpoint As ServiceEndpoint, ByVal clientRuntime As System.ServiceModel.Dispatcher.ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		Public Sub ApplyDispatchBehavior(ByVal endpoint As ServiceEndpoint, ByVal endpointDispatcher As System.ServiceModel.Dispatcher.EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		Public Sub Validate(ByVal endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
			Throw New Exception("The method or operation is not implemented.")
		End Sub

		#End Region
	End Class

	Friend Class Snippet
		Public Shared Sub Snippet2()
			' <Snippet2>
			Dim address As String = "http://localhost:8001/CalculatorService"

			Dim endpoint As New ServiceEndpoint(ContractDescription.GetContract(GetType(ICalculator), GetType(CalculatorService)), New WSHttpBinding(), New EndpointAddress(address))
			' </Snippet2>
		End Sub

		Public Shared Sub Snippet4()
			' <Snippet4>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			Dim endpoint As ServiceEndpoint = serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			endpoint.Behaviors.Add(New MyEndpointBehavior())

			Console.WriteLine("List all behaviors:")
			For Each behavior As IEndpointBehavior In endpoint.Behaviors
				Console.WriteLine("Behavior: {0}", CType(behavior, Object).ToString())
			Next behavior
			' </Snippet4>
		End Sub

		Public Shared Sub Snippet5()
			' <Snippet5>
			Dim baseAddress As New Uri("http://localhost:8001/Simple")
			Dim serviceHost As New ServiceHost(GetType(CalculatorService), baseAddress)

			Dim endpoint As ServiceEndpoint = serviceHost.AddServiceEndpoint(GetType(ICalculator), New WSHttpBinding(), "CalculatorServiceObject")

			Console.WriteLine("Service endpoint {0} contains the following:", endpoint.Name)
			Console.WriteLine("Binding: {0}", endpoint.Binding.ToString())
			Console.WriteLine("Contract: {0}", endpoint.Contract.ToString())
			Console.WriteLine("ListenUri: {0}", endpoint.ListenUri.ToString())
			Console.WriteLine("ListenUriMode: {0}", endpoint.ListenUriMode.ToString())
			' </Snippet5>
		End Sub

	End Class
End Namespace
