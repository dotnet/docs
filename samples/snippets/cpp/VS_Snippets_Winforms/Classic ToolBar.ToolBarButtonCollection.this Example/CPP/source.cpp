

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

public:

   // <Snippet1>
   void ReplaceMyToolBarButton()
   {
      int btns;
      btns = toolBar1->Buttons->Count;
      ToolBarButton^ toolBarButton1 = gcnew ToolBarButton;
      toolBarButton1->Text = "myButton";
      
      // Replace the last ToolBarButton in the collection.
      toolBar1->Buttons[ btns - 1 ] = toolBarButton1;
   }
   // </Snippet1>
};
