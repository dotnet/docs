#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeTypeDeclarationCollectionExample
{
   public ref class Class1
   {
   public:
      Class1(){}

      // CodeTypeDeclarationCollection
      void CodeTypeDeclarationCollectionExample()
      {
         
         //<Snippet1>
         //<Snippet2>
         // Creates an empty CodeTypeDeclarationCollection.
         CodeTypeDeclarationCollection^ collection = gcnew CodeTypeDeclarationCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a CodeTypeDeclaration to the collection.
         collection->Add( gcnew CodeTypeDeclaration( "TestType" ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of CodeTypeDeclaration objects to the collection.
         array<CodeTypeDeclaration^>^declarations = {gcnew CodeTypeDeclaration( "TestType1" ),gcnew CodeTypeDeclaration( "TestType2" )};
         collection->AddRange( declarations );
         
         // Adds a collection of CodeTypeDeclaration objects to the 
         // collection.
         CodeTypeDeclarationCollection^ declarationsCollection = gcnew CodeTypeDeclarationCollection;
         declarationsCollection->Add( gcnew CodeTypeDeclaration( "TestType1" ) );
         declarationsCollection->Add( gcnew CodeTypeDeclaration( "TestType2" ) );
         collection->AddRange( declarationsCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a CodeTypeDeclaration in the 
         // collection, and retrieves its index if it is found.
         CodeTypeDeclaration^ testDeclaration = gcnew CodeTypeDeclaration( "TestType" );
         int itemIndex = -1;
         if ( collection->Contains( testDeclaration ) )
            itemIndex = collection->IndexOf( testDeclaration );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection, beginning at index 0,
         // to the specified CodeTypeDeclaration array.
         // 'declarations' is a CodeTypeDeclaration array.
         collection->CopyTo( declarations, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a CodeTypeDeclaration at index 0 of the collection.
         collection->Insert( 0, gcnew CodeTypeDeclaration( "TestType" ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified CodeTypeDeclaration from the collection.
         CodeTypeDeclaration^ declaration = gcnew CodeTypeDeclaration( "TestType" );
         collection->Remove( declaration );
         //</Snippet9>

         //<Snippet10>
         // Removes the CodeTypeDeclaration at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>
         //</Snippet1>
      }
   };
}
