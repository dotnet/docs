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

      // This method satisfies the rule by checking
      // the result of the as operation.
      public static void BetterPerforming1(ArrayList list)
      {
          foreach (object obj in list)
          {
              Control aControl = obj as Control;
              if (aControl != null)
              {
                  // Use aControl.
                  Console.WriteLine(aControl.Name);
              }
          }
      }

      // This method also satisfies the rule by using
      // the is operator with a type pattern (C# 7.0).
      public static void BetterPerforming2(ArrayList list)
      {
          foreach (object obj in list)
          {
              if (obj is Control aControl)
              {
                  // Use aControl.
                  Console.WriteLine(aControl.Name);
              }
          }
      }
   }
}