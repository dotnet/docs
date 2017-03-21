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