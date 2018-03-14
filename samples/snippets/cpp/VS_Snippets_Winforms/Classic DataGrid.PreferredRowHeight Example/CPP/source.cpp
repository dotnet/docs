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
   void ChangeFontHeight( DataGrid^ myGrid )
   {
      myGrid->Font = gcnew System::Drawing::Font(
         "Microsoft Sans Serif",
         15, System::Drawing::FontStyle::Regular );
      myGrid->PreferredRowHeight = myGrid->Font->Height;
   }
   // </Snippet1>
};
