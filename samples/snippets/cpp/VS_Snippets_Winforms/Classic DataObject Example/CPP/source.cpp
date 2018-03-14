#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void AddMyData3()
   {
      // Creates a component to store in the data object.
      Component^ myComponent = gcnew Component;
      
      // Creates a new data object.
      DataObject^ myDataObject = gcnew DataObject;
      
      // Adds the component to the DataObject.
      myDataObject->SetData( myComponent );
      
      // Prints whether data of the specified type is in the DataObject.
      Type^ myType = myComponent->GetType();
      if ( myDataObject->GetDataPresent( myType ) )
      {
         textBox1->Text = String::Concat( "Data of type ", myType,
            " is present in the DataObject" );
      }
      else
      {
         textBox1->Text = String::Concat( "Data of type ", myType,
            " is not present in the DataObject" );
      }
   }
   // </Snippet1>

   // <Snippet2>
   void GetMyData2()
   {
      // Creates a new data object using a string and the text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,"Text to Store" );
      
      // Prints the string in a text box.
      textBox1->Text = myDataObject->GetData( DataFormats::Text )->ToString();
   }
   // </Snippet2>
};
