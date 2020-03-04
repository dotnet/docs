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
   void AddMyData()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject;
      
      // Stores a string, specifying the Unicode format.
      myDataObject->SetData( DataFormats::UnicodeText, "Text string" );
      
      // Retrieves the data by specifying Text.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->GetType()->Name;
   }
   // </Snippet1>
};
