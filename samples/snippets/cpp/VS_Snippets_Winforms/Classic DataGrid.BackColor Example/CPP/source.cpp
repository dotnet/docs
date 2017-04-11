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
protected:
   DataGrid^ dataGrid1;

   // <Snippet1>
private:
   void SetBackColorAndBackgroundColor()
   {
      // Set the BackColor and BackgroundColor properties.
      dataGrid1->BackColor = System::Drawing::Color::Blue;
      dataGrid1->BackgroundColor = System::Drawing::Color::Red;
   }
   // </Snippet1>
};
