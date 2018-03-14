#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   Button^ button1;
   TextBox^ textBox1;

   // <Snippet1>
private:
   void MyEnumerator()
   {
      // Creates a new collection and assigns it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Creates an enumerator.
      IEnumerator^ ie = properties->GetEnumerator();
      
      // Prints the name of each property in the collection.
      Object^ myProperty;
      while ( ie->MoveNext() == true )
      {
         myProperty = ie->Current;
         textBox1->Text = textBox1->Text + myProperty + "\n";
      }
   }
   // </Snippet1>
};
