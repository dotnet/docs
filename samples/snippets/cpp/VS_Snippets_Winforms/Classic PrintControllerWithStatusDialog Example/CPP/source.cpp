#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::IO;
using namespace System::Data;
using namespace System::Drawing::Printing;
using namespace System::Windows::Forms;

public ref class myControllerImplementation: public PrintController{};

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   bool useMyPrintController;
   bool wantsStatusDialog;
   PrintDocument^ myDocumentPrinter;

   // <Snippet1>
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
   // </Snippet1>
};
