using System;
using System.IO;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected bool useMyPrintController;
 protected bool wantsStatusDialog;
 protected PrintDocument myDocumentPrinter;
 
// <Snippet1>
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

// </Snippet1>
}

public class myControllerImplementation : PrintController {

}
