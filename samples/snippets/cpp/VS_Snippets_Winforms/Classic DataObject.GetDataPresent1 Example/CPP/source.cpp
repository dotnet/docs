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
   void GetIfPresent3()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text, "Another string" );
      
      // Prints the string in a text box with autoconvert = false.
      if ( myDataObject->GetDataPresent( "System.String", false ) )
      {
         // Prints the string in a text box.
         textBox1->Text = String::Concat(
            myDataObject->GetData( "System.String", false )->ToString(), "\n" );
      }
      else
      {
         textBox1->Text = "Could not convert data to specified format\n";
      }
      
      // Prints the string in a text box with autoconvert = true.
      textBox1->Text = String::Concat( textBox1->Text,
         "With autoconvert = true, you can convert text to string format. String is: ",
         myDataObject->GetData( "System.String", true )->ToString() );
   }
   // </Snippet1>
};
