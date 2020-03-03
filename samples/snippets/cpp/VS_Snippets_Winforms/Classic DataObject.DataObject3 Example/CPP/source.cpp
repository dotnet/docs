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
   void CreateTextDataObject()
   {
      // Creates a new data object using a string.
      String^ myString = "My text string";
      DataObject^ myDataObject = gcnew DataObject( myString );
      
      // Prints the string in a text box.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->ToString();
   }
   // </Snippet1>
};
