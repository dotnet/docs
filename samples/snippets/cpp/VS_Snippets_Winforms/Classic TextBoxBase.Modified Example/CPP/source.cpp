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
   String^ originalText;

   // <Snippet1>
private:
   void TextBox1_TextChanged( Object^ sender, EventArgs^ e )
   {
      /* Check to see if the change made does not return the
         control to its original state. */
      if ( originalText != textBox1->Text )
      {
         // Set the Modified property to true to reflect the change.
         textBox1->Modified = true;
      }
      else
      {
         // Contents of textBox1 have not changed, reset the Modified property.
         textBox1->Modified = false;
      }
   }
   // </Snippet1>
};
