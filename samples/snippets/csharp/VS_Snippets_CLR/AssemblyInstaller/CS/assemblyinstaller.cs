// System.Configuration.Install.AssemblyInstaller

/*  The following example demonstrates the 'AssemblyInstaller' class.
      An object of the AssemblyInstaller class is created by invoking the constructor.
      The properties of this object are set and the install and commit methods are
      called to install the 'MyAssembly.exe' assembly.
*/

// <Snippet1>
using System;
using System.Configuration.Install;
using System.Collections;
using System.Collections.Specialized;

class AssemblyInstaller_Example
{
   static void Main()
   {
      IDictionary mySavedState = new Hashtable();

      Console.WriteLine( "" );

      try
      {
         // Set the commandline argument array for 'logfile'.
         string[] commandLineOptions = new string[ 1 ] {"/LogFile=example.log"};

         // Create an object of the 'AssemblyInstaller' class.
         AssemblyInstaller myAssemblyInstaller = new 
                     AssemblyInstaller( "MyAssembly.exe" , commandLineOptions );

         myAssemblyInstaller.UseNewContext = true;

         // Install the 'MyAssembly' assembly.
         myAssemblyInstaller.Install( mySavedState );

         // Commit the 'MyAssembly' assembly.
         myAssemblyInstaller.Commit( mySavedState );
      }
      catch (ArgumentException)
      {
      }
      catch (Exception e)
      {
         Console.WriteLine( e.Message );
      }
   }
}
// </Snippet1>