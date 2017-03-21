Namespace CustomMode
	Public Class Test
		Public Shared Sub Main()
			Try
				Dim ppwm As New ShowPrincipalPermissionModeCustom()
				ppwm.Run()

			Catch exc As Exception
				Console.WriteLine("Error: {0}", exc.Message)
				Console.ReadLine()
			End Try
		End Sub
	End Class

	Friend Class ShowPrincipalPermissionModeCustom
		<ServiceContract> _
		Private Interface ISecureService
			<OperationContract> _
			Function Method1(ByVal request As String) As String
		End Interface

		<ServiceBehavior> _
		Private Class SecureService
			Implements ISecureService
            <PrincipalPermission(SecurityAction.Demand, Role:="everyone")> _
            Public Function Method1(ByVal request As String) As String Implements ISecureService.Method1
                Return String.Format("Hello, ""{0}""", Thread.CurrentPrincipal.Identity.Name)
            End Function
		End Class

		Public Sub Run()
			Dim serviceUri As New Uri("http://localhost:8006/Service")
			Dim service As New ServiceHost(GetType(SecureService))
			service.AddServiceEndpoint(GetType(ISecureService), GetBinding(), serviceUri)
			Dim policies As New List(Of IAuthorizationPolicy)()
			policies.Add(New CustomAuthorizationPolicy())
			service.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly()
			service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom
			service.Open()

			Dim sr As New EndpointAddress(serviceUri, EndpointIdentity.CreateUpnIdentity(WindowsIdentity.GetCurrent().Name))
			Dim cf As New ChannelFactory(Of ISecureService)(GetBinding(), sr)
			Dim client As ISecureService = cf.CreateChannel()
			Console.WriteLine("Client received response from Method1: {0}", client.Method1("hello"))
			CType(client, IChannel).Close()
			Console.ReadLine()
			service.Close()
		End Sub

		Public Shared Function GetBinding() As Binding
			Dim binding As New WSHttpBinding(SecurityMode.Message)
			binding.Security.Message.ClientCredentialType = MessageCredentialType.Windows
			Return binding
		End Function

		Private Class CustomAuthorizationPolicy
			Implements IAuthorizationPolicy
			Private id_Renamed As String = Guid.NewGuid().ToString()

			Public ReadOnly Property Id() As String Implements System.IdentityModel.Policy.IAuthorizationComponent.Id
				Get
					Return Me.id_Renamed
				End Get
			End Property

			Public ReadOnly Property Issuer() As ClaimSet Implements IAuthorizationPolicy.Issuer
				Get
					Return ClaimSet.System
				End Get
			End Property

			Public Function Evaluate(ByVal context As EvaluationContext, ByRef state As Object) As Boolean Implements IAuthorizationPolicy.Evaluate
                Dim obj As Object = Nothing
				If (Not context.Properties.TryGetValue("Identities", obj)) Then
					Return False
				End If

				Dim identities As IList(Of IIdentity) = TryCast(obj, IList(Of IIdentity))
				If obj Is Nothing OrElse identities.Count <= 0 Then
					Return False
				End If

				context.Properties("Principal") = New CustomPrincipal(identities(0))
				Return True
			End Function
		End Class

		Private Class CustomPrincipal
			Implements IPrincipal
			Private identity_Renamed As IIdentity
			Public Sub New(ByVal identity As IIdentity)
				Me.identity_Renamed = identity
			End Sub

			Public ReadOnly Property Identity() As IIdentity Implements IPrincipal.Identity
				Get
					Return Me.identity_Renamed
				End Get
			End Property

			Public Function IsInRole(ByVal role As String) As Boolean Implements IPrincipal.IsInRole
				Return True
			End Function
		End Class
	End Class
End Namespace