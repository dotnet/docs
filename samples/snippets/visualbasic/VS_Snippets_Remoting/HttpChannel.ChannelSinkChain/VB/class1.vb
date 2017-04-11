Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.IO
Imports System.Runtime.Remoting.Messaging

 _

' This snippet demonstrates HttpChannel.ChannelSinkChain.
' client code should NOT call this call directly. So, I'm
' writing a class that implements the member as HttpChannel
' does. That is, it returns the first sink after the transport
' sink. ie... if the sink chain is transport=>encryption=>formatter
' then this member should return encryption.
' <Snippet1>
Class CustomChannel
   Inherits BaseChannelWithProperties
   Implements IChannelReceiverHook, IChannelReceiver, IChannel, IChannelSender
   
   ' TransportSink is a private class defined within CustomChannel.
   Private myTransportSink As TransportSink
   
   
   Public ReadOnly Property ChannelSinkChain() As IServerChannelSink Implements IChannelReceiverHook.ChannelSinkChain
      Get
         Return myTransportSink.NextChannelSink
      End Get
   End Property
    
   ' Rest of CustomChannel's implementation...
   '</Snippet1>
   Public Shared Sub Main()
      Dim channel As New CustomChannel(8085)
      channel.AddHookChannelUri("TempConverter")            
      System.Console.WriteLine(channel.ChannelSinkChain)
   End Sub 'Main
   
   Private dataStore As ChannelDataStore
   Private wantsToListenVar As Boolean
   Private priority As Integer
   Private socket As String
   
   
   Public Sub New()
      Dim formatterSink As New BinaryServerFormatterSink(BinaryServerFormatterSink.Protocol.Http, Nothing, Me)
      myTransportSink = New TransportSink(formatterSink)
      priority = 0
      dataStore = New ChannelDataStore(Nothing)
      wantsToListenVar = True
      socket = ""
   End Sub 'New
   
   
   Public Sub New(portNum As Integer)
      Dim formatterSink As New BinaryServerFormatterSink(BinaryServerFormatterSink.Protocol.Http, Nothing, Me)
      myTransportSink = New TransportSink(formatterSink)
      priority = 0
      dataStore = New ChannelDataStore(Nothing)
      wantsToListenVar = False
      socket = "http://localhost:" + portNum.ToString()
   End Sub 'New
   
   
   Public Sub New(properties As IDictionary, clientSinkProvider As IClientChannelSinkProvider, serverSinkProvider As IServerChannelSinkProvider)
   End Sub 'New
   
   
   
   
   Public ReadOnly Property ChannelName() As String Implements IChannel.ChannelName
      Get
         Return "custom"
      End Get
   End Property
   
   
   Public ReadOnly Property ChannelData() As Object Implements IChannelReceiver.ChannelData
      Get
         Return CType(dataStore, Object)
      End Get
   End Property
   
   
   Public Sub AddHookChannelUri(channelUri As String) Implements IChannelReceiverHook.AddHookChannelUri
      
      If Not (channelUri Is Nothing) Then
         Dim uris As String() = dataStore.ChannelUris
         
         If uris Is Nothing Then
            Dim newUris(1) As String
            newUris(0) = channelUri
            dataStore.ChannelUris = newUris
         Else
            Dim msg As String = "This channel is already listening for data, " + "and can't be hooked into at this stage."
            Throw New System.Runtime.Remoting.RemotingException(msg)
         End If
      End If
   End Sub 'AddHookChannelUri
   
   
   Public ReadOnly Property WantsToListen() As Boolean Implements IChannelReceiverHook.WantsToListen
      Get
         Return wantsToListenVar
      End Get
   End Property 
   
   Public ReadOnly Property ChannelPriority() As Integer Implements IChannel.ChannelPriority
      Get
         Return priority
      End Get
   End Property 
   
   Public Overloads ReadOnly Property ChannelScheme() As String Implements IChannelReceiverHook.ChannelScheme
      Get
         Return "http"
      End Get
   End Property
    
   Public Function GetUrlsForUri(uri As String) As String() Implements IChannelReceiver.GetUrlsForUri
      Dim urls(dataStore.ChannelUris.Length) As String
      Dim i As Integer = 0
      Dim currUri As String
      For Each currUri In  dataStore.ChannelUris
         urls(i) = socket + "/" + currUri
         i += 1
      Next currUri
      Return urls
   End Function 'GetUrlsForUri
   
   
   Public Sub StartListening(data As Object) Implements IChannelReceiver.StartListening
   End Sub 'StartListening
    
   
   Public Sub StopListening(data As Object) Implements IChannelReceiver.StopListening
   End Sub 'StopListening
    
   
   Public Function Parse(url As String, ByRef objectURI As String) As String Implements IChannel.Parse
      Dim lastSlash As Integer = url.LastIndexOf("/")
      objectURI = ""
      objectURI = url.Substring(lastSlash)
      Return socket
   End Function 'Parse
   
   
   Public Function CreateMessageSink(url As String, remoteChannelData As Object, ByRef objectURI As String) As IMessageSink Implements IChannelSender.CreateMessageSink
      Parse(url, objectURI)
      
      Return Nothing
   End Function 'CreateMessageSink
    _
   
   
   Private Class TransportSink
      Implements IServerChannelSink 
      Private [next] As IServerChannelSink
      
      
      Public ReadOnly Property NextChannelSink() As IServerChannelSink Implements IServerChannelSink.NextChannelSink
         Get
            Return [next]
         End Get
      End Property
       
      Public Sub New(nextSink As IServerChannelSink)
         [next] = nextSink
      End Sub 'New
      
      
      ' I am not implementing these because they are
      ' not needed for my snippet but they must be here.
      Public Sub AsyncProcessResponse(sinkStack As IServerResponseChannelSinkStack, state As Object, msg As IMessage, headers As ITransportHeaders, stream As Stream) Implements IServerChannelSink.AsyncProcessResponse
      End Sub 'AsyncProcessResponse
      
      
      
      Public Function GetResponseStream(sinkStack As IServerResponseChannelSinkStack, state As Object, msg As IMessage, headers As ITransportHeaders) As Stream Implements IServerChannelSink.GetResponseStream
         Return Nothing
      End Function 'GetResponseStream
      
      
      Public Function ProcessMessage(sinkStack As IServerChannelSinkStack, requestMsg As IMessage, requestHeaders As ITransportHeaders, requestStream As Stream, ByRef msg As IMessage, ByRef responseHeaders As ITransportHeaders, ByRef responseStream As Stream) As ServerProcessing Implements IServerChannelSink.ProcessMessage
         
         msg = Nothing
         responseHeaders = Nothing
         responseStream = Nothing
         Return ServerProcessing.Complete
      End Function 'ProcessMessage
      
      
      Public ReadOnly Property Properties() As IDictionary Implements IChannelSinkBase.Properties
         Get
            Return Nothing
         End Get
      End Property
   End Class 'TransportSink
End Class 'CustomChannel
