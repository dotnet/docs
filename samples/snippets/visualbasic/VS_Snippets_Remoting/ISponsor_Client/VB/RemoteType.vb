Imports System
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Principal
Imports System.Security.Permissions

<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public Class ClientActivatedType
   Inherits MarshalByRefObject
   
   ' Override the lease settings for this object.
   Public Overrides Function InitializeLifetimeService() As Object
      Dim lease As ILease = CType(MyBase.InitializeLifetimeService(), ILease)
      If lease.CurrentState = LeaseState.Initial Then
         lease.InitialLeaseTime = TimeSpan.FromSeconds(3)
         lease.SponsorshipTimeout = TimeSpan.FromSeconds(10)
         lease.RenewOnCallTime = TimeSpan.FromSeconds(2)
      End If
      Return lease
   End Function 'InitializeLifetimeService
   
   Public Function RemoteMethod() As String
      Console.WriteLine("ClientActivatedType.RemoteMethod called.")
      ' Report our client identity name.
      Return "RemoteMethodCalled. User name : " + WindowsIdentity.GetCurrent().Name
   End Function 'RemoteMethod
End Class 'ClientActivatedType