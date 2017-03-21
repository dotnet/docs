   void myPrint()
   {
      if ( useMyPrintController )
      {
         myDocumentPrinter->PrintController = gcnew myControllerImplementation;
         if ( wantsStatusDialog )
         {
            myDocumentPrinter->PrintController =
               gcnew PrintControllerWithStatusDialog( myDocumentPrinter->PrintController );
         }
      }
      myDocumentPrinter->Print();
   }