' <Snippet1>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Lifetime
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Security.Permissions
Imports Microsoft.VisualBasic

Public Class Client
<SecurityPermission(SecurityAction.Demand)> _
   Public Shared Sub Main()      
      ChannelServices.RegisterChannel(New HttpChannel(0))
      RemotingConfiguration.RegisterActivatedClientType(GetType(ClientActivatedType), "http://localhost:8080")
      Dim CAObject As New ClientActivatedType()
      
      Dim serverLease As ILease = CType(RemotingServices.GetLifetimeService(CAObject), ILease)
      Dim sponsor As New MyClientSponsor()
      
      serverLease.Register(sponsor)
      
      ' Call same method on the object
      Console.WriteLine(("Client-activated object: " + CAObject.RemoteMethod("Bob")))
      
      Console.WriteLine("Press Enter to end the client application domain.")
      Console.ReadLine()
   End Sub 'Main
   
End Class 'Client


Public Class MyClientSponsor
   Inherits MarshalByRefObject
   Implements ISponsor 
   
   Private lastRenewal As DateTime   
   
   Public Sub New()
      Console.WriteLine("Activateing client...")
      lastRenewal = Now
   End Sub 'New
      
<SecurityPermission(SecurityAction.Demand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Function Renewal(lease As ILease) As TimeSpan _
      Implements ISponsor.Renewal

      Console.WriteLine("Renewing a lease for 4 seconds.")
      Console.WriteLine(("Time since last renewal:" + (Now.Subtract(lastRenewal)).ToString()))
      lastRenewal = Now
      
      Return TimeSpan.FromSeconds(4)
   End Function 'Renewal
   
End Class 'MyClientSponsor
' </Snippet1>
