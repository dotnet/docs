#using <System.dll>

using namespace System;
using namespace System::CodeDom;
using namespace System::CodeDom::Compiler;

namespace CodeCommentStatementCollectionExample
{
   public ref class Class1
   {
   public:
      Class1(){}

      // CodeCommentStatementCollection
      void CodeCommentStatementCollectionExample()
      {
         
         //<Snippet1>
         //<Snippet2>
         // Creates an empty CodeCommentStatementCollection.
         CodeCommentStatementCollection^ collection = gcnew CodeCommentStatementCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a CodeCommentStatement to the collection.
         collection->Add( gcnew CodeCommentStatement( "Test comment" ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of CodeCommentStatement objects to the collection.
         array<CodeCommentStatement^>^comments = {gcnew CodeCommentStatement( "Test comment" ),gcnew CodeCommentStatement( "Another test comment" )};
         collection->AddRange( comments );
         
         // Adds a collection of CodeCommentStatement objects to the collection.
         CodeCommentStatementCollection^ commentsCollection = gcnew CodeCommentStatementCollection;
         commentsCollection->Add( gcnew CodeCommentStatement( "Test comment" ) );
         commentsCollection->Add( gcnew CodeCommentStatement( "Another test comment" ) );
         collection->AddRange( commentsCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a CodeCommentStatement in the 
         // collection, and retrieves its index if it is found.
         CodeCommentStatement^ testComment = gcnew CodeCommentStatement( "Test comment" );
         int itemIndex = -1;
         if ( collection->Contains( testComment ) )
            itemIndex = collection->IndexOf( testComment );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection, beginning at index 0, 
         // to the specified CodeCommentStatement array.
         // 'comments' is a CodeCommentStatement array.
         collection->CopyTo( comments, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a CodeCommentStatement at index 0 of the collection.
         collection->Insert( 0, gcnew CodeCommentStatement( "Test comment" ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified CodeCommentStatement from the collection.
         CodeCommentStatement^ comment = gcnew CodeCommentStatement( "Test comment" );
         collection->Remove( comment );
         //</Snippet9>

         //<Snippet10>
         // Removes the CodeCommentStatement at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>
         //</Snippet1>
      }
   };
}
