' Program.vb
' Snippet for ServiceHostFactory


Imports System
Imports System.ServiceModel
Imports System.ServiceModel.Activation
Imports System.Collections.Generic
Imports System.Text

Namespace CS
	Friend Interface IHelloService
		Function Hello(ByVal message As String) As String
	End Interface



	<ServiceContract> _
	Public Interface IHelloContract
		<OperationContract> _
		Function Hello(ByVal message As String) As String
	End Interface

	Public Class HelloService
		Implements IHelloService
		<OperationBehavior(Impersonation := ImpersonationOption.Required)> _
		Public Function Hello(ByVal message As String) As String Implements IHelloService.Hello
			Return "hello"
		End Function
	End Class

	Public Class DerivedHost
		Inherits ServiceHost

		Public Sub New(ByVal t As Type, ParamArray ByVal baseAddresses() As Uri)
			MyBase.New(t, baseAddresses)
		End Sub


		Protected Overrides Sub OnOpening()
			' add code here 
		End Sub

		' <Snippet1>
		Shared Sub Main()
			Dim factory As New ServiceHostFactory()
		End Sub
		' </Snippet1>

	End Class

	' <Snippet0>
	Public Class DerivedFactory
		Inherits ServiceHostFactory

		Protected Overrides Overloads Function CreateServiceHost(ByVal t As Type, ByVal baseAddresses() As Uri) As ServiceHost
			Return New DerivedHost(t, baseAddresses)
		End Function

		'Then in the CreateServiceHost method, we can do all of the
		'things that we can do in a self-hosted case:
		' <Snippet3>
		Public Overrides Overloads Function CreateServiceHost(ByVal service As String, ByVal baseAddresses() As Uri) As ServiceHostBase


			' The service parameter is ignored here because we know our service.
			Dim serviceHost As New ServiceHost(GetType(HelloService), baseAddresses)
			Return serviceHost

		End Function
		' </Snippet3>

	End Class
	' </Snippet0>


	'To use this factory instead of the default factory,
	'provide the type name in the @ServiceHost directive as follows:

	'<% @ServiceHost Factory="DerivedFactory" Service="MyService" %> 

End Namespace
