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
      SetData3();
   }

   // <snippet1>
private:
   void SetData3()
   {
      // Creates a component.
      Component^ myComponent = gcnew Component;
      
      // Gets the type of the component.
      Type^ myType = myComponent->GetType();
      
      // Creates a data object.
      DataObject^ myDataObject = gcnew DataObject;
      
      // Stores the component in the data object.
      myDataObject->SetData( myType, myComponent );
      
      // Checks whether data of the specified type is in the data object.
      String^ myMessageText;
      if ( myDataObject->GetDataPresent( myType ) )
      {
         myMessageText = "Data of type " + myType->Name +
            " is stored in the data object";
      }
      else
      {
         myMessageText = "No data of type " + myType->Name +
            " is stored in the data object";
      }
      
      // Displays the result.
      MessageBox::Show( myMessageText, "The Test Result" );
   }
   // </snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
