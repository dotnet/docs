using System;
using System.CodeDom;

namespace CodeTypeDeclarationCollectionExample
{
	public class Class1
	{
		public Class1()
		{
		}

        // CodeTypeDeclarationCollection
        public void CodeTypeDeclarationCollectionExample()
        {
            //<Snippet1>
            //<Snippet2>
            // Creates an empty CodeTypeDeclarationCollection.
            CodeTypeDeclarationCollection collection = new CodeTypeDeclarationCollection();
            //</Snippet2>

            //<Snippet3>
            // Adds a CodeTypeDeclaration to the collection.
            collection.Add( new CodeTypeDeclaration("TestType") );
            //</Snippet3>

            //<Snippet4>
            // Adds an array of CodeTypeDeclaration objects to the collection.
            CodeTypeDeclaration[] declarations = { new CodeTypeDeclaration("TestType1"), new CodeTypeDeclaration("TestType2") };
            collection.AddRange( declarations );

            // Adds a collection of CodeTypeDeclaration objects to the 
            // collection.
            CodeTypeDeclarationCollection declarationsCollection = new CodeTypeDeclarationCollection();
            declarationsCollection.Add( new CodeTypeDeclaration("TestType1") );
            declarationsCollection.Add( new CodeTypeDeclaration("TestType2") );
            collection.AddRange( declarationsCollection );
            //</Snippet4>

            //<Snippet5>
            // Tests for the presence of a CodeTypeDeclaration in the 
            // collection, and retrieves its index if it is found.
            CodeTypeDeclaration testDeclaration = new CodeTypeDeclaration("TestType");
            int itemIndex = -1;
            if( collection.Contains( testDeclaration ) )
                itemIndex = collection.IndexOf( testDeclaration );
            //</Snippet5>

            //<Snippet6>
            // Copies the contents of the collection, beginning at index 0,
            // to the specified CodeTypeDeclaration array.
            // 'declarations' is a CodeTypeDeclaration array.
            collection.CopyTo( declarations, 0 );
            //</Snippet6>

            //<Snippet7>
            // Retrieves the count of the items in the collection.
            int collectionCount = collection.Count;
            //</Snippet7>

            //<Snippet8>
            // Inserts a CodeTypeDeclaration at index 0 of the collection.
            collection.Insert( 0, new CodeTypeDeclaration("TestType") );
            //</Snippet8>

            //<Snippet9>
            // Removes the specified CodeTypeDeclaration from the collection.
            CodeTypeDeclaration declaration = new CodeTypeDeclaration("TestType");
            collection.Remove( declaration );
            //</Snippet9>

            //<Snippet10>
            // Removes the CodeTypeDeclaration at index 0.
            collection.RemoveAt(0);
            //</Snippet10>
            //</Snippet1>
        }
	}
}