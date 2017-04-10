// System.Configuration.Install.InstallerCollection.CopyTo(Installer[], Int32)

/*
   The following example demonstrates the 'CopyTo(Installer[], Int32)' method
   of the 'InstallerCollection' class. It Creates 'AssemblyInstaller' instances
   for 'MyAssembly1.exe' and 'MyAssembly2.exe'. These instances of 
   'AssemblyInstaller' are added to an instance of 'TransactedInstaller'
   instance. The names of the assemblies to be installed
   are displayed on the console. The installation process then installs 
   both 'MyAssembly1.exe' and 'MyAssembly2.exe'.
*/

using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;

public class InstallerCollection_CopyTo
{
   public static void Main()
   {
// <Snippet1>
      TransactedInstaller myTransactedInstaller = new TransactedInstaller();
      AssemblyInstaller myAssemblyInstaller;
      InstallContext myInstallContext;

      // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller =
         new AssemblyInstaller("MyAssembly1.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller.Installers.Add(myAssemblyInstaller);

      // Create an instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller =
         new AssemblyInstaller("MyAssembly2.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller.Installers.Add(myAssemblyInstaller);
     
      Installer[] myInstallers =
         new Installer[myTransactedInstaller.Installers.Count];

      myTransactedInstaller.Installers.CopyTo(myInstallers, 0);
      // Print the assemblies to be installed.
      Console.WriteLine("Printing all assemblies to be installed -");
      for(int i = 0; i < myInstallers.Length; i++)
      {
         if((myInstallers[i].GetType()).Equals(typeof(AssemblyInstaller)))
         {
            Console.WriteLine("{0} {1}", i + 1,
               ((AssemblyInstaller)myInstallers[i]).Path);
         }
      }
// </Snippet1>
      // Create a instance of 'InstallContext' with log file named 'Install.log'.
      myInstallContext = 
         new InstallContext("Install.log", null);
      myTransactedInstaller.Context = myInstallContext;

      // Install an assembly.
      myTransactedInstaller.Install(new Hashtable());  
   }  
}