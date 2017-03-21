         // Example of CanWrite, and BeginWrite.
         // Check to see if this NetworkStream is writable.
         if ( myNetworkStream->CanWrite )
         {
            array<Byte>^myWriteBuffer = Encoding::ASCII->GetBytes( "Are you receiving this message?" );
            myNetworkStream->BeginWrite( myWriteBuffer, 0, myWriteBuffer->Length, gcnew AsyncCallback( &MyNetworkStreamClass::myWriteCallBack ), myNetworkStream );
            allDone->WaitOne();
         }
         else
         {
            Console::WriteLine( "Sorry.  You cannot write to this NetworkStream." );
         }