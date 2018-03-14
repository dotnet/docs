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
   void CreateMyBorderlessWindow()
   {
      this->FormBorderStyle = ::FormBorderStyle::None;
      this->MaximizeBox = false;
      this->MinimizeBox = false;
      this->StartPosition = FormStartPosition::CenterScreen;
      // Remove the control box so the form will only display client area.
      this->ControlBox = false;
   }
   // </Snippet1>
};
