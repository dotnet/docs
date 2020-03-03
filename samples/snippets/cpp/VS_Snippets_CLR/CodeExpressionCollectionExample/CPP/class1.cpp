#using <System.dll>

using namespace System;
using namespace System::CodeDom;

namespace CodeExpressionCollectionExample
{
   public ref class Class1
   {
   public:
      Class1(){}

      // CodeExpressionCollection
      void CodeExpressionCollectionExample()
      {
         //<Snippet1>
         //<Snippet2>
         // Creates an empty CodeExpressionCollection.
         CodeExpressionCollection^ collection = gcnew CodeExpressionCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a CodeExpression to the collection.
         collection->Add( gcnew CodePrimitiveExpression( true ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of CodeExpression objects to the collection.
         array<CodeExpression^>^expressions = {gcnew CodePrimitiveExpression( true ),gcnew CodePrimitiveExpression( true )};
         collection->AddRange( expressions );
         
         // Adds a collection of CodeExpression objects to the collection.
         CodeExpressionCollection^ expressionsCollection = gcnew CodeExpressionCollection;
         expressionsCollection->Add( gcnew CodePrimitiveExpression( true ) );
         expressionsCollection->Add( gcnew CodePrimitiveExpression( true ) );
         collection->AddRange( expressionsCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a CodeExpression in the 
         // collection, and retrieves its index if it is found.
         CodeExpression^ testComment = gcnew CodePrimitiveExpression( true );
         int itemIndex = -1;
         if ( collection->Contains( testComment ) )
            itemIndex = collection->IndexOf( testComment );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection beginning at index 0 to the specified CodeExpression array.
         // 'expressions' is a CodeExpression array.
         collection->CopyTo( expressions, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a CodeExpression at index 0 of the collection.
         collection->Insert( 0, gcnew CodePrimitiveExpression( true ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified CodeExpression from the collection.
         CodeExpression^ expression = gcnew CodePrimitiveExpression( true );
         collection->Remove( expression );
         //</Snippet9>

         //<Snippet10>
         // Removes the CodeExpression at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>           
         //</Snippet1>
      }
   };
}
