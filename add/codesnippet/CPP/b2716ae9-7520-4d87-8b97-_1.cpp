         // Example of CanRead, and BeginRead.
         // Check to see if this NetworkStream is readable.
         if ( myNetworkStream->CanRead )
         {
            array<Byte>^myReadBuffer = gcnew array<Byte>(1024);
            myNetworkStream->BeginRead( myReadBuffer, 0, myReadBuffer->Length, gcnew AsyncCallback( &MyNetworkStreamClass::myReadCallBack ), myNetworkStream );
            allDone->WaitOne();
         }
         else
         {
            Console::WriteLine( "Sorry.  You cannot read from this NetworkStream." );
         }