' <Snippet5>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions

Namespace RemotingSamples
   Public Class HelloService
      Inherits MarshalByRefObject

      Public Function HelloMethod(name As String) As String
         Console.WriteLine("Hello " + name)
         Return "Hello " + name
      End Function 'HelloMethod

<SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.Infrastructure)> _
      Public Overrides Function InitializeLifetimeService() As Object
         Dim baseLease As ILease = CType(MyBase.InitializeLifetimeService(), ILease)
         If baseLease.CurrentState = LeaseState.Initial Then
            ' For demonstration the initial time is kept small.
            ' in actual scenarios it will be large.
            baseLease.InitialLeaseTime = TimeSpan.FromSeconds(15)
            baseLease.RenewOnCallTime = TimeSpan.FromSeconds(15)
            baseLease.SponsorshipTimeout = TimeSpan.FromMinutes(2)
         End If
         Return baseLease
      End Function 'InitializeLifetimeService
   End Class 'HelloService
End Namespace 'RemotingSamples
' </Snippet5>
