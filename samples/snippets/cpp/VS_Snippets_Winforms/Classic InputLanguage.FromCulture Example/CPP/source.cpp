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
   void SetNewCurrentLanguage()
   {
      // Gets the default, and current languages.
      InputLanguage^ myDefaultLanguage = InputLanguage::DefaultInputLanguage;
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      textBox1->Text = String::Format( "{0}Current input language is: {1}\n",
         myCurrentLanguage->Culture->EnglishName, myDefaultLanguage->Culture->EnglishName );
      
      //Print the new current input language.
      InputLanguage^ myCurrentLanguage2 = InputLanguage::CurrentInputLanguage;
      textBox1->Text = String::Format( "{0}New current input language is: {1}",
         textBox1->Text, myCurrentLanguage2->Culture->EnglishName );
   }
   // </Snippet1>
};
