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
   Button^ button1;
   TextBox^ textBox1;

   // <Snippet1>
private:
   void GetCount()
   {
      // Creates a new collection and assign it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Prints the number of properties on button1 in a textbox.
      textBox1->Text = properties->Count.ToString();
   }
   // </Snippet1>
};
