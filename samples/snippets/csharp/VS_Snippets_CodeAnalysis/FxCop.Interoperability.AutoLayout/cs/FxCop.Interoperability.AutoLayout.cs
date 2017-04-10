//<Snippet1>
using System;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
namespace InteroperabilityLibrary
{
   // This violates the rule.
   [StructLayout(LayoutKind.Auto)]
   [ComVisible(true)]
   public struct AutoLayout
   {
      public int ValueOne;
      public int ValueTwo;
   }

   // This satisfies the rule.
   [StructLayout(LayoutKind.Explicit)]
   [ComVisible(true)]
   public struct ExplicitLayout
   {
      [FieldOffset(0)]
      public int ValueOne;

      [FieldOffset(4)]
      public  int ValueTwo;
   }
}
//</Snippet1>
