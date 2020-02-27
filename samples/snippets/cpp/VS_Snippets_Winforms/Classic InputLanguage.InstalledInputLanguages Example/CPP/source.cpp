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
};
