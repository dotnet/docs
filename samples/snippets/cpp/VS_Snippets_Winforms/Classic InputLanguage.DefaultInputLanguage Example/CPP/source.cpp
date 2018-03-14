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
   void MyDefaultInputLanguage()
   {
      // Gets the default input language  and prints it in a text box.
      InputLanguage^ myDefaultLanguage = InputLanguage::DefaultInputLanguage;
      textBox1->Text = String::Format( "Default input language is: {0}",
         myDefaultLanguage->Culture->EnglishName );
   }
   // </Snippet1>
};
