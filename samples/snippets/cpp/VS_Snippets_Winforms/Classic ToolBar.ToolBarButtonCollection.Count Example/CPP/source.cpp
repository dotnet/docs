#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Diagnostics;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   ToolBar^ toolBar1;

   // <Snippet1>
public:
   void ClearMyToolBar()
   {
      int btns;
      // Get the count before the Clear method is called.
      btns = toolBar1->Buttons->Count;
      toolBar1->Buttons->Clear();
      MessageBox::Show( "Count Before Clear: " + btns.ToString() +
         "\nCount After Clear: " + toolBar1->Buttons->Count.ToString() );
   }
   // </Snippet1>
};
