      StringDictionary^ myStringDictionary = myInstallContext->Parameters;
      if ( myStringDictionary->Count == 0 )
      {
         Console::Write( "No parameters have been entered in the command line " );
         Console::WriteLine( "hence, the install will take place in the silent mode" );
      }
      else
      {
         // Check whether the "LogtoConsole" parameter has been set.
         if ( myInstallContext->IsParameterTrue( "LogtoConsole" ) )
         {
            // Display the message to the console and add it to the logfile.
            myInstallContext->LogMessage( "The 'Install' method has been called" );
         }
      }