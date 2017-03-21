   private:
      Image^ picture;
      Point pictureLocation;

   public:
      Form1()
      {
         
         // Enable drag-and-drop operations and
         // add handlers for DragEnter and DragDrop.
         this->AllowDrop = true;
         this->DragDrop += gcnew DragEventHandler( this, &Form1::Form1_DragDrop );
         this->DragEnter += gcnew DragEventHandler( this, &Form1::Form1_DragEnter );
      }

   protected:
      virtual void OnPaint( PaintEventArgs^ e ) override
      {
         
         // If there is an image and it has a location,
         // paint it when the Form is repainted.
         Form::OnPaint( e );
         if ( this->picture != nullptr && this->pictureLocation != Point::Empty )
         {
            e->Graphics->DrawImage( this->picture, this->pictureLocation );
         }
      }

   private:
      void Form1_DragDrop( Object^ /*sender*/, DragEventArgs^ e )
      {
         
         // Handle FileDrop data.
         if ( e->Data->GetDataPresent( DataFormats::FileDrop ) )
         {
            // Assign the file names to a String* array, in
            // case the user has selected multiple files.
            array<String^>^files = (array<String^>^)e->Data->GetData( DataFormats::FileDrop );
            try
            {
               // Assign the first image to the picture variable.
               this->picture = Image::FromFile( files[ 0 ] );
               
               // Set the picture location equal to the drop point.
               this->pictureLocation = this->PointToClient( Point(e->X,e->Y) );
            }
            catch ( Exception^ ex ) 
            {
               MessageBox::Show( ex->Message );
               return;
            }

         }
         
         // Handle Bitmap data.
         if ( e->Data->GetDataPresent( DataFormats::Bitmap ) )
         {
            try
            {
               // Create an Image and assign it to the picture variable.
               this->picture = dynamic_cast<Image^>(e->Data->GetData( DataFormats::Bitmap ));

               // Set the picture location equal to the drop point.
               this->pictureLocation = this->PointToClient( Point(e->X,e->Y) );
            }
            catch ( Exception^ ex ) 
            {
               MessageBox::Show( ex->Message );
               return;
            }
         }
         
         // Force the form to be redrawn with the image.
         this->Invalidate();
      }

      void Form1_DragEnter( Object^ /*sender*/, DragEventArgs^ e )
      {
         // If the data is a file or a bitmap, display the copy cursor.
         if ( e->Data->GetDataPresent( DataFormats::Bitmap ) || e->Data->GetDataPresent( DataFormats::FileDrop ) )
         {
            e->Effect = DragDropEffects::Copy;
         }
         else
         {
            e->Effect = DragDropEffects::None;
         }
      }