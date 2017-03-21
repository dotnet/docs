         [EditorAttribute(System::Drawing::Design::BitmapEditor::typeid,System::Drawing::Design::UITypeEditor::typeid)]
         Bitmap^ get()
         {
            return testBmp;
         }

         void set( Bitmap^ value )
         {
            testBmp = value;
         }
      }

   private:
      Bitmap^ testBmp;