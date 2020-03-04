

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
   void PrintIndexItem2()
   {
      
      // Creates a new collection and assigns it the events for button1.
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );
      
      // Sets an EventDescriptor to the specific event.
      EventDescriptor^ myEvent = events[ "KeyDown" ];
      
      // Prints the name of the event.
      textBox1->Text = myEvent->Name;
   }
   // </Snippet1>
};
