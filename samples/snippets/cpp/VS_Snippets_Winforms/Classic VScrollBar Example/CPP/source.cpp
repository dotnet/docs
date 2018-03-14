#using <system.dll>
#using <System.Drawing.dll>
#using <system.data.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void InitializeMyScrollBar()
   {
      // Create and initialize a VScrollBar.
      VScrollBar^ vScrollBar1 = gcnew VScrollBar;
      
      // Dock the scroll bar to the right side of the form.
      vScrollBar1->Dock = DockStyle::Right;
      
      // Add the scroll bar to the form.
      Controls->Add( vScrollBar1 );
   }
   // </Snippet1>
};
