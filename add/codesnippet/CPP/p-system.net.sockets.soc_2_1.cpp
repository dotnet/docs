      s->Connect( lep );
      
      // Uses the RemoteEndPoint property.
      Console::WriteLine(  "I am connected to {0} on port number {1}",
         IPAddress::Parse( ( ( (IPEndPoint^)(s->RemoteEndPoint) )->Address)->ToString() ),
         ( (IPEndPoint^)(s->RemoteEndPoint) )->Port.ToString() );
      
      // Uses the LocalEndPoint property.
      Console::Write(  "My local IpAddress is : {0}\nI am connected on port number {1}",
         IPAddress::Parse( ( ( (IPEndPoint^)(s->LocalEndPoint) )->Address)->ToString() ),
         ( (IPEndPoint^)(s->LocalEndPoint) )->Port.ToString() );