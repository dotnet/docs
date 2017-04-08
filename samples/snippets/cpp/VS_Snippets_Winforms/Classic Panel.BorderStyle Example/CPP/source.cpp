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
   void CreateMyPanel()
   {
      Panel^ panel1 = gcnew Panel;
      
      // Initialize the Panel control.
      panel1->Location = Point(56,72);
      panel1->Size = System::Drawing::Size( 264, 152 );
      // Set the Borderstyle for the Panel to three-dimensional.
      panel1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
   }
   // </Snippet1>
};
