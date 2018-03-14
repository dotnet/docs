using System;
using System.Data;
using System.Drawing.Printing;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected bool useMyPrintController;
 protected bool wantsStatusDialog;
 protected PrintDocument myPrintDocument;
 
// <Snippet1>
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
 
// </Snippet1>
}

public class myControllerImplementation : PrintController {

}

