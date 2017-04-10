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

namespace FontDialog_cs
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::FontDialog^ fontDialog1;
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
         this->button1 = gcnew System::Windows::Forms::Button;
         this->fontDialog1 = gcnew System::Windows::Forms::FontDialog;
         this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 32, 8 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // fontDialog1
         //
         this->fontDialog1->Apply += gcnew System::EventHandler( this, &Form1::fontDialog1_Apply );

         //
         // richTextBox1
         //
         this->richTextBox1->Location = System::Drawing::Point( 56, 72 );
         this->richTextBox1->Name = "richTextBox1";
         this->richTextBox1->TabIndex = 1;
         this->richTextBox1->Text = "richTextBox1";

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^formControls = {this->richTextBox1,this->button1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      //<snippet1>
   private:
      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Sets the ShowApply property, then displays the dialog.
         fontDialog1->ShowApply = true;
         fontDialog1->ShowDialog();
      }

      void fontDialog1_Apply( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Applies the selected font to the selected text.
         richTextBox1->Font = fontDialog1->Font;
      }
      //</snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew FontDialog_cs::Form1 );
}
