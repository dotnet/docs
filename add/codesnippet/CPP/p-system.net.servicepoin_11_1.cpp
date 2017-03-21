   // Display the date and time that the ServicePoint was last 
   // connected to a host.
   Console::WriteLine( "IdleSince = {0}", sp->IdleSince );
   
   // Display the maximum length of time that the ServicePoint instance  
   // is allowed to maintain an idle connection to an Internet  
   // resource before it is recycled for use in another connection.
   Console::WriteLine( "MaxIdleTime = {0}", sp->MaxIdleTime );
   