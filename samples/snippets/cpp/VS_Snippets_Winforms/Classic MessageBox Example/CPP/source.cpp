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
   void Form1_FormClosing(Object^ sender, FormClosingEventArgs^ e)
   {
	  // If the no button was pressed ...
      if ((MessageBox::Show(
         "Are you sure that you would like to close the form?", 
         "Form Closing", MessageBoxButtons::YesNo, 
         MessageBoxIcon::Question) == DialogResult::No))
      {
		 // cancel the closure of the form.
         e->Cancel = true;
      }
   }

   // </Snippet1>
};
