

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// <Snippet1>
public ref class MyGridColumn: public DataGridBoolColumn
{
public:
   int GetMinHeight()
   {
      return this->GetMinimumHeight();
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:
   void GetHeight()
   {
      MyGridColumn^ myGridColumn = dynamic_cast<MyGridColumn^>(dataGrid1->TableStyles[ 1 ]->GridColumnStyles[ 0 ]);
      Console::WriteLine( myGridColumn->GetMinHeight() );
   }

};

// </Snippet1>
