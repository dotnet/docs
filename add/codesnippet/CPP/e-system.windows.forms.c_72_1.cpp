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