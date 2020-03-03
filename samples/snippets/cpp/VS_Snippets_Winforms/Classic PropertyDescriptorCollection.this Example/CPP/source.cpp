

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

   // <Snippet1>
   void PrintIndexItem()
   {
      
      // Creates a new collection and assigns it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Prints the second property's name.
      textBox1->Text = properties[ 1 ]->ToString();
   }
   // </Snippet1>
};
