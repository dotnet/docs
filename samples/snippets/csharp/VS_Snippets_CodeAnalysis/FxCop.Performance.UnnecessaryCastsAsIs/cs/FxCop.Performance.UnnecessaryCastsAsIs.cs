//<Snippet1>
using System;
using System.Collections;
using System.Windows.Forms;

namespace PerformanceLibrary
{
   public sealed class SomeClass
   {
      private SomeClass() {}

      // This method violates the rule.
      public static void UnderPerforming(ArrayList list)
      {
         foreach(object obj in list) 
         {
            // The 'is' statement performs a cast operation.
            if(obj is Control) 
            {
               // The 'as' statement performs a duplicate cast operation.
               Control aControl = obj as Control;
               // Use aControl.
            }

         }
      }

      // This method satisfies the rule.
      public static void BetterPerforming(ArrayList list)
      {
         foreach(object obj in list) 
         {
            Control aControl = obj as Control;
            if(aControl != null) 
            {
               // Use aControl.
            }
         }
      }
   }
}
//</Snippet1>
