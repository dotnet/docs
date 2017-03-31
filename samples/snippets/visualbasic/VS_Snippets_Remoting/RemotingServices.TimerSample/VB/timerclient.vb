 ' System.Runtime.Remoting.RemotingServices.GetLifetimeService
' This sample is of a remote client for a group coffee timer.
' Since the client must stay connected to a stateful server object
' for minutes without calling it, it needs to register as a sponsor
' of the lease to prevent the server from being collected.
' Multiple clients can connect to the same timer object, and receive
' notification when the timer expires.
' System.Runtime.Remoting.RemotingServices.GetLifetimeService
' <Snippet1>
Imports System
Imports System.Collections
Imports System.Net.Sockets
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Lifetime
Imports System.Security.Permissions
Imports TimerService



Public Class TimerClient
    Inherits MarshalByRefObject
    Implements ISponsor
    
    Public Shared Sub Main() 
        Dim myClient As New TimerClient()
    
    End Sub 'Main
    
    <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
    Public Sub New() 
        ' Registers the HTTP Channel so that this client can receive
        ' events from the remote service.
        Dim serverProv As New BinaryServerFormatterSinkProvider()
        serverProv.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
        Dim clientProv As New BinaryClientFormatterSinkProvider()
        
        Dim props As New Hashtable()
        props("port") = 0
        Dim channel As New HttpChannel(props, clientProv, serverProv)
        ChannelServices.RegisterChannel(channel)
        
        Dim remoteType As New WellKnownClientTypeEntry(GetType(TimerService), "http://localhost:9000/MyService/TimerService.soap")
        RemotingConfiguration.RegisterWellKnownClientType(remoteType)
        
        Dim groupTimer As New TimerService()
        groupTimer.MinutesToTime = 4.0
        
        ' Registers this client as a lease sponsor so that it can
        ' prevent the expiration of the TimerService.
        Dim leaseObject As ILease = CType(RemotingServices.GetLifetimeService(groupTimer), ILease)
        leaseObject.Register(Me)
        
        ' Subscribes to the event so that the client can receive notifications from the server.
        AddHandler groupTimer.TimerExpired, AddressOf OnTimerExpired
        Console.WriteLine("Connected to TimerExpired event")
        
        groupTimer.Start()
        Console.WriteLine("Timer started for {0} minutes.", groupTimer.MinutesToTime)
        Console.WriteLine("Press enter to end the client process.")
        Console.ReadLine()
    
    End Sub 'New
    
    
    Private Sub OnTimerExpired(ByVal [source] As Object, ByVal e As TimerServiceEventArgs) 
        Console.WriteLine("TimerHelper.OnTimerExpired: {0}", e.Message)
    
    End Sub 'OnTimerExpired
    
    <SecurityPermission(SecurityAction.LinkDemand, Flags := SecurityPermissionFlag.Infrastructure)> _
    Public Function Renewal(ByVal lease As ILease) As TimeSpan Implements ISponsor.Renewal
        Console.WriteLine("TimerClient: Renewal called.")
        Return TimeSpan.FromMinutes(0.5)
    
    End Function 'Renewal
End Class 'TimerClient
' </Snippet1>