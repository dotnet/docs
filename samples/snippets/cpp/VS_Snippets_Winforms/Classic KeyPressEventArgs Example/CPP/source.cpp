#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

// <Snippet1>
public ref class myKeyPressClass
{
private:
   static long keyPressCount = 0;
   static long backspacePressed = 0;
   static long returnPressed = 0;
   static long escPressed = 0;
   TextBox^ textBox1;
   void myKeyCounter( Object^ sender, KeyPressEventArgs^ ex )
   {
      switch ( ex->KeyChar )
      {
            // Counts the backspaces.
         case '\b':
         backspacePressed = backspacePressed + 1;
         break;

            // Counts the ENTER keys.
         case '\r':
         returnPressed = returnPressed + 1;
         break;

            // Counts the ESC keys.  
         case (char)27:
         escPressed = escPressed + 1;
         break;
            
            // Counts all other keys.
         default:
         keyPressCount = keyPressCount + 1;
         break;
      }
      textBox1->Text = String::Concat( 
         backspacePressed, " backspaces pressed\r\n",
         escPressed, " escapes pressed\r\n",
         returnPressed, " returns pressed\r\n",
         keyPressCount, " other keys pressed\r\n" );
      ex->Handled = true;
   }
};
// </Snippet1>
