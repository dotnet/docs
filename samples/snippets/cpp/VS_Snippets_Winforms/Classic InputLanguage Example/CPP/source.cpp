#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
public:
   void GetLanguages()
   {
      // Gets the list of installed languages.
      for each ( InputLanguage^ lang in InputLanguage::InstalledInputLanguages )
      {
         textBox1->Text = String::Concat( textBox1->Text, lang->Culture->EnglishName, "\n" );
      }
   }
   // </Snippet1>

   // <Snippet2>
public:
   void SetNewCurrentLanguage()
   {
      
      // Gets the default, and current languages.
      InputLanguage^ myDefaultLanguage = InputLanguage::DefaultInputLanguage;
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      textBox1->Text = String::Format( "Current input language is: {0}\nDefault input language is: {1}\n",
         myCurrentLanguage->Culture->EnglishName, myDefaultLanguage->Culture->EnglishName );
      
      // Changes the current input language to the default, and prints the new current language.
      InputLanguage::CurrentInputLanguage = myDefaultLanguage;
      textBox1->Text = String::Format( "{0}Current input language is now: {1}",
         textBox1->Text, myDefaultLanguage->Culture->EnglishName );
   }
   // </Snippet2>
};
