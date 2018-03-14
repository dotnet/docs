

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

namespace ControlMembers6
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::TextBox^ textBox1;
      System::Windows::Forms::Button^ button2;
      System::Windows::Forms::CheckBox^ checkBox1;
      System::Windows::Forms::Button^ button3;
      System::Windows::Forms::Button^ button4;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         InitializeComponent();
         textBox1->Enabled = checkBox1->Checked;
      }

   protected:
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         this->button1 = gcnew System::Windows::Forms::Button;
         this->textBox1 = gcnew System::Windows::Forms::TextBox;
         this->button2 = gcnew System::Windows::Forms::Button;
         this->checkBox1 = gcnew System::Windows::Forms::CheckBox;
         this->button3 = gcnew System::Windows::Forms::Button;
         this->button4 = gcnew System::Windows::Forms::Button;
         this->SuspendLayout();

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 48, 40 );
         this->button1->Name = "button1";
         this->button1->TabIndex = 0;
         this->button1->Text = "Focus";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

         //
         // textBox1
         //
         this->textBox1->Location = System::Drawing::Point( 48, 88 );
         this->textBox1->Name = "textBox1";
         this->textBox1->TabIndex = 1;
         this->textBox1->Text = "textBox1";

         //
         // button2
         //
         this->button2->Location = System::Drawing::Point( 160, 40 );
         this->button2->Name = "button2";
         this->button2->TabIndex = 2;
         this->button2->Text = "Select";
         this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );

         //
         // checkBox1
         //
         this->checkBox1->Location = System::Drawing::Point( 160, 88 );
         this->checkBox1->Name = "checkBox1";
         this->checkBox1->TabIndex = 3;
         this->checkBox1->Text = "Enabled";
         this->checkBox1->CheckedChanged += gcnew System::EventHandler( this, &Form1::checkBox1_CheckedChanged );

         //
         // button3
         //
         this->button3->Location = System::Drawing::Point( 216, 248 );
         this->button3->Name = "button3";
         this->button3->TabIndex = 4;
         this->button3->Text = "button3";
         this->button3->Click += gcnew System::EventHandler( this, &Form1::button3_Click );

         //
         // button4
         //
         this->button4->Location = System::Drawing::Point( 0, 248 );
         this->button4->Name = "button4";
         this->button4->TabIndex = 5;
         this->button4->Text = "button4";
         this->button4->Click += gcnew System::EventHandler( this, &Form1::button4_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 292, 273 );
         array<System::Windows::Forms::Control^>^temp0 = {this->button4,this->button3,this->checkBox1,this->button2,this->textBox1,this->button1};
         this->Controls->AddRange( temp0 );
         this->Name = "Form1";
         this->Text = "Form1";
         this->ResumeLayout( false );
      }

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->ControlSetFocus( this->textBox1 );
      }

      //<snippet1>
   public:
      void ControlSetFocus( Control^ control )
      {
         
         // Set focus to the control, if it can receive focus.
         if ( control->CanFocus )
         {
            control->Focus();
         }
      }
      //</snippet1>

      //<snippet2>
   public:
      void ControlSelect( Control^ control )
      {
         
         // Select the control, if it can be selected.
         if ( control->CanSelect )
         {
            control->Select(  );
         }
      }
      //</snippet2>

   private:
      void checkBox1_CheckedChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         textBox1->Enabled = checkBox1->Checked;
      }

      void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->ControlSelect( this->textBox1 );
      }

      //<snippet3>
   public:
      void EnableDoubleBuffering()
      {
         // Set the value of the double-buffering style bits to true.
         this->SetStyle( static_cast<ControlStyles>(ControlStyles::DoubleBuffer | ControlStyles::UserPaint | ControlStyles::AllPaintingInWmPaint), true );
         this->UpdateStyles();
      }
      // </snippet3>

      // <snippet4>
   public:
      bool DoubleBufferingEnabled()
      {
         
         // Get the value of the double-buffering style bits.
         return this->GetStyle( static_cast<ControlStyles>(ControlStyles::DoubleBuffer | ControlStyles::UserPaint | ControlStyles::AllPaintingInWmPaint) );
      }
      // </snippet4>


   private:
      void button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         this->EnableDoubleBuffering();
      }

      void button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         MessageBox::Show( this->DoubleBufferingEnabled().ToString() );
         this->ScaleChildControls();
      }

      // <snippet5>
   public:
      void ScaleChildControlsEqually()
      {
         // Resize all child controls to 1.5
         // times their current size.
         for ( int i = 0; i < this->Controls->Count; i++ )
         {
            this->Controls[ i ]->Scale( 1.5f );
         }
      }
      // </snippet5>

      // <snippet6>
      void ScaleChildControls()
      {
         // Resize all child controls to 1.5 times their current
         // height while, maintaining their current width.
         for ( int i = 0; i < this->Controls->Count; i++ )
         {
            this->Controls[ i ]->Scale( 1.0f, 1.5f );
         }
      }
      // </snippet6>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew ControlMembers6::Form1 );
}
