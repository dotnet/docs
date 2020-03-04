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
   Button^ button2;
   int myVar;

   // <Snippet1>
private:
   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // If myVar is an even number, click Button2.
      if ( myVar % 2 == 0 )
      {
         button2->PerformClick();
         // Display the status of Button2's Click event.
         MessageBox::Show( "button2 was clicked " );
      }
      else
      {
         // Display the status of Button2's Click event.
         MessageBox::Show( "button2 was NOT clicked" );
      }
      // Increment myVar.   
      myVar++;
   }
   // </Snippet1>
};
