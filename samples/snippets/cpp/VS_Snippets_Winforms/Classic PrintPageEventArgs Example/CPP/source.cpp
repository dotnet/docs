#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Drawing::Printing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;

   // <Snippet1>
private:
   // Specifies what happens when the user clicks the Button.
   void printButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         pd->Print();
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( "An error occurred while printing", ex->ToString() );
      }
   }

   // Specifies what happens when the PrintPage event is raised.
   void pd_PrintPage( Object^ /*sender*/, PrintPageEventArgs^ ev )
   {
      // Draw a picture.
      ev->Graphics->DrawImage( Image::FromFile( "C:\\My Folder\\MyFile.bmp" ),
         ev->Graphics->VisibleClipBounds );
      
      // Indicate that this is the last page to print.
      ev->HasMorePages = false;
   }
   // </Snippet1>
};
