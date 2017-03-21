private:
   void Form1_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Sets the AllowDrop property so that data can be dragged onto the control.
      richTextBox1->AllowDrop = true;

      // Add code here to populate the ListBox1 with paths to text files.
   }

   void listBox1_MouseDown( Object^ sender, System::Windows::Forms::MouseEventArgs^ e )
   {
      // Determines which item was selected.
      ListBox^ lb = (dynamic_cast<ListBox^>(sender));
      Point pt = Point(e->X,e->Y);
      int index = lb->IndexFromPoint( pt );

      // Starts a drag-and-drop operation with that item.
      if ( index >= 0 )
      {
         lb->DoDragDrop( lb->Items[ index ], DragDropEffects::Link );
      }
   }

   void richTextBox1_DragEnter( Object^ /*sender*/, DragEventArgs^ e )
   {
      // If the data is text, copy the data to the RichTextBox control.
      if ( e->Data->GetDataPresent( "Text" ) )
            e->Effect = DragDropEffects::Copy;
   }

   void richTextBox1_DragDrop( Object^ /*sender*/, DragEventArgs^ e )
   {
      // Loads the file into the control.
      richTextBox1->LoadFile( dynamic_cast<String^>(e->Data->GetData( "Text" )), System::Windows::Forms::RichTextBoxStreamType::RichText );
   }