public:
   void Printing()
   {
      try
      {
         streamToPrint = gcnew StreamReader( filePath );
         try
         {
            printFont = gcnew Font( "Arial",10 );
            PrintDocument^ pd = gcnew PrintDocument;
            pd->PrintPage += gcnew PrintPageEventHandler(
               this, &Sample::pd_PrintPage );
            pd->PrinterSettings->PrinterName = printer;
            // Set the page orientation to landscape.
            pd->DefaultPageSettings->Landscape = true;
            pd->Print();
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