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
   void PrintProductName()
   {
      textBox1->Text = "The product name is: {0}",
         Application::ProductName;
   }
   // </Snippet1>
};
