#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   MonthCalendar^ monthCalendar1;
   TextBox^ textBox1;
   TextBox^ textBox2;

   // <Snippet1>
private:
   void button1_Click( Object^ sender, EventArgs^ e )
   {
      // Set the SelectionRange with start and end dates from text boxes.
      try
      {
         monthCalendar1->SelectionRange = gcnew SelectionRange(
            DateTime::Parse( textBox1->Text ),
            DateTime::Parse( textBox2->Text ) );
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( ex->Message );
      }
   }
   // </Snippet1>
};
