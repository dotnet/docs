#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

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
         textBox1->Text = String::Concat( "Data of type ", myType->Name,
           " is present in the DataObject" );
      }
      else
      {
         textBox1->Text = String::Concat( "Data of type ", myType->Name,
           " is not present in the DataObject" );
      }
   }
   // </Snippet1>
};
