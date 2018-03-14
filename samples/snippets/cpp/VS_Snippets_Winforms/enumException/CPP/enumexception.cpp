#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

#define NULL 0

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
      
      //
      // TODO: Add any constructor code after InitializeComponent call
      //
   }

protected:

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

   //#region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 292, 273 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
   }

   //#endregion
   void Form1_Load( Object^ sender, System::EventArgs^ e )
   {
      //<snippet1>
      try
      {
         //Attempting to pass an invalid enum value (MessageBoxButtons) to the Show method
         MessageBoxButtons myButton = (MessageBoxButtons)123; // to fix use System::Windows::Forms::DialogResult::OK;

         MessageBox::Show( this,  "This is a message",  "This is the Caption", myButton );
      }
      catch ( InvalidEnumArgumentException^ invE ) 
      {
         Console::WriteLine( invE->Message );
         Console::WriteLine( invE->ParamName );
         Console::WriteLine( invE->StackTrace );
         Console::WriteLine( invE->Source );
      }
      //</snippet1>
   }
};

/// <summary>
/// The main entry point for the application.
/// </summary>
void main()
{
   Application::Run( gcnew Form1 );
}
