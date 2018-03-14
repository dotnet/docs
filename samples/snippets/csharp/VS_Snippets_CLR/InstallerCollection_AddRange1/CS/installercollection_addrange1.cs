// System.Configuration.Install.InstallerCollection.AddRange(Installer[])

/*
   The following example demonstrates the 'AddRange(Installer[])'
   method of the 'InstallerCollection' class. It Creates 'AssemblyInstaller' 
   instances for 'MyAssembly1.exe' and for 'MyAssembly2.exe'. These 
   instances are added to an instance of 'TransactedInstaller'. The installation 
   process installs both 'MyAssembly1.exe' and 'MyAssembly2.exe'.
*/

using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;

public class InstallerCollection_AddRange1
{
   public static void Main()
   {
      try
      {
// <Snippet1>
         ArrayList myInstallers =new ArrayList();
         TransactedInstaller myTransactedInstaller = new TransactedInstaller();
         AssemblyInstaller myAssemblyInstaller;
         InstallContext myInstallContext;

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
         myAssemblyInstaller = 
            new AssemblyInstaller("MyAssembly1.exe", null);

         // Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller);

         // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
         myAssemblyInstaller = 
            new AssemblyInstaller("MyAssembly2.exe", null);

         // Add the instance of 'AssemblyInstaller' to the list of installers.  
         myInstallers.Add(myAssemblyInstaller);

         // Add the installers to the 'TransactedInstaller' instance.
         myTransactedInstaller.Installers.AddRange((Installer[])myInstallers.ToArray(typeof(Installer)));
// </Snippet1>

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