      void MoveCursor()
      {
         // Set the Current cursor, move the cursor's Position,
         // and set its clipping rectangle to the form.

         this->Cursor = gcnew System::Windows::Forms::Cursor( ::Cursor::Current->Handle );
         ::Cursor::Position = Point(::Cursor::Position.X - 50,::Cursor::Position.Y - 50);
         ::Cursor::Clip = Rectangle(this->Location,this->Size);

      }