#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public Form
{
   // <snippet1>
private:
   void GetFormats1()
   {
      // Creates a data object using a string and the Text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,"My text string" );
      
      // Gets all the data formats and data conversion formats in the data object.
      array<String^>^allFormats = myDataObject->GetFormats();
      
      // Creates the string that contains the formats.
      String^ theResult = "The format(s) associated with the data are: \n";
      for ( int i = 0; i < allFormats->Length; i++ )
         theResult = theResult + allFormats[ i ] + "\n";
      
      // Displays the result in a message box.
      MessageBox::Show( theResult );
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
