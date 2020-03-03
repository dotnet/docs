

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

namespace CSExample
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::RichTextBox^ richTextBox1;
      System::Windows::Forms::Button^ button1;

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
         components = nullptr;
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

      //      #region Windows Form Designer generated code
      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->richTextBox1 = gcnew System::Windows::Forms::RichTextBox;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();
         
         // 
         // richTextBox1
         // 
         this->richTextBox1->Location = System::Drawing::Point( 8, 8 );
         this->richTextBox1->Name = "richTextBox1";
         this->richTextBox1->Size = System::Drawing::Size( 256, 24 );
         this->richTextBox1->TabIndex = 0;
         this->richTextBox1->Text = "Make me BOLD";
         this->richTextBox1->Enter += gcnew System::EventHandler( this, &Form1::richTextBox1_Enter );
         
         // 
         // button1
         // 
         this->button1->Location = System::Drawing::Point( 8, 40 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 72, 32 );
         this->button1->TabIndex = 1;
         this->button1->Text = "Bold";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
         
         // 
         // Form1
         // 
         this->ClientSize = System::Drawing::Size( 292, 117 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button1,this->richTextBox1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }
      //      #endregion

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->ToggleBold();
      }

      // <Snippet1>
      void ToggleBold()
      {
         if ( richTextBox1->SelectionFont != nullptr )
         {
            System::Drawing::Font^ currentFont = richTextBox1->SelectionFont;
            System::Drawing::FontStyle newFontStyle;
            if ( richTextBox1->SelectionFont->Bold == true )
            {
               newFontStyle = FontStyle::Regular;
            }
            else
            {
               newFontStyle = FontStyle::Bold;
            }
            richTextBox1->SelectionFont = gcnew System::Drawing::Font( currentFont->FontFamily,currentFont->Size,newFontStyle );
         }
      }
      // </Snippet1>
      void richTextBox1_Enter( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         richTextBox1->SelectionStart = 8;
         richTextBox1->SelectionLength = 4;
      }
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew CSExample::Form1 );
}
