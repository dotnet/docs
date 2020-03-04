#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;

namespace CodeCatchClauseCollectionExample
{
   public ref class Class1
   {
   public:
      Class1(){}

      // CodeCatchClauseCollection
      void CodeCatchClauseCollectionExample()
      {
         //<Snippet1>
         //<Snippet2>
         // Creates an empty CodeCatchClauseCollection.
         CodeCatchClauseCollection^ collection = gcnew CodeCatchClauseCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a CodeCatchClause to the collection.
         collection->Add( gcnew CodeCatchClause( "e" ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of CodeCatchClause objects to the collection.
         array<CodeCatchClause^>^clauses = {gcnew CodeCatchClause,gcnew CodeCatchClause};
         collection->AddRange( clauses );

         // Adds a collection of CodeCatchClause objects to the collection.
         CodeCatchClauseCollection^ clausesCollection = gcnew CodeCatchClauseCollection;
         clausesCollection->Add( gcnew CodeCatchClause( "e",gcnew CodeTypeReference( System::ArgumentOutOfRangeException::typeid ) ) );
         clausesCollection->Add( gcnew CodeCatchClause( "e" ) );
         collection->AddRange( clausesCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a CodeCatchClause in the 
         // collection, and retrieves its index if it is found.
         CodeCatchClause^ testClause = gcnew CodeCatchClause( "e" );
         int itemIndex = -1;
         if ( collection->Contains( testClause ) )
            itemIndex = collection->IndexOf( testClause );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection beginning at index 0 to the specified CodeCatchClause array.
         // 'clauses' is a CodeCatchClause array.
         collection->CopyTo( clauses, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a CodeCatchClause at index 0 of the collection.
         collection->Insert( 0, gcnew CodeCatchClause( "e" ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified CodeCatchClause from the collection.
         CodeCatchClause^ clause = gcnew CodeCatchClause( "e" );
         collection->Remove( clause );
         //</Snippet9>

         //<Snippet10>
         // Removes the CodeCatchClause at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>
         //</Snippet1>
      }
   };
}
