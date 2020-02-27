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
   void GetAllFormats()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,"Another string" );
      
      // Gets all the data formats and data conversion formats in the DataObject.
      array<String^>^ arrayOfFormats = myDataObject->GetFormats();
      
      // Prints the results.
      textBox1->Text = "The format(s) associated with the data are: \n";
      for ( int i = 0; i < arrayOfFormats->Length; i++ )
      {
         textBox1->Text = String::Concat( textBox1->Text, arrayOfFormats[ i ], "\n" );
      }
   }
   // </Snippet1>
};
