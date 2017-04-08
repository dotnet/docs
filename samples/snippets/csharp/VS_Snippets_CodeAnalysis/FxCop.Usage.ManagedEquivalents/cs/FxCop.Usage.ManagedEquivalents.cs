//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace UsageLibrary
{
   internal class NativeMethods
   {
      private NativeMethods() {}

      // The following method definition violates the rule.
      [DllImport("kernel32.dll", CharSet = CharSet.Unicode, 
          SetLastError = true)]
      internal static extern int ExpandEnvironmentStrings(
         string lpSrc, StringBuilder lpDst, int nSize);
   }

   public class UseNativeMethod
   {
      public void Test()
      {
         string environmentVariable = "%TEMP%";
         StringBuilder expandedVariable = new StringBuilder(100);

         // Call the unmanaged method.
         NativeMethods.ExpandEnvironmentStrings(
            environmentVariable, 
            expandedVariable, 
            expandedVariable.Capacity);

         // Call the equivalent managed method.
         Environment.ExpandEnvironmentVariables(environmentVariable);
      }
   }
}
//</Snippet1>
