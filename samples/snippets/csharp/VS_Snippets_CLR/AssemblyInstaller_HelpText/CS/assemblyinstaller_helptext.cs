// System.Configuration.Install.AssemblyInstaller.UseNewContext
// System.Configuration.Install.AssemblyInstaller.HelpText

/* The following example demonstrates the 'UseNewContext' and the
   'HelpText' properties of the 'AssemblyInstaller' class.
   An object of the AssemblyInstaller class is created by invoking the constructor.
   The 'UseNewContext' property of this object is set to true and the install
   method is invoked on the 'MyAssembly_HelpText.exe' assembly. Due
   to this the log messages are displayed on the console. The 'HelpText'
   property for the object is displayed on the console.
*/

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
         string[] commandLineOptions = new string[ 1 ] {"/LogFile=example.log"};

// <Snippet1>
         // Create an object of the 'AssemblyInstaller' class.
         AssemblyInstaller myAssemblyInstaller = new
                        AssemblyInstaller( "MyAssembly_HelpText.exe", commandLineOptions );

         // Set the 'UseNewContext' property to true.
         myAssemblyInstaller.UseNewContext = true;
// </Snippet1>

         // Install the 'MyAssembly_HelpText' assembly.
         myAssemblyInstaller.Install( mySavedState );

// <Snippet2>
         Console.WriteLine( "The 'HelpText' is-" );
         // Display the 'HelpText' of this AssemblyInstaller object.
         Console.WriteLine( myAssemblyInstaller.HelpText );
// </Snippet2>
      }
      catch( ArgumentException )
      {
      }
      catch( Exception e )
      {
         Console.WriteLine( e.Message );
      }

   }
}
