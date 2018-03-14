#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

/// <summary>
/// Summary description for Form1.
/// </summary>
public ref class Form1: public System::Windows::Forms::Form
{
private:

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;

      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
      GetData2();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

public:

   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 276 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
   }

   // <snippet1>
private:
   void GetData2()
   {
      // Creates a component.
      Component^ myComponent = gcnew Component;

      // Creates a data object, and assigns it the component.
      DataObject^ myDataObject = gcnew DataObject( myComponent );

      // Creates a type, myType, to store the type of data.
      Type^ myType = myComponent->GetType();

      // Retrieves the data using myType to represent its type.
      Object^ myObject = myDataObject->GetData( myType );
      if ( myObject != nullptr )
            MessageBox::Show( "The data type stored in the data object is " +
                  myObject->GetType()->Name + "." );
      else
            MessageBox::Show( "Data of the specified type was not stored in the data object." );
   }
   // </snippet1>

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

/*
 * Output:
 * Parameter args for method ParamArrayAndDesc has a description attribute.
 * The description is: "This argument is a ParamArray"
 * Parameter args for method ParamArrayAndDesc has the ParamArray attribute.
 */
