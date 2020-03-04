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

namespace SetData4
{

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
         SetData4();
         
         //
         // TODO: Adds any constructor code after InitializeComponent call
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
      void SetData4()
      {
         // Creates a new data object.
         DataObject^ myDataObject = gcnew DataObject;

         // Adds UnicodeText string to the object, and set the autoConvert
         // parameter to false.
         myDataObject->SetData( DataFormats::UnicodeText, false, "My text String*" );

         // Gets the data format(s) in the data object.
         array<String^>^arrayOfFormats = myDataObject->GetFormats();

         // Stores the results in a string.
         String^ theResult = "The format(s) associated with the data are: \n";
         for ( int i = 0; i < arrayOfFormats->Length; i++ )
            theResult = theResult + arrayOfFormats[ i ], " \n";

         // Show the results in a message box.
         MessageBox::Show( theResult );
      }
      // </snippet1>

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew SetData4::Form1 );
}
