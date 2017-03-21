<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Friend Class MyClientFormatterChannelSink
   Inherits BaseChannelSinkWithProperties
   Implements IClientChannelSink, IMessageSink
   Private nextClientSink As IClientChannelSink = Nothing
   Private nextMessageSink As IMessageSink = Nothing

   Public Sub New(nextSink As IClientChannelSink, nextMsgSink As IMessageSink)
      MyBase.New()
      nextClientSink = nextSink
      nextMessageSink = nextMsgSink
   End Sub 'New

   Public Sub ProcessMessage(msg As IMessage, requestHeaders As ITransportHeaders, _
               requestStream As Stream, ByRef responseHeaders As ITransportHeaders, _
               ByRef responseStream As Stream) _
               Implements IClientChannelSink.ProcessMessage
      nextClientSink.ProcessMessage(msg, requestHeaders, requestStream, _
                                    responseHeaders, responseStream)
   End Sub 'ProcessMessage

   Public Sub AsyncProcessRequest(sinkStack As IClientChannelSinkStack, _
            msg As IMessage, headers As ITransportHeaders, myStream As Stream) _
            Implements IClientChannelSink.AsyncProcessRequest
      sinkStack.Push(Me, Nothing)
      nextClientSink.AsyncProcessRequest(sinkStack, msg, headers, myStream)
   End Sub 'AsyncProcessRequest

   Public Sub AsyncProcessResponse(sinkStack As IClientResponseChannelSinkStack, _
            state As Object, headers As ITransportHeaders, myStream As Stream) _
            Implements IClientChannelSink.AsyncProcessResponse
      sinkStack.AsyncProcessResponse(headers, myStream)
   End Sub 'AsyncProcessResponse

   Public Function GetRequestStream(msg As IMessage, headers As ITransportHeaders) As Stream _
         Implements IClientChannelSink.GetRequestStream
      Return Nothing
   End Function 'GetRequestStream

   Public ReadOnly Property NextChannelSink() As IClientChannelSink _
         Implements IClientChannelSink.NextChannelSink
      Get
         Return nextClientSink
      End Get
   End Property

   Public ReadOnly Property NextSink() As IMessageSink _
         Implements IMessageSink.NextSink
      Get
         Return nextMessageSink
      End Get
   End Property

   Public Overrides ReadOnly Property Properties() As Collections.IDictionary _
            Implements IClientChannelSink.Properties
      Get
      End Get
   End Property

   Public Function AsyncProcessMessage(msg As IMessage, replySink As IMessageSink) As IMessageCtrl _
            Implements IMessageSink.AsyncProcessMessage
      Return Nothing
   End Function 'AsyncProcessMessage

   Public Function SyncProcessMessage(msg As IMessage) As IMessage _
            Implements IMessageSink.SyncProcessMessage
      Return nextMessageSink.SyncProcessMessage(msg)
   End Function 'SyncProcessMessage

   Default Public Overrides Property Item(key As Object) As Object
      Get
         If key Is GetType(MyKey) Then
            Return Me
         End If
         Return Nothing
      End Get
      Set
         Throw New NotSupportedException()
      End Set
   End Property

   Public Overrides ReadOnly Property Keys() As ICollection
      Get
         Dim myKeys As New ArrayList(0)
         myKeys.Add(GetType(MyKey))
         Return myKeys
      End Get
   End Property
End Class 'MyClientFormatterChannelSink

Public Class MyKey
End Class 'MyKey