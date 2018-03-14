

#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::ComponentModel::Design;
using namespace System::Drawing;
using namespace System::Drawing::Design;
using namespace System::Windows::Forms;

[STAThread]
int main()
{
   
   //<Snippet1>
   // Create a new ToolboxItemCollection using a ToolboxItem array.
   array<ToolboxItem^>^temp0 = {gcnew ToolboxItem( System::Windows::Forms::Label::typeid ),gcnew ToolboxItem( System::Windows::Forms::TextBox::typeid )};
   ToolboxItemCollection^ collection = gcnew ToolboxItemCollection( temp0 );
   //</Snippet1>

   //<Snippet2>
   // Create a new ToolboxItemCollection using an existing ToolboxItemCollection.
   ToolboxItemCollection^ coll = gcnew ToolboxItemCollection( collection );
   //</Snippet2>

   //<Snippet3>
   // Get the number of items in the collection.
   int collectionLength = collection->Count;
   //</Snippet3>

   //<Snippet4>
   // Get the ToolboxItem at each index.
   ToolboxItem^ item = nullptr;
   for ( int index = 0; index < collection->Count; index++ )
      item = collection[ index ];
   //</Snippet4>

   //<Snippet5>
   // If the collection contains the specified ToolboxItem, 
   // retrieve the collection index of the specified item.
   int indx = -1;
   if ( collection->Contains( item ) )
      indx = collection->IndexOf( item );
   //</Snippet5>

   //<Snippet6>
   // Copy the ToolboxItemCollection to the specified array.
   array<ToolboxItem^>^items = gcnew array<ToolboxItem^>(collection->Count);
   collection->CopyTo( items, 0 );
   //</Snippet6>
}
