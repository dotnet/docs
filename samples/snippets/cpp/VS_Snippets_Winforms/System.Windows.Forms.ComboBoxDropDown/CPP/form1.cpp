// This example demonstrates the ComboBox.ObjectCollection.AddRange, 
// ComboBox.DropDown, and ComboBox.Text properties and the 
// MessageBox.Show(string, string, MessageBoxButton, MessageBoxIcon) 
// method.

#using <System.Drawing.dll>
#using <System.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1() : Form()
   {
      InitializeComponent();
      InitializeComboBox();
   }

internal:
   System::Windows::Forms::Label ^ Label2;
   System::Windows::Forms::Label ^ Label1;

private:
   void InitializeComponent()
   {
      this->Label2 = gcnew System::Windows::Forms::Label;
      this->Label1 = gcnew System::Windows::Forms::Label;
      this->SuspendLayout();
      this->Label1->Location = System::Drawing::Point( 24, 48 );
      this->Label1->Name = "Label1";
      this->Label1->TabIndex = 3;
      this->Label1->Text = "Installation Type:";
      this->Label1->TextAlign =
         System::Drawing::ContentAlignment::MiddleRight;
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->Label1 );
      this->Controls->Add( this->Label2 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet2>
   //<snippet1>
internal:
   // Declare ComboBox1
   System::Windows::Forms::ComboBox^ ComboBox1;

private:
   // Initialize ComboBox1.
   void InitializeComboBox()
   {
      this->ComboBox1 = gcnew ComboBox;
      this->ComboBox1->Location = System::Drawing::Point( 128, 48 );
      this->ComboBox1->Name = "ComboBox1";
      this->ComboBox1->Size = System::Drawing::Size( 100, 21 );
      this->ComboBox1->TabIndex = 0;
      this->ComboBox1->Text = "Typical";
      array<String^>^ installs = {"Typical","Compact","Custom"};
      ComboBox1->Items->AddRange( installs );
      this->Controls->Add( this->ComboBox1 );
      
      // Hook up the event handler.
      this->ComboBox1->DropDown += gcnew System::EventHandler(
         this, &Form1::ComboBox1_DropDown );
   }
   //</snippet1>

   // Handles the ComboBox1 DropDown event. If the user expands the  
   // drop-down box, a message box will appear, recommending the
   // typical installation.
   void ComboBox1_DropDown( Object^ sender, System::EventArgs^ e )
   {
      MessageBox::Show( "Typical installation is strongly recommended.",
         "Install information", MessageBoxButtons::OK,
         MessageBoxIcon::Information );
   }
   //</snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
