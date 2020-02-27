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
   void PrintStartupPath()
   {
      textBox1->Text = String::Concat( "The path for the executable file",
        " that started the application is: ", Application::StartupPath );
   }
   // </Snippet1>
};
