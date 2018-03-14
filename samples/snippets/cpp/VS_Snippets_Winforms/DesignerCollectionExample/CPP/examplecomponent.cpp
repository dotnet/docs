#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Security::Permissions;

public ref class ExampleComponent: public Component
{
public:
   ExampleComponent()
   {
      IDesignerHost^ designerhost1 = nullptr;
      IDesignerHost^ designerhost2 = nullptr;
      
      //<Snippet1>            
      // Create a DesignerCollection using a constructor
      // that accepts an array of IDesignerHost objects with 
      // which to initialize the array.
      array<IDesignerHost^>^temp0 = {designerhost1,designerhost2};
      DesignerCollection^ collection = gcnew DesignerCollection( temp0 );
      //</Snippet1>
   }

   [PermissionSetAttribute(SecurityAction::Demand, Name="FullTrust")]
   void OutputDesignerCollectionInfo( DesignerCollection^ collection )
   {
      
      //<Snippet2>
      // Get the number of elements in the collection.
      int count = collection->Count;
      //</Snippet2>

      //<Snippet3>
      // Access each IDesignerHost in the DesignerCollection using
      // the collection's indexer property, and output the class name 
      // of the root component associated with each IDesignerHost.            
      for ( int i = 0; i < collection->Count; i++ )
         Console::WriteLine( collection[ i ]->RootComponentClassName );
      //</Snippet3>
   }
};
