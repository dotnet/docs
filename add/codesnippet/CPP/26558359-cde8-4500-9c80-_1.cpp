   // Create a message sink.
   String^ messageSinkUri;
   Messaging::IMessageSink^ messageSink = clientChannel->CreateMessageSink(
      L"ipc://localhost:9090/RemoteObject.rem", nullptr,  messageSinkUri );
   Console::WriteLine( L"The URI of the message sink is {0}.", messageSinkUri );
   if ( messageSink != nullptr )
   {
      Console::WriteLine( L"The type of the message sink is {0}.", messageSink->GetType() );
   }

   