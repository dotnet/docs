         UdpClient^ udpClient = gcnew UdpClient( "www.contoso.com",11000 );
         array<Byte>^ sendBytes = Encoding::ASCII->GetBytes( "Is anybody there" );
         try
         {
            udpClient->Send( sendBytes, sendBytes->Length );
         }
         catch ( Exception^ e ) 
         {
            Console::WriteLine( e->ToString() );
         }