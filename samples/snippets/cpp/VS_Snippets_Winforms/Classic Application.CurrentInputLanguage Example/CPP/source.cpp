#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   ListBox^ textBox1;

   // <Snippet1>
private:
   void PrintCurrentInputLanguage()
   {
      textBox1->Text = "The current input language is: {0}",
         Application::CurrentInputLanguage->Culture->EnglishName;
   }
   // </Snippet1>
};
