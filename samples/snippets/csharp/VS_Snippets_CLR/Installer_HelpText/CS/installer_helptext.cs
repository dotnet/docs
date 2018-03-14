/*
   System.Configuration.Install.Installer.HelpText
   
   The following example demonstrates the property 'HelpText'. The
   'HelpText' property is defined in the 'Installer', which when called
   returns the description of the 'Installer' and the command line 
   options for the installation executable, such as the InstallUtil.exe utility,
   that can be passed to and understood by the 'Installer'.

   Use 'installutil' to run the assembly Installer_HelpText.exe.
*/
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;

[RunInstaller(true)]
public class MyInstaller: Installer 
{
   // Override the 'Install' method.
   public override void Install(IDictionary savedState)
   {
      base.Install(savedState);
      string myHelpText = HelpText;
      Console.WriteLine("Help Text : ");
      Console.WriteLine(myHelpText);
   }

   // Override the 'Commit' method.
   public override void Commit(IDictionary savedState)
   {
      base.Commit(savedState);
   }

   // Override the 'Rollback' method.
   public override void Rollback(IDictionary savedState)
   {
      base.Rollback(savedState);
   }

   // Override the 'Uninstall' method.
   public override void Uninstall(IDictionary savedState)
   {
      base.Uninstall(savedState);
   }
// <Snippet1>
   // Override the property 'HelpText'.
   public override string HelpText
   {
      get
      {
         return "Installer Description : This is a sample Installer\n"
              + "HelpText is used to provide useful information about the "
              + "installer.";
      }
   }
// </Snippet1>
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Use installutil.exe to run the assembly Installer_HelpText.exe");
   }
}

