   // Create the server channel.
   System::Collections::IDictionary^ properties = gcnew System::Collections::Hashtable;
   properties->default[ L"name" ] = L"ipc";
   properties->default[ L"priority" ] = L"20";
   properties->default[ L"portName" ] = L"localhost:9090";
   IpcChannel^ serverChannel = gcnew IpcChannel( properties,nullptr,nullptr );
   