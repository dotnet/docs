	IPHostEntry^ lipa = Dns::Resolve( "host.contoso.com" );
	IPEndPoint^ lep = gcnew IPEndPoint( lipa->AddressList[ 0 ], 11000);

       Socket^ s = gcnew Socket( lep->Address->AddressFamily,
       	  SocketType::Dgram,
          ProtocolType::Udp);
       
       IPEndPoint^ sender = gcnew IPEndPoint( IPAddress::Any, 0 );
       EndPoint^ tempRemoteEP = (EndPoint^)( sender );
       s->Connect( sender );
       
       try{
          while(true){
             allDone->Reset();
             StateObject^ so2 = gcnew StateObject();
                 so2->workSocket = s;
                 Console::WriteLine( "Attempting to Receive data from host.contoso.com" );
             
                 s->BeginReceiveFrom( so2->buffer, 0, StateObject::BUFFER_SIZE, SocketFlags::None, tempRemoteEP,
	            gcnew AsyncCallback( &Async_Send_Receive::ReceiveFrom_Callback), so2);	
                 allDone->WaitOne();
            }
       }
       catch ( Exception^ e )
       {
            Console::WriteLine( e );
       }