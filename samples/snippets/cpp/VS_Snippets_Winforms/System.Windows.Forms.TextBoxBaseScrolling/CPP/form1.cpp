

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

// The following code example demonstrates using the Keys enum,  
// and the TextBoxBase.ScrollToCaret,  and TextBox.HideSelection methods.
// It also demonstrates and handling the TextBox.Click event.
using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeTextBox();
      
      // Hook up the event-handling method with the
      // KeyDown Event.
      this->TextBox1->KeyDown += gcnew KeyEventHandler( this, &Form1::TextBox1_KeyDown );
      this->TextBox1->Click += gcnew System::EventHandler( this, &Form1::TextBox1_Click );
      
      //Add any initialization after the InitializeComponent() call
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

   //Required by the Windows Form Designer
   System::ComponentModel::IContainer^ components;

internal:

   //NOTE: The following procedure is required by the Windows 
   //Form Designer. It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.
   System::Windows::Forms::RichTextBox^ RichTextBox1;

private:

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      this->RichTextBox1 = gcnew System::Windows::Forms::RichTextBox;
      this->TextBox1 = gcnew System::Windows::Forms::TextBox;
      this->SuspendLayout();
      
      //
      //RichTextBox1
      //
      this->RichTextBox1->Location = System::Drawing::Point( 40, 80 );
      this->RichTextBox1->Name = "RichTextBox1";
      this->RichTextBox1->ReadOnly = true;
      this->RichTextBox1->TabIndex = 0;
      this->RichTextBox1->Text = "and the text will be added here.";
      
      //
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->RichTextBox1 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet3>
   //Declare a textbox called TextBox1.
internal:
   System::Windows::Forms::TextBox^ TextBox1;

private:

   //Initialize TextBox1.
   void InitializeTextBox()
   {
      this->TextBox1 = gcnew TextBox;
      this->TextBox1->Location = System::Drawing::Point( 32, 24 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->Size = System::Drawing::Size( 136, 20 );
      this->TextBox1->TabIndex = 1;
      this->TextBox1->Text = "Type and hit enter here...";
      
      //Keep the selection highlighted, even after textbox loses focus.
      TextBox1->HideSelection = false;
      this->Controls->Add( TextBox1 );
   }
   //</snippet3>

   //<snippet2>
private:
   //Selects everything in TextBox1.
   void TextBox1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      TextBox1->SelectAll();
   }
   //</snippet2>

   //<snippet1>
private:
   //Handles the Enter key being pressed while TextBox1 has focus. 
   void TextBox1_KeyDown( Object^ /*sender*/, KeyEventArgs^ e )
   {
      TextBox1->HideSelection = false;
      if ( e->KeyCode == Keys::Enter )
      {
         e->Handled = true;

         // Copy the text from TextBox1 to RichTextBox1, add a CRLF after 
         // the copied text, and keep the caret in view.
         RichTextBox1->SelectedText = String::Concat( TextBox1->Text, "\r\n" );
         RichTextBox1->ScrollToCaret();
      }
   }
   //</snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
