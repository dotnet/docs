using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace CompilerErrorCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}

        // CompilerErrorCollection
        public void CompilerErrorCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CompilerErrorCollection.
            CompilerErrorCollection collection = new CompilerErrorCollection();            			
            //</Snippet2>

            //<Snippet3>
            // Adds a CompilerError to the collection.
            collection.Add( new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CompilerError objects to the collection.
            CompilerError[] errors = { new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text"), new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") };
            collection.AddRange( errors );

            // Adds a collection of CompilerError objects to the collection.
            CompilerErrorCollection errorsCollection = new CompilerErrorCollection();
            errorsCollection.Add( new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") );
            errorsCollection.Add( new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") );
            collection.AddRange( errorsCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CompilerError in the 
            // collection, and retrieves its index if it is found.
            CompilerError testError = new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text");
            int itemIndex = -1;
            if( collection.Contains( testError ) )
                itemIndex = collection.IndexOf( testError );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection, beginning at index 0, 
            // to the specified CompilerError array.
            // 'errors' is a CompilerError array.
            collection.CopyTo( errors, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CompilerError at index 0 of the collection.
            collection.Insert( 0, new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text") );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CompilerError from the collection.
            CompilerError error = new CompilerError("Testfile.cs", 5, 10, "CS0001", "Example error text");
            collection.Remove( error );
            //</Snippet9>
            
            //<Snippet10>
            // Removes the CompilerError at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}