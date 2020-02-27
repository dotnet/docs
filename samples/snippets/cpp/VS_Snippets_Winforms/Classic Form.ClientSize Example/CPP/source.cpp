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
   Button^ button1;

   // <Snippet1>
private:
   void MyForm_Resize( Object^ sender, EventHandler^ e )
   {
      // Set the size of button1 to the size of the client area of the form.
      button1->Size = this->ClientSize;
   }
   // </Snippet1>
};
