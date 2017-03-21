      public ServerProcessing ProcessMessage(IServerChannelSinkStack myServerChannelSinkStack,
         IMessage requestMsg, ITransportHeaders requestHeaders, Stream requestStream,
         out IMessage msg, out ITransportHeaders responseHeaders,
         out Stream responseStream)
      {
         if (myBoolEnabled)
            LoggingHelper.PrintRequest(myTextWriterOutput, requestHeaders, ref requestStream);

         myServerChannelSinkStack.Push(this, null);
         ServerProcessing myServerProcessing =
            myNewNextSink.ProcessMessage(myServerChannelSinkStack, requestMsg, requestHeaders, requestStream, out msg,
            out responseHeaders, out responseStream);

         Console.WriteLine("ServerProcessing.Complete value is:   " +ServerProcessing.Complete);
         Console.WriteLine("ServerProcessing.OneWay Value is:     " +ServerProcessing.OneWay);
         Console.WriteLine("ServerProcessing.Async value is:      " +ServerProcessing.Async);

         switch (myServerProcessing)
         {
            case ServerProcessing.Complete:
            {
               myServerChannelSinkStack.Pop(this);
               if (myBoolEnabled)
                  LoggingHelper.PrintResponse(myTextWriterOutput, responseHeaders, ref responseStream);
               break;
            }

            case ServerProcessing.OneWay:
            {
               myServerChannelSinkStack.Pop(this);
               break;
            }

            case ServerProcessing.Async:
            {
               myServerChannelSinkStack.Store(this, null);
               break;
            }
         }
         return myServerProcessing;
      }