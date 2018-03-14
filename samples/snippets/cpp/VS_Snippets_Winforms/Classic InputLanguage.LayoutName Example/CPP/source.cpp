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
   void MyLayoutName()
   {
      // Gets the current input language.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;

      if ( myCurrentLanguage != nullptr )
      {
         textBox1->Text = String::Format( "Layout: {0}", myCurrentLanguage->LayoutName );
      }
      else
      {
         textBox1->Text = "There is no current language";
      }
   }
   // </Snippet1>
};
