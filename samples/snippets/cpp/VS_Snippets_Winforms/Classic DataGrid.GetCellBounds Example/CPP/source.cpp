

#using <System.Xml.dll>
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
   DataSet^ myDataSet;

   // <Snippet1>
private:
   void dataGrid1_MouseDown( Object^ sender, MouseEventArgs^ e )
   {
      
      // Use the HitTest method to get a HitTestInfo object.
      System::Windows::Forms::DataGrid::HitTestInfo^ hi;
      DataGrid^ grid = dynamic_cast<DataGrid^>(sender);
      hi = grid->HitTest( e->X, e->Y );
      
      // Test if the clicked area was a cell.
      if ( hi->Type == DataGrid::HitTestType::Cell )
      {
         
         // If it's a cell, get the GridTable and CurrencyManager of the
         // clicked table.
         DataGridTableStyle^ dgt = dataGrid1->TableStyles[ 0 ];
         CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(BindingContext[ myDataSet->Tables[ dataGrid1->DataMember ] ]);
         
         // Get the Rectangle of the clicked cell.
         Rectangle cellRect;
         cellRect = grid->GetCellBounds( hi->Row, hi->Column );
         
         // Get the clicked DataGridTextBoxColumn.
         DataGridTextBoxColumn^ gridCol = dynamic_cast<DataGridTextBoxColumn^>(dgt->GridColumnStyles[ hi->Column ]);
         
         // Insert code to edit the value.
      }
   }

   // </Snippet1>
};
