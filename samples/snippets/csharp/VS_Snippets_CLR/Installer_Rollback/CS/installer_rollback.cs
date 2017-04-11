/*
   System.Configuration.Install.Installer.Rollback

   The following example demonstrates the Rollback method
   of the class 'installer'. The Rollback method is overridden
   in a derived class of 'installer'.An exception is generated to
   force an installation rollback.
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
      // Override 'Install' method of Installer class.
      public override void Install( IDictionary mySavedState )
      {
         base.Install( mySavedState );
         Console.WriteLine( "" );
         // Include code to install an application.
         Console.WriteLine( "The Install method of 'MyInstallerSample'" +
                           " has been called" );
         Console.WriteLine( "" );
         
         // Exception generated to call Rollback method.
         Exception myException = new Exception();
         Console.WriteLine("Exception thrown during Installation");
         throw myException;
         
      }
// <Snippet1>
      // Override 'Rollback' method of Installer class.
      public override void Rollback( IDictionary mySavedState )
      {
         base.Rollback( mySavedState );
         Console.WriteLine( "The Rollback method of 'MyInstallerSample'" +
                           " has been called" );
      }
// </Snippet1>
      static void Main()
      {
         Console.WriteLine("Use installutil.exe to run the assembly"
            + " Installer_Rollback.exe");
      }
   }
}
