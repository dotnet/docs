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
   void PrintCompanyName()
   {
      textBox1->Text = String::Format( "The company name is: {0}",
         Application::CompanyName );
   }
   // </Snippet1>
};
