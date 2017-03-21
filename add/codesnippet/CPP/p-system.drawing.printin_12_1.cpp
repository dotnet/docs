public:
   void Printing( String^ printer )
   {
      try
      {
         streamToPrint = gcnew StreamReader( filePath );
         try
         {
            printFont = gcnew System::Drawing::Font( "Arial",10 );
            PrintDocument^ pd = gcnew PrintDocument;
            pd->PrintPage += gcnew PrintPageEventHandler(
               this, &Form1::pd_PrintPage );
            // Specify the printer to use.
            pd->PrinterSettings->PrinterName = printer;
            if ( pd->PrinterSettings->IsValid )
            {
               pd->Print();
            }
            else
            {
               MessageBox::Show( "Printer is invalid." );
            }
         }
         finally
         {
            streamToPrint->Close();
         }
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }