

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
public:
   Form1()
      : Form()
   {
      
      //This call is required by the Windows Form Designer.
      InitializeComponent();
      InitializeRadioButtonsAndGroupBox();
      this->RadioButton1->CheckedChanged += gcnew EventHandler( this,&Form1::RadioButton_CheckedChanged );
      this->RadioButton2->CheckedChanged += gcnew EventHandler( this,&Form1::RadioButton_CheckedChanged );
      this->RadioButton3->CheckedChanged += gcnew EventHandler( this,&Form1::RadioButton_CheckedChanged );
      
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

   //NOTE: The following procedure is required by the Windows Form Designer
   //It can be modified using the Windows Form Designer.  
   //Do not modify it using the code editor.

   [System::Diagnostics::DebuggerStepThrough]
   void InitializeComponent()
   {
      
      //Form1
      //
      this->ClientSize = System::Drawing::Size( 292, 266 );
      this->Name = "Form1";
      this->Text = "Form1";
      this->ResumeLayout( false );
   }

   //<snippet1>
   //<snippet2>
internal:
   System::Windows::Forms::GroupBox^ GroupBox1;
   System::Windows::Forms::RadioButton^ RadioButton1;
   System::Windows::Forms::RadioButton^ RadioButton2;
   System::Windows::Forms::RadioButton^ RadioButton3;

private:
   void InitializeRadioButtonsAndGroupBox()
   {
      
      // Construct the GroupBox object.
      this->GroupBox1 = gcnew GroupBox;
      
      // Construct the radio buttons.
      this->RadioButton1 = gcnew System::Windows::Forms::RadioButton;
      this->RadioButton2 = gcnew System::Windows::Forms::RadioButton;
      this->RadioButton3 = gcnew System::Windows::Forms::RadioButton;
      
      // Set the location, tab and text for each radio button
      // to a cursor from the Cursors enumeration.
      this->RadioButton1->Location = System::Drawing::Point( 24, 24 );
      this->RadioButton1->TabIndex = 0;
      this->RadioButton1->Text = "Help";
      this->RadioButton1->Tag = Cursors::Help;
      this->RadioButton1->TextAlign = ContentAlignment::MiddleCenter;
      this->RadioButton2->Location = System::Drawing::Point( 24, 56 );
      this->RadioButton2->TabIndex = 1;
      this->RadioButton2->Text = "Up Arrow";
      this->RadioButton2->Tag = Cursors::UpArrow;
      this->RadioButton2->TextAlign = ContentAlignment::MiddleCenter;
      this->RadioButton3->Location = System::Drawing::Point( 24, 80 );
      this->RadioButton3->TabIndex = 3;
      this->RadioButton3->Text = "Cross";
      this->RadioButton3->Tag = Cursors::Cross;
      this->RadioButton3->TextAlign = ContentAlignment::MiddleCenter;
      
      // Add the radio buttons to the GroupBox.  
      this->GroupBox1->Controls->Add( this->RadioButton1 );
      this->GroupBox1->Controls->Add( this->RadioButton2 );
      this->GroupBox1->Controls->Add( this->RadioButton3 );
      
      // Set the location of the GroupBox. 
      this->GroupBox1->Location = System::Drawing::Point( 56, 64 );
      this->GroupBox1->Size = System::Drawing::Size( 200, 150 );
      
      // Set the text that will appear on the GroupBox.
      this->GroupBox1->Text = "Choose a Cursor Style";
      
      //
      // Add the GroupBox to the form.
      this->Controls->Add( this->GroupBox1 );
      
      //
   }
   // </snippet1>

   void RadioButton_CheckedChanged( Object^ sender, EventArgs^ /*e*/ )
   {
      
      // Cast the sender back to a RadioButton object.
      RadioButton^ selectedRadioButton = dynamic_cast<RadioButton^>(sender);
      
      // If the radio button is in a checked state, then
      // change the cursor.
      if ( selectedRadioButton->Checked )
      {
         this->Cursor = dynamic_cast<System::Windows::Forms::Cursor^>(selectedRadioButton->Tag);
      }
   }
   //</snippet2>
};

int main()
{
   Application::Run( gcnew Form1 );
}
