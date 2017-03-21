Namespace TestPrincipalPermission
	Friend Class PrincipalPermissionModeWindows

		<ServiceContract> _
		Private Interface ISecureService
			<OperationContract> _
			Function Method1() As String
		End Interface

		Private Class SecureService
			Implements ISecureService
            <PrincipalPermission(SecurityAction.Demand, Role:="everyone")> _
            Public Function Method1() As String Implements ISecureService.Method1
                Return String.Format("Hello, ""{0}""", Thread.CurrentPrincipal.Identity.Name)
            End Function

		End Class

		Public Sub Run()
			Dim serviceUri As New Uri("http://localhost:8006/Service")
			Dim service As New ServiceHost(GetType(SecureService))
			service.AddServiceEndpoint(GetType(ISecureService), GetBinding(), serviceUri)
			service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles
			service.Open()

			Dim sr As New EndpointAddress(serviceUri, EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name))
			Dim cf As New ChannelFactory(Of ISecureService)(GetBinding(), sr)
			Dim client As ISecureService = cf.CreateChannel()
			Console.WriteLine("Client received response from Method1: {0}", client.Method1())
			CType(client, IChannel).Close()
			Console.ReadLine()
			service.Close()

		End Sub

		Public Shared Function GetBinding() As Binding
			Dim binding As New WSHttpBinding(SecurityMode.Message)
			binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows
			Return binding
		End Function
	End Class
End Namespace