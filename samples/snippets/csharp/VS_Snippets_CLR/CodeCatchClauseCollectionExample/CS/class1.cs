using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace CodeCatchClauseCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}
        
        // CodeCatchClauseCollection
        public void CodeCatchClauseCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeCatchClauseCollection.
            CodeCatchClauseCollection collection = new CodeCatchClauseCollection();
            //</Snippet2>

            //<Snippet3>
            // Adds a CodeCatchClause to the collection.
            collection.Add( new CodeCatchClause("e") );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeCatchClause objects to the collection.
            CodeCatchClause[] clauses = { new CodeCatchClause(), new CodeCatchClause() };
            collection.AddRange( clauses );

            // Adds a collection of CodeCatchClause objects to the collection.
            CodeCatchClauseCollection clausesCollection = new CodeCatchClauseCollection();
            clausesCollection.Add( new CodeCatchClause("e", new CodeTypeReference(typeof(System.ArgumentOutOfRangeException))) );
            clausesCollection.Add( new CodeCatchClause("e") );
            collection.AddRange( clausesCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeCatchClause in the 
            // collection, and retrieves its index if it is found.
            CodeCatchClause testClause = new CodeCatchClause("e");
            int itemIndex = -1;
            if( collection.Contains( testClause ) )
                itemIndex = collection.IndexOf( testClause );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection beginning at index 0 to the specified CodeCatchClause array.
            // 'clauses' is a CodeCatchClause array.
            collection.CopyTo( clauses, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeCatchClause at index 0 of the collection.
            collection.Insert( 0, new CodeCatchClause("e") );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeCatchClause from the collection.
            CodeCatchClause clause = new CodeCatchClause("e");
            collection.Remove( clause );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeCatchClause at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}
