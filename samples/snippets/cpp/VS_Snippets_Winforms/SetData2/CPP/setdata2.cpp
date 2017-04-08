#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public Form
{
public:
   Form1()
   {
      SetData2();
   }

   // <snippet1>
private:
   void SetData2()
   {
      // Creates a data object.
      DataObject^ myDataObject = gcnew DataObject;
      
      // Stores a string, specifying the UnicodeText format.
      myDataObject->SetData( DataFormats::UnicodeText, "Hello World!" );
      
      // Retrieves the data by specifying the Text format.
      String^ myMessageText = "The data type is " +
         myDataObject->GetData( DataFormats::Text )->GetType()->Name;
      
      // Displays the result.
      MessageBox::Show( myMessageText, "The Test Result" );
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
