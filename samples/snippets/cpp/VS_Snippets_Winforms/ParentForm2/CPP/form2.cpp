#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

/// <summary>
/// Summary description for Form2.
/// </summary>
public ref class Form2: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::Button^ button1;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;

public:
   Form2()
   {
      components = nullptr;
      InitializeComponent();
   }

public:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~Form2()
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
      this->button1->Location = System::Drawing::Point( 160, 176 );
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 80, 24 );
      this->button1->TabIndex = 0;
      this->button1->Text = "button1";
      this->button1->Click += gcnew System::EventHandler( this, &Form2::button1_Click );

      //
      // Form2
      //
      this->ClientSize = System::Drawing::Size( 292, 276 );
      array<System::Windows::Forms::Control^>^formControls = {this->button1};
      this->Controls->AddRange( formControls );
      this->Name = "Form2";
      this->Text = "Form2";
      this->Load += gcnew System::EventHandler( this, &Form2::Form2_Load );
      this->ResumeLayout( false );
   }

   // <snippet2>
   // The event handler on Form2.
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Get the Name property of the Parent.
      String^ s = ParentForm->Name;

      // Display the name in a message box.
      MessageBox::Show( String::Concat( "My Parent is ", s, "." ) );
   }
   // </snippet2>

   void Form2_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ ){}
};
