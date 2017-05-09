Option Explicit On 
Option Strict On

Imports System
Imports System.Collections
Imports System.Runtime.Remoting
Imports System.Runtime.Remoting.Channels
Imports System.IO
Imports System.Runtime.Remoting.Messaging

Namespace TempConvertServer
    _
   ' This snippet demonstrates HttpChannel.AddHookChannelUri.
   ' client code should NOT call this call directly. So, I'm
   ' writing a class using an implementation that mimics the behavior
   ' of HttpChannel.
   ' <Snippet1>
   Class CustomChannel
      Inherits BaseChannelWithProperties
      Implements IChannelReceiverHook, IChannelReceiver, IChannel, IChannelSender

      Public Sub AddHookChannelUri(ByVal channelUri As String) _
                           Implements IChannelReceiverHook.AddHookChannelUri

         If Not (channelUri Is Nothing) Then
            Dim uris As String() = dataStore.ChannelUris

            ' This implementation only allows one URI to be hooked in.
            If uris Is Nothing Then
               Dim newUris(1) As String
               newUris(0) = channelUri
               dataStore.ChannelUris = newUris
               wantsListen = False
            Else
               Dim msg As String
               msg = "This channel is already listening for data, and " + _
                     "can't be hooked into at this stage."
               Throw New System.Runtime.Remoting.RemotingException(msg)
            End If
         End If
      End Sub

      ' The rest of CustomChannel's implementation.
      '</Snippet1>

      ' TransportSink is a private class defined within CustomChannel.
      Private transSink As TransportSink


      Public ReadOnly Property ChannelSinkChain() As IServerChannelSink _
                      Implements IChannelReceiverHook.ChannelSinkChain
         Get
            Return transSink.NextChannelSink
         End Get
      End Property

      'Entry point which delegates to C-style main Private Function
      Public Overloads Shared Sub Main()
         Main(System.Environment.GetCommandLineArgs())
      End Sub

      Public Overloads Shared Sub Main(ByVal args() As String)
         Dim channel As New CustomChannel(8085)
         channel.AddHookChannelUri("TempConverter")

         'System.Runtime.Remoting.Channels.Http.HttpChannel channel = 
         ' new System.Runtime.Remoting.Channels.Http.HttpChannel(8085);

         'System.Runtime.Remoting.Channels.Tcp.TcpChannel channel =
         ' new System.Runtime.Remoting.Channels.Tcp.TcpChannel(8085);

         System.Console.WriteLine(channel.GetUrlsForUri("TempConverter")(0))
      End Sub 'Main

      Private dataStore As ChannelDataStore
      Private wantsListen As Boolean
      Private priority As Integer
      Private socket As String


      Public Sub New()
         Dim formatterSink As New BinaryServerFormatterSink( _
                     BinaryServerFormatterSink.Protocol.Http, _
                     Nothing, _
                     Me)
         transSink = New TransportSink(formatterSink)
         priority = 0
         dataStore = New ChannelDataStore(Nothing)
         wantsListen = True
         socket = ""
      End Sub 'New


      Public Sub New(ByVal portNum As Integer)
         Dim formatterSink As New BinaryServerFormatterSink( _
                         BinaryServerFormatterSink.Protocol.Http, _
                         Nothing, _
                         Me)
         transSink = New TransportSink(formatterSink)
         priority = 0
         dataStore = New ChannelDataStore(Nothing)
         wantsListen = False
         socket = "http://localhost:" + portNum.ToString()
      End Sub 'New


      Public Sub New(ByVal properties As IDictionary, _
                      ByVal clientSinkProvider As IClientChannelSinkProvider, _
                      ByVal serverSinkProvider As IServerChannelSinkProvider)
      End Sub 'New

      Public ReadOnly Property ChannelName() As String _
                      Implements IChannelReceiver.ChannelName
         Get
            Return "custom"
         End Get
      End Property


      Public ReadOnly Property ChannelData() As Object _
                          Implements IChannelReceiver.ChannelData
         Get
            Return CType(dataStore, Object)
         End Get
      End Property

      Public ReadOnly Property WantsToListen() As Boolean _
                              Implements IChannelReceiverHook.WantsToListen
         Get
            Return wantsListen
         End Get
      End Property


      Public ReadOnly Property ChannelPriority() As Integer _
                                  Implements IChannelReceiver.ChannelPriority
         Get
            Return priority
         End Get
      End Property


      Public ReadOnly Property ChannelScheme() As String _
                                  Implements IChannelReceiverHook.ChannelScheme
         Get
            Return "http"
         End Get
      End Property


      Public Function GetUrlsForUri(ByVal uri As String) As String() _
                                  Implements IChannelReceiver.GetUrlsForUri
         Dim urls(dataStore.ChannelUris.Length) As String
         Dim i As Integer = 0
         Dim currUri As String
         For Each currUri In dataStore.ChannelUris
            urls(i) = socket + "/" + currUri
            i += 1
         Next currUri
         Return urls
      End Function 'GetUrlsForUri


      Public Sub StartListening(ByVal data As Object) _
                      Implements IChannelReceiver.StartListening
      End Sub 'StartListening


      Public Sub StopListening(ByVal data As Object) _
                      Implements IChannelReceiver.StopListening
      End Sub 'StopListening


      Public Function Parse(ByVal url As String, _
                            ByRef objectURI As String) As String Implements IChannel.Parse
         Dim lastSlash As Integer = url.LastIndexOf("/")
         objectURI = ""
         objectURI = url.Substring(lastSlash)
         Return socket
      End Function 'Parse


      Public Function CreateMessageSink(ByVal url As String, _
                                        ByVal remoteChannelData As Object, _
                                        ByRef objectURI As String) _
                                      As IMessageSink Implements IChannelSender.CreateMessageSink
         Parse(url, objectURI)

         Return Nothing
      End Function 'CreateMessageSink
       _

      Private Class TransportSink
         Implements IServerChannelSink
         Private nextSink As IServerChannelSink


         Public ReadOnly Property NextChannelSink() As IServerChannelSink _
                                     Implements IServerChannelSink.NextChannelSink
            Get
               Return nextSink
            End Get
         End Property


         Public Sub New(ByVal nSink As IServerChannelSink)
            nextSink = nSink
         End Sub 'New


         ' I am not implementing these because they are
         ' not needed for my snippet but they must be here.
         Public Sub AsyncProcessResponse(ByVal sinkStack As IServerResponseChannelSinkStack, _
                                         ByVal state As Object, _
                                         ByVal msg As IMessage, _
                                         ByVal headers As ITransportHeaders, _
                                         ByVal stream As Stream) _
                                         Implements IServerChannelSink.AsyncProcessResponse
         End Sub 'AsyncProcessResponse


         Public Function GetResponseStream(ByVal sinkStack As IServerResponseChannelSinkStack, _
                                           ByVal state As Object, _
                                           ByVal msg As IMessage, _
                                           ByVal headers As ITransportHeaders _
                                           ) As Stream _
                                           Implements IServerChannelSink.GetResponseStream
            Return Nothing
         End Function 'GetResponseStream

         Public Function ProcessMessage(ByVal sinkStack As IServerChannelSinkStack, ByVal requestMsg As IMessage, ByVal requestHeaders As ITransportHeaders, ByVal requestStream As Stream, ByRef msg As IMessage, ByRef responseHeaders As ITransportHeaders, ByRef responseStream As Stream) As ServerProcessing Implements IServerChannelSink.ProcessMessage
            msg = Nothing
            responseHeaders = Nothing
            responseStream = Nothing
            Return ServerProcessing.Complete
         End Function 'ProcessMessage


         Public ReadOnly Property Properties() As IDictionary Implements IServerChannelSink.Properties
            Get
               Return Nothing
            End Get
         End Property
      End Class 'TransportSink
   End Class 'CustomChannel
End Namespace 'TempConvertServer
