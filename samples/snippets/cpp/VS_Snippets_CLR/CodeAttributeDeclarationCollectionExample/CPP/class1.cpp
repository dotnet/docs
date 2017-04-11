#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;
using namespace System::Collections;

namespace CodeAttributeDeclarationCollectionExample
{
   public ref class Class1
   {
   public:
      Class1(){}

      // CodeAttributeDeclarationCollection
      void CodeAttributeDeclarationCollectionExample()
      {
         
         //<Snippet1>
         //<Snippet2>
         // Creates an empty CodeAttributeDeclarationCollection.
         CodeAttributeDeclarationCollection^ collection = gcnew CodeAttributeDeclarationCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a CodeAttributeDeclaration to the collection.
         array<CodeAttributeArgument^>^temp = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         collection->Add( gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of CodeAttributeDeclaration objects 
         // to the collection.
         array<CodeAttributeDeclaration^>^declarations = {gcnew CodeAttributeDeclaration,gcnew CodeAttributeDeclaration};
         collection->AddRange( declarations );

         // Adds a collection of CodeAttributeDeclaration objects 
         // to the collection.
         CodeAttributeDeclarationCollection^ declarationsCollection = gcnew CodeAttributeDeclarationCollection;
         array<CodeAttributeArgument^>^temp1 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         declarationsCollection->Add( gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp1 ) );
         array<CodeAttributeArgument^>^temp2 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( true ) )};
         declarationsCollection->Add( gcnew CodeAttributeDeclaration( "BrowsableAttribute",temp2 ) );
         collection->AddRange( declarationsCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a CodeAttributeDeclaration in 
         // the collection, and retrieves its index if it is found.
         array<CodeAttributeArgument^>^temp3 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         CodeAttributeDeclaration^ testdeclaration = gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp3 );
         int itemIndex = -1;
         if ( collection->Contains( testdeclaration ) )
            itemIndex = collection->IndexOf( testdeclaration );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection, beginning at index 0,
         // to the specified CodeAttributeDeclaration array.
         // 'declarations' is a CodeAttributeDeclaration array.
         collection->CopyTo( declarations, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a CodeAttributeDeclaration at index 0 of the collection.
         array<CodeAttributeArgument^>^temp4 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         collection->Insert( 0, gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp4 ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified CodeAttributeDeclaration from 
         // the collection.
         array<CodeAttributeArgument^>^temp5 = {gcnew CodeAttributeArgument( gcnew CodePrimitiveExpression( "Test Description" ) )};
         CodeAttributeDeclaration^ declaration = gcnew CodeAttributeDeclaration( "DescriptionAttribute",temp5 );
         collection->Remove( declaration );
         //</Snippet9>

         //<Snippet10>
         // Removes the CodeAttributeDeclaration at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>
         //</Snippet1>
      }
   };
}
