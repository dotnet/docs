	Public Class DerivedFactory
		Inherits ServiceHostFactory

		Protected Overrides Overloads Function CreateServiceHost(ByVal t As Type, ByVal baseAddresses() As Uri) As ServiceHost
			Return New DerivedHost(t, baseAddresses)
		End Function

		'Then in the CreateServiceHost method, we can do all of the
		'things that we can do in a self-hosted case:
		Public Overrides Overloads Function CreateServiceHost(ByVal service As String, ByVal baseAddresses() As Uri) As ServiceHostBase


			' The service parameter is ignored here because we know our service.
			Dim serviceHost As New ServiceHost(GetType(HelloService), baseAddresses)
			Return serviceHost

		End Function

	End Class