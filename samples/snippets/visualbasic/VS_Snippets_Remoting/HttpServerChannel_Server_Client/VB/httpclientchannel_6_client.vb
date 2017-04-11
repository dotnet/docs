' System.Runtime.Remoting.Channels.Http.HttpClientChannel
' System.Runtime.Remoting.Channels.Http.HttpClientChannel.ChannelName; System.Runtime.Remoting.Channels.Http.HttpClientChannel.ChannelPriority; System.Runtime.Remoting.Channels.Http.HttpClientChannel.Parse(); System.Runtime.Remoting.Channels.Http.HttpClientChannel.Keys; System.Runtime.Remoting.Channels.Http.HttpClientChannel.CreateMessageSink()

' The following program demonstrates the 'HttpClientChannel' class and
' 'ChannelName','ChannelPriority' , 'Keys', properties, and 'Parse',
' CreateMessageSink methods of 'HttpClientChannel' class. This program 
' create and registers 'HttpClientChannel'. This will change the priority
' of the 'HttpClientChannel' channel and it displays the property values 
' of 'HttpClientChannel'.

' <Snippet4>
Imports System
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Collections
Imports System.Runtime.Remoting.Messaging
Imports System.Security.Permissions

Public Class MyHttpClientChannel
   <PermissionSet(SecurityAction.LinkDemand)> _
   Public Shared Sub Main() 
      Try
' <Snippet5>
         ' Creating the 'IDictionary' to set the server object properties.
         Dim myDictionary As  New Hashtable()
         myDictionary("name") = "HttpClientChannel"
         myDictionary("priority") = 2
         ' Set the properties along with the constructor.
       Dim myHttpClientChannel As New _
                 HttpClientChannel( myDictionary, New BinaryClientFormatterSinkProvider)
         ' Register the server channel.
         ChannelServices.RegisterChannel(myHttpClientChannel)
         Dim myHelloServer1 As MyHelloServer = CType(Activator.GetObject(GetType(MyHelloServer), _
                 "http://localhost:8085/SayHello"), MyHelloServer)
         If myHelloServer1 Is Nothing Then
            System.Console.WriteLine("Could not locate server")
         Else
            Console.WriteLine(myHelloServer1.myHelloMethod("Client"))
            ' Get the name of the channel.
            Console.WriteLine("Channel Name :" + myHttpClientChannel.ChannelName)
            ' Get the channel priority.
            Console.WriteLine("ChannelPriority :" + myHttpClientChannel.ChannelPriority.ToString())
            Dim myString, myObjectURI1 As String
            Console.WriteLine("Parse :" + _
                 myHttpClientChannel.Parse("http://localhost:8085/SayHello", myString) + myString)
            ' Get the key count.
            System.Console.WriteLine("Keys.Count : " + myHttpClientChannel.Keys.Count.ToString())
            ' Get the channel message sink that delivers message to the specified url.
            Dim myIMessageSink As IMessageSink =myHttpClientChannel.CreateMessageSink( _
                 "http://localhost:8085/NewEndPoint", Nothing, myObjectURI1)
          Console.WriteLine("The channel message sink that delivers the messages to the URL is :" + _
                  CType(myIMessageSink, Object).ToString)
          Console.WriteLine("URI of the new channel message sink is: " + myObjectURI1)
         End If 
' </Snippet5>
      Catch ex As Exception
         Console.WriteLine("The following exception is raised on client side :" + ex.Message)
      End Try
   End Sub 'Main
End Class 'MyHttpClientChannel
' </Snippet4>
