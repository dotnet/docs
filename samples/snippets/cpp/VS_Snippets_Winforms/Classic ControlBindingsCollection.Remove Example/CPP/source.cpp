

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;
public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

private:

   // <Snippet1>
   void RemoveBackColorBinding()
   {
      Binding^ colorBinding = textBox1->DataBindings[ "BackColor" ];
      textBox1->DataBindings->Remove( colorBinding );
   }

   // </Snippet1>
};
