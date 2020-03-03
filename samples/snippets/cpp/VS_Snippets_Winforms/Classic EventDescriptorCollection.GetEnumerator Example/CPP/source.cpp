#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.dll>

using namespace System;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
protected:
   TextBox^ textBox1;
   Button^ button1;

   // <Snippet1>
private:
   void MyEnumerator()
   {
      // Creates a new collection, and assigns to it the events for button1.
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );
      
      // Creates an enumerator.
      IEnumerator^ ie = events->GetEnumerator();
      
      // Prints the name of each event in the collection.
      Object^ myEvent;
      while ( ie->MoveNext() == true )
      {
         myEvent = ie->Current;
         textBox1->Text = String::Concat( textBox1->Text, myEvent, "\n" );
      }
   }
   // </Snippet1>
};
