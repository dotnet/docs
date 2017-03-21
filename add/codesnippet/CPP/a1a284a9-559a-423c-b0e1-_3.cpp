   if ( service == nullptr )
   {
      Console::WriteLine( "Could not locate server." );
      return  -1;
   }

   // Calls the remote method.
   Console::WriteLine();
   Console::WriteLine( "Calling remote Object*" );
   Console::WriteLine( service->HelloMethod( "Caveman" ) );
   Console::WriteLine( service->HelloMethod( "Spaceman" ) );
   Console::WriteLine( service->HelloMethod( "Client Man" ) );
   Console::WriteLine( "Finished remote Object* call" );
   Console::WriteLine();
   return 0;
}