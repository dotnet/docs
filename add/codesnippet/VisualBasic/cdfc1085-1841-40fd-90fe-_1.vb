		Public Overrides Overloads Function CreateServiceHost(ByVal service As String, ByVal baseAddresses() As Uri) As ServiceHostBase


			' The service parameter is ignored here because we know our service.
			Dim serviceHost As New ServiceHost(GetType(HelloService), baseAddresses)
			Return serviceHost

		End Function