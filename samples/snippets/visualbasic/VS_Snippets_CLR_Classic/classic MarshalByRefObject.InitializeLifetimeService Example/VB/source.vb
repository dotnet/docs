Imports System
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions

' <Snippet1>
Public Class LSClass
    Inherits MarshalByRefObject
    
    <SecurityPermissionAttribute(SecurityAction.Demand, _
                                 Flags:=SecurityPermissionFlag.Infrastructure)> _
    Public Overrides Function InitializeLifetimeService() As Object
        Dim lease As ILease = CType(MyBase.InitializeLifetimeService(), ILease)
        If lease.CurrentState = LeaseState.Initial Then
            lease.InitialLeaseTime = TimeSpan.FromMinutes(1)
            lease.SponsorshipTimeout = TimeSpan.FromMinutes(2)
            lease.RenewOnCallTime = TimeSpan.FromSeconds(2)
        End If
        Return lease
    End Function


    Public Shared Sub Main()  
    ' The main thread processing is here.
    End Sub
End Class

' </Snippet1>