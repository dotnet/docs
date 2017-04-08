//<Snippet1>
using System;
using System.Collections;

namespace UsageLibrary
{
   public class WritableCollection
   {
      ArrayList strings;

      public ArrayList SomeStrings
      {
         get { return strings; }

         // Violates the rule.
         set { strings = value; }
      }

      public WritableCollection()
      {
         strings = new ArrayList(
            new string[] {"IEnumerable", "ICollection", "IList"} );
      }
   }

   class ReplaceWritableCollection
   {
      static void Main()
      {
         ArrayList newCollection = new ArrayList(
            new string[] {"a", "new", "collection"} );

         // strings is directly replaced with newCollection.
         WritableCollection collection = new WritableCollection();
         collection.SomeStrings = newCollection;

         // newCollection is added to the cleared strings collection.
         collection.SomeStrings.Clear();
         collection.SomeStrings.AddRange(newCollection);
      }
   }
}
//</Snippet1>
