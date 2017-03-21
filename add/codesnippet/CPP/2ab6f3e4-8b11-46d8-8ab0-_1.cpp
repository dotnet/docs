   // Create a message sink.
   String^ objectUri;
   System::Runtime::Remoting::Messaging::IMessageSink^ messageSink = clientChannel->CreateMessageSink( "tcp://localhost:9090/RemoteObject.rem", nullptr, objectUri );
   Console::WriteLine( "The URI of the message sink is {0}.", objectUri );
   Console::WriteLine( "The type of the message sink is {0}.", messageSink->GetType() );
   