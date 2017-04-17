using System;

// <Snippet1>
namespace System.Runtime.InteropServices
{
   [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field |
    AttributeTargets.Property)]
   public class DispIdAttribute: System.Attribute
   {
      public DispIdAttribute(int value) {
        // . . .
      }
      
      public int Value {
         get {
            // . . .
            return 0;
         }
      }
   }
}
// </Snippet1>

