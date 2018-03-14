

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
   MainMenu^ mainMenu1;

public:

   // <Snippet1>
   void CloneMyMenu()
   {
      // Determine if mainMenu1 is currently hosted on the form.
      if ( mainMenu1->GetForm() != nullptr )
      {
         // Create a copy of the MainMenu that is hosted on the form.
         MainMenu^ mainMenu2 = mainMenu1->CloneMenu();

         // Set the RightToLeft property for mainMenu2.
         mainMenu2->RightToLeft = ::RightToLeft::Yes;
      }
   }
   // </Snippet1>
};
