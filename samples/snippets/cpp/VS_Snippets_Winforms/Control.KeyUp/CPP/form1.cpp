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
   System::Windows::Forms::TextBox^ textBox1;

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
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();

      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 120, 80 );
      this->textBox1->Name = "textBox1";
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "";
      this->textBox1->MouseUp += gcnew System::Windows::Forms::MouseEventHandler( this, &Form1::textBox1_MouseUp );
      this->textBox1->KeyUp += gcnew System::Windows::Forms::KeyEventHandler( this, &Form1::textBox1_KeyUp );

      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 464, 326 );
      array<System::Windows::Forms::Control^>^temp0 = {this->textBox1};
      this->Controls->AddRange( temp0 );
      this->KeyPreview = true;
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   void textBox1_MouseUp( Object^ /*sender*/, System::Windows::Forms::MouseEventArgs^ /*e*/ ){}

   //<Snippet1>
   // This example demonstrates how to use the KeyUp event with the Help class to display
   // pop-up style help to the user of the application. When the user presses F1, the Help
   // class displays a pop-up window, similar to a ToolTip, near the control. This example assumes
   // that a TextBox control, named textBox1, has been added to the form and its KeyUp
   // event has been connected to this event handler method.
private:
   void textBox1_KeyUp( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      
      // Determine whether the key entered is the F1 key. Display help if it is.
      if ( e->KeyCode == Keys::F1 )
      {
         
         // Display a pop-up help topic to assist the user.
         Help::ShowPopup( textBox1, "Enter your first name", Point(textBox1->Right,this->textBox1->Bottom) );
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
