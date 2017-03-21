         //Creates a TCPClient using a local end point.
         IPAddress^ ipAddress = Dns::Resolve( Dns::GetHostName() )->AddressList[ 0 ];
         IPEndPoint^ ipLocalEndPoint = gcnew IPEndPoint( ipAddress,11000 );
         TcpClient^ tcpClientA = gcnew TcpClient( ipLocalEndPoint );
         