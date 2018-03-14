#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;

public ref class Form1: public Form
{
protected:
   Button^ button1;
   TextBox^ textBox1;

   void Method1()
   {
      // <Snippet1>
      AttributeCollection^ collection1;
      collection1 = TypeDescriptor::GetAttributes( button1 );
      // </Snippet1>
   }
};
