   // Show the URIs associated with the channel.
   ChannelDataStore^ data = dynamic_cast<ChannelDataStore^>(serverChannel->ChannelData);
   System::Collections::IEnumerator^ myEnum = data->ChannelUris->GetEnumerator();
   while ( myEnum->MoveNext() )
   {
      String^ uri = safe_cast<String^>(myEnum->Current);
      Console::WriteLine( uri );
   }