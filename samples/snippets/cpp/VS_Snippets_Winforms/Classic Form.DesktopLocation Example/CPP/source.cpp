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
      // Create a Point object that will be used as the location of the form.
      Point tempPoint = Point( 100, 100 );
      // Set the location of the form using the Point object.
      this->DesktopLocation = tempPoint;
   }
   // </Snippet1>
};
