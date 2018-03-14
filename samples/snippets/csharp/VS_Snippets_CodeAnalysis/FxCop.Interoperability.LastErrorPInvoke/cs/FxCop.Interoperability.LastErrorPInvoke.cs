//<Snippet1>
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace InteroperabilityLibrary
{
   internal class NativeMethods
   {
      private NativeMethods() {}

      // Violates rule UseManagedEquivalentsOfWin32Api.
      [DllImport("kernel32.dll", CharSet = CharSet.Auto, 
          SetLastError = true)]
      internal static extern int ExpandEnvironmentStrings(
         string lpSrc, StringBuilder lpDst, int nSize);
   }

   public class UseNativeMethod
   {
      string environmentVariable = "%TEMP%";
      StringBuilder expandedVariable;

      public void ViolateRule()
      {
         expandedVariable = new StringBuilder(100);

         if(NativeMethods.ExpandEnvironmentStrings(
            environmentVariable, 
            expandedVariable, 
            expandedVariable.Capacity) == 0)
         {
            // Violates rule CallGetLastErrorImmediatelyAfterPInvoke.
            Console.Error.WriteLine(Marshal.GetLastWin32Error());
         }
         else
         {
            Console.WriteLine(expandedVariable);
         }
      }

      public void SatisfyRule()
      {
         expandedVariable = new StringBuilder(100);

         if(NativeMethods.ExpandEnvironmentStrings(
            environmentVariable, 
            expandedVariable, 
            expandedVariable.Capacity) == 0)
         {
            // Satisfies rule CallGetLastErrorImmediatelyAfterPInvoke.
            int lastError = Marshal.GetLastWin32Error();
            Console.Error.WriteLine(lastError);
         }
         else
         {
            Console.WriteLine(expandedVariable);
         }
      }
   }
}
//</Snippet1>
