      void DrawCursorsOnForm( System::Windows::Forms::Cursor^ cursor )
      {
         
         // If the form's cursor is not the Hand cursor and the
         // Current cursor is the Default, Draw the specified
         // cursor on the form in normal size and twice normal size.
         if ( this->Cursor != Cursors::Hand && System::Windows::Forms::Cursor::Current == Cursors::Default )
         {
            
            // Draw the cursor stretched.
            Graphics^ graphics = this->CreateGraphics();
            Rectangle rectangle = Rectangle(Point(10,10),System::Drawing::Size( cursor->Size.Width * 2, cursor->Size.Height * 2 ));
            cursor->DrawStretched( graphics, rectangle );
            
            // Draw the cursor in normal size.
            rectangle.Location = Point(rectangle.Width + rectangle.Location.X,rectangle.Height + rectangle.Location.Y);
            rectangle.Size = cursor->Size;
            cursor->Draw( graphics, rectangle );
            
            // Dispose of the cursor.
            delete cursor;
         }
      }