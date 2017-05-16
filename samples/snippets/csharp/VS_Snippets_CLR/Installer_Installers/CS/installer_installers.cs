/*
   System.Configuration.Install.Installer.Installers
   System.Configuration.Install.Installer.Parent

   The following example demonstrates the properties 'Installers' and
   'Parent'. The Installers property shows the InstallerCollection 
   associated with an Installer and the Parent property gets the
   installer containing the collection that this installer belongs to.
*/

using System;
using System.Collections;
using System.ServiceProcess;
using System.Diagnostics;
using System.Configuration.Install;

public class Installer_Installers
{
   public static void Main()
   {
// <Snippet1>
      AssemblyInstaller myAssemblyInstaller = new AssemblyInstaller();
      ServiceInstaller myServiceInstaller = new ServiceInstaller();
      EventLogInstaller myEventLogInstaller = new EventLogInstaller();
      
      InstallerCollection myInstallerCollection = myAssemblyInstaller.Installers;
      
      // Add Installers to the InstallerCollection of 'myAssemblyInstaller'.
      myInstallerCollection.Add(myServiceInstaller);
      myInstallerCollection.Add(myEventLogInstaller);

      Installer[] myInstaller = new Installer[2];
      myInstallerCollection.CopyTo(myInstaller,0);
      // Show the contents of the InstallerCollection of 'myAssemblyInstaller'.
      Console.WriteLine("Installers in the InstallerCollection : ");
      for (int iIndex=0; iIndex < myInstaller.Length; iIndex++)
         Console.WriteLine(myInstaller[iIndex].ToString());
// </Snippet1>
      Console.WriteLine("");
// <Snippet2>
      AssemblyInstaller myAssemblyInstaller1 = new AssemblyInstaller();
      InstallerCollection myInstallerCollection1 = myAssemblyInstaller1.Installers;
      // 'myAssemblyInstaller' is an installer of type 'AssemblyInstaller'.
      myInstallerCollection1.Add(myAssemblyInstaller);

      Installer myInstaller1 = myAssemblyInstaller.Parent;
      Console.WriteLine("Parent of myAssembly : {0}", myInstaller1.ToString());
// </Snippet2>
   }
}
