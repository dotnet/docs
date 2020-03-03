

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
   void PrintIndexItem()
   {
      
      // Creates a new collection and assigns it the events for button1.
      EventDescriptorCollection^ events = TypeDescriptor::GetEvents( button1 );
      
      // Prints the second event's name.
      textBox1->Text = events[ 1 ]->ToString();
   }
   // </Snippet1>
};
