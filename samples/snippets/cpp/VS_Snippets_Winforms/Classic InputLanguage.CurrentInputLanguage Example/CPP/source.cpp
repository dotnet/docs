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
   void MyCurrentInputLanguage()
   {
      // Gets the current input language  and prints it in a text box.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      textBox1->Text = String::Format( "Current input language is: {0}",
         myCurrentLanguage->Culture->EnglishName );
   }
   // </Snippet1>
};
