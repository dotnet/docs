/*
   System.Configuration.Install.Installer.Uninstall

   The following example demonstrates the Uninstall method 
   of the class 'installer'. The method Uninstall is overridden
   in the derived class of 'installer'.
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
      // Override 'Uninstall' method of Installer class.
      public override void Uninstall( IDictionary mySavedState )
      {  
         if (mySavedState == null)
         {
            Console.WriteLine("Uninstallation Error !");
         }
         else
         {
            base.Uninstall( mySavedState );
            Console.WriteLine( "The Uninstall method of 'MyInstallerSample' has been called" );
         }
      }
// </Snippet1>

      static void Main()
      {
         Console.WriteLine("Use 'installutil.exe -u' to run the assembly"
            + " Installer_Uninstall.exe");
      }
   }
}
