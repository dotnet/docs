#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing::Printing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class myControllerImplementation: public PrintController{};

public ref class Form1: public Form
{
protected:
   bool useMyPrintController;
   bool wantsStatusDialog;
   PrintDocument^ myPrintDocument;

   // <Snippet1>
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
   // </Snippet1>
};
