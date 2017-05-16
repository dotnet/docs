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

   // <Snippet1>
private:
   bool flag;

private:
   void MyTextChangedHandler( System::Object^ sender, System::EventArgs^ e )
   {
      Int64 val;
      // Check the flag to prevent code re-entry. 
      if ( flag == false )
      {
         // Set the flag to True to prevent re-entry of the code below.
         flag = true;
         // Determine if the text of the control is a number.
         try
         {
            // Attempt to convert to long
            val = System::Convert::ToInt64( textBox1->Text );
         }
         catch ( Exception^ ) 
         {
            // Display a message box and clear the contents if not a number.
            MessageBox::Show( "The text is not a valid number. Please re-enter" );
            // Clear the contents of the text box to allow re-entry.
            textBox1->Clear();
         }
         // Reset the flag so other TextChanged events are processed correctly.
         flag = false;
      }
   }
   // </Snippet1>
};
