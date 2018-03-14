' <Snippet3>
Imports System
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions

Public Class ClientActivatedType
   Inherits MarshalByRefObject
   
   
   ' override the lease settings for this object
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Overrides Function InitializeLifetimeService() As [Object]
      Dim lease As New MyLease(CType(MyBase.InitializeLifetimeService(), ILease))
      Return lease
   End Function 'InitializeLifetimeService
   
   
   Public Function RemoteMethod(name As String) As String
      ' announce to the server that we've been called.
      Console.WriteLine("ClientActivatedType.RemoteMethod called by {0}", name)
      
      ' report our client identity name
      Return "Hello, " + name + "!"
   End Function 'RemoteMethod
End Class 'ClientActivatedType

Public Class MyLease
   Inherits MarshalByRefObject
   Implements ILease
   
   Private baseLease As ILease
   
   
   Public Sub New(oldLease As ILease)
      Console.WriteLine("Constructing MyLease.")
      If oldLease Is Nothing Then
         Console.WriteLine("CRUD!")
      End If
      baseLease = oldLease
   End Sub 'New
   
   
   Public ReadOnly Property CurrentLeaseTime() As TimeSpan _
      Implements ILease.CurrentLeaseTime
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Get
         Dim time As TimeSpan = baseLease.CurrentLeaseTime
         Console.WriteLine("The CurrentLeaseTime property returned {0}.", time.Milliseconds)
         Return time
      End Get
   End Property
   
   
   Public ReadOnly Property CurrentState() As LeaseState _
      Implements ILease.CurrentState
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Get
         Dim state As LeaseState = baseLease.CurrentState
         Console.WriteLine("The CurrentState property returned {0}.", state)
         Return state
      End Get
   End Property
   
   
   Public Property InitialLeaseTime() As TimeSpan _
      Implements ILease.InitialLeaseTime
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Get
         Dim time As TimeSpan = baseLease.InitialLeaseTime
         Console.WriteLine("The InitialLeaseTime property returned {0}.", time.Milliseconds)
         Return time
      End Get
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Set
         baseLease.InitialLeaseTime = value
         Console.WriteLine("The InitialLeaseTime property was set to {0}.", value.Milliseconds)
      End Set
   End Property
   
   
   Public Property RenewOnCallTime() As TimeSpan _
      Implements ILease.RenewOnCallTime
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Get
         Dim time As TimeSpan = baseLease.RenewOnCallTime
         Console.WriteLine("The RenewOnCallTime property returned {0}.", time.Milliseconds)
         Return time
      End Get
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Set
         Console.WriteLine("The RenewOnCallTime property was set to {0}.", value.Milliseconds)
         baseLease.RenewOnCallTime = value
      End Set
   End Property
   
   
   Public Property SponsorshipTimeout() As TimeSpan _
      Implements ILease.SponsorshipTimeout
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Get
         Dim time As TimeSpan = baseLease.SponsorshipTimeout
         Console.WriteLine("The SponsorshipTimeout property returned {0}.", time.Milliseconds)
         Return time
      End Get
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
      Set
         Console.WriteLine("The SponsorshipTimeout property was set to {0}.", value.Milliseconds)
         baseLease.SponsorshipTimeout = value
      End Set
   End Property
   
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _   
   Overloads Public Sub Register(sponsor As ISponsor) _
      Implements ILease.Register
      Console.WriteLine("The sponsor {0} has been registered with the current lease.", sponsor)
      baseLease.Register(sponsor)
   End Sub 'Register
   
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _   
   Overloads Public Sub Register(sponsor As ISponsor, renewalTime As TimeSpan) _
      Implements ILease.Register
      Console.WriteLine("The sponsor {0} has been registered with the current lease for {0} milliseconds...", _
                         sponsor, renewalTime.Milliseconds)
      baseLease.Register(sponsor, renewalTime)
   End Sub 'Register
   
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _   
   Public Function Renew(renewalTime As TimeSpan) As TimeSpan _
      Implements ILease.Renew
      Console.WriteLine("The lease has been renewed for {0} milliseconds...", renewalTime.Milliseconds)
      Return baseLease.Renew(renewalTime)
   End Function 'Renew
   
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _   
   Public Sub Unregister(sponsor As ISponsor) _
      Implements ILease.Unregister
      Console.WriteLine("The sponsor {0} has been unregistered from the current lease.", sponsor)
      baseLease.Unregister(sponsor)
   End Sub 'Unregister
   
End Class 'MyLease
' </Snippet3>
