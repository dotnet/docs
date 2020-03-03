

#using <System.dll>
#using <System.Windows.Forms.dll>
#using <System.Drawing.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

// <Snippet1>
public ref class MyGridColumn: public DataGridTextBoxColumn
{
public:
   int GetPrefHeight( Graphics^ g, String^ val )
   {
      return this->GetPreferredHeight( g, val );
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;

private:
   void GetPreferredHeight()
   {
      Graphics^ g;
      g = this->CreateGraphics();
      int gridPreferredHeight;
      MyGridColumn^ myTextColumn;
      
      // Assuming column 1 of a DataGrid control is a 
      // DataGridTextBoxColumn.
      myTextColumn = dynamic_cast<MyGridColumn^>(dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ 1 ]);
      String^ myVal;
      myVal = "A long string value";
      gridPreferredHeight = myTextColumn->GetPrefHeight( g, myVal );
      Console::WriteLine( gridPreferredHeight );
   }

};
// </Snippet1>
