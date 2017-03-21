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

         // Create an object of the 'AssemblyInstaller' class.
         AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();

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