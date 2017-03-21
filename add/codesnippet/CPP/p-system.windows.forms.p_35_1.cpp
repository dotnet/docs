   // Declare the PrintDocument object.
   System::Drawing::Printing::PrintDocument^ docToPrint;

   // This method will set properties on the PrintDialog object and
   // then display the dialog.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Allow the user to choose the page range he or she would
      // like to print.
      PrintDialog1->AllowSomePages = true;
      
      // Show the help button.
      PrintDialog1->ShowHelp = true;
      
      // Set the Document property to the PrintDocument for 
      // which the PrintPage Event has been handled. To display the
      // dialog, either this property or the PrinterSettings property 
      // must be set 
      PrintDialog1->Document = docToPrint;
      if ( docToPrint == nullptr )
            System::Windows::Forms::MessageBox::Show(  "null" );

      ;
      ;
      if ( PrintDialog1 == nullptr )
            System::Windows::Forms::MessageBox::Show(  "pnull" );

      ;
      ;
      System::Windows::Forms::DialogResult result = PrintDialog1->ShowDialog();
      System::Windows::Forms::MessageBox::Show( result.ToString() );
      ;
      ;
      
      // If the result is OK then print the document.
      if ( result == ::DialogResult::OK )
      {
         docToPrint->Print();
      }

   }

   // The PrintDialog will print the document
   // by handling the document's PrintPage event.
   void document_PrintPage( Object^ /*sender*/, System::Drawing::Printing::PrintPageEventArgs^ e )
   {
      // Insert code to render the page here.
      // This code will be called when the control is drawn.
      // The following code will render a simple
      // message on the printed document.
      String^ text = "In document_PrintPage method.";
      System::Drawing::Font^ printFont = gcnew System::Drawing::Font( "Arial",35,System::Drawing::FontStyle::Regular );
      
      // Draw the content.
      e->Graphics->DrawString( text, printFont, System::Drawing::Brushes::Black, 10, 10 );
   }