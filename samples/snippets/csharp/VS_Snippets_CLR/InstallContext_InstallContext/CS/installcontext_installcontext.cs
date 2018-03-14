// System.Configuration.Install.InstallContext
// System.Configuration.Install.InstallContext.InstallContext()
// System.Configuration.Install.InstallContext.InstallContext(string, string[])
// System.Configuration.Install.InstallContext.IsParameterTrue
// System.Configuration.Install.InstallContext.LogMessage
// System.Configuration.Install.InstallContext.Parameters

/* The following example demonstrates the 'InstallContext()' and
   InstallContext(string, string[]) constructors, the 'Parameters' property
   and the 'LogMessage' and 'IsParameterTrue' methods of the
   'InstallContext' class.
   When the program is invoked without any arguments an empty InstallContext
   object is created and when the '/LogFile' and '/LogtoConsole' are
   specified the InstallContext object is created by passing the respective
   arguments to InstallContext(string, string[]). When the install method of the
   installer is called, it checks for parameters from the command line and
   depending on that it displays the progress messages onto the console and
   also saves it to the specified log file.
*/

// <Snippet1>
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
// <Snippet6>
         StringDictionary myStringDictionary = myInstallContext.Parameters;
         if( myStringDictionary.Count == 0 )
         {
            Console.WriteLine( "No parameters have been entered in the command line "
               +"hence, the install will take place in the silent mode" );
         }
         else
         {
// <Snippet4>
// <Snippet5>
            // Check whether the "LogtoConsole" parameter has been set.
            if( myInstallContext.IsParameterTrue( "LogtoConsole" ) == true )
            {
               // Display the message to the console and add it to the logfile.
               myInstallContext.LogMessage( "The 'Install' method has been called" );
            }
// </Snippet5>
// </Snippet4>
         }
// </Snippet6>

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
// <Snippet2>
            // There are no command line arguments, create an empty 'InstallContext'.
            myInstallObject.myInstallContext = new InstallContext();
// </Snippet2>
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
// <Snippet3>
            // Create an InstallContext object with the given parameters.
            String[] commandLine = new string[ args.Length ];
            for( int i = 0; i < args.Length; i++ )
            {
               commandLine[ i ] = args[ i ];
            }
            myInstallObject.myInstallContext = new InstallContext( args[ 0 ], commandLine);
// </Snippet3>
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
// </Snippet1>
