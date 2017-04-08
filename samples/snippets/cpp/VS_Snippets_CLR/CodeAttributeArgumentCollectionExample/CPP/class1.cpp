#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;

namespace CodeAttributeArgumentCollectionExample
{
   public ref class Class1
   {
   public:
      Class1(){}


      // CodeAttributeArgumentCollection
      void CodeAttributeArgumentCollectionExample()
      {
         
         //<Snippet1>
         //<Snippet2>
         // Creates an empty CodeAttributeArgumentCollection.
         CodeAttributeArgumentCollection^ collection = gcnew CodeAttributeArgumentCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a CodeAttributeArgument to the collection.
         collection->Add( gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of CodeAttributeArgument objects to the collection.
         array<CodeAttributeArgument^>^arguments = {gcnew CodeAttributeArgument,gcnew CodeAttributeArgument};
         collection->AddRange( arguments );
         
         // Adds a collection of CodeAttributeArgument objects to 
         // the collection.
         CodeAttributeArgumentCollection^ argumentsCollection = gcnew CodeAttributeArgumentCollection;
         argumentsCollection->Add( gcnew CodeAttributeArgument( "TestBooleanArgument",gcnew CodePrimitiveExpression( true ) ) );
         argumentsCollection->Add( gcnew CodeAttributeArgument( "TestIntArgument",gcnew CodePrimitiveExpression( 1 ) ) );
         collection->AddRange( argumentsCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a CodeAttributeArgument 
         // within the collection, and retrieves its index if it is found.
         CodeAttributeArgument^ testArgument = gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) );
         int itemIndex = -1;
         if ( collection->Contains( testArgument ) )
            itemIndex = collection->IndexOf( testArgument );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection beginning at index 0,
         // to the specified CodeAttributeArgument array.
         // 'arguments' is a CodeAttributeArgument array.
         collection->CopyTo( arguments, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a CodeAttributeArgument at index 0 of the collection.
         collection->Insert( 0, gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified CodeAttributeArgument from the collection.
         CodeAttributeArgument^ argument = gcnew CodeAttributeArgument( "Test Boolean Argument",gcnew CodePrimitiveExpression( true ) );
         collection->Remove( argument );
         //</Snippet9>

         //<Snippet10>
         // Removes the CodeAttributeArgument at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>
         //</Snippet1>
      }
   };
}
