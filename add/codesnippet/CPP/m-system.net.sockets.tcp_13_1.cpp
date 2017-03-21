         //Uses a remote end point to establish a socket connection.
         TcpClient^ tcpClient = gcnew TcpClient;
         IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
         IPEndPoint^ ipEndPoint = gcnew IPEndPoint( ipAddress,11004 );
         tcpClient->Connect( ipEndPoint );
         