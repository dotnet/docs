   String^ myDiscoFile = "http://localhost/MathService_cs.vsdisco";
   String^ myEncoding = "";
   DiscoveryClientProtocol^ myDiscoveryClientProtocol =
      gcnew DiscoveryClientProtocol;

   Stream^ myStream = myDiscoveryClientProtocol->Download(
      myDiscoFile, myEncoding );
   Console::WriteLine( "The length of the stream in bytes: {0}",
      myStream->Length );
   Console::WriteLine( "The MIME encoding of the downloaded " +
      "discovery document: {0}", myEncoding );
   myStream->Close();