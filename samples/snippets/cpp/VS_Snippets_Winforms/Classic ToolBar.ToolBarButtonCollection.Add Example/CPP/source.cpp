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
   void AddMyButton()
   {
      ToolBarButton^ toolBarButton1 = gcnew ToolBarButton;
      toolBarButton1->Text = "Print";
      
      // Add the new toolbar button to the toolbar.
      toolBar1->Buttons->Add( toolBarButton1 );
   }
   // </Snippet1>
};
