   // Declare the dialog.
internal:
   PrintPreviewDialog^ PrintPreviewDialog1;

private:

   // Declare a PrintDocument object named document.
   System::Drawing::Printing::PrintDocument^ document;

   // Initalize the dialog.
   void InitializePrintPreviewDialog()
   {
      
      // Create a new PrintPreviewDialog using constructor.
      this->PrintPreviewDialog1 = gcnew PrintPreviewDialog;
      
      //Set the size, location, and name.
      this->PrintPreviewDialog1->ClientSize = System::Drawing::Size( 400, 300 );
      this->PrintPreviewDialog1->Location = System::Drawing::Point( 29, 29 );
      this->PrintPreviewDialog1->Name = "PrintPreviewDialog1";
      
      // Associate the event-handling method with the 
      // document's PrintPage event.
      this->document->PrintPage += gcnew System::Drawing::Printing::PrintPageEventHandler( this, &Form1::document_PrintPage );
      
      // Set the minimum size the dialog can be resized to.
      this->PrintPreviewDialog1->MinimumSize = System::Drawing::Size( 375, 250 );
      
      // Set the UseAntiAlias property to true, which will allow the 
      // operating system to smooth fonts.
      this->PrintPreviewDialog1->UseAntiAlias = true;
   }

   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( TreeView1->SelectedNode != nullptr )
      {
         document->DocumentName = TreeView1->SelectedNode->Tag->ToString();
      }

      // Set the PrintPreviewDialog.Document property to
      // the PrintDocument object selected by the user.
      PrintPreviewDialog1->Document = document;
      
      // Call the ShowDialog method. This will trigger the document's
      //  PrintPage event.
      PrintPreviewDialog1->ShowDialog();
   }

   void document_PrintPage( Object^ /*sender*/, System::Drawing::Printing::PrintPageEventArgs^ e )
   {
      
      // Insert code to render the page here.
      // This code will be called when the PrintPreviewDialog.Show 
      // method is called.
      // The following code will render a simple
      // message on the document in the dialog.
      String^ text = "In document_PrintPage method.";
      System::Drawing::Font^ printFont = gcnew System::Drawing::Font( "Arial",35,System::Drawing::FontStyle::Regular );
      e->Graphics->DrawString( text, printFont, System::Drawing::Brushes::Black, 0, 0 );
   }