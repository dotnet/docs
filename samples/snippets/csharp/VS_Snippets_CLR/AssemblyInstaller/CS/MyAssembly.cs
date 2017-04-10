/*  The following example creates an assembly which is used to demonstrate
      the methods, properties and constructors of the 'AssemblyInstaller' class.
*/

using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.Collections;

namespace MyAssembly
{
   [RunInstallerAttribute(true)]
   public class MyProjectInstaller : Installer
   {
      static void Main()
      {
         Console.WriteLine( "Hello World" );
      }
   }
}
