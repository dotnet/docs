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

   // <Snippet1>
public:
   void CreateMyMenuItem()
   {
      // Create an instance of MenuItem with caption and an event handler
      MenuItem^ menuItem1 = gcnew MenuItem( "&New",gcnew System::EventHandler(
         this, &Form1::MenuItem1_Click ) );
   }

private:
   // This method is an event handler for menuItem1 to use when connecting its event handler.
   void MenuItem1_Click( Object^ sender, System::EventArgs^ e )
   {
      // Code goes here that handles the Click event.
   }
   // </Snippet1>
};
