

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class ListViewInsertionMarkExample: public Form
{
private:
   ListView^ myListView;

public:

   //<Snippet2>
   ListViewInsertionMarkExample()
   {
      // Initialize myListView.
      myListView = gcnew ListView;
      myListView->Dock = DockStyle::Fill;
      myListView->View = View::LargeIcon;
      myListView->MultiSelect = false;
      myListView->ListViewItemSorter = gcnew ListViewIndexComparer;

      // Initialize the insertion mark.
      myListView->InsertionMark->Color = Color::Green;

      // Add items to myListView.
      myListView->Items->Add( "zero" );
      myListView->Items->Add( "one" );
      myListView->Items->Add( "two" );
      myListView->Items->Add( "three" );
      myListView->Items->Add( "four" );
      myListView->Items->Add( "five" );

      // Initialize the drag-and-drop operation when running
      // under Windows XP or a later operating system.
      if ( System::Environment::OSVersion->Version->Major > 5 || (System::Environment::OSVersion->Version->Major == 5 && System::Environment::OSVersion->Version->Minor >= 1) )
      {
         myListView->AllowDrop = true;
         myListView->ItemDrag += gcnew ItemDragEventHandler( this, &ListViewInsertionMarkExample::myListView_ItemDrag );
         myListView->DragEnter += gcnew DragEventHandler( this, &ListViewInsertionMarkExample::myListView_DragEnter );
         myListView->DragOver += gcnew DragEventHandler( this, &ListViewInsertionMarkExample::myListView_DragOver );
         myListView->DragLeave += gcnew EventHandler( this, &ListViewInsertionMarkExample::myListView_DragLeave );
         myListView->DragDrop += gcnew DragEventHandler( this, &ListViewInsertionMarkExample::myListView_DragDrop );
      }

      // Initialize the form.
      this->Text = "ListView Insertion Mark Example";
      this->Controls->Add( myListView );
   }

private:

   //</Snippet2>
   // Starts the drag-and-drop operation when an item is dragged.
   void myListView_ItemDrag( Object^ /*sender*/, ItemDragEventArgs^ e )
   {
      myListView->DoDragDrop( e->Item, DragDropEffects::Move );
   }

   // Sets the target drop effect.
   void myListView_DragEnter( Object^ /*sender*/, DragEventArgs^ e )
   {
      e->Effect = e->AllowedEffect;
   }

   //<Snippet3>
   // Moves the insertion mark as the item is dragged.
   void myListView_DragOver( Object^ /*sender*/, DragEventArgs^ e )
   {
      // Retrieve the client coordinates of the mouse pointer.
      Point targetPoint = myListView->PointToClient( Point(e->X,e->Y) );

      // Retrieve the index of the item closest to the mouse pointer.
      int targetIndex = myListView->InsertionMark->NearestIndex( targetPoint );

      // Confirm that the mouse pointer is not over the dragged item.
      if ( targetIndex > -1 )
      {
         // Determine whether the mouse pointer is to the left or
         // the right of the midpoint of the closest item and set
         // the InsertionMark.AppearsAfterItem property accordingly.
         Rectangle itemBounds = myListView->GetItemRect( targetIndex );
         if ( targetPoint.X > itemBounds.Left + (itemBounds.Width / 2) )
         {
            myListView->InsertionMark->AppearsAfterItem = true;
         }
         else
         {
            myListView->InsertionMark->AppearsAfterItem = false;
         }
      }

      // Set the location of the insertion mark. If the mouse is
      // over the dragged item, the targetIndex value is -1 and
      // the insertion mark disappears.
      myListView->InsertionMark->Index = targetIndex;
   }

   //</Snippet3>
   // Removes the insertion mark when the mouse leaves the control.
   void myListView_DragLeave( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myListView->InsertionMark->Index = -1;
   }

   // Moves the item to the location of the insertion mark.
   void myListView_DragDrop( Object^ /*sender*/, DragEventArgs^ e )
   {
      // Retrieve the index of the insertion mark;
      int targetIndex = myListView->InsertionMark->Index;

      // If the insertion mark is not visible, exit the method.
      if ( targetIndex == -1 )
      {
         return;
      }

      // If the insertion mark is to the right of the item with
      // the corresponding index, increment the target index.
      if ( myListView->InsertionMark->AppearsAfterItem )
      {
         targetIndex++;
      }

      // Retrieve the dragged item.
      ListViewItem^ draggedItem = dynamic_cast<ListViewItem^>(e->Data->GetData( ListViewItem::typeid ));

      // Insert a copy of the dragged item at the target index.
      // A copy must be inserted before the original item is removed
      // to preserve item index values.
      myListView->Items->Insert( targetIndex, dynamic_cast<ListViewItem^>(draggedItem->Clone()) );

      // Remove the original copy of the dragged item.
      myListView->Items->Remove( draggedItem );

   }

   // Sorts ListViewItem objects by index.
   ref class ListViewIndexComparer: public System::Collections::IComparer
   {
   public:
      virtual int Compare( Object^ x, Object^ y )
      {
         return (dynamic_cast<ListViewItem^>(x))->Index - (dynamic_cast<ListViewItem^>(y))->Index;
      }
   };
};

[STAThread]
int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew ListViewInsertionMarkExample );
}
//</Snippet1>
