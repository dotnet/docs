// System.Configuration.Install.InstallerCollection.Insert(Int32, Installer)
// System.Configuration.Install.InstallerCollection.AddRange(InstallerCollection)

/*
   The following example demonstrates the 'Insert(Int32, Installer)' and
   'AddRange(InstallerCollection)' methods of the 'InstallerCollection' 
   class. It Creates 'AssemblyInstaller' instances for 'MyAssembly1.exe' 
   and 'MyAssembly2.exe'. These instances of 'AssemblyInstaller' are 
   added to an instance of 'TransactedInstaller' named 'myTransactedInstaller1'.
   The installers in the 'myTransactedInstaller1' are copied to another
   instance of 'TransactedInstaller' named 'myTransactedInstaller2'.The 
   installation process installs both 'MyAssembly1.exe' and 'MyAssembly2.exe'.
*/

using System;
using System.Reflection;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;


public class InstallerCollection_Insert
{
   public static void Main()
   {
// <Snippet1>
// <Snippet2>
      TransactedInstaller myTransactedInstaller1 = new TransactedInstaller();
      TransactedInstaller myTransactedInstaller2 = new TransactedInstaller();
      AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
      InstallContext myInstallContext;

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly1.exe'.
      myAssemblyInstaller = 
         new AssemblyInstaller("MyAssembly1.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(0, myAssemblyInstaller);

      // Create a instance of 'AssemblyInstaller' that installs 'MyAssembly2.exe'.
      myAssemblyInstaller = 
         new AssemblyInstaller("MyAssembly2.exe", null);

      // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
      myTransactedInstaller1.Installers.Insert(1, myAssemblyInstaller);

      // Copy the installers of 'myTransactedInstaller1' to 'myTransactedInstaller2'.
      myTransactedInstaller2.Installers.AddRange(myTransactedInstaller1.Installers);

// </Snippet2>
// </Snippet1>

      // Create a instance of 'InstallContext' with log file named 'Install.log'.
      myInstallContext = 
         new InstallContext("Install.log", null);
      myTransactedInstaller2.Context = myInstallContext;

      // Install an assembly.
      myTransactedInstaller2.Install(new Hashtable());  
   }  
}