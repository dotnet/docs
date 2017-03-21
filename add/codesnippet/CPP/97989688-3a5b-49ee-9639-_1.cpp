   // readData and buffer holds the data read from the server.
   // They is used by the ReadCallback method.
   static StringBuilder^ readData = gcnew StringBuilder;
   static array<Byte>^buffer = gcnew array<Byte>(2048);
