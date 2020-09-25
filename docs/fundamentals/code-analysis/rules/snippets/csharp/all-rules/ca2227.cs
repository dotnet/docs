using System;
using System.Collections;

namespace ca2227
{
    //<snippet1>
    public class WritableCollection
    {
        public ArrayList SomeStrings
        {
            get;

            // This set accessor violates rule CA2227.
            // To fix the code, remove this set accessor.
            set;
        }

        public WritableCollection()
        {
            SomeStrings = new ArrayList(new string[] { "one", "two", "three" });
        }
    }

    class ReplaceWritableCollection
    {
        static void Main2227()
        {
            ArrayList newCollection = new ArrayList(new string[] { "a", "new", "collection" });

            WritableCollection collection = new WritableCollection();

            // This line of code demonstrates how the entire collection
            // can be replaced by a property that's not read only.
            collection.SomeStrings = newCollection;

            // If the intent is to replace an entire collection,
            // implement and/or use the Clear() and AddRange() methods instead.
            collection.SomeStrings.Clear();
            collection.SomeStrings.AddRange(newCollection);
        }
    }
    //</snippet1>
}
