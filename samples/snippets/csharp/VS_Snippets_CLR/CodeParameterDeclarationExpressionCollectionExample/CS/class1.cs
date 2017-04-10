using System;
using System.CodeDom;

namespace CodeParameterDeclarationExpressionCollectionExample
{
	public class Class1
	{
		public Class1()
		{			
		}

        // CodeParameterDeclarationExpressionCollection
        public void CodeParameterDeclarationExpressionCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeParameterDeclarationExpressionCollection.
            CodeParameterDeclarationExpressionCollection collection = new CodeParameterDeclarationExpressionCollection();
            //</Snippet2>

            //<Snippet3>
            // Adds a CodeParameterDeclarationExpression to the collection.
            collection.Add( new CodeParameterDeclarationExpression(typeof(int), "testIntArgument") );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeParameterDeclarationExpression objects 
            // to the collection.
            CodeParameterDeclarationExpression[] parameters = { new CodeParameterDeclarationExpression(typeof(int), "testIntArgument"), new CodeParameterDeclarationExpression(typeof(bool), "testBoolArgument") };
            collection.AddRange( parameters );

            // Adds a collection of CodeParameterDeclarationExpression objects 
            // to the collection.
            CodeParameterDeclarationExpressionCollection parametersCollection = new CodeParameterDeclarationExpressionCollection();
            parametersCollection.Add( new CodeParameterDeclarationExpression(typeof(int), "testIntArgument") );
            parametersCollection.Add( new CodeParameterDeclarationExpression(typeof(bool), "testBoolArgument") );
            collection.AddRange( parametersCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeParameterDeclarationExpression 
            // in the collection, and retrieves its index if it is found.
            CodeParameterDeclarationExpression testParameter = new CodeParameterDeclarationExpression(typeof(int), "testIntArgument");
            int itemIndex = -1;
            if( collection.Contains( testParameter ) )
                itemIndex = collection.IndexOf( testParameter );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection beginning at index 0 to the specified CodeParameterDeclarationExpression array.
            // 'parameters' is a CodeParameterDeclarationExpression array.
            collection.CopyTo( parameters, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeParameterDeclarationExpression at index 0 
            // of the collection.
            collection.Insert( 0, new CodeParameterDeclarationExpression(typeof(int), "testIntArgument") );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeParameterDeclarationExpression 
            // from the collection.
            CodeParameterDeclarationExpression parameter = new CodeParameterDeclarationExpression(typeof(int), "testIntArgument");
            collection.Remove( parameter );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeParameterDeclarationExpression at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}