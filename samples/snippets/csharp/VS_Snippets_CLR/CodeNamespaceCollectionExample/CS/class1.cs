using System;
using System.CodeDom;

namespace CodeNamespaceCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}

        // CodeNamespaceCollection
        public void CodeNamespaceCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeNamespaceCollection.            
            CodeNamespaceCollection collection = new CodeNamespaceCollection();
            //</Snippet2>
            
            //<Snippet3>
            // Adds a CodeNamespace to the collection.
            collection.Add( new CodeNamespace("TestNamespace") );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeNamespace objects to the collection.
            CodeNamespace[] namespaces = { new CodeNamespace("TestNamespace1"), new CodeNamespace("TestNamespace2") };
            collection.AddRange( namespaces );

            // Adds a collection of CodeNamespace objects to the collection.
            CodeNamespaceCollection namespacesCollection = new CodeNamespaceCollection();
            namespacesCollection.Add( new CodeNamespace("TestNamespace1") );
            namespacesCollection.Add( new CodeNamespace("TestNamespace2") );
            collection.AddRange( namespacesCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeNamespace in the collection,
            // and retrieves its index if it is found.
            CodeNamespace testNamespace = new CodeNamespace("TestNamespace");
            int itemIndex = -1;
            if( collection.Contains( testNamespace ) )
                itemIndex = collection.IndexOf( testNamespace );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection beginning at index 0,
            // to the specified CodeNamespace array.
            // 'namespaces' is a CodeNamespace array.
            collection.CopyTo( namespaces, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeNamespace at index 0 of the collection.
            collection.Insert( 0, new CodeNamespace("TestNamespace") );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeNamespace from the collection.
            CodeNamespace namespace_ = new CodeNamespace("TestNamespace");
            collection.Remove( namespace_ );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeNamespace at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}