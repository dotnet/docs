         // Check whether the "LogtoConsole" parameter has been set.
         if ( myInstallContext->IsParameterTrue( "LogtoConsole" ) )
         {
            // Display the message to the console and add it to the logfile.
            myInstallContext->LogMessage( "The 'Install' method has been called" );
         }