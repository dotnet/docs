      try
      {
         IPHostEntry^ hostInfo = Dns::GetHostByName( hostName );
         
         // Get the IP address list that resolves to the host names contained in the
         // Alias property.
         array<IPAddress^>^address = hostInfo->AddressList;
         
         // Get the alias names of the addresses in the IP address list.
         array<String^>^alias = hostInfo->Aliases;
         Console::WriteLine( "Host name : {0}", hostInfo->HostName );
         Console::WriteLine( "\nAliases : " );
         for ( int index = 0; index < alias->Length; index++ )
            Console::WriteLine( alias[ index ] );
         Console::WriteLine( "\nIP address list : " );
         for ( int index = 0; index < address->Length; index++ )
            Console::WriteLine( address[ index ] );
      }
      catch ( SocketException^ e ) 
      {
         Console::WriteLine( "SocketException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( ArgumentNullException^ e ) 
      {
         Console::WriteLine( "ArgumentNullException caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }
      catch ( Exception^ e ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", e->Source );
         Console::WriteLine( "Message : {0}", e->Message );
      }