#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   Button^ button1;
   void Method()
   {
      // <Snippet1>
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );
      // </Snippet1>
   }
};
