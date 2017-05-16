

#using <System.dll>
#using <System.Xml.dll>
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

private:

   // <Snippet1>
   void PrintCellValues( DataGrid^ myGrid )
   {
      int iRow;
      int iCol;
      DataTable^ myTable;
      
      // Assumes the DataGrid is bound to a DataTable.
      myTable = dynamic_cast<DataTable^>(dataGrid1->DataSource);
      for ( iRow = 0; iRow < myTable->Rows->Count; iRow++ )
      {
         for ( iCol = 0; iCol < myTable->Columns->Count; iCol++ )
         {
            Console::WriteLine( myGrid[iRow, iCol] );

         }

      }
   }

   // </Snippet1>
};

int main(){}
