//<Snippet1>
using System;
using System.Windows.Forms;

namespace PerformanceLibrary
{
   public class UnusedLocals
   {
      public void SomeMethod()
      {
         int unusedInteger;
         string unusedString = "hello";
         string[] unusedArray = Environment.GetLogicalDrives();
         Button unusedButton = new Button();
      }
   }
}
//</Snippet1>
