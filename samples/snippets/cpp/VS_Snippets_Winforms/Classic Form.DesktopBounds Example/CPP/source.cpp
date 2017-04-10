#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
   // <Snippet1>
public:
   void MoveMyForm()
   {
      // Create a Rectangle object that will be used as the bound of the form.
      Rectangle tempRect = Rectangle( 50, 50, 100, 100 );
      // Set the bounds of the form using the Rectangle object.
      this->DesktopBounds = tempRect;
   }
   // </Snippet1>
};
