

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
   System::Windows::Forms::HelpProvider^ helpProvider1;
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
      this->helpLabel->Text = "Click the Help button in the title bar, then click a control to see a Help tooltip for the control.  Click on a control and press F1 to invoke the Help system with a sample Help file.";
      
      // Address Label
      this->label2->Location = System::Drawing::Point( 16, 8 );
      this->label2->Size = System::Drawing::Size( 100, 16 );
      this->label2->Text = "Address:";
      
      // Comma Label
      this->label3->Location = System::Drawing::Point( 136, 56 );
      this->label3->Size = System::Drawing::Size( 16, 16 );
      this->label3->Text = ", ";
      
      //<Snippet4>
      // Create the HelpProvider.
      this->helpProvider1 = gcnew System::Windows::Forms::HelpProvider;
      
      //</Snippet4>
      //<Snippet2>
      // Tell the HelpProvider what controls to provide help for, and
      // what the help String* is.
      this->helpProvider1->SetShowHelp( this->addressTextBox, true );
      this->helpProvider1->SetHelpString( this->addressTextBox, "Enter the street address in this text box." );
      this->helpProvider1->SetShowHelp( this->cityTextBox, true );
      this->helpProvider1->SetHelpString( this->cityTextBox, "Enter the city here." );
      this->helpProvider1->SetShowHelp( this->stateTextBox, true );
      this->helpProvider1->SetHelpString( this->stateTextBox, "Enter the state in this text box." );
      this->helpProvider1->SetShowHelp( this->zipTextBox, true );
      this->helpProvider1->SetHelpString( this->zipTextBox, "Enter the zip code here." );
      
      //</Snippet2>
      //<Snippet3>
      // Set what the Help file will be for the HelpProvider.
      this->helpProvider1->HelpNamespace = "mspaint.chm";
      
      //</Snippet3>
      // Sets properties for the different address fields.
      // Address TextBox
      this->addressTextBox->Location = System::Drawing::Point( 16, 24 );
      this->addressTextBox->Size = System::Drawing::Size( 264, 20 );
      this->addressTextBox->TabIndex = 0;
      this->addressTextBox->Text = "";
      
      // City TextBox
      this->cityTextBox->Location = System::Drawing::Point( 16, 48 );
      this->cityTextBox->Size = System::Drawing::Size( 120, 20 );
      this->cityTextBox->TabIndex = 3;
      this->cityTextBox->Text = "";
      
      // State TextBox
      this->stateTextBox->Location = System::Drawing::Point( 152, 48 );
      this->stateTextBox->MaxLength = 2;
      this->stateTextBox->Size = System::Drawing::Size( 32, 20 );
      this->stateTextBox->TabIndex = 5;
      this->stateTextBox->Text = "";
      
      // Zip TextBox
      this->zipTextBox->Location = System::Drawing::Point( 192, 48 );
      this->zipTextBox->Size = System::Drawing::Size( 88, 20 );
      this->zipTextBox->TabIndex = 6;
      this->zipTextBox->Text = "";
      
      // Add the controls to the form.
      array<System::Windows::Forms::Control^>^temp0 = {this->zipTextBox,this->stateTextBox,this->label3,this->cityTextBox,this->label2,this->helpLabel,this->addressTextBox};
      this->Controls->AddRange( temp0 );
      
      // Set the form to look like a dialog, and show the HelpButton.
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
      this->HelpButton = true;
      this->MaximizeBox = false;
      this->MinimizeBox = false;
      this->ClientSize = System::Drawing::Size( 292, 160 );
      this->Text = "Help Provider Demonstration";
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
