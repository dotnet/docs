   EventSourceCreationData ^ mySourceData = gcnew EventSourceCreationData( "","" );
   bool registerSource = true;
   
   // Process input parameters.
   if ( args->Length > 1 )
   {
      
      // Require at least the source name.
      mySourceData->Source = args[ 1 ];
      if ( args->Length > 2 )
      {
         mySourceData->LogName = args[ 2 ];
      }

      if ( args->Length > 3 )
      {
         mySourceData->MachineName = args[ 3 ];
      }

      if ( (args->Length > 4) && (args[ 4 ]->Length > 0) )
      {
         mySourceData->MessageResourceFile = args[ 4 ];
      }
   }
   else
   {
      
      // Display a syntax help message.
      Console::WriteLine( "Input:" );
      Console::WriteLine( " source [event log] [machine name] [resource file]" );
      registerSource = false;
   }

   
   // Set defaults for parameters missing input.
   if ( mySourceData->MachineName->Length == 0 )
   {
      
      // Default to the local computer.
      mySourceData->MachineName = ".";
   }

   if ( mySourceData->LogName->Length == 0 )
   {
      
      // Default to the Application log.
      mySourceData->LogName = "Application";
   }

   