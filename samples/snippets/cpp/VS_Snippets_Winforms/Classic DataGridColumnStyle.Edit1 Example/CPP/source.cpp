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
public ref class Form1: public Form
{
private:
   DataSet^ myDataSet;
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
         DataGridTableStyle^ dgt = grid->TableStyles[ 0 ];
         CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[ myDataSet->Tables[ dgt->MappingName ] ]);

         // Get the Rectangle of the clicked cell.
         Rectangle cellRect;
         cellRect = grid->GetCellBounds( hi->Row, hi->Column );

         // Get the clicked DataGridTextBoxColumn.
         MyColumnStyle ^ gridCol = dynamic_cast<MyColumnStyle^>(dgt->GridColumnStyles[ hi->Column ]);

         // Edit the value.
         gridCol->EditVal( myCurrencyManager, hi->Row, cellRect, false, "New Text" );
      }
   }


public:
   ref class MyColumnStyle: public DataGridTextBoxColumn
   {
   public:
      void EditVal( CurrencyManager^ cm, int row, Rectangle rec, bool readOnly, String^ text )
      {
         this->Edit( cm, row, rec, readOnly, text );
      }
   };
};
// </Snippet1>

int main(){}
