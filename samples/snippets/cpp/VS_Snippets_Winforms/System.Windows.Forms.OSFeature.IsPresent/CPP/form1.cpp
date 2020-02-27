

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
//</Snippet1>

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

   void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}

   //<Snippet2>
   // Gets the caret width based upon the operating system or default value.
   int GetCaretWidth()
   {
      // Check to see if the operating system supports the caret width metric. 
      if ( OSFeature::Feature->IsPresent( SystemParameter::CaretWidthMetric ) )
      {
         // If the operating system supports this metric,
         // return the value for the caret width metric. 
         return SystemInformation::CaretWidth;
      }
      else
            1;

      // If the operating system does not support this metric,
      // return a custom default value for the caret width.
   }
   //</Snippet2>
};


/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
