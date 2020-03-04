

//<Snippet1>
#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::TextBox^ addressTextBox;
   System::Windows::Forms::Label ^ label2;
   System::Windows::Forms::TextBox^ cityTextBox;
   System::Windows::Forms::Label ^ label3;
   System::Windows::Forms::TextBox^ stateTextBox;
   System::Windows::Forms::TextBox^ zipTextBox;
   System::Windows::Forms::Label ^ helpLabel;

public:
   Form1()
   {
      this->addressTextBox = gcnew System::Windows::Forms::TextBox;
      this->helpLabel = gcnew System::Windows::Forms::Label;
      this->label2 = gcnew System::Windows::Forms::Label;
      this->cityTextBox = gcnew System::Windows::Forms::TextBox;
      this->label3 = gcnew System::Windows::Forms::Label;
      this->stateTextBox = gcnew System::Windows::Forms::TextBox;
      this->zipTextBox = gcnew System::Windows::Forms::TextBox;
      
      // Help Label
      this->helpLabel->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->helpLabel->Location = System::Drawing::Point( 8, 80 );
      this->helpLabel->Size = System::Drawing::Size( 272, 72 );
      this->helpLabel->Text = "Click on any control to give it focus, and then press F1 to display help for that control.  Alternately, you can click the help button at the top of the dialog and then click on a control.";
      
      // Address Label
      this->label2->Location = System::Drawing::Point( 16, 8 );
      this->label2->Size = System::Drawing::Size( 100, 16 );
      this->label2->Text = "Address:";
      
      // Comma Label
      this->label3->Location = System::Drawing::Point( 136, 56 );
      this->label3->Size = System::Drawing::Size( 16, 16 );
      this->label3->Text = ", ";
      
      // Address TextBox
      this->addressTextBox->Location = System::Drawing::Point( 16, 24 );
      this->addressTextBox->Size = System::Drawing::Size( 264, 20 );
      this->addressTextBox->TabIndex = 0;
      this->addressTextBox->Tag = "Enter the street address in this text box.";
      this->addressTextBox->Text = "";
      this->addressTextBox->HelpRequested += gcnew System::Windows::Forms::HelpEventHandler( this, &Form1::textBox_HelpRequested );
      
      // City TextBox
      this->cityTextBox->Location = System::Drawing::Point( 16, 48 );
      this->cityTextBox->Size = System::Drawing::Size( 120, 20 );
      this->cityTextBox->TabIndex = 3;
      this->cityTextBox->Tag = "Enter the city here.";
      this->cityTextBox->Text = "";
      this->cityTextBox->HelpRequested += gcnew System::Windows::Forms::HelpEventHandler( this, &Form1::textBox_HelpRequested );
      
      // State TextBox
      this->stateTextBox->Location = System::Drawing::Point( 152, 48 );
      this->stateTextBox->MaxLength = 2;
      this->stateTextBox->Size = System::Drawing::Size( 32, 20 );
      this->stateTextBox->TabIndex = 5;
      this->stateTextBox->Tag = "Enter the state in this text box.";
      this->stateTextBox->Text = "";
      this->stateTextBox->HelpRequested += gcnew System::Windows::Forms::HelpEventHandler( this, &Form1::textBox_HelpRequested );
      
      // Zip TextBox
      this->zipTextBox->Location = System::Drawing::Point( 192, 48 );
      this->zipTextBox->Name = "zipTextBox";
      this->zipTextBox->Size = System::Drawing::Size( 88, 20 );
      this->zipTextBox->TabIndex = 6;
      this->zipTextBox->Tag = "Enter the zip code here.";
      this->zipTextBox->Text = "";
      this->zipTextBox->HelpRequested += gcnew System::Windows::Forms::HelpEventHandler( this, &Form1::textBox_HelpRequested );
      
      // Set up how the form should be displayed and add the controls to the form.
      this->ClientSize = System::Drawing::Size( 292, 160 );
      array<System::Windows::Forms::Control^>^temp0 = {this->zipTextBox,this->stateTextBox,this->label3,this->cityTextBox,this->label2,this->helpLabel,this->addressTextBox};
      this->Controls->AddRange( temp0 );
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
      this->HelpButton = true;
      this->MaximizeBox = false;
      this->MinimizeBox = false;
      this->Text = "Help Event Demonstration";
   }


private:
   void textBox_HelpRequested( Object^ sender, System::Windows::Forms::HelpEventArgs^ hlpevent )
   {
      
      // This event is raised when the F1 key is pressed or the
      // Help cursor is clicked on any of the address fields.
      // The Help text for the field is in the control's
      // Tag property. It is retrieved and displayed in the label.
      Control^ requestingControl = dynamic_cast<Control^>(sender);
      helpLabel->Text = dynamic_cast<String^>(requestingControl->Tag);
      hlpevent->Handled = true;
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
