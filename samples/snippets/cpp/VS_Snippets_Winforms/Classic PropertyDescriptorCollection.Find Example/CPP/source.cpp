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
   void FindProperty()
   {
      // Creates a new collection and assign it the properties for button1.
      PropertyDescriptorCollection^ properties = TypeDescriptor::GetProperties( button1 );
      
      // Sets a PropertyDescriptor to the specific property.
      PropertyDescriptor^ myProperty = properties->Find( "Opacity", false );
      
      // Prints the property and the property description.
      textBox1->Text = myProperty->DisplayName + "\n" + myProperty->Description;
   }
   // </Snippet1>
};
