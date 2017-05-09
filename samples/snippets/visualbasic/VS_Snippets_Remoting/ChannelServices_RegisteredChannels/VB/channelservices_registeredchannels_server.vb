' System.Runtime.Remoting.Channels.ChannelServices
' System.Runtime.Remoting.Channels.ChannelServices.RegisteredChannels
' System.Runtime.Remoting.Channels.ChannelServices.UnregisterChannel(IChannel[])

' The following example demonstrates the property 'RegisteredChannels'
' of the class 'ChannelServices', its method 'UnregisterChannel', 
' and usage of the class 'ChannelServices'. The example demonstrates 
' the remoting version of a server. When a client calls the
' 'HelloMethod' on the 'HelloServer' class, the server object appends the
' string passed from the client to the string "Hi There" and returns the
' resulting string back to the client.

Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting.Channels.Http
Imports System.Security.Permissions

Namespace RemotingSamples
   Public Class MyChannelServices_Server
      <PermissionSet(SecurityAction.LinkDemand)> _
      Public Shared Sub Main()
         Try
' <Snippet1>
            ' Create and register 'HttpChannel'.
            Dim myHttpChannel As New HttpChannel(8085)
            ChannelServices.RegisterChannel(myHttpChannel)
            ' Create and register 'TcpChannel'.
            Dim myTcpChannel As New TcpChannel(8080)
            ChannelServices.RegisterChannel(myTcpChannel)
' <Snippet2>
            ' Retrieve and print information about the registered channels.
            Dim myIChannelArray As IChannel() = ChannelServices.RegisteredChannels
            Dim i As Integer
            For i = 0 To myIChannelArray.Length - 1
               Console.WriteLine("Name of Channel: {0}", myIChannelArray(i).ChannelName)
               Console.WriteLine("Priority of Channel: {0}", + myIChannelArray(i).ChannelPriority)
            Next i
' </Snippet2>
            RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType _
            ("RemotingSamples.HelloServer,ChannelServices_RegisteredChannels_Share"), "SayHello", _
                                                   WellKnownObjectMode.SingleCall)
' <Snippet3>   
            System.Console.WriteLine("Hit <enter> to unregister the channels...")
            System.Console.ReadLine()
            ' Unregister the 'HttpChannel' and 'TcpChannel' channels.
            ChannelServices.UnregisterChannel(myTcpChannel)
            ChannelServices.UnregisterChannel(myHttpChannel)
            Console.WriteLine("Unregistered the channels.")
' </Snippet3>   
            System.Console.WriteLine("Hit <enter> to exit...")
            System.Console.ReadLine()
' </Snippet1>
         Catch e As Exception
            Console.WriteLine("Exception caught!!!")
            Console.WriteLine("The source of exception: " + e.Source)
            Console.WriteLine("The Message of exception: " + e.Message)
         End Try
      End Sub 'Main
   End Class 'MyChannelServices_Server
End Namespace 'RemotingSamples