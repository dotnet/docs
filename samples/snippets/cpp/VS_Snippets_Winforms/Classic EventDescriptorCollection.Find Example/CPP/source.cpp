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
   TextBox^ textBox1;
   Button^ button1;

   // <Snippet1>
private:
   void FindEvent()
   {
      // Creates a new collection and assigns it the events for button1.
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );
      
      // Sets an EventDescriptor to the specific event.
      EventDescriptor^ myEvent = events->Find( "Resize", false );
      
      // Prints the event name and event description.
      textBox1->Text = String::Concat( myEvent->Name, ": ", myEvent->Description );
   }
   // </Snippet1>
};
