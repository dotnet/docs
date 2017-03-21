using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections;
using System.Collections.Specialized;

namespace MyInstallContextNamespace
{
   [RunInstallerAttribute(true)]
   class InstallContext_Example : Installer
   {
      public InstallContext myInstallContext;

      public override void Install( IDictionary mySavedState )
      {
         StringDictionary myStringDictionary = myInstallContext.Parameters;
         if( myStringDictionary.Count == 0 )
         {
            Console.WriteLine( "No parameters have been entered in the command line "
               +"hence, the install will take place in the silent mode" );
         }
         else
         {
            // Check whether the "LogtoConsole" parameter has been set.
            if( myInstallContext.IsParameterTrue( "LogtoConsole" ) == true )
            {
               // Display the message to the console and add it to the logfile.
               myInstallContext.LogMessage( "The 'Install' method has been called" );
            }
         }

         // The 'Install procedure should be added here.
      }

      public override void Uninstall( IDictionary mySavedState )
      {
         // The 'Uninstall' procedure should be added here.
      }

      public override void Rollback( IDictionary mySavedState )
      {
         if( myInstallContext.IsParameterTrue( "LogtoConsole" ) == true )
         {
            myInstallContext.LogMessage( "The 'Rollback' method has been called" );
         }

         // The 'Rollback' procedure should be added here.
      }

      public override void Commit( IDictionary mySavedState )
      {
         if( myInstallContext.IsParameterTrue( "LogtoConsole" ) == true )
         {
            myInstallContext.LogMessage( "The 'Commit' method has been called" );
         }

         // The 'Commit' procedure should be added here.
      }

      static void Main( string[] args )
      {
         InstallContext_Example myInstallObject = new InstallContext_Example();

         IDictionary mySavedState = new Hashtable();

         if( args.Length < 1 )
         {
            // There are no command line arguments, create an empty 'InstallContext'.
            myInstallObject.myInstallContext = new InstallContext();
         }

         else if( ( args.Length == 1 ) && ( args[ 0 ] == "/?" ) )
         {
            // Display the 'Help' for this utility.
            Console.WriteLine( "Specify the '/Logfile' and '/LogtoConsole' parameters" );
            Console.WriteLine( "Example: " );
            Console.WriteLine( "InstallContext_InstallContext.exe /LogFile=example.log"
                                          +" /LogtoConsole=true" );
            return;
         }

         else
         {
            // Create an InstallContext object with the given parameters.
            String[] commandLine = new string[ args.Length ];
            for( int i = 0; i < args.Length; i++ )
            {
               commandLine[ i ] = args[ i ];
            }
            myInstallObject.myInstallContext = new InstallContext( args[ 0 ], commandLine);
         }

         try
         {
            // Call the 'Install' method.
            myInstallObject.Install( mySavedState );

            // Call the 'Commit' method.
            myInstallObject.Commit( mySavedState );
         }
         catch( Exception )
         {
            // Call the 'Rollback' method.
            myInstallObject.Rollback( mySavedState );
         }
      }
   }
}