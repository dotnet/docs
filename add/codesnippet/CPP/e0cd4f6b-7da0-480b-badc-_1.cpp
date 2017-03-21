   // Create a message sink.
   String^ objectUri;
   System::Runtime::Remoting::Messaging::IMessageSink^ messageSink = channel->CreateMessageSink(
      L"ipc://localhost:9090/RemoteObject.rem", nullptr, objectUri );
   Console::WriteLine( L"The URI of the message sink is {0}.", objectUri );
   if ( messageSink != nullptr )
   {
      Console::WriteLine( L"The type of the message sink is {0}.", messageSink->GetType() );
   }

   