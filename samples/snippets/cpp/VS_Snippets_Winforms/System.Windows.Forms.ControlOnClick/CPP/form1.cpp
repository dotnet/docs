// This example demonstrates overriding the OnClick method of a 
// custom TextBox control.

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;

//<snippet1>
// This is a custom TextBox control that overrides the OnClick method
// to allow one-click selection of the text in the text box.
public ref class SingleClickTextBox: public TextBox
{
protected:
   virtual void OnClick( EventArgs^ e ) override
   {
      this->SelectAll();
      TextBox::OnClick( e );
   }
};
//</snippet1>

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      InitializeComponent();
   }

internal:
   TextBox^ TextBox1;
   SingleClickTextBox^ TextBox2;

private:
   void InitializeComponent()
   {
      this->TextBox1 = gcnew TextBox;
      this->TextBox2 = gcnew SingleClickTextBox;
      this->SuspendLayout();
      this->TextBox1->Location = System::Drawing::Point( 40, 60 );
      this->TextBox1->Name = "TextBox1";
      this->TextBox1->TabIndex = 1;
      this->TextBox1->Size = System::Drawing::Size( 150, 80 );
      this->TextBox1->Text = "This textbox requires a drag motion for selection.";
      this->TextBox1->Multiline = true;
      this->TextBox1->Select( 0, 0 );
      this->SuspendLayout();
      this->TextBox2->Location = System::Drawing::Point( 40, 150 );
      this->TextBox2->Name = "TextBox2";
      this->TextBox2->TabIndex = 2;
      this->TextBox2->Size = System::Drawing::Size( 150, 80 );
      this->TextBox2->Text = "One click causes all text to be selected.";
      this->TextBox2->Multiline = true;
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->TextBox1 );
      this->Controls->Add( this->TextBox2 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }
};

int main()
{
   Application::Run( gcnew Form1 );
}
