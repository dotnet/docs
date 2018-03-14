' This file is a support file for demonstrating the members of
' IChannelSender interface on the client side.

Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http

Class MyServer
   
   Shared Sub Main()
      Try
         Dim myString As String = ""
         Dim myPort As Integer = 8085
         ' Create the 'IDictionary' to set the server object properties.
         Dim myDictionary As New Hashtable()
         myDictionary("name") = "MyServerChannel1"
         myDictionary("priority") = 2
         myDictionary("port") = 8085
         ' Set the properties along with the constructor.
         Dim myHttpServerChannel As New HttpServerChannel(myDictionary, _
                 New BinaryServerFormatterSinkProvider())
         ' Register the server channel.
         ChannelServices.RegisterChannel(myHttpServerChannel)
         RemotingConfiguration.RegisterWellKnownServiceType(GetType(MyHelloServer), "SayHello", _
                 WellKnownObjectMode.SingleCall)
         ' Start listening on a specific port.
         myHttpServerChannel.StartListening(CType(myPort, Object))
         ' Get the name of the channel.
         Console.WriteLine("ChannelName : " + myHttpServerChannel.ChannelName)
         ' Get the channel priority.
         Console.WriteLine("ChannelPriority : " + myHttpServerChannel.ChannelPriority.ToString())
         ' Get the schema of the channel.
         Console.WriteLine("ChannelScheme : " + myHttpServerChannel.ChannelScheme)
         ' Get the channel URI.
         Console.WriteLine("GetChannelUri : " + myHttpServerChannel.GetChannelUri())
         ' Indicate whether 'IChannelReceiverHook' wants to be hooked into the outside listener service.
         Console.WriteLine("WantsToListen : " + myHttpServerChannel.WantsToListen.ToString())
         ' Extract the channel URI and the remote well known object URI from the specified URL.
         Console.WriteLine("Parsed : " + myHttpServerChannel.Parse(myHttpServerChannel.GetChannelUri() + _
                 "/SayHello", myString))
         Console.WriteLine("String : " + myString)
         Console.WriteLine("Hit <enter> to stop listening...")
         Console.ReadLine()
         ' Stop listening to channel.
         myHttpServerChannel.StopListening(CType(myPort, Object))
         Console.WriteLine("Hit <enter> to exit...")
         Console.ReadLine()
      Catch ex As Exception
         Console.WriteLine("The following exception is raised on server side : " + ex.Message)
      End Try
   End Sub 'Main
End Class 'MyServer