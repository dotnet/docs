      IPAddress^ hostIPAddress1 = (Dns::Resolve( hostString1 ))->AddressList[ 0 ];
      Console::WriteLine( hostIPAddress1 );
      IPEndPoint^ hostIPEndPoint = gcnew IPEndPoint( hostIPAddress1,80 );
      Console::WriteLine( "\nIPEndPoint information:{0}", hostIPEndPoint );
      Console::WriteLine( "\n\tMaximum allowed Port Address :{0}", IPEndPoint::MaxPort );
      Console::WriteLine( "\n\tMinimum allowed Port Address :{0}", (int^)IPEndPoint::MinPort );
      Console::WriteLine( "\n\tAddress Family :{0}", hostIPEndPoint->AddressFamily );