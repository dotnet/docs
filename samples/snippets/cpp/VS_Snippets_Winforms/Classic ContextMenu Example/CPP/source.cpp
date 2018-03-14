#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Data.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Data;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Drawing;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   TextBox^ pictureBox1;
   System::Windows::Forms::ContextMenu^ contextMenu1;

   // <Snippet1>
private:
   void MyPopupEventHandler( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Define the MenuItem objects to display for the TextBox.
      MenuItem^ menuItem1 = gcnew MenuItem( "&Copy" );
      MenuItem^ menuItem2 = gcnew MenuItem( "&Find and Replace" );
      // Define the MenuItem object to display for the PictureBox.
      MenuItem^ menuItem3 = gcnew MenuItem( "C&hange Picture" );
      
      // Clear all previously added MenuItems.
      contextMenu1->MenuItems->Clear();

      if ( contextMenu1->SourceControl == textBox1 )
      {
         
         // Add MenuItems to display for the TextBox.
         contextMenu1->MenuItems->Add( menuItem1 );
         contextMenu1->MenuItems->Add( menuItem2 );
      }
      else if ( contextMenu1->SourceControl == pictureBox1 )
      {
         // Add the MenuItem to display for the PictureBox.
         contextMenu1->MenuItems->Add( menuItem3 );
      }
   }
   // </Snippet1>
};
