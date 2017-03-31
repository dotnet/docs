

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
   ListBox^ listBox1;

public:

   // <Snippet1>
   void AddToMyListBox()
   {
      // Stop the ListBox from drawing while items are added.
      listBox1->BeginUpdate();

      // Loop through and add five thousand new items.
      for ( int x = 1; x < 5000; x++ )
      {
         listBox1->Items->Add( String::Format( "Item {0}", x ) );
      }
      listBox1->EndUpdate();
   }
   // </Snippet1>
};
