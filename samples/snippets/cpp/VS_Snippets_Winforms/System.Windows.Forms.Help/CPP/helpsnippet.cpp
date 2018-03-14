

//<Snippet1>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class Form1: public System::Windows::Forms::Form
{
private:
   String^ helpfile;
   System::Windows::Forms::Button^ showIndex;
   System::Windows::Forms::Button^ showHelp;
   System::Windows::Forms::Label ^ label1;
   System::Windows::Forms::ComboBox^ navigatorCombo;
   System::Windows::Forms::Button^ showKeyword;
   System::Windows::Forms::TextBox^ keyword;
   System::Windows::Forms::Label ^ label2;
   System::Windows::Forms::Label ^ label3;
   System::Windows::Forms::TextBox^ parameterTextBox;

public:
   Form1()
   {
      helpfile = "mspaint.chm";
      this->showIndex = gcnew System::Windows::Forms::Button;
      this->showHelp = gcnew System::Windows::Forms::Button;
      this->navigatorCombo = gcnew System::Windows::Forms::ComboBox;
      this->label1 = gcnew System::Windows::Forms::Label;
      this->showKeyword = gcnew System::Windows::Forms::Button;
      this->keyword = gcnew System::Windows::Forms::TextBox;
      this->label2 = gcnew System::Windows::Forms::Label;
      this->label3 = gcnew System::Windows::Forms::Label;
      this->parameterTextBox = gcnew System::Windows::Forms::TextBox;
      
      // Help Navigator Label
      this->label1->Location = System::Drawing::Point( 112, 64 );
      this->label1->Size = System::Drawing::Size( 168, 16 );
      this->label1->Text = "Help Navigator:";
      
      // Keyword Label 
      this->label2->Location = System::Drawing::Point( 120, 184 );
      this->label2->Size = System::Drawing::Size( 100, 16 );
      this->label2->Text = "Keyword:";
      
      // Parameter Label
      this->label3->Location = System::Drawing::Point( 112, 120 );
      this->label3->Size = System::Drawing::Size( 168, 16 );
      this->label3->Text = "Parameter:";
      
      // Show Index Button
      this->showIndex->Location = System::Drawing::Point( 16, 16 );
      this->showIndex->Size = System::Drawing::Size( 264, 32 );
      this->showIndex->TabIndex = 0;
      this->showIndex->Text = "Show Help Index";
      this->showIndex->Click += gcnew System::EventHandler( this, &Form1::showIndex_Click );
      
      // Show Help Button
      this->showHelp->Location = System::Drawing::Point( 16, 80 );
      this->showHelp->Size = System::Drawing::Size( 80, 80 );
      this->showHelp->TabIndex = 1;
      this->showHelp->Text = "Show Help";
      this->showHelp->Click += gcnew System::EventHandler( this, &Form1::showHelp_Click );
      
      // Show Keyword Button
      this->showKeyword->Location = System::Drawing::Point( 16, 192 );
      this->showKeyword->Size = System::Drawing::Size( 88, 32 );
      this->showKeyword->TabIndex = 4;
      this->showKeyword->Text = "Show Keyword";
      this->showKeyword->Click += gcnew System::EventHandler( this, &Form1::showKeyword_Click );
      
      // Help Navigator ComboBox
      this->navigatorCombo->DropDownStyle = System::Windows::Forms::ComboBoxStyle::DropDownList;
      this->navigatorCombo->Location = System::Drawing::Point( 112, 80 );
      this->navigatorCombo->Size = System::Drawing::Size( 168, 21 );
      this->navigatorCombo->TabIndex = 2;
      
      // Keyword TextBox
      this->keyword->Location = System::Drawing::Point( 120, 200 );
      this->keyword->Size = System::Drawing::Size( 160, 20 );
      this->keyword->TabIndex = 5;
      this->keyword->Text = "";
      
      // Parameter TextBox
      this->parameterTextBox->Location = System::Drawing::Point( 112, 136 );
      this->parameterTextBox->Size = System::Drawing::Size( 168, 20 );
      this->parameterTextBox->TabIndex = 8;
      this->parameterTextBox->Text = "";
      
      // Set up how the form should be displayed and add the controls to the form.
      this->ClientSize = System::Drawing::Size( 292, 266 );
      array<System::Windows::Forms::Control^>^formControls = {this->parameterTextBox,this->label3,this->label2,this->keyword,this->showKeyword,this->label1,this->navigatorCombo,this->showHelp,this->showIndex};
      this->Controls->AddRange( formControls );
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
      this->Text = "Help App";
      
      //<Snippet5>
      // Load the various values of the HelpNavigator enumeration
      // into the combo box.
      TypeConverter^ converter;
      converter = TypeDescriptor::GetConverter( HelpNavigator::typeid );
      System::Collections::IEnumerator^ myEnum = converter->GetStandardValues()->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         Object^ value = safe_cast<Object^>(myEnum->Current);
         navigatorCombo->Items->Add( value );
      }
      //</Snippet5>
   }

   //<Snippet2>
private:
   void showIndex_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display the index for the help file.
      Help::ShowHelpIndex( this, helpfile );
   }
   //</Snippet2>

   //<Snippet3>
   void showHelp_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display Help using the Help navigator enumeration
      // that is selected in the combo box. Some enumeration
      // values make use of an extra parameter, which can
      // be passed in through the Parameter text box.
      HelpNavigator navigator = HelpNavigator::TableOfContents;
      if ( navigatorCombo->SelectedItem != nullptr )
      {
         navigator =  *safe_cast<HelpNavigator^>(navigatorCombo->SelectedItem);
      }

      Help::ShowHelp( this, helpfile, navigator, parameterTextBox->Text );
   }
   //</Snippet3>

   //<Snippet4>
   void showKeyword_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Display help using the provided keyword.
      Help::ShowHelp( this, helpfile, keyword->Text );
   }
   //</Snippet4>
};

[STAThread]
int main()
{
   Application::Run( gcnew Form1 );
}
//</Snippet1>
