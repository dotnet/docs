

// <Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

// Creates a new type.

[Serializable]
public ref class MyNewObject: public Object
{
private:
   String^ myValue;

public:

   // Creates a default constructor for the class.
   MyNewObject()
   {
      myValue = "This is the value of the class";
   }


   property String^ MyObjectValue 
   {

      // Creates a property to retrieve or set the value.
      String^ get()
      {
         return myValue;
      }

      void set( String^ value )
      {
         myValue = value;
      }

   }

};

public ref class MyClass: public Form
{
protected:
   TextBox^ textBox1;

public:
   void MyClipboardMethod()
   {
      
      // Creates a new data format.
      DataFormats::Format^ myFormat = DataFormats::GetFormat( "myFormat" );
      
      /* Creates a new object and stores it in a DataObject using myFormat 
               * as the type of format. */
      MyNewObject^ myObject = gcnew MyNewObject;
      DataObject^ myDataObject = gcnew DataObject( myFormat->Name,myObject );
      
      // Copies myObject into the clipboard.
      Clipboard::SetDataObject( myDataObject );
      
      // Performs some processing steps.
      // Retrieves the data from the clipboard.
      IDataObject^ myRetrievedObject = Clipboard::GetDataObject();
      
      // Converts the IDataObject type to MyNewObject type. 
      MyNewObject^ myDereferencedObject = dynamic_cast<MyNewObject^>(myRetrievedObject->GetData( myFormat->Name ));
      
      // Prints the value of the Object in a textBox.
      textBox1->Text = myDereferencedObject->MyObjectValue;
   }

};

// </Snippet1>
