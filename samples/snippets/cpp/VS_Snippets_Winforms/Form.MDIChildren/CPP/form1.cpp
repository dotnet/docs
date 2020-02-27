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
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;

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

#pragma region Windows Form Designer generated code
   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      // 
      // button1
      // 
      this->button1->Location = System::Drawing::Point( 208, 48 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 72, 32 );
      this->button1->TabIndex = 1;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );

      // 
      // button2
      // 
      this->button2->Location = System::Drawing::Point( 344, 144 );
      this->button2->Name = "button2";
      this->button2->Size = System::Drawing::Size( 96, 40 );
      this->button2->TabIndex = 2;
      this->button2->Text = "button2";
      this->button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );

      // 
      // Form1
      // 
      this->ClientSize = System::Drawing::Size( 512, 494 );
      array<System::Windows::Forms::Control^>^temp1 = {this->button2,this->button1};
      this->Controls->AddRange( temp1 );
      this->IsMdiContainer = true;
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }
#pragma endregion

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Form^ frm2 = gcnew Form;
      frm2->MdiParent = this;
      frm2->Show();
   }

   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      AddButtonsToMyChildren();
   }

   //<Snippet1>
private:
   void AddButtonsToMyChildren()
   {
      // If there are child forms in the parent form, add Button controls to them.
      for ( int x = 0; x < this->MdiChildren->Length; x++ )
      {
         // Create a temporary Button control to add to the child form.
         Button^ tempButton = gcnew Button;

         // Set the location and text of the Button control.
         tempButton->Location = Point(10,10);
         tempButton->Text = "OK";

         // Create a temporary instance of a child form (Form 2 in this case).
         Form^ tempChild = dynamic_cast<Form^>(this->MdiChildren[ x ]);

         // Add the Button control to the control collection of the form.
         tempChild->Controls->Add( tempButton );
      }
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
