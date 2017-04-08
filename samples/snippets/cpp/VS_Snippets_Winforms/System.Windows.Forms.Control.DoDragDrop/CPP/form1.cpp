

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

//<Snippet1>
using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

namespace Snip_DragNDrop
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::ListBox^ ListDragSource;
      System::Windows::Forms::ListBox^ ListDragTarget;
      System::Windows::Forms::CheckBox^ UseCustomCursorsCheck;
      System::Windows::Forms::Label ^ DropLocationLabel;
      Int32 indexOfItemUnderMouseToDrag;
      Int32 indexOfItemUnderMouseToDrop;
      Rectangle dragBoxFromMouseDown;
      Point screenOffset;
      System::Windows::Forms::Cursor^ MyNoDropCursor;
      System::Windows::Forms::Cursor^ MyNormalCursor;

   public:
      Form1()
      {
         this->ListDragSource = gcnew System::Windows::Forms::ListBox;
         this->ListDragTarget = gcnew System::Windows::Forms::ListBox;
         this->UseCustomCursorsCheck = gcnew System::Windows::Forms::CheckBox;
         this->DropLocationLabel = gcnew System::Windows::Forms::Label;
         this->SuspendLayout();
         
         // ListDragSource
         array<Object^>^temp0 = {"five","six","seven","eight","nine","ten"};
         this->ListDragSource->Items->AddRange( temp0 );
         this->ListDragSource->Location = System::Drawing::Point( 10, 17 );
         this->ListDragSource->Size = System::Drawing::Size( 120, 225 );
         this->ListDragSource->MouseDown += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::ListDragSource_MouseDown );
         this->ListDragSource->QueryContinueDrag += gcnew System::Windows::Forms::QueryContinueDragEventHandler( this, &Form1::ListDragSource_QueryContinueDrag );
         this->ListDragSource->MouseUp += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::ListDragSource_MouseUp );
         this->ListDragSource->MouseMove += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::ListDragSource_MouseMove );
         this->ListDragSource->GiveFeedback += gcnew System::Windows::Forms::GiveFeedbackEventHandler( this, &Form1::ListDragSource_GiveFeedback );
         
         // ListDragTarget
         this->ListDragTarget->AllowDrop = true;
         this->ListDragTarget->Location = System::Drawing::Point( 154, 17 );
         this->ListDragTarget->Size = System::Drawing::Size( 120, 225 );
         this->ListDragTarget->DragOver += gcnew System::Windows::Forms::DragEventHandler( this, &Form1::ListDragTarget_DragOver );
         this->ListDragTarget->DragDrop += gcnew System::Windows::Forms::DragEventHandler( this, &Form1::ListDragTarget_DragDrop );
         this->ListDragTarget->DragEnter += gcnew System::Windows::Forms::DragEventHandler( this, &Form1::ListDragTarget_DragEnter );
         this->ListDragTarget->DragLeave += gcnew System::EventHandler( this, &Form1::ListDragTarget_DragLeave );
         
         // UseCustomCursorsCheck
         this->UseCustomCursorsCheck->Location = System::Drawing::Point( 10, 243 );
         this->UseCustomCursorsCheck->Size = System::Drawing::Size( 137, 24 );
         this->UseCustomCursorsCheck->Text = "Use Custom Cursors";
         
         // DropLocationLabel
         this->DropLocationLabel->Location = System::Drawing::Point( 154, 245 );
         this->DropLocationLabel->Size = System::Drawing::Size( 137, 24 );
         this->DropLocationLabel->Text = "None";
         
         // Form1
         this->ClientSize = System::Drawing::Size( 292, 270 );
         array<System::Windows::Forms::Control^>^formControls = {this->ListDragSource,this->ListDragTarget,this->UseCustomCursorsCheck,this->DropLocationLabel};
         this->Controls->AddRange( formControls );
         this->Text = "drag-and-drop Example";
         this->ResumeLayout( false );
      }


   private:
      void ListDragSource_MouseDown( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         
         // Get the index of the item the mouse is below.
         indexOfItemUnderMouseToDrag = this->ListDragSource->IndexFromPoint( e->X, e->Y );
         if ( indexOfItemUnderMouseToDrag != ListBox::NoMatches )
         {
            
            // Remember the point where the mouse down occurred. The DragSize indicates
            // the size that the mouse can move before a drag event should be started.
            System::Drawing::Size dragSize = SystemInformation::DragSize;
            
            // Create a rectangle using the DragSize, with the mouse position being
            // at the center of the rectangle.
            dragBoxFromMouseDown = Rectangle(Point(e->X - (dragSize.Width / 2),e->Y - (dragSize.Height / 2)),dragSize);
         }
         else
                  dragBoxFromMouseDown = Rectangle::Empty;

         
         // Reset the rectangle if the mouse is not over an item in the ListBox.
      }

      void ListDragSource_MouseUp( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ /*e*/ )
      {
         
         // Reset the drag rectangle when the mouse button is raised.
         dragBoxFromMouseDown = Rectangle::Empty;
      }


      //<Snippet2>
      void ListDragSource_MouseMove( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ e )
      {
         if ( (e->Button & ::MouseButtons::Left) == ::MouseButtons::Left )
         {
            
            // If the mouse moves outside the rectangle, start the drag.
            if ( dragBoxFromMouseDown != Rectangle::Empty &&  !dragBoxFromMouseDown.Contains( e->X, e->Y ) )
            {
               
               // Create custom cursors for the drag-and-drop operation.
               try
               {
                  MyNormalCursor = gcnew System::Windows::Forms::Cursor( "3dwarro.cur" );
                  MyNoDropCursor = gcnew System::Windows::Forms::Cursor( "3dwno.cur" );
               }
               catch ( Exception^ ) 
               {
                  // An error occurred while attempting to load the cursors, so use
                  // the standard cursors.
                  this->UseCustomCursorsCheck->Checked = false;
               }
               __finally
               {                  
                  // The screenOffset is used to account for any desktop bands
                  // that may be at the top or left side of the screen when
                  // determining when to cancel the drag drop operation.
                  screenOffset = SystemInformation::WorkingArea.Location;
                  
                  // Proceed with the drag-and-drop, passing in the list item.
                  DragDropEffects dropEffect = this->ListDragSource->DoDragDrop( ListDragSource->Items[ indexOfItemUnderMouseToDrag ], static_cast<DragDropEffects>(DragDropEffects::All | DragDropEffects::Link) );
                  
                  // If the drag operation was a move then remove the item.
                  if ( dropEffect == DragDropEffects::Move )
                  {
                     ListDragSource->Items->RemoveAt( indexOfItemUnderMouseToDrag );
                     
                     // Selects the previous item in the list as long as the list has an item.
                     if ( indexOfItemUnderMouseToDrag > 0 )
                                          ListDragSource->SelectedIndex = indexOfItemUnderMouseToDrag - 1;
                     else
                     if ( ListDragSource->Items->Count > 0 )
                                          
                     // Selects the first item.
                     ListDragSource->SelectedIndex = 0;
                  }
                  
                  // Dispose of the cursors since they are no longer needed.
                  if ( MyNormalCursor != nullptr )
                                    delete MyNormalCursor;
                  if ( MyNoDropCursor != nullptr )
                                    delete MyNoDropCursor;
               }
            }
         }
      }
      //</Snippet2>

      //<Snippet9>
      //<Snippet3>
      void ListDragSource_GiveFeedback( Object^ /*sender*/, System::Windows::Forms::GiveFeedbackEventArgs^ e )
      {
         // Use custom cursors if the check box is checked.
         if ( UseCustomCursorsCheck->Checked )
         {
            // Sets the custom cursor based upon the effect.
            e->UseDefaultCursors = false;
            if ( (e->Effect & DragDropEffects::Move) == DragDropEffects::Move )
                        ::Cursor::Current = MyNormalCursor;
            else
                        ::Cursor::Current = MyNoDropCursor;
         }
      }
      //</Snippet3>

      //<Snippet4>
      void ListDragTarget_DragOver( Object^ /*sender*/, System::Windows::Forms::DragEventArgs^ e )
      {
         // Determine whether string data exists in the drop data. If not, then
         // the drop effect reflects that the drop cannot occur.
         if (  !e->Data->GetDataPresent( System::String::typeid ) )
         {
            e->Effect = DragDropEffects::None;
            DropLocationLabel->Text = "None - no string data.";
            return;
         }

         // Set the effect based upon the KeyState.
         if ( (e->KeyState & (8 + 32)) == (8 + 32) && ((e->AllowedEffect & DragDropEffects::Link) == DragDropEffects::Link) )
         {
            // KeyState 8 + 32 = CTL + ALT
            // Link drag-and-drop effect.
            e->Effect = DragDropEffects::Link;
         }
         else
         if ( (e->KeyState & 32) == 32 && ((e->AllowedEffect & DragDropEffects::Link) == DragDropEffects::Link) )
         {
            // ALT KeyState for link.
            e->Effect = DragDropEffects::Link;
         }
         else
         if ( (e->KeyState & 4) == 4 && ((e->AllowedEffect & DragDropEffects::Move) == DragDropEffects::Move) )
         {
            // SHIFT KeyState for move.
            e->Effect = DragDropEffects::Move;
         }
         else
         if ( (e->KeyState & 8) == 8 && ((e->AllowedEffect & DragDropEffects::Copy) == DragDropEffects::Copy) )
         {
            // CTL KeyState for copy.
            e->Effect = DragDropEffects::Copy;
         }
         else
         if ( (e->AllowedEffect & DragDropEffects::Move) == DragDropEffects::Move )
         {
            // By default, the drop action should be move, if allowed.
            e->Effect = DragDropEffects::Move;
         }
         else
                  e->Effect = DragDropEffects::None;





         
         // Get the index of the item the mouse is below.
         // The mouse locations are relative to the screen, so they must be
         // converted to client coordinates.
         indexOfItemUnderMouseToDrop = ListDragTarget->IndexFromPoint( ListDragTarget->PointToClient( Point(e->X,e->Y) ) );
         
         // Updates the label text.
         if ( indexOfItemUnderMouseToDrop != ListBox::NoMatches )
         {
            DropLocationLabel->Text = String::Concat( "Drops before item # ", (indexOfItemUnderMouseToDrop + 1) );
         }
         else
                  DropLocationLabel->Text = "Drops at the end.";
      }
      //</Snippet4>

      //<Snippet5>
      void ListDragTarget_DragDrop( Object^ /*sender*/, System::Windows::Forms::DragEventArgs^ e )
      {
         // Ensure that the list item index is contained in the data.
         if ( e->Data->GetDataPresent( System::String::typeid ) )
         {
            Object^ item = dynamic_cast<Object^>(e->Data->GetData( System::String::typeid ));
            
            // Perform drag-and-drop, depending upon the effect.
            if ( e->Effect == DragDropEffects::Copy || e->Effect == DragDropEffects::Move )
            {
               // Insert the item.
               if ( indexOfItemUnderMouseToDrop != ListBox::NoMatches )
                              ListDragTarget->Items->Insert( indexOfItemUnderMouseToDrop, item );
               else
                              ListDragTarget->Items->Add( item );
            }
         }

         // Reset the label text.
         DropLocationLabel->Text = "None";
      }
      //</Snippet5>

      //<Snippet6>
      void ListDragSource_QueryContinueDrag( Object^ sender, System::Windows::Forms::QueryContinueDragEventArgs^ e )
      {
         // Cancel the drag if the mouse moves off the form.
         ListBox^ lb = dynamic_cast<ListBox^>(sender);
         if ( lb != nullptr )
         {
            Form^ f = lb->FindForm();

            // Cancel the drag if the mouse moves off the form. The screenOffset
            // takes into account any desktop bands that may be at the top or left
            // side of the screen.
            if ( ((Control::MousePosition.X - screenOffset.X) < f->DesktopBounds.Left) || ((Control::MousePosition.X - screenOffset.X) > f->DesktopBounds.Right) || ((Control::MousePosition.Y - screenOffset.Y) < f->DesktopBounds.Top) || ((Control::MousePosition.Y - screenOffset.Y) > f->DesktopBounds.Bottom) )
            {
               e->Action = DragAction::Cancel;
            }
         }
      }
      //</Snippet6>

      //<Snippet7>
      void ListDragTarget_DragEnter( Object^ /*sender*/, System::Windows::Forms::DragEventArgs^ /*e*/ )
      {
         // Reset the label text.
         DropLocationLabel->Text = "None";
      }
      //</Snippet7>

      //<Snippet8>
      void ListDragTarget_DragLeave( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
        // Reset the label text.
         DropLocationLabel->Text = "None";
      }
      //</Snippet8>
      //</Snippet9>
   };
}

/// The main entry point for the application.

[STAThread]
int main()
{
   Application::Run( gcnew Snip_DragNDrop::Form1 );
}
//</Snippet1>
