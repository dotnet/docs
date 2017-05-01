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
      GetDataPresent3();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

public:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
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
   void GetDataPresent3()
   {
      // Creates a new data object using a string and the Text format.
      DataObject^ myDataObject = gcnew DataObject( DataFormats::Text,"My String" );

      // Checks whether the string can be displayed with autoConvert equal to false.
      if ( myDataObject->GetDataPresent( "System::String", false ) )
            MessageBox::Show( myDataObject->GetData( "System::String", false )->ToString(), "Message #1" );
      else
            MessageBox::Show( "Cannot convert data to the specified format with autoConvert set to false.", "Message #1" );

      // Displays the string with autoConvert equal to true.
      MessageBox::Show( "Now that autoConvert is true, you can convert " + myDataObject->GetData( "System::String", true ) + " to string format.", "Message #2" );
   }
   // </snippet1>

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

   void label1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

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
