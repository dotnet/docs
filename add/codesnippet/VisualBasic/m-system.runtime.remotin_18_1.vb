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
            Console.WriteLine(CommonTransportKeys.IPAddress.ToString() + ":" + _ 
                                 requestHeaders(CommonTransportKeys.IPAddress).ToString())
         Console.WriteLine(CommonTransportKeys.ConnectionId.ToString() + ":" + _ 
                                 requestHeaders(CommonTransportKeys.ConnectionId).ToString())
         Console.WriteLine(CommonTransportKeys.RequestUri.ToString() + ":" + _ 
                                 requestHeaders(CommonTransportKeys.RequestUri).ToString())
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