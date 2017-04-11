// System.Configuration.Install.AssemblyInstaller.AssemblyInstaller()
// System.Configuration.Install.AssemblyInstaller.Install
// System.Configuration.Install.AssemblyInstaller.Commit

/* The following example demonstrates the 'AssemblyInstaller()' constructor and
   the 'Install' and 'Commit' methods of the 'AssemblyInstaller' class.
   An object of the AssemblyInstaller class is created by invoking the constructor.
   The properties of this object are set and the install and commit methods are
   called to install the 'MyAssembly_Install.exe' assembly.
*/
// <Snippet2>
// <Snippet3>
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
         // Set the commandline argument array for 'logfile'.
         string[] myString = new string[ 1 ];
         myString[ 0 ] = "/logFile=example.log";

// <Snippet1>
         // Create an object of the 'AssemblyInstaller' class.
         AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
// </Snippet1>

         // Set the properties to install the required assembly.
         myAssemblyInstaller.Path = "MyAssembly_Install.exe";
         myAssemblyInstaller.CommandLine = myString;
         myAssemblyInstaller.UseNewContext = true;

         // Clear the 'IDictionary' object.
         mySavedState.Clear();

         // Install the 'MyAssembly_Install' assembly.
         myAssemblyInstaller.Install( mySavedState );

         // Commit the 'MyAssembly_Install' assembly.
         myAssemblyInstaller.Commit( mySavedState );
      }
      catch( Exception )
      {
      }


   }
}
// </Snippet2>
// </Snippet3>