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
   void PrintCurrentCulture()
   {
      textBox1->Text = "The current culture is: {0}",
         Application::CurrentCulture->EnglishName;
   }
   // </Snippet1>
};
