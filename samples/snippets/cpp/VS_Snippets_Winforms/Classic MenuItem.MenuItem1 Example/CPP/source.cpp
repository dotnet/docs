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
   MenuItem^ menuItem1;

   // <Snippet1>
public:
   void CreateMyMenus()
   {
      // Create an instance of a MenuItem with a specified caption.
      menuItem1 = gcnew MenuItem( "&File" );
   }
   // </Snippet1>
};
