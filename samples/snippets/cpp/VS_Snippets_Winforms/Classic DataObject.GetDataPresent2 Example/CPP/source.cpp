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
   void GetIfPresent()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject(
         DataFormats::Text,"A new string" );
      
      // Prints whether data is present in text format.
      textBox1->Text = String::Format( "Data in text format is: {0}",
         myDataObject->GetDataPresent( DataFormats::Text ) );
   }
   // </Snippet1>
};
