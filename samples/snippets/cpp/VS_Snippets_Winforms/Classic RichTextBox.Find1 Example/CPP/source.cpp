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
   RichTextBox^ richTextBox1;

   // <Snippet1>
public:
   bool FindMyText( String^ text )
   {
      // Initialize the return value to false by default.
      bool returnValue = false;
      
      // Ensure a search string has been specified.
      if ( text->Length > 0 )
      {
         // Obtain the location of the search string in richTextBox1.
         int indexToText = richTextBox1->Find( text, RichTextBoxFinds::MatchCase );
         // Determine if the text was found in richTextBox1.
         if ( indexToText >= 0 )
         {
            returnValue = true;
         }
      }

      return returnValue;
   }
   // </Snippet1>
};
