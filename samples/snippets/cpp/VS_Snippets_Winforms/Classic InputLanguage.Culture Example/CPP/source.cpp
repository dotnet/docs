#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Globalization;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
public:
   void MyCulture()
   {
      // Gets the current input language.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      
      // Gets the culture for the language  and prints it.
      CultureInfo^ myCultureInfo = myCurrentLanguage->Culture;
      textBox1->Text = myCultureInfo->EnglishName;
   }
   // </Snippet1>
};
