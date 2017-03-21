   //This method displays a PageSetupDialog object. If the
   // user clicks OK in the dialog, selected results of
   // the dialog are displayed in ListBox1.
   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Initialize the dialog's PrinterSettings property to hold user
      // defined printer settings.
      PageSetupDialog1->PageSettings = gcnew System::Drawing::Printing::PageSettings;
      
      // Initialize dialog's PrinterSettings property to hold user
      // set printer settings.
      PageSetupDialog1->PrinterSettings = gcnew System::Drawing::Printing::PrinterSettings;
      
      //Do not show the network in the printer dialog.
      PageSetupDialog1->ShowNetwork = false;
      
      //Show the dialog storing the result.
      System::Windows::Forms::DialogResult result = PageSetupDialog1->ShowDialog();
      
      // If the result is OK, display selected settings in
      // ListBox1. These values can be used when printing the
      // document.
      if ( result == ::DialogResult::OK )
      {
         array<Object^>^results = {PageSetupDialog1->PageSettings->Margins,PageSetupDialog1->PageSettings->PaperSize,PageSetupDialog1->PageSettings->Landscape,PageSetupDialog1->PrinterSettings->PrinterName,PageSetupDialog1->PrinterSettings->PrintRange};
         ListBox1->Items->AddRange( results );
      }
      
   }