         //Uses the IP address and port number to establish a socket connection.
         TcpClient^ tcpClient = gcnew TcpClient;
         IPAddress^ ipAddress = Dns::Resolve( "www.contoso.com" )->AddressList[ 0 ];
         tcpClient->Connect( ipAddress, 11003 );
         