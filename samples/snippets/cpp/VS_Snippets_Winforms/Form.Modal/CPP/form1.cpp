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

namespace FormModalEx
{

   /// <summary>
   /// Summary description for Form1.
   /// </summary>
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;

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

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 184, 56 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 88, 24 );
         this->button1->TabIndex = 0;
         this->button1->Text = "button1";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 266 );
         array<System::Windows::Forms::Control^>^formControls = {this->button1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         ShowMyNonModalForm();
      }

      //<Snippet1>
   private:
      void ShowMyNonModalForm()
      {
         Form^ myForm = gcnew Form;
         myForm->Text = "My Form";
         myForm->SetBounds( 10, 10, 200, 200 );
         myForm->Show();

         // Determine if the form is modal.
         if ( myForm->Modal == false )
         {
            // Change borderstyle and make it not a top level window.
            myForm->FormBorderStyle = ::FormBorderStyle::FixedToolWindow;
            myForm->TopLevel = false;
         }
      }
      //</Snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew FormModalEx::Form1 );
}
