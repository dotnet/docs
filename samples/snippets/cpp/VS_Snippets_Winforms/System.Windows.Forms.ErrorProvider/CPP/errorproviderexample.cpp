

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
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::Label ^ label2;
   System::Windows::Forms::Label ^ label4;
   System::Windows::Forms::Label ^ label5;
   System::Windows::Forms::Label ^ label6;
   System::Windows::Forms::Label ^ label3;
   System::Windows::Forms::TextBox^ nameTextBox1;
   System::Windows::Forms::NumericUpDown^ ageUpDownPicker;
   System::Windows::Forms::ComboBox^ favoriteColorComboBox;
   System::Windows::Forms::ErrorProvider^ ageErrorProvider;
   System::Windows::Forms::ErrorProvider^ nameErrorProvider;
   System::Windows::Forms::ErrorProvider^ favoriteColorErrorProvider;

public:
   Form1()
   {
      this->nameTextBox1 = gcnew System::Windows::Forms::TextBox;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->label2 = gcnew System::Windows::Forms::Label;
      this->ageUpDownPicker = gcnew System::Windows::Forms::NumericUpDown;
      this->favoriteColorComboBox = gcnew System::Windows::Forms::ComboBox;
      this->label3 = gcnew System::Windows::Forms::Label;
      this->label4 = gcnew System::Windows::Forms::Label;
      this->label5 = gcnew System::Windows::Forms::Label;
      this->label6 = gcnew System::Windows::Forms::Label;
      
      // Name Label
      this->label1->Location = System::Drawing::Point( 56, 32 );
      this->label1->Size = System::Drawing::Size( 40, 23 );
      this->label1->Text = "Name:";
      
      // Age Label
      this->label2->Location = System::Drawing::Point( 40, 64 );
      this->label2->Size = System::Drawing::Size( 56, 23 );
      this->label2->Text = "Age (3-5)";
      
      // Favorite Color Label
      this->label3->Location = System::Drawing::Point( 24, 96 );
      this->label3->Size = System::Drawing::Size( 80, 24 );
      this->label3->Text = "Favorite color";
      
      // ErrorBlinkStyle::AlwaysBlink Label
      this->label4->Location = System::Drawing::Point( 264, 32 );
      this->label4->Size = System::Drawing::Size( 160, 23 );
      this->label4->Text = "ErrorBlinkStyle::AlwaysBlink";
      
      // ErrorBlinkStyle::BlinkIfDifferentError Label
      this->label5->Location = System::Drawing::Point( 264, 64 );
      this->label5->Size = System::Drawing::Size( 200, 23 );
      this->label5->Text = "ErrorBlinkStyle::BlinkIfDifferentError";
      
      // ErrorBlinkStyle::NeverBlink Label
      this->label6->Location = System::Drawing::Point( 264, 96 );
      this->label6->Size = System::Drawing::Size( 200, 23 );
      this->label6->Text = "ErrorBlinkStyle::NeverBlink";
      
      // Name TextBox
      this->nameTextBox1->Location = System::Drawing::Point( 112, 32 );
      this->nameTextBox1->Size = System::Drawing::Size( 120, 20 );
      this->nameTextBox1->TabIndex = 0;
      this->nameTextBox1->Validated += gcnew System::EventHandler( this, &Form1::nameTextBox1_Validated );
      
      // Age NumericUpDown
      this->ageUpDownPicker->Location = System::Drawing::Point( 112, 64 );
      array<int>^temp0 = {150,0,0,0};
      this->ageUpDownPicker->Maximum = System::Decimal( temp0 );
      this->ageUpDownPicker->TabIndex = 4;
      this->ageUpDownPicker->Validated += gcnew System::EventHandler( this, &Form1::ageUpDownPicker_Validated );
      
      // Favorite Color ComboBox
      array<Object^>^temp1 = {"None","Red","Yellow","Green","Blue","Purple"};
      this->favoriteColorComboBox->Items->AddRange( temp1 );
      this->favoriteColorComboBox->Location = System::Drawing::Point( 112, 96 );
      this->favoriteColorComboBox->Size = System::Drawing::Size( 120, 21 );
      this->favoriteColorComboBox->TabIndex = 5;
      this->favoriteColorComboBox->Validated += gcnew System::EventHandler( this, &Form1::favoriteColorComboBox_Validated );
      
      // Set up how the form should be displayed and add the controls to the form.
      this->ClientSize = System::Drawing::Size( 464, 150 );
      array<System::Windows::Forms::Control^>^temp2 = {this->label6,this->label5,this->label4,this->label3,this->favoriteColorComboBox,this->ageUpDownPicker,this->label2,this->label1,this->nameTextBox1};
      this->Controls->AddRange( temp2 );
      this->Text = "Error Provider Example";
      
      //<Snippet2>
      // Create and set the ErrorProvider for each data entry control.
      nameErrorProvider = gcnew System::Windows::Forms::ErrorProvider;
      nameErrorProvider->SetIconAlignment( this->nameTextBox1, ErrorIconAlignment::MiddleRight );
      nameErrorProvider->SetIconPadding( this->nameTextBox1, 2 );
      nameErrorProvider->BlinkRate = 1000;
      nameErrorProvider->BlinkStyle = System::Windows::Forms::ErrorBlinkStyle::AlwaysBlink;
      ageErrorProvider = gcnew System::Windows::Forms::ErrorProvider;
      ageErrorProvider->SetIconAlignment( this->ageUpDownPicker, ErrorIconAlignment::MiddleRight );
      ageErrorProvider->SetIconPadding( this->ageUpDownPicker, 2 );
      ageErrorProvider->BlinkStyle = System::Windows::Forms::ErrorBlinkStyle::BlinkIfDifferentError;
      favoriteColorErrorProvider = gcnew System::Windows::Forms::ErrorProvider;
      favoriteColorErrorProvider->SetIconAlignment( this->favoriteColorComboBox, ErrorIconAlignment::MiddleRight );
      favoriteColorErrorProvider->SetIconPadding( this->favoriteColorComboBox, 2 );
      favoriteColorErrorProvider->BlinkRate = 1000;
      favoriteColorErrorProvider->BlinkStyle = System::Windows::Forms::ErrorBlinkStyle::NeverBlink;
      //</Snippet2>
   }


private:

   //<Snippet3>
   void nameTextBox1_Validated( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( IsNameValid() )
      {
         
         // Clear the error, if any, in the error provider.
         nameErrorProvider->SetError( this->nameTextBox1, String.Empty );
      }
      else
      {
         
         // Set the error if the name is not valid.
         nameErrorProvider->SetError( this->nameTextBox1, "Name is required." );
      }
   }

   void ageUpDownPicker_Validated( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( IsAgeTooYoung() )
      {
         
         // Set the error if the age is too young.
         ageErrorProvider->SetError( this->ageUpDownPicker, "Age not old enough" );
      }
      else
      if ( IsAgeTooOld() )
      {
         
         // Set the error if the age is too old.
         ageErrorProvider->SetError( this->ageUpDownPicker, "Age is too old" );
      }
      else
      {
         
         // Clear the error, if any, in the error provider.
         ageErrorProvider->SetError( this->ageUpDownPicker, String.Empty );
      }
   }

   void favoriteColorComboBox_Validated( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if (  !IsColorValid() )
      {
         
         // Set the error if the favorite color is not valid.
         favoriteColorErrorProvider->SetError( this->favoriteColorComboBox, "Must select a color." );
      }
      else
      {
         
         // Clear the error, if any, in the error provider.
         favoriteColorErrorProvider->SetError( this->favoriteColorComboBox, String.Empty );
      }
   }


   //</Snippet3>
   // Functions to verify data.
   bool IsNameValid()
   {
      
      // Determine whether the text box contains a zero-length String*.
      return (nameTextBox1->Text->Length > 0);
   }

   bool IsAgeTooYoung()
   {
      
      // Determine whether the age value is less than three.
      return (ageUpDownPicker->Value < 3);
   }

   bool IsAgeTooOld()
   {
      
      // Determine whether the age value is greater than five.
      return (ageUpDownPicker->Value > 5);
   }

   bool IsColorValid()
   {
      
      // Determine whether the favorite color has a valid value.
      return ((favoriteColorComboBox->SelectedItem != 0) && ( !favoriteColorComboBox->SelectedItem->Equals( "None" )));
   }

};


[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
