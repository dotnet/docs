

#using <System.Xml.dll>
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
   void EditCol( CurrencyManager^ cm, int rowNum, Rectangle cellRect, bool readOnly, String^ myString, bool isVisible )
   {
      this->Edit( cm, rowNum, cellRect, readOnly, myString, isVisible );
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;
   DataSet^ myDataSet;
private:
   void dataGrid1_MouseDown( Object^ sender, MouseEventArgs^ e )
   {
      
      // Use the HitTest method to get a HitTestInfo object.
      DataGrid::HitTestInfo ^ hi;
      DataGrid^ grid = dynamic_cast<DataGrid^>(sender);
      hi = grid->HitTest( e->X, e->Y );
      
      // Test if the clicked area was a cell.
      if ( hi->Type == DataGrid::HitTestType::Cell )
      {
         
         // If it's a cell, get the GridTable and CurrencyManager of the
         // clicked table.         
         DataGridTableStyle^ dgt = dataGrid1->TableStyles[ 0 ];
         CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(this->BindingContext[ myDataSet->Tables[ dgt->MappingName ] ]);
         
         // Get the Rectangle of the clicked cell.
         Rectangle cellRect = grid->GetCellBounds( hi->Row, hi->Column );
         
         // Get the clicked DataGridTextBoxColumn.
         MyGridColumn^ gridCol = dynamic_cast<MyGridColumn^>(dgt->GridColumnStyles[ hi->Column ]);
         
         // Edit the value.
         gridCol->EditCol( cm, hi->Row, cellRect, false, "New Text", true );
      }
   }

};
// </Snippet1>
