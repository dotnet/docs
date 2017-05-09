#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   void RemoveThirdBinding()
   {
      if ( textBox1->DataBindings->Count < 3 )
      {
         return;
      }
      textBox1->DataBindings->RemoveAt( 2 );
   }
   // </Snippet1>
};
