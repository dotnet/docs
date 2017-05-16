/*
   System.Configuration.Install.Installer.Install
   System.Configuration.Install.Installer.Commit

   The following example demonstrates the 'Install' and 'Commit' methods 
   of the 'Installer' class.
   A class is derived from the 'Installer' base class and the Install
   and Commit methods are overridden.
*/

using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections;

namespace MyAssembly
{
[RunInstaller(true)]
   public class MyInstallerSample : Installer
   {

// <Snippet1>
      // Override the 'Install' method of the Installer class.
      public override void Install( IDictionary mySavedState )
      {
         base.Install( mySavedState );
         // Code maybe written for installation of an application.
         Console.WriteLine( "The Install method of 'MyInstallerSample' has been called" );
      }
// </Snippet1>
// <Snippet2>
      // Override the 'Commit' method of the Installer class.
      public override void Commit( IDictionary mySavedState )
      {
         base.Commit( mySavedState );
         Console.WriteLine( "The Commit method of 'MyInstallerSample'"
                           + "has been called" );
      }
// </Snippet2>
      static void Main()
      {
         Console.WriteLine("Use installutil.exe to run the assembly"
                              + " Installer_Install.exe");
      }
   }
}
