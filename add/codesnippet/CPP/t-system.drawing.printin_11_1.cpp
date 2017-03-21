private:
   // Specifies what happens when the user clicks the Button.
   void printButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         pd->Print();
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( "An error occurred while printing", ex->ToString() );
      }
   }

   // Specifies what happens when the PrintPage event is raised.
   void pd_PrintPage( Object^ /*sender*/, PrintPageEventArgs^ ev )
   {
      // Draw a picture.
      ev->Graphics->DrawImage( Image::FromFile( "C:\\My Folder\\MyFile.bmp" ),
         ev->Graphics->VisibleClipBounds );
      
      // Indicate that this is the last page to print.
      ev->HasMorePages = false;
   }