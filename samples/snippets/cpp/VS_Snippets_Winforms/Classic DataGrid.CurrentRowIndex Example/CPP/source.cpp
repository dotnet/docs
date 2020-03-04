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
   void GetSelectedIndex( DataGrid^ myGrid )
   {
      Console::WriteLine( myGrid->CurrentRowIndex );
   }

   void SetSelectedIndex( DataGrid^ myGrid, int selIndex )
   {
      myGrid->CurrentRowIndex = selIndex;
   }
   // </Snippet1>
};
