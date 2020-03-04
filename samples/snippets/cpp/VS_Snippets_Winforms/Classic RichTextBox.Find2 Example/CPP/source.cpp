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
   int FindMyText( String^ text, int start )
   {
      // Initialize the return value to false by default.
      int returnValue = -1;
      
      // Ensure that a search string has been specified and a valid start point.
      if ( text->Length > 0 && start >= 0 )
      {
         // Obtain the location of the search string in richTextBox1.
         int indexToText = richTextBox1->Find( text, start, RichTextBoxFinds::MatchCase );
         // Determine whether the text was found in richTextBox1.
         if ( indexToText >= 0 )
         {
            returnValue = indexToText;
         }
      }

      return returnValue;
   }
   // </Snippet1>
};
