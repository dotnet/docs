// System.Configuration.Install.InstallerCollection
// System.Configuration.Install.InstallerCollection.Add(Installer)

/*
   The following example demonstrates the Add(Installer)
   method of the 'InstallerCollection' class. This example provides
   an implementation similar to that of 'InstallUtil.exe'. It installs
   assemblies with the options preceding that particular assembly.
   If an option is not specified for an assembly the previous assemblies
   options are taken if there is a previous assembly in the list. If the
   '/u' or '/uninstall' option is specified then the assemblies are uninstalled.
   If the '/?' or '/help' option is provided then the help information is
  displayed to the console.
*/

// <Snippet1>
using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration.Install;
using System.IO;

public class InstallerCollection_Add
{
   public static void Main(String[] args)
   {
      ArrayList options = new ArrayList();
      String myOption;
      bool toUnInstall = false;
      bool toPrintHelp = false;
      TransactedInstaller myTransactedInstaller = new TransactedInstaller();
      AssemblyInstaller myAssemblyInstaller;
      InstallContext myInstallContext;

      try
      {
         for(int i = 0; i < args.Length; i++)
         {
            // Process the arguments.
            if(args[i].StartsWith("/") || args[i].StartsWith("-"))
            {
               myOption = args[i].Substring(1);
               // Determine whether the option is to 'uninstall' a assembly.
               if(String.Compare(myOption, "u", true) == 0 ||
                  String.Compare(myOption, "uninstall", true) == 0)
               {
                  toUnInstall = true;
                  continue;
               }
               // Determine whether the option is for printing help information.
               if(String.Compare(myOption, "?", true) == 0 ||
                  String.Compare(myOption, "help", true) == 0)
               {
                  toPrintHelp = true;
                  continue;
               }
               // Add the option encountered to the list of all options
               // encountered for the current assembly.
               options.Add(myOption);
            }
            else
            {
               // Determine whether the assembly file exists.
               if(!File.Exists(args[i]))
               {
                  // If assembly file doesn't exist then print error.
                  Console.WriteLine(" Error : {0} - Assembly file doesn't exist.", args[i]);
                  return;
               }
// <Snippet2>
               // Create an instance of 'AssemblyInstaller' that installs the given assembly.
               myAssemblyInstaller = new AssemblyInstaller(args[i],
                  (string[]) options.ToArray(typeof(string)));
               // Add the instance of 'AssemblyInstaller' to the 'TransactedInstaller'.
               myTransactedInstaller.Installers.Add(myAssemblyInstaller);
// </Snippet2>
            }
         }
         // If user requested help or didn't provide any assemblies to install
         // then print help message.
         if(toPrintHelp || myTransactedInstaller.Installers.Count == 0)
         {
            PrintHelpMessage();
            return;
         }

         // Create an instance of 'InstallContext' with the options specified.
         myInstallContext =
            new InstallContext("Install.log",
            (string[]) options.ToArray(typeof(string)));
         myTransactedInstaller.Context = myInstallContext;

         // Install or Uninstall an assembly depending on the option provided.
         if(!toUnInstall)
            myTransactedInstaller.Install(new Hashtable());
         else
            myTransactedInstaller.Uninstall(null);
      }
      catch(Exception e)
      {
         Console.WriteLine(" Exception raised : {0}", e.Message);
      }
   }

   public static void PrintHelpMessage()
   {
      Console.WriteLine("Usage : InstallerCollection_Add [/u | /uninstall] [option [...]] assembly" +
         "[[option [...]] assembly] [...]]");
      Console.WriteLine("InstallerCollection_Add executes the installers in each of" +
         " the given assembly. If /u or /uninstall option" +
         " is given it uninstalls the assemblies.");
   }
}
// </Snippet1>