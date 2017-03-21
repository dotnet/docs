   // Get the width of row header.
private:
   void button9_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Int32 myRowHeaderWidth = myDataGrid->RowHeaderWidth;
      MessageBox::Show( String::Concat( "Width of row headers is: ", myRowHeaderWidth ), "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
   }