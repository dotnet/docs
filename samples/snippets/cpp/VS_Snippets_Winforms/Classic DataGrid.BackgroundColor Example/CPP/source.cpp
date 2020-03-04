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
   void SetGridColors()
   {
      dataGrid1->BackColor = System::Drawing::Color::Red;
      dataGrid1->AlternatingBackColor = System::Drawing::Color::AliceBlue;
      dataGrid1->BackgroundColor = System::Drawing::Color::Yellow;
   }
   // </Snippet1>
};
