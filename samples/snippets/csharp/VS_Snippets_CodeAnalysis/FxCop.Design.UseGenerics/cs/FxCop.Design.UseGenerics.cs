//<Snippet1>
using System;

namespace DesignLibrary
{
   public sealed class ReferenceParameters
   {
      private ReferenceParameters(){}

      // This method violates the rule.
      public static void Swap(ref object object1, ref object object2)
      {
         object temp = object1;
         object1 = object2;
         object2 = temp;
      }

      // This method satifies the rule.
      public static void GenericSwap<T>(ref T reference1, ref T reference2)
      {
         T temp = reference1;
         reference1 = reference2;
         reference2 = temp;
      }
   }

   class Test
   {
      static void Main()
      {
         string string1 = "Swap";
         string string2 = "It";

         object object1 = (object)string1;
         object object2 = (object)string2;
         ReferenceParameters.Swap(ref object1, ref object2);
         string1 = (string)object1;
         string2 = (string)object2;
         Console.WriteLine("{0} {1}", string1, string2);

         ReferenceParameters.GenericSwap(ref string1, ref string2);
         Console.WriteLine("{0} {1}", string1, string2);
      }
   }
}
//</Snippet1>
