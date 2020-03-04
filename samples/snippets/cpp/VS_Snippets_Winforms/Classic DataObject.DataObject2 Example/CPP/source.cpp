#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void CreateDefaultDataObject()
   {
      // Creates a data object.
      DataObject^ myDataObject;
      
      // Assigns the string to the data object.
      String^ myString = "My text string";
      myDataObject = gcnew DataObject( myString );
      
      // Prints the string in a text box.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->ToString();
   }
   // </Snippet1>
};
