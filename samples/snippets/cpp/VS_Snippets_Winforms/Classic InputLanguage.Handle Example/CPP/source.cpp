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
   void MyHandle()
   {
      // Gets the current input language.
      InputLanguage^ myCurrentLanguage = InputLanguage::CurrentInputLanguage;
      
      // Gets a handle for the language and prints the number.
      IntPtr myHandle = myCurrentLanguage->Handle;
      textBox1->Text = String::Format( "The handle number is: {0}", myHandle );
   }
   // </Snippet1>
};
