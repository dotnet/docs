' System.Runtime.Remoting.Channels.CommonTransportKeys
' System.Runtime.Remoting.Channels.CommonTransportKeys.IPAddress
' System.Runtime.Remoting.Channels.CommonTransportKeys.ConnectionId
' System.Runtime.Remoting.Channels.CommonTransportKeys.RequestUri

' This program demonstrates 'CommonTransportKeys' class and the static members 'IPAddress',
' 'ConnectionId','RequestUri'. 'LoggingClientChannelSinkProvider' and 'LoggingServerChannelSinkProvider'
' classes are created which inherits'IClientChannelSinkProvider' and 'IServerChannelSinkProvider' 
' respectively.'ProcessMessage' method is having 'ITransportHeaders' parameter which gives the required
' header values.

' Note: This snippet assumes CommonTransportKeys_Server.vb, CommonTransportKeys_Client.vb,
' CommonTransportKeys_Share.vb files along with channels.config, server.exe.config, client.exe.config 
' config files.

Imports System
Imports System.Collections
Imports System.IO
Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Messaging
Imports System.Runtime.InteropServices
Imports System.Security.Permissions

Namespace Logging
 
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _   
   Public Class LoggingClientChannelSinkProvider
      Implements IClientChannelSinkProvider 
      Private next1 As IClientChannelSinkProvider = Nothing
      
      Public Function CreateSink(channel1 As IChannelSender, url1 As String, _ 
             remoteChannelData As Object) As IClientChannelSink implements _ 
                                       IClientChannelSinkProvider.CreateSink
         Dim localNextSink As IClientChannelSink = Nothing
         If Not (next1 Is Nothing) Then
            localNextSink = next1.CreateSink(channel1, url1, remoteChannelData)
            If localNextSink Is Nothing Then
               Return Nothing
            End If
         End If
         Return New LoggingClientChannelSink(localNextSink)
      End Function 'CreateSink
      
      Public Property [Next]() As IClientChannelSinkProvider _ 
                                   implements IClientChannelSinkProvider.Next
         Get
            Return next1
         End Get
         Set
            next1 = value
         End Set
      End Property
   End Class 'LoggingClientChannelSinkProvider
  
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _  
   Friend Class LoggingClientChannelSink
      Inherits BaseChannelObjectWithProperties
      Implements IClientChannelSink 
      Private nextSink1 As IClientChannelSink = Nothing
      
      Public Sub New(localNextSink As IClientChannelSink)
         MyBase.new()
         nextSink1 = localNextSink
      End Sub 'New

      Public Sub ProcessMessage(msg As IMessage, requestHeaders As ITransportHeaders, _ 
                 requestStream As Stream, ByRef responseHeaders As ITransportHeaders, _ 
                 ByRef responseStream As Stream) implements IClientChannelSink.ProcessMessage
              nextSink1.ProcessMessage _ 
                         (msg, requestHeaders, requestStream, responseHeaders, responseStream)
      End Sub 'ProcessMessage
      
      Public Sub AsyncProcessRequest(sinkStack As IClientChannelSinkStack, msg As IMessage, _ 
                 headers As ITransportHeaders, stream1 As Stream) _ 
                 Implements IClientChannelSink.AsyncProcessRequest
         sinkStack.Push(Me, Nothing)
         nextSink1.AsyncProcessRequest(sinkStack, msg, headers, stream1)
      End Sub 'AsyncProcessRequest

      Public Sub AsyncProcessResponse(sinkStack As IClientResponseChannelSinkStack, _ 
                  state As Object, headers As ITransportHeaders, stream1 As Stream) _ 
                                    implements IClientChannelSink.AsyncProcessResponse
         sinkStack.AsyncProcessResponse(headers, stream1)
      End Sub 'AsyncProcessResponse
      
      Public Function GetRequestStream(msg As IMessage, headers As ITransportHeaders) _ 
                             As Stream Implements IClientChannelSink.GetRequestStream
         Return Nothing
      End Function 'GetRequestStream
      
      Public ReadOnly Property NextChannelSink() As IClientChannelSink _ 
                             Implements IClientChannelSink.NextChannelSink
         Get
            Return nextSink1
         End Get
      End Property

     Public Overrides ReadOnly Property Properties() As Collections.IDictionary _ 
                Implements IClientChannelSink.Properties
        Get
	  return nothing		
        End Get
        End Property
   End Class 'LoggingClientChannelSink
    
' <Snippet1>
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
   Public Class LoggingServerChannelSinkProvider
      Implements IServerChannelSinkProvider 
      Private next2 As IServerChannelSinkProvider = Nothing
      
      Public Sub New(properties As IDictionary, providerData As ICollection)
      End Sub 'New
      
      Public Sub GetChannelData(channelData As IChannelDataStore) _ 
                                  Implements IServerChannelSinkProvider.GetChannelData
      End Sub 'GetChannelData
      
      Public Function CreateSink(channel1 As IChannelReceiver) As IServerChannelSink _ 
                                        Implements IServerChannelSinkProvider.CreateSink
         Dim localNextSink As IServerChannelSink = Nothing
         If Not (next2 Is Nothing) Then
            localNextSink = next2.CreateSink(channel1)
         End If
         Return New LoggingServerChannelSink(localNextSink)
      End Function 'CreateSink
      
      Public Property [Next]() As IServerChannelSinkProvider Implements _ 
                                                        IServerChannelSinkProvider.Next
         Get
            Return next2
         End Get
         Set
            next2 = value
         End Set
      End Property
   End Class 'LoggingServerChannelSinkProvider
   
   <PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _ 
   Friend Class LoggingServerChannelSink
      Inherits BaseChannelObjectWithProperties
      Implements IServerChannelSink 
      Private nextSink2 As IServerChannelSink = Nothing
      Private bEnabled2 As Boolean = True
      
      Public Sub New(localNextSink As IServerChannelSink)
         MyBase.new()
         nextSink2 = localNextSink
      End Sub 'New
      
     Public Function ProcessMessage(   ByVal sinkStack As IServerChannelSinkStack, _
         ByVal requestMsg As IMessage, _
         ByVal requestHeaders As ITransportHeaders, _
         ByVal requestStream As Stream, _
         <Out> ByRef responseMsg As IMessage, _
         <Out> ByRef responseHeaders As ITransportHeaders, _
         <Out> ByRef responseStream As Stream _
      ) As ServerProcessing _ 
         Implements IServerChannelSink.ProcessMessage
         If bEnabled2 Then
            Console.WriteLine("----------Request Headers-----------")
' <Snippet2>
            Console.WriteLine(CommonTransportKeys.IPAddress.ToString() + ":" + _ 
                                 requestHeaders(CommonTransportKeys.IPAddress).ToString())
' </Snippet2>
' <Snippet3>
         Console.WriteLine(CommonTransportKeys.ConnectionId.ToString() + ":" + _ 
                                 requestHeaders(CommonTransportKeys.ConnectionId).ToString())
' </Snippet3>
' <Snippet4>
         Console.WriteLine(CommonTransportKeys.RequestUri.ToString() + ":" + _ 
                                 requestHeaders(CommonTransportKeys.RequestUri).ToString())
' </Snippet4>
         End If
         sinkStack.Push(Me, Nothing)
         Dim processing As ServerProcessing = _ 
                                      nextSink2.ProcessMessage _ 
                  (sinkStack, requestMsg, requestHeaders, requestStream, responseMsg, responseHeaders, responseStream)
         
         Select Case processing
            Case ServerProcessing.Complete
                  sinkStack.Pop(Me)
            Case ServerProcessing.OneWay
                  sinkStack.Pop(Me)
            Case ServerProcessing.Async
                  sinkStack.Store(Me, Nothing)
         End Select
         Return processing
      End Function 'ProcessMessage
      
      Public Sub AsyncProcessResponse(sinkStack As IServerResponseChannelSinkStack, _ 
              state As Object, msg As IMessage, headers As ITransportHeaders, stream1 As Stream) _ 
                                       Implements IServerChannelSink.AsyncProcessResponse
         sinkStack.AsyncProcessResponse(msg, headers, stream1)
      End Sub 'AsyncProcessResponse
      
      Public Function GetResponseStream(sinkStack As IServerResponseChannelSinkStack, _ 
                  state As Object, msg As IMessage, headers As ITransportHeaders) As Stream _ 
                                       Implements IServerChannelSink.GetResponseStream
         Return Nothing
      End Function 'GetResponseStream
      
      Public ReadOnly Property NextChannelSink() As IServerChannelSink _ 
                                          Implements IServerChannelSink.NextChannelSink
         Get
            Return nextSink2
         End Get
      End Property

      Public Overrides ReadOnly Property Properties() As Collections.IDictionary _ 
                  Implements IServerChannelSink.Properties
         Get
		return nothing		
         End Get
      End Property
   End Class 'LoggingServerChannelSink
' </Snippet1>
End Namespace 'Logging 
