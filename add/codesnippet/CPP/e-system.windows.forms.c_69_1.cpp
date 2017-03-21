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