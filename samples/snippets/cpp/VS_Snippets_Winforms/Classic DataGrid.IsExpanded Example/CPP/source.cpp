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

   // <Snippet1>
protected:
   void TextExpanded( DataGrid^ myGrid )
   {
      // Get the DataTable of the grid
      DataTable^ myTable;
      // Assuming the grid is bound to a DataTable
      myTable = (DataTable^)(myGrid->DataSource);
      for ( int i = 0; i < myTable->Rows->Count; i++ )
      {
         if ( myGrid->IsExpanded( i ) )
         {
            Console::WriteLine( "Row {0} was expanded", i );
         }
      }
   }
   // </Snippet1>
};
