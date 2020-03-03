#using <system.dll>

using namespace System;
using namespace System::ComponentModel::Design;
using namespace System::Security::Permissions;

namespace DesignerVerbCollectionExample
{
   public ref class Class1
   {
   private:
      void ExampleEvent( Object^ sender, EventArgs^ e )
      {
      }

   public:
      // DesignerVerbCollection
      [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
      void DesignerVerbCollectionExample()
      {
         //<Snippet1>
         //<Snippet2>
         // Creates an empty DesignerVerbCollection.
         DesignerVerbCollection^ collection = gcnew DesignerVerbCollection;
         //</Snippet2>

         //<Snippet3>
         // Adds a DesignerVerb to the collection.
         collection->Add( gcnew DesignerVerb( "Example designer verb",gcnew EventHandler( this, &Class1::ExampleEvent ) ) );
         //</Snippet3>

         //<Snippet4>
         // Adds an array of DesignerVerb objects to the collection.
         array<DesignerVerb^>^ verbs = {
            gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ),
            gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) )};
         collection->AddRange( verbs );
         
         // Adds a collection of DesignerVerb objects to the collection.
         DesignerVerbCollection^ verbsCollection = gcnew DesignerVerbCollection;
         verbsCollection->Add( gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );
         verbsCollection->Add( gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );
         collection->AddRange( verbsCollection );
         //</Snippet4>

         //<Snippet5>
         // Tests for the presence of a DesignerVerb in the collection,
         // and retrieves its index if it is found.
         DesignerVerb^ testVerb = gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) );
         int itemIndex = -1;
         if ( collection->Contains( testVerb ) )
                  itemIndex = collection->IndexOf( testVerb );
         //</Snippet5>

         //<Snippet6>
         // Copies the contents of the collection, beginning at index 0,
         // to the specified DesignerVerb array.
         // 'verbs' is a DesignerVerb array.
         collection->CopyTo( verbs, 0 );
         //</Snippet6>

         //<Snippet7>
         // Retrieves the count of the items in the collection.
         int collectionCount = collection->Count;
         //</Snippet7>

         //<Snippet8>
         // Inserts a DesignerVerb at index 0 of the collection.
         collection->Insert( 0, gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) ) );
         //</Snippet8>

         //<Snippet9>
         // Removes the specified DesignerVerb from the collection.
         DesignerVerb^ verb = gcnew DesignerVerb( "Example designer verb", gcnew EventHandler( this, &Class1::ExampleEvent ) );
         collection->Remove( verb );
         //</Snippet9>

         //<Snippet10>
         // Removes the DesignerVerb at index 0.
         collection->RemoveAt( 0 );
         //</Snippet10>
         //</Snippet1>
      }
   };
}
