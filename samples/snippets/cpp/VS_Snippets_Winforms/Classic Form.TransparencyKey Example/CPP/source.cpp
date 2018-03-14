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
   void InitializeMyForm()
   {
      this->BackColor = Color::Red;
      // Make the background color of form display transparently.
      this->TransparencyKey = BackColor;
   }
   // </Snippet1>
};
