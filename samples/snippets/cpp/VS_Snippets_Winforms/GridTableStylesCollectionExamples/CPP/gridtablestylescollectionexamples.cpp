#using <System.Xml.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Collections;
using namespace System::Drawing;
using namespace System::ComponentModel;
using namespace System::IO;
using namespace System::Data;
using namespace System::Windows::Forms;

public ref class DataGridTableStuff: public Form
{
private:
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   void SetUp()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      myDataGrid = gcnew DataGrid;
   }

   //<snippet1>
   void AddCustomDataTableStyle()
   {
      DataGridTableStyle^ ts1 = gcnew DataGridTableStyle;
      ts1->MappingName = "Customers";
      
      // Set other properties.
      ts1->AlternatingBackColor = Color::LightGray;
      
      /* Add a GridColumnStyle and set its MappingName
        to the name of a DataColumn in the DataTable.
        Set the HeaderText and Width properties. */
      DataGridColumnStyle^ boolCol = gcnew DataGridBoolColumn;
      boolCol->MappingName = "Current";
      boolCol->HeaderText = "IsCurrent Customer";
      boolCol->Width = 150;
      ts1->GridColumnStyles->Add( boolCol );
      
      // Add a second column style.
      DataGridColumnStyle^ TextCol = gcnew DataGridTextBoxColumn;
      TextCol->MappingName = "custName";
      TextCol->HeaderText = "Customer Name";
      TextCol->Width = 250;
      ts1->GridColumnStyles->Add( TextCol );
      
      // Create the second table style with columns.
      DataGridTableStyle^ ts2 = gcnew DataGridTableStyle;
      ts2->MappingName = "Orders";
      
      // Set other properties.
      ts2->AlternatingBackColor = Color::LightBlue;
      
      // Create new ColumnStyle objects.
      DataGridColumnStyle^ cOrderDate = gcnew DataGridTextBoxColumn;
      cOrderDate->MappingName = "OrderDate";
      cOrderDate->HeaderText = "Order Date";
      cOrderDate->Width = 100;
      ts2->GridColumnStyles->Add( cOrderDate );
      
      /*Use a PropertyDescriptor to create a formatted
        column. First get the PropertyDescriptorCollection
        for the data source and data member. */
      System::ComponentModel::PropertyDescriptorCollection^ pcol = this->
          BindingContext[myDataSet, "Customers::custToOrders"]->
          GetItemProperties();
      
      /* Create a formatted column using a PropertyDescriptor.
        The formatting character S"c" specifies a currency format. */
      DataGridColumnStyle^ csOrderAmount =
         gcnew DataGridTextBoxColumn( pcol[ "OrderAmount" ],"c",true );
      csOrderAmount->MappingName = "OrderAmount";
      csOrderAmount->HeaderText = "Total";
      csOrderAmount->Width = 100;
      ts2->GridColumnStyles->Add( csOrderAmount );
      
      /* Add the DataGridTableStyle instances to
        the GridTableStylesCollection. */
      myDataGrid->TableStyles->Add( ts1 );
      myDataGrid->TableStyles->Add( ts2 );
   }
   //</snippet1>

   //<snippet2>
   void GetGridTableByIndex()
   {
      DataGridTableStyle^ myGridStyle = myDataGrid->TableStyles[ 0 ];
      Console::WriteLine( myGridStyle->MappingName );
   }
   //</snippet2>

   //<snippet3>
   void GetGridTableByName()
   {
      DataGridTableStyle^ myGridStyle = myDataGrid->TableStyles[ "customers" ];
      Console::WriteLine( myGridStyle->MappingName );
   }
   //</snippet3>

   //<snippet4>
   void AddDataGridTableStyle()
   {
      // Create a new DataGridTableStyle and set MappingName.
      DataGridTableStyle^ myGridStyle = gcnew DataGridTableStyle;
      myGridStyle->MappingName = "Customers";
      
      // Create two DataGridColumnStyle objects.
      DataGridColumnStyle^ colStyle1 = gcnew DataGridTextBoxColumn;
      colStyle1->MappingName = "firstName";
      DataGridColumnStyle^ colStyle2 = gcnew DataGridBoolColumn;
      colStyle2->MappingName = "Current";
      
      // Add column styles to table style.
      myGridStyle->GridColumnStyles->Add( colStyle1 );
      myGridStyle->GridColumnStyles->Add( colStyle2 );
      
      // Add the grid style to the GridStylesCollection.
      myDataGrid->TableStyles->Add( myGridStyle );
   }
   //</snippet4>

   //<snippet5>
   void AddArray()
   {
      /* Get three CurrencyManager objects used to construct
        DataGridTableSTyle objects. */
      CurrencyManager^ customersManager =
         dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Customers"]);
      CurrencyManager^ regionsManager =
         dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Customers"]);
      CurrencyManager^ productsManager =
         dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "Customers"]);
      DataGridTableStyle^ gridCustomers = gcnew DataGridTableStyle( customersManager );
      DataGridTableStyle^ gridRegions = gcnew DataGridTableStyle( regionsManager );
      DataGridTableStyle^ gridProducts = gcnew DataGridTableStyle( productsManager );
      
      // Create a DataGridTableStyle array.
      array<DataGridTableStyle^>^myGrids = {gridCustomers,gridRegions,gridProducts};
      
      // Use AddRange to add to the collection.
      myDataGrid->TableStyles->AddRange( myGrids );
   }
   //</snippet5>

   //<snippet6>
   void TestContains()
   {
      bool isContained;
      isContained = myDataGrid->TableStyles->Contains( "Customers" );
      Console::WriteLine( isContained );
   }
   //</snippet6>
};

int main()
{
   DataGridTableStuff^ dg = gcnew DataGridTableStuff;
}
