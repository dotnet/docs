

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
   void PaintCol( Graphics^ g, Rectangle cellRect, CurrencyManager^ cm, int rowNum, Brush^ bBrush, Brush^ fBrush, bool isVisible )
   {
      this->Paint( g, cellRect, cm, rowNum, bBrush, fBrush, isVisible );
   }

};

public ref class Form1: public Form
{
protected:
   DataGrid^ dataGrid1;
   DataSet^ myDataSet;

private:
   void PaintCell( Object^ sender, MouseEventArgs^ e )
   {
      
      // Use the HitTest method to get a HitTestInfo object.
      DataGrid::HitTestInfo ^ hi;
      DataGrid^ grid = dynamic_cast<DataGrid^>(sender);
      hi = grid->HitTest( e->X, e->Y );
      
      // Test if the clicked area was a cell.
      if ( hi->Type == DataGrid::HitTestType::Cell )
      {
         
         // If it's a cell, get the GridTable and ListManager of the
         // clicked table.         
         DataGridTableStyle^ dgt = dataGrid1->TableStyles[ 0 ];
         CurrencyManager^ cm = dynamic_cast<CurrencyManager^>(this->BindingContext[ myDataSet->Tables[ dgt->MappingName ] ]);
         
         // Get the Rectangle of the clicked cell.
         Rectangle cellRect;
         cellRect = grid->GetCellBounds( hi->Row, hi->Column );
         
         // Get the clicked DataGridTextBoxColumn.
         MyGridColumn^ gridCol = dynamic_cast<MyGridColumn^>(dgt->GridColumnStyles[ hi->Column ]);
         
         // Get the Graphics object for the form.
         Graphics^ g = dataGrid1->CreateGraphics();
         
         // Create two new Brush objects, a fore brush, and back brush.
         Brush^ fBrush = gcnew System::Drawing::SolidBrush( Color::Blue );
         Brush^ bBrush = gcnew System::Drawing::SolidBrush( Color::Yellow );
         
         // Invoke the Paint method to paint the cell with the brushes.
         gridCol->PaintCol( g, cellRect, cm, hi->Row, bBrush, fBrush, false );
      }
   }

};

// </Snippet1>
