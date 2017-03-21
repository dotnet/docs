   private:
      bool pasteMyBitmap( String^ fileName )
      {
         // Open an bitmap from file and copy it to the clipboard.
         Bitmap^ myBitmap = gcnew Bitmap( fileName );

         // Copy the bitmap to the clipboard.
         Clipboard::SetDataObject( myBitmap );

         // Get the format for the object type.
         DataFormats::Format^ myFormat = DataFormats::GetFormat( DataFormats::Bitmap );

         // After verifying that the data can be pasted, paste it.
         if ( richTextBox1->CanPaste( myFormat ) )
         {
            richTextBox1->Paste( myFormat );
            return true;
         }
         else
         {
            MessageBox::Show( "The data format that you attempted to paste is not supported by this control." );
            return false;
         }
      }