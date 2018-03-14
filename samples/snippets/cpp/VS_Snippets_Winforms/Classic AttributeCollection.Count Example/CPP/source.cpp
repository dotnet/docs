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

   // <Snippet1>
private:
   void GetCount()
   {
      // Creates a new collection and assigns it the attributes for button1.
      AttributeCollection^ attributes;
      attributes = TypeDescriptor::GetAttributes( button1 );
      
      // Prints the number of items in the collection.
      textBox1->Text = attributes->Count.ToString();
   }
   // </Snippet1>
};
