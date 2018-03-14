// System.Configuration.Install.AssemblyInstaller.CheckIfInstallable

/* The following example demonstrates the 'CheckIfInstallable' method
   of the 'AssemblyInstaller' class.
   The 'CheckIfInstallable' method is applied to an existent and 
   nonexistent assembly and the results of the call are displayed 
   onto the console.
*/
// <Snippet1>
using System;
using System.Configuration.Install;



class MyCheckIfInstallableClass:Installer
{
   static void Main()
   {


      try
      {
         // Determine whether the assembly 'MyAssembly' is installable.
         AssemblyInstaller.CheckIfInstallable( "MyAssembly_CheckIfInstallable.exe" );

         Console.WriteLine( "The assembly 'MyAssembly_CheckIfInstallable' is installable" );

         // Determine whether the assembly 'NonExistant' is installable.
         AssemblyInstaller.CheckIfInstallable( "NonExistant" );
      }
      catch( Exception )
      {
      }


   }
}
// </Snippet1>