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
   void RemoveMyButton()
   {
      int btns;
      btns = toolBar1->Buttons->Count;
      
      // Remove the last toolbar button.
      toolBar1->Buttons->RemoveAt( btns - 1 );
   }
   // </Snippet1>
};
