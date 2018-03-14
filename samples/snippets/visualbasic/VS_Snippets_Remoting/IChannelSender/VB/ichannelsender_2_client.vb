' System.Runtime.Remoting.Channels.IChannelSender
' System.Runtime.Remoting.Channels.IChannelSender.CreateMessageSink()

' The following program demonstrates the usage of IChannelSender 
' interface and its 'CreateMessageSink' method in the namespace
' 'System.Runtime.Remoting.Channels'. This program creates and
' registers an IChannelSender of type 'HttpClientChannel'.
' It sets the priority of the channel and it displays the
' property values of 'HttpClientChannel'.

' <Snippet1>
Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.Remoting.Channels.Http
Imports System.Security.Permissions

Public Class MyClient
   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Shared Sub Main()
      Try
         ' Create the 'IDictionary' to set the server object properties.
         Dim myDictionary As New Hashtable()
         myDictionary("name") = "HttpClientChannel"
         myDictionary("priority") = 2
         ' Set the properties along with the constructor.
         Dim myIChannelSender As New HttpClientChannel(myDictionary, _
                 New BinaryClientFormatterSinkProvider())
         ' Register the server channel.
         ChannelServices.RegisterChannel(myIChannelSender)
         Dim myHelloServer1 As MyHelloServer = CType(Activator.GetObject(GetType(MyHelloServer), _
                 "http://localhost:8085/SayHello"), MyHelloServer)
         If myHelloServer1 Is Nothing Then
            Console.WriteLine("Could not locate server")
         Else
            Console.WriteLine(myHelloServer1.myHelloMethod("Client"))
            ' Get the name of the channel.
            Console.WriteLine("Channel Name :" + myIChannelSender.ChannelName)
            ' Get the channel priority.
            Console.WriteLine("ChannelPriority :" + myIChannelSender.ChannelPriority.ToString())
            Dim myString As String = ""
            Dim myObjectURI1 As String = ""
            Console.WriteLine("Parse :" + myIChannelSender.Parse("http://localhost:8085/SayHello", _
                 myString) + myString)
' <Snippet2>
            ' Get the channel message sink that delivers message to specified url.
            Dim myIMessageSink As IMessageSink = _
                 myIChannelSender.CreateMessageSink("http://localhost:8085/NewEndPoint", _
                 Nothing, myObjectURI1)
            Console.WriteLine("Channel message sink used :" + CType(myIMessageSink,Object).ToString())
' </Snippet2>
            Console.WriteLine("URI of new channel message sink :" + myObjectURI1)
         End If
      Catch ex As Exception
         Console.WriteLine("Following exception is raised on client side : " + ex.Message)
      End Try
   End Sub 'Main
End Class 'MyClient
' </Snippet1>