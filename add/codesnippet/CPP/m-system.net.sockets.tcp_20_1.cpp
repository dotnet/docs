      //Creates an instance of the TcpListener class by providing a local endpoint.

      IPAddress^ ipAddress = Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ];
      IPEndPoint^ ipLocalEndPoint = gcnew IPEndPoint( ipAddress,11000 );

      try
      {
         TcpListener^ tcpListener = gcnew TcpListener( ipLocalEndPoint );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( e->ToString() );
      }