using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace CodeAttributeArgumentCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}

        // CodeAttributeArgumentCollection
        public void CodeAttributeArgumentCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeAttributeArgumentCollection.
            CodeAttributeArgumentCollection collection = new CodeAttributeArgumentCollection();
            //</Snippet2>

            //<Snippet3>
            // Adds a CodeAttributeArgument to the collection.
            collection.Add( new CodeAttributeArgument("Test Boolean Argument", new CodePrimitiveExpression(true)) );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeAttributeArgument objects to the collection.
            CodeAttributeArgument[] arguments = { new CodeAttributeArgument(), new CodeAttributeArgument() };
            collection.AddRange( arguments );

            // Adds a collection of CodeAttributeArgument objects to 
            // the collection.
            CodeAttributeArgumentCollection argumentsCollection = new CodeAttributeArgumentCollection();
            argumentsCollection.Add( new CodeAttributeArgument("TestBooleanArgument", new CodePrimitiveExpression(true)) );
            argumentsCollection.Add( new CodeAttributeArgument("TestIntArgument", new CodePrimitiveExpression(1)) );
            collection.AddRange( argumentsCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeAttributeArgument 
            // within the collection, and retrieves its index if it is found.
            CodeAttributeArgument testArgument = new CodeAttributeArgument("Test Boolean Argument", new CodePrimitiveExpression(true));
            int itemIndex = -1;
            if( collection.Contains( testArgument ) )
                itemIndex = collection.IndexOf( testArgument );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection beginning at index 0,
            // to the specified CodeAttributeArgument array.
            // 'arguments' is a CodeAttributeArgument array.
            collection.CopyTo( arguments, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeAttributeArgument at index 0 of the collection.
            collection.Insert( 0, new CodeAttributeArgument("Test Boolean Argument", new CodePrimitiveExpression(true)) );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeAttributeArgument from the collection.
            CodeAttributeArgument argument = new CodeAttributeArgument("Test Boolean Argument", new CodePrimitiveExpression(true));
            collection.Remove( argument );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeAttributeArgument at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}