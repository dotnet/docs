using System;
using System.CodeDom;

namespace CodeDirectiveCollectionExample
{
    public class Class1
    {
        public Class1()
        {
        }

        // CodeDirectiveCollection
        public void CodeDirectiveCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeDirectiveCollection.
            CodeDirectiveCollection collection = new CodeDirectiveCollection();
            //</Snippet2>

            //<Snippet3>
            // Adds a CodeDirective to the collection.
            collection.Add(new CodeRegionDirective(CodeRegionMode.Start, "Region1"));
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeDirective objects to the collection.
            CodeDirective[] directives = { 
                new CodeRegionDirective(CodeRegionMode.Start,"Region1"), 
                new CodeRegionDirective(CodeRegionMode.End,"Region1") };
            collection.AddRange(directives);

            // Adds a collection of CodeDirective objects to the collection.
            CodeDirectiveCollection directivesCollection = new CodeDirectiveCollection();
            directivesCollection.Add(new CodeRegionDirective(CodeRegionMode.Start, "Region2"));
            directivesCollection.Add(new CodeRegionDirective(CodeRegionMode.End, "Region2"));
            collection.AddRange(directivesCollection);
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeDirective in the 
            // collection, and retrieves its index if it is found.
            CodeDirective testDirective = new CodeRegionDirective(CodeRegionMode.Start, "Region1");
            int itemIndex = -1;
            if (collection.Contains(testDirective))
                itemIndex = collection.IndexOf(testDirective);
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection beginning at index 0 to the specified CodeDirective array.
            // 'directives' is a CodeDirective array.
            collection.CopyTo(directives, 0);
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeDirective at index 0 of the collection.
            collection.Insert(0, new CodeRegionDirective(CodeRegionMode.Start, "Region1"));
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeDirective from the collection.
            CodeDirective directive = new CodeRegionDirective(CodeRegionMode.Start, "Region1");
            collection.Remove(directive);
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeDirective at index 0.
            collection.RemoveAt(0);
            //</Snippet10>           
            //</Snippet1>
        }
    }
}
