 public void myPrint()
 {
    if (useMyPrintController == true)
    {
       myPrintDocument.PrintController = 
          new myControllerImplementation();     
       if (wantsStatusDialog == true)
       {
          myPrintDocument.PrintController = 
             new PrintControllerWithStatusDialog
             (myPrintDocument.PrintController);
       }
    }
    myPrintDocument.Print();
 }
 