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
      this->textBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();
      
      //
      // textBox1
      //
      this->textBox1->Location = System::Drawing::Point( 48, 48 );
      this->textBox1->Name = "textBox1";
      this->textBox1->Size = System::Drawing::Size( 176, 20 );
      this->textBox1->TabIndex = 0;
      this->textBox1->Text = "textBox1";
      this->textBox1->KeyDown += gcnew System::Windows::Forms::KeyEventHandler( this, &Form1::textBox1_KeyDown );
      
      //
      // Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^temp0 = {this->textBox1};
      this->Controls->AddRange( temp0 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<Snippet1>
   // This example demonstrates how to use the KeyDown event with the Help class to display
   // pop-up style help to the user of the application. The example filters for all variations
   // of pressing the F1 key with a modifier key by using the KeyEventArgs properties passed
   // to the event handling method.
   // When the user presses any variation of F1 that includes any keyboard modifier, the Help
   // class displays a pop-up window, similar to a ToolTip, near the control. If the user presses
   // ALT + F2, a different Help pop-up is displayed with additional information. This example assumes
   // that a tTextBox control, named textBox1, has been added to the form and its KeyDown
   // event has been contected to this event handling method.
private:
   void textBox1_KeyDown( Object^ /*sender*/, System::Windows::Forms::KeyEventArgs^ e )
   {
      // Determine whether the key entered is the F1 key. If it is, display Help.
      if ( e->KeyCode == Keys::F1 && (e->Alt || e->Control || e->Shift) )
      {
         
         // Display a pop-up Help topic to assist the user.
         Help::ShowPopup( textBox1, "Enter your name.", Point(textBox1->Bottom,textBox1->Right) );
      }
      else
      if ( e->KeyCode == Keys::F2 && e->Modifiers == Keys::Alt )
      {
         // Display a pop-up Help topic to provide additional assistance to the user.
         Help::ShowPopup( textBox1, "Enter your first name followed by your last name. Middle name is optional.",
            Point(textBox1->Top,this->textBox1->Left) );
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
