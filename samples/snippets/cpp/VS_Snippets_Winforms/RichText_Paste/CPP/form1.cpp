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

namespace RichText_CanPaste_CS
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::RichTextBox^ richTextBox1;

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
         pasteMyBitmap( "c:\\NoImage::bmp" );
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

      //<snippet1>
   private:
      bool pasteMyBitmap( String^ fileName )
      {
         // Open an bitmap from file and copy it to the clipboard.
         Bitmap^ myBitmap = gcnew Bitmap( fileName );

         // Copy the bitmap to the clipboard.
         Clipboard::SetDataObject( myBitmap );

         // Get the format for the object type.
         DataFormats::Format^ myFormat = DataFormats::GetFormat( DataFormats::Bitmap );

         // After verifying that the data can be pasted, paste it.
         if ( richTextBox1->CanPaste( myFormat ) )
         {
            richTextBox1->Paste( myFormat );
            return true;
         }
         else
         {
            MessageBox::Show( "The data format that you attempted to paste is not supported by this control." );
            return false;
         }
      }
      //</snippet1>

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
         this->SuspendLayout();

         //
         // richTextBox1
         //
         this->richTextBox1->Location = System::Drawing::Point( 40, 136 );
         this->richTextBox1->Name = "richTextBox1";
         this->richTextBox1->TabIndex = 0;
         this->richTextBox1->Text = "richTextBox1";

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^formControls = {this->richTextBox1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew RichText_CanPaste_CS::Form1 );
}
