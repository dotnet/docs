' System.Runtime.Remoting.Lifetime.ISponsor
' System.Runtime.Remoting.Lifetime.ISponsor.Renewal

' The following program demonstrates the 'ISponsor' interface and its 'Renewal' method.
' It defines 'MyClientSponsor' which implements 'ISponsor' interface. The server and
' client is created. The client registers a sponsor that(after the initial lease time)
' renews the lease at different time from that specified in the remote type.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
Imports MicroSoft.VisualBasic

Public Class Client
   <SecurityPermission(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      ' Load the configuration file.
      RemotingConfiguration.Configure("ISponsor_Client.config")
      Dim clientActivatedObject As New ClientActivatedType()
      
      Dim serverLease As ILease = _ 
                  CType(RemotingServices.GetLifetimeService(clientActivatedObject), ILease)
      Dim sponsor As New MyClientSponsor()
      
      ' Note: If you don't pass an initial time, the first request will be taken
      ' from the LeaseTime settings specified in the ISponsor_Server.config file.
      serverLease.Register(sponsor)
      
      Console.WriteLine("Client-activated object." + ControlChars.Newline + _
                                    clientActivatedObject.RemoteMethod())
      
      Console.WriteLine("Press enter to end the client application domain.")
      Console.ReadLine()
   End Sub 'Main
End Class 'Client
 
' <Snippet1>
' <Snippet2>
Public Class MyClientSponsor
   Inherits MarshalByRefObject
   Implements ISponsor 
   Private lastRenewal As DateTime
   
   Public Sub New()
      lastRenewal = DateTime.Now
   End Sub 'New
   
   <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
   Public Function Renewal(lease As ILease) As TimeSpan Implements ISponsor.Renewal
      Console.WriteLine("Request to renew the lease time.")
      Console.WriteLine("Time since last renewal: " + _ 
                      DateTime.op_Subtraction(DateTime.Now, lastRenewal).ToString())
      
      lastRenewal = DateTime.Now
      Return TimeSpan.FromSeconds(20)
   End Function 'Renewal
End Class 'MyClientSponsor
' </Snippet2>
' </Snippet1>