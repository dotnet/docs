using System;
using System.CodeDom;

namespace CodeTypeReferenceCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}
        
        // CodeTypeReferenceCollection
        public void CodeTypeReferenceCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeTypeReferenceCollection.
            CodeTypeReferenceCollection collection = new CodeTypeReferenceCollection();
            //</Snippet2>
            
            //<Snippet3>
            // Adds a CodeTypeReference to the collection.
            collection.Add( new CodeTypeReference(typeof(bool)) );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeTypeReference objects to the collection.
            CodeTypeReference[] references = { new CodeTypeReference(typeof(bool)), new CodeTypeReference(typeof(bool)) };
            collection.AddRange( references );

            // Adds a collection of CodeTypeReference objects to the collection.
            CodeTypeReferenceCollection referencesCollection = new CodeTypeReferenceCollection();
            referencesCollection.Add( new CodeTypeReference(typeof(bool)) );
            referencesCollection.Add( new CodeTypeReference(typeof(bool)) );
            collection.AddRange( referencesCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeTypeReference in the 
            // collection, and retrieves its index if it is found.
            CodeTypeReference testReference = new CodeTypeReference(typeof(bool));
            int itemIndex = -1;
            if( collection.Contains( testReference ) )
                itemIndex = collection.IndexOf( testReference );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection, beginning at index 0, 
            // to the specified CodeTypeReference array.
            // 'references' is a CodeTypeReference array.
            collection.CopyTo( references, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeTypeReference at index 0 of the collection.
            collection.Insert( 0, new CodeTypeReference(typeof(bool)) );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeTypeReference from the collection.
            CodeTypeReference reference = new CodeTypeReference(typeof(bool));
            collection.Remove( reference );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeTypeReference at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }    
	}
}