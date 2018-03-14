// System.Configuration.Install.AssemblyInstaller.AssemblyInstaller( string, string[] )
// System.Configuration.Install.AssemblyInstaller.Uninstall

/* The following example demonstrates the 'AssemblyInstaller( string, string[] )'
   constructor and the 'Uninstall' method of the 'AssemblyInstaller' class.
   An object of the AssemblyInstaller class is created by invoking the constructor
   with the assembly to install and the commandline argument array as
   parameters. The uninstall method is called after installing and committing
   the assembly passed as the parameter to the constructor.
*/

using System;
using System.Configuration.Install;
using System.Collections;
using System.Collections.Specialized;

class MyInstallClass
{
   static void Main()
   {
      IDictionary mySavedState = new Hashtable();

      Console.WriteLine( "" );

      try
      {
         // <Snippet1>
         string[] myStringArray = new string[ 1 ];
         string myString;


         // Set the commandline argument array for 'logfile'.
         myStringArray[ 0 ] = "/logFile=example.log";

         // Set the name of the assembly to install.
         myString = "MyAssembly_Uninstall.exe";

         // Create an object of the 'AssemblyInstaller' class.
         AssemblyInstaller myAssemblyInstaller = new 
                  AssemblyInstaller( myString , myStringArray );
// </Snippet1>

         // Install and commit the 'MyAssembly_Uninstall' assembly.
         mySavedState.Clear();
         myAssemblyInstaller.Install( mySavedState );
         myAssemblyInstaller.Commit( mySavedState );

// <Snippet2>
         // Uninstall the 'MyAssembly_Uninstall' assembly.
         myAssemblyInstaller.Uninstall( mySavedState );
// </Snippet2>

      }
      catch( ArgumentException )
      {
      }
      catch( Exception myException )
      {
         Console.WriteLine( myException.Message );
      }
   }
}
