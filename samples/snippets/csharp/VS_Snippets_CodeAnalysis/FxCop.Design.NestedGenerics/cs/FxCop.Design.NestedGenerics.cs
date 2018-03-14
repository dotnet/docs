//<Snippet1>
using System;
using System.Collections.Generic;

namespace DesignLibrary
{
   public class IntegerCollections
   {
      public void NotNestedCollection(ICollection<int> collection)
      {
         foreach(int i in collection)
         {
            Console.WriteLine(i);
         }
      }

      // This method violates the rule.
      public void NestedCollection(
         ICollection<ICollection<int>> outerCollection)
      {
         foreach(ICollection<int> innerCollection in outerCollection)
         {
            foreach(int i in innerCollection)
            {
               Console.WriteLine(i);
            }
         }
      }
   }

   class Test
   {
      static void Main()
      {
         IntegerCollections collections = new IntegerCollections();

         List<int> integerListA = new List<int>();
         integerListA.Add(1);
         integerListA.Add(2);
         integerListA.Add(3);

         collections.NotNestedCollection(integerListA);

         List<int> integerListB = new List<int>();
         integerListB.Add(4);
         integerListB.Add(5);
         integerListB.Add(6);

         List<int> integerListC = new List<int>();
         integerListC.Add(7);
         integerListC.Add(8);
         integerListC.Add(9);

         List<ICollection<int>> nestedIntegerLists = 
            new List<ICollection<int>>();
         nestedIntegerLists.Add(integerListA);
         nestedIntegerLists.Add(integerListB);
         nestedIntegerLists.Add(integerListC);

         collections.NestedCollection(nestedIntegerLists);
      }
   }
}
//</Snippet1>
