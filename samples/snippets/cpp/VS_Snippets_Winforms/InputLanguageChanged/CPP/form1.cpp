

//<Snippet1>
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
public ref class Form1: public System::Windows::Forms::Form
{
private:
   RichTextBox^ rtb;

public:
   Form1()
   {
      rtb = gcnew RichTextBox;
      this->Controls->Add( rtb );
      rtb->Dock = DockStyle::Fill;
      this->InputLanguageChanged += gcnew InputLanguageChangedEventHandler( this, &Form1::languageChange );
   }


private:
   void languageChange( Object^ /*sender*/, InputLanguageChangedEventArgs^ e )
   {
      
      // If the input language is Japanese.
      // set the initial IMEMode to Katakana.
      if ( e->InputLanguage->Culture->TwoLetterISOLanguageName->Equals( "ja" ) )
      {
         rtb->ImeMode = System::Windows::Forms::ImeMode::Katakana;
      }
   }

};

int main()
{
   Application::Run( gcnew Form1 );
}

//</Snippet1>
