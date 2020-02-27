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
   System::ComponentModel::Container^ components;

public:
   Form1()
   {
      components = nullptr;
      InitializeComponent();
      TestDataObject();
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
   void TestDataObject()
   {
      // Creates a new data object using a string and the Text format.
      String^ myString = "Hello World!";
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,myString );

      // Checks whether the data is present in the Text format and displays the result.
      if ( myDataObject->GetDataPresent( DataFormats::Text ) )
            MessageBox::Show( "The stored data is in the Text format.", "Test Result" );
      else
            MessageBox::Show( "The stored data is not in the Text format.", "Test Result" );
   }
   // </snippet1>

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
};

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
