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