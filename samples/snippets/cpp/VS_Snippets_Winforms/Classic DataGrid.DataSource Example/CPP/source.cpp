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

   // <Snippet1>
private:
   void BindToDataView( DataGrid^ myGrid )
   {
      // Create a DataView using the DataTable.
      DataTable^ myTable = gcnew DataTable( "Suppliers" );
      // Insert code to create and populate columns.
      DataView^ myDataView = gcnew DataView( myTable );
      myGrid->DataSource = myDataView;
   }

   void BindToDataSet( DataGrid^ myGrid )
   {
      // Create a DataSet.
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      // Insert code to populate DataSet with several tables.
      myGrid->DataSource = myDataSet;
      // Use the DataMember property to specify the DataTable.
      myGrid->DataMember = "Suppliers";
   }

   DataView^ GetDataViewFromDataSource()
   {
      // Create a DataTable variable, and set it to the DataSource.
      DataView^ myDataView;
      myDataView = (DataView^)(dataGrid1->DataSource);
      return myDataView;
   }

   DataSet^ GetDataSetFromDataSource()
   {
      // Create a DataSet variable, and set it to the DataSource.
      DataSet^ myDataSet;
      myDataSet = (DataSet^)(dataGrid1->DataSource);
      return myDataSet;
   }
   // </Snippet1>
};
