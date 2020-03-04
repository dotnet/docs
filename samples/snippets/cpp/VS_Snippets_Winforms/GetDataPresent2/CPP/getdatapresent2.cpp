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
   System::Windows::Forms::TextBox^ textBox1;

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
      GetDataPresent2();

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
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();

      //
      // textBox1
      //
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 288, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "textBox1";

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 276 );
      array<System::Windows::Forms::Control^>^formControls = {this->textBox1};
      this->Controls->AddRange( formControls );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
      this->ResumeLayout( false );
   }

   // <snippet1>
private:
   void GetDataPresent2()
   {
      // Creates a component to store in the data object.
      Component^ myComponent = gcnew Component;

      // Creates a new data object and assigns it the component.
      DataObject^ myDataObject = gcnew DataObject( myComponent );

      // Creates a type to store the type of data.
      Type^ myType = myComponent->GetType();

      // Checks whether the specified data type exists in the object.
      if ( myDataObject->GetDataPresent( myType ) )
      {
         MessageBox::Show( "The specified data is stored in the data object." );

         // Displays the type of data.
         textBox1->Text = "The data type is " + myDataObject->GetData( myType )->GetType()->Name + ".";
      }
      else
            MessageBox::Show( "The specified data is not stored in the data object." );
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
