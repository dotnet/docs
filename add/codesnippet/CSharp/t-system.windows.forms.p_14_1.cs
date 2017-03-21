 void myPrint() {
    if (useMyPrintController==true) {
       myDocumentPrinter.PrintController = new myControllerImplementation();     
       if (wantsStatusDialog==true) {
          myDocumentPrinter.PrintController =
            new PrintControllerWithStatusDialog(myDocumentPrinter.PrintController);
       }
    }
    myDocumentPrinter.Print();
 }
