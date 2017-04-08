#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
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

private:

   // <Snippet1>
   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      
      // Create an instance of the ListBox.
      ListBox^ listBox1 = gcnew ListBox;
      
      // Set the size and location of the ListBox.
      listBox1->Size = System::Drawing::Size( 200, 100 );
      listBox1->Location = System::Drawing::Point( 10, 10 );
      
      // Add the ListBox to the form.
      this->Controls->Add( listBox1 );
      
      // Set the ListBox to display items in multiple columns.
      listBox1->MultiColumn = true;
      
      // Set the selection mode to multiple and extended.
      listBox1->SelectionMode = SelectionMode::MultiExtended;
      
      // Shutdown the painting of the ListBox as items are added.
      listBox1->BeginUpdate();
      
      // Loop through and add 50 items to the ListBox.
      for ( int x = 1; x <= 50; x++ )
      {
         listBox1->Items->Add( String::Format( "Item {0}", x ) );

      }
      listBox1->EndUpdate();
      
      // Select three items from the ListBox.
      listBox1->SetSelected( 1, true );
      listBox1->SetSelected( 3, true );
      listBox1->SetSelected( 5, true );
      
      #if defined(DEBUG)
      // Display the second selected item in the ListBox to the console.
      System::Diagnostics::Debug::WriteLine( listBox1->SelectedItems[ 1 ] );
      
      // Display the index of the first selected item in the ListBox.
      System::Diagnostics::Debug::WriteLine( listBox1->SelectedIndices[ 0 ] );
      #endif
   }

   // </Snippet1>
};
