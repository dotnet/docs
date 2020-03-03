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
   // <Snippet1>
private:
   void AddTables( DataGrid^ myDataGrid, DataSet^ myDataSet )
   {
      for each ( DataTable^ t in myDataSet->Tables )
      {
         DataGridTableStyle^ myGridTableStyle =
            gcnew DataGridTableStyle;
         myGridTableStyle->MappingName = t->TableName;
         myDataGrid->TableStyles->Add( myGridTableStyle );
         
         /* Note that DataGridColumnStyle objects will
            be created automatically for the first DataGridTableStyle
            when you add it to the GridTableStylesCollection.*/
      }
   }

   void PrintGridStyleInfo( DataGrid^ myDataGrid )
   {
      /* Print the MappingName of each DataGridTableStyle,
         and the MappingName of each DataGridColumnStyle. */
      for each ( DataGridTableStyle^ myGridStyle in
         myDataGrid->TableStyles )
      {
         Console::WriteLine( myGridStyle->MappingName );
         for each ( DataGridColumnStyle^ myColumnStyle in
            myGridStyle->GridColumnStyles )
         {
            Console::WriteLine( myColumnStyle->MappingName );
         }
      }
   }
   // </Snippet1>
};
