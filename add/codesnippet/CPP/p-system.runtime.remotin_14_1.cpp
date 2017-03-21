   // Display the channel's properties using Keys and Item.
   for each(String^ key in clientChannel->Keys)
   {
       Console::WriteLine("clientChannel[{0}] = <{1}>", key, clientChannel[key]);
   }