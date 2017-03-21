public:
   void myPrint()
   {
      if ( useMyPrintController == true )
      {
         myPrintDocument->PrintController =
            gcnew myControllerImplementation;
         if ( wantsStatusDialog == true )
         {
            myPrintDocument->PrintController =
               gcnew PrintControllerWithStatusDialog(
                  myPrintDocument->PrintController );
         }
      }
      myPrintDocument->Print();
   }