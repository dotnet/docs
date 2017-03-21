   // Recreate the connection endpoint from the serialized information.
   IPEndPoint^ endpoint = gcnew IPEndPoint( (__int64)0,0 );
   IPEndPoint^ clonedIPEndPoint = dynamic_cast<IPEndPoint^>(endpoint->Create( socketAddress ));
   Console::WriteLine( "clonedIPEndPoint: {0}", clonedIPEndPoint );