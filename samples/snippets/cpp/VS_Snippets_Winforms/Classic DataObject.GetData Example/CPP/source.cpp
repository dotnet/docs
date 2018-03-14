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
   void GetMyData3()
   {
      // Creates a new data object using a string and the text format.
      String^ myString = "My new text string";
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,myString );
      
      // Prints the string in a text box with autoconvert = false.
      if ( myDataObject->GetData( "System.String", false ) != 0 )
      {
         // Prints the string in a text box.
         textBox1->Text = String::Concat(
            myDataObject->GetData( "System.String", false )->ToString(), "\n" );
      }
      else
      {
         textBox1->Text = "Could not find data of the specified format\n";
      }
      
      // Prints the string in a text box with autoconvert = true.
      textBox1->Text = String::Concat(
            textBox1->Text, myDataObject->GetData( "System.String", true )->ToString() );
   }
   // </Snippet1>
};
