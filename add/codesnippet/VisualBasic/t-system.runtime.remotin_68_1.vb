      Public Function ProcessMessage(ByVal myServerChannelSinkStack As IServerChannelSinkStack, _
                  ByVal requestMsg As IMessage, ByVal requestHeaders As ITransportHeaders, ByVal requestStream As Stream, ByRef _
                  msg As IMessage, ByRef responseHeaders As ITransportHeaders, ByRef responseStream _
                  As Stream) As ServerProcessing Implements IServerChannelSink.ProcessMessage
         If myBoolEnabled Then
            LoggingHelper.PrintRequest(myTextWriterOutput, requestHeaders, requestStream)
         End If
         myServerChannelSinkStack.Push(Me, Nothing)
         Dim myServerProcessing As ServerProcessing = myNewNextSink.ProcessMessage( _
          myServerChannelSinkStack, requestMsg, requestHeaders, requestStream, msg, responseHeaders, responseStream)

         Console.WriteLine("ServerProcessing.Complete value is:   " + ServerProcessing.Complete.Tostring())
         Console.WriteLine("ServerProcessing.OneWay Value is:     " + ServerProcessing.OneWay.Tostring())
         Console.WriteLine("ServerProcessing.Async value is:      " + ServerProcessing.Async.Tostring())

         Select Case myServerProcessing
            Case ServerProcessing.Complete
               myServerChannelSinkStack.Pop(Me)
               If myBoolEnabled Then
                  LoggingHelper.PrintResponse(myTextWriterOutput, responseHeaders, responseStream)
               End If

            Case ServerProcessing.OneWay
               myServerChannelSinkStack.Pop(Me)

            Case ServerProcessing.Async
               myServerChannelSinkStack.Store(Me, Nothing)

         End Select
         Return myServerProcessing
      End Function 'ProcessMessage
