

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
   DataSet^ dataSet1;

private:

   // <Snippet1>
   void SetReadOnly()
   {
      DataColumnCollection^ myDataColumns;
      
      // Get the columns for a table bound to a DataGrid.
      myDataColumns = dataSet1->Tables[ "Suppliers" ]->Columns;
      System::Collections::IEnumerator^ myEnum = myDataColumns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataColumn^ dataColumn = safe_cast<DataColumn^>(myEnum->Current);
         dataGrid1->TableStyles[ 0 ]->GridColumnStyles[ dataColumn->ColumnName ]->ReadOnly = dataColumn->ReadOnly;
      }
   }

   // </Snippet1>
};
