// System.Configuration.Install.InstallerCollection.Remove(Installer)
// System.Configuration.Install.InstallerCollection.Contains(Installer)
// System.Configuration.Install.InstallerCollection.IndexOf(Installer)

/*
   The following example demonstrates the 'Remove(Installer)',
   'Contains(Installer)' and 'IndexOf(Installer)' methods of the 
   'InstallerCollection' class. Create's 'AssemblyInstaller' instances
   for 'MyAssembly1.exe' and for 'MyAssembly2.exe'. These instances
   of 'AssemblyInstaller' are added to an instance of 'TransactedInstaller'.
   The 'AssemblyIntaller' instance for 'MyAssembly2.exe' is removed
   from the installers collection of the 'TransactedInstaller' instance.
   The installation process is started which installs only 'MyAssembly1.exe'.
*/

using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;

public class InstallerCollection_Remove
{
   public static void Main()
   {
      try
      {
// <Snippet1>
// <Snippet2>
// <Snippet3>
         TransactedInstaller myTransactedInstaller = new TransactedInstaller();
         AssemblyInstaller myAssemblyInstaller1;
         AssemblyInstaller myAssemblyInstaller2;
         InstallContext myInstallContext;

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller1 = 
            new AssemblyInstaller("MyAssembly1.exe", null);

         // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Insert(0, myAssemblyInstaller1);

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller2 = 
            new AssemblyInstaller("MyAssembly2.exe", null);

         // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
         myTransactedInstaller.Installers.Insert(1, myAssemblyInstaller2);

         // Remove the 'myAssemblyInstaller2' from the 'Installers' collection.
         if(myTransactedInstaller.Installers.Contains(myAssemblyInstaller2))
         {
            Console.WriteLine("\nInstaller at index : {0} is being removed",
               myTransactedInstaller.Installers.IndexOf(myAssemblyInstaller2));
            myTransactedInstaller.Installers.Remove(myAssemblyInstaller2);
         }
// </Snippet3>
// </Snippet2>
// </Snippet1>
         //Print the installers to be installed.
         InstallerCollection myInstallers = myTransactedInstaller.Installers;
         Console.WriteLine("\nPrinting all installers to be installed\n");
         for(int i = 0; i < myInstallers.Count; i++)
         {
            if((myInstallers[i].GetType()).Equals(typeof(AssemblyInstaller)))
            {
               Console.WriteLine("{0} {1}", i + 1, 
                  ((AssemblyInstaller)myInstallers[i]).Path);
            }
         }

         // Create a instance of 'InstallContext' with log file named 'Install.log'.
         myInstallContext = 
            new InstallContext("Install.log", null);
         myTransactedInstaller.Context = myInstallContext;

         // Install an assembly.
         myTransactedInstaller.Install(new Hashtable());
      }
      catch(Exception e)
      {
         Console.WriteLine("Exception raised : {0}", e.Message);
      }
   }
}
