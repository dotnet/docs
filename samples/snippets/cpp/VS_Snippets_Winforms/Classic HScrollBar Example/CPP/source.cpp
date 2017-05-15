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
   // <Snippet1>
private:
   void InitializeMyScrollBar()
   {
      // Create and initialize an HScrollBar.
      HScrollBar^ hScrollBar1 = gcnew HScrollBar;
      
      // Dock the scroll bar to the bottom of the form.
      hScrollBar1->Dock = DockStyle::Bottom;
      
      // Add the scroll bar to the form.
      Controls->Add( hScrollBar1 );
   }
   // </Snippet1>
};
