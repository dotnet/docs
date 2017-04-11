'<snippet0>
Imports System.Security.Permissions
Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.IdentityModel.Claims
Imports System.IdentityModel.Policy
Imports System.Security.Principal
Imports System.ServiceModel
Imports System.ServiceModel.Description
Imports System.ServiceModel.Channels
Imports System.Threading
Imports System.Web.Security
'</snippet0>


Namespace Samples
	Public Class Test
		Public Shared Sub Run()
			Dim baseUri As New Uri("http://ServiceModelSamples")

			'<snippet3>
			'<snippet1>
			Dim myServiceHost As New ServiceHost(GetType(Calculator), baseUri)
			Dim myServiceBehavior As ServiceAuthorizationBehavior = myServiceHost.Description.Behaviors.Find(Of ServiceAuthorizationBehavior)()
			myServiceBehavior.PrincipalPermissionMode = PrincipalPermissionMode.UseAspNetRoles
			'</snippet1>
			'<snippet5>
			Dim sm As New MyServiceAuthorizationManager()
			myServiceBehavior.ServiceAuthorizationManager = sm
			'</snippet5>
			'</snippet3>
			'<snippet11>
			Dim myCustomRoleProvider As RoleProvider = myServiceBehavior.RoleProvider
			'</snippet11>

		End Sub
	End Class


	Public Class Calculator
		'<snippet2>
		' Only members of the CalculatorClients group can call this method.
		<PrincipalPermission(SecurityAction.Demand, Role := "Users")> _
		Public Function Add(ByVal a As Double, ByVal b As Double) As Double
			Return a + b
		End Function
		'</snippet2>


		'<snippet10>
		' Only a client authenticated with a valid certificate that has the 
		' specified subject name and thumbprint can call this method.
		<PrincipalPermission(SecurityAction.Demand, Name := "CN=ReplaceWithSubjectName; 123456712345677E8E230FDE624F841B1CE9D41E")> _
		Public Function Multiply(ByVal a As Double, ByVal b As Double) As Double
			Return a * b
		End Function
		'</snippet10>


		'<snippet4>
		' Only a client authenticated with a valid certificate that has the 
		' specified thumbprint can call this method.
		<PrincipalPermission(SecurityAction.Demand, Name := "; 123456712345677E8E230FDE624F841B1CE9D41E")> _
		Public Function Divide(ByVal a As Double, ByVal b As Double) As Double
			Return a * b
		End Function
		'</snippet4>

		'<snippet9>        
		<PrincipalPermission(SecurityAction.Demand, Role := "AspCustomRole")> _
		Public Function Subtract(ByVal a As Double, ByVal b As Double) As Double
			Return a * b
		End Function
		'</snippet9>

		'<snippet13>
		<PrincipalPermission(SecurityAction.Demand, Role := "Administrators")> _
		Public Function ReadFile(ByVal fileName As String) As String
			' Code not shown.
			Return "Not implemented"
		End Function
		'</snippet13>
	End Class

	'<snippet6>
	Public Class MyServiceAuthorizationManager
		Inherits ServiceAuthorizationManager
		Protected Overrides Function CheckAccessCore(ByVal operationContext As OperationContext) As Boolean
			' Extract the action URI from the OperationContext. Match this against the claims
			' in the AuthorizationContext.
			Dim action As String = operationContext.RequestContext.RequestMessage.Headers.Action
			Console.WriteLine("action: {0}", action)

			' Iterate through the various claim sets in the AuthorizationContext.
			For Each cs As ClaimSet In operationContext.ServiceSecurityContext.AuthorizationContext.ClaimSets
				' Examine only those claim sets issued by System.
				If cs.Issuer Is ClaimSet.System Then
					' Iterate through claims of type "http://example.org/claims/allowedoperation".
					For Each c As Claim In cs.FindClaims("http://example.org/claims/allowedoperation", Rights.PossessProperty)
						' Write the claim resource to the console.
						Console.WriteLine("resource: {0}", c.Resource.ToString())

						' If the claim resource matches the action URI, then return true to allow access.
						If action = c.Resource.ToString() Then
							Return True
						End If
					Next c
				End If
			Next cs

			' If this point is reached, return false to deny access.
			Return False
		End Function
	End Class
	'</snippet6>

End Namespace

'<snippet14>
'<snippet7>
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
'</snippet7>

'<snippet8>
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
			' <snippet20>
			Dim serviceUri As New Uri("http://localhost:8006/Service")
			Dim service As New ServiceHost(GetType(SecureService))
			service.AddServiceEndpoint(GetType(ISecureService), GetBinding(), serviceUri)
			Dim policies As New List(Of IAuthorizationPolicy)()
			policies.Add(New CustomAuthorizationPolicy())
			service.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly()
			service.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom
			service.Open()
			' </snippet20>

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
'</snippet8>
'</snippet14>