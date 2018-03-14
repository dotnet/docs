#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   FontDialog^ fontDialog1;

   // <Snippet1>
private:
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      fontDialog1->ShowColor = true;

      fontDialog1->Font = textBox1->Font;
      fontDialog1->Color = textBox1->ForeColor;

      if ( fontDialog1->ShowDialog() != ::DialogResult::Cancel )
      {
         textBox1->Font = fontDialog1->Font;
         textBox1->ForeColor = fontDialog1->Color;
      }
   }
   // </Snippet1>
};
