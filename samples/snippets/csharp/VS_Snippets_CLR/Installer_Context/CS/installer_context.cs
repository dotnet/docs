/*
   System.Configuration.Install.Installer.Context

   The following example demonstrates the 'Context' property of 
   the 'Installer' class. The contents of the 'Context' property 
   like information about the location of the log file for the 
   installation, the location of the file to save information 
   required by the Uninstall method, and the command line that 
   was entered when the installation executable was run is 
   displayed on the console.
   
   Use 'installutil' to run the assembly Installer_Context.exe
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections.Specialized;

[RunInstaller(true)]
public class MyInstaller : Installer
{
   // Override the 'Install' method.
   public override void Install( IDictionary mySavedState )
   {
      base.Install(mySavedState);
      Console.WriteLine( "" );
// <Snippet1>
      StringDictionary myStringDictionary = Context.Parameters;
      if ( Context.Parameters.Count > 0 )
      {
         Console.WriteLine("Context Property : " );
         foreach( string myString in Context.Parameters.Keys)
         {
            Console.WriteLine( Context.Parameters[ myString ] );
         }
      }
// </Snippet1>
      Console.WriteLine( "" );
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
}

public class MyAssembly
{
   public static void Main()
   {
      Console.WriteLine("Run the assembly Installer_Context.exe using the" +
                        " installer process 'installutil'");
   }
}
