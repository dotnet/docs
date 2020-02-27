#using <System.Data.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

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
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();
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
      this->ClientSize = System::Drawing::Size( 344, 270 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->Resize += gcnew System::EventHandler( this, &Form1::Form1_Resize );
      this->Move += gcnew System::EventHandler( this, &Form1::Form1_Move );
   }

   void Form1_Resize( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

   //<Snippet1>
   // The following example displays the location of the form in screen coordinates
   // on the caption bar of the form.
private:
   void Form1_Move( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      this->Text = String::Format( "Form screen position = {0}", this->Location );
   }
   //</Snippet1>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
