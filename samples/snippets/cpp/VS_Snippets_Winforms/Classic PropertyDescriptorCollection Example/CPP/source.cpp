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

private:
   void Method1()
   {
      // <Snippet1>
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      // </Snippet1>
   }

   // <Snippet2>
private:
   void MyPropertyCollection()
   {
      // Creates a new collection and assign it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Displays each property in the collection in a text box.
      for each ( PropertyDescriptor^ myProperty in properties )
      {
         textBox1->Text = String::Concat( textBox1->Text, myProperty->Name, "\n" );
      }
   }
   // </Snippet2>
};
