// System::Windows::Forms::GridColumnStylesCollection::RemoveAt

/*
The following program demonstrates the 'RemoveAt(int)' method of
'GridColumnStylesCollection' class. An instance of DataGrid is created
by associating the DataGrid with a data source and column style
collections are added to it. A Remove button is provided to delete the
CustomerName column style collection.
*/

#using <System.Xml.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Collections;

public ref class MyForm: public Form
{
private:
   System::ComponentModel::Container^ components;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Button^ removeStyle;
   GridColumnStylesCollection^ myColumns;

public:
   MyForm()
   {
      InitializeComponent();
      SetUp();
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      components = gcnew System::ComponentModel::Container;
      myDataGrid = gcnew DataGrid;
      removeStyle = gcnew Button;

      // Set the myDataGrid properties.
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 300, 200 );
      myDataGrid->CaptionText = "Microsoft DataGrid Control";

      // Set the removeStyle properties.
      removeStyle->Location = Point(276,16);
      removeStyle->Name = "removeStyle";
      removeStyle->Size = System::Drawing::Size( 120, 24 );
      removeStyle->Text = "Remove";
      removeStyle->Click += gcnew System::EventHandler( this, &MyForm::RemoveColumnStyle_Clicked );
      ClientSize = System::Drawing::Size( 600, 500 );
      Name = "GridColumnStylesCollection_RemoveAt";
      Text = "DataGrid Control Sample";

      // Add the controls to the form.
      Controls->Add( removeStyle );
      Controls->Add( myDataGrid );
   }

   void SetUp()
   {
      // Create the data source.
      MakeDataSet();

      // Associate the data set.
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
   }

   // Create a DataSet with two tables and populate it.
   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create two DataTables.
      DataTable^ myCustomer = gcnew DataTable( "Customers" );
      DataTable^ myOrders = gcnew DataTable( "Orders" );

      // Create two columns, and add them to the first table.
      DataColumn^ myCustomerID = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ myCustomerName = gcnew DataColumn( "CustName" );
      DataColumn^ myCurrent = gcnew DataColumn( "Current",bool::typeid );
      myCustomer->Columns->Add( myCustomerID );
      myCustomer->Columns->Add( myCustomerName );
      myCustomer->Columns->Add( myCurrent );

      // Create three columns, and add them to the second table.
      DataColumn^ myID = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ myOrderDate = gcnew DataColumn( "OrderDate",DateTime::typeid );
      DataColumn^ myOrderAmount = gcnew DataColumn( "OrderAmount",Decimal::typeid );
      myOrders->Columns->Add( myOrderAmount );
      myOrders->Columns->Add( myID );
      myOrders->Columns->Add( myOrderDate );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( myCustomer );
      myDataSet->Tables->Add( myOrders );

      // Create a DataRelation, and add it to the DataSet.
      DataRelation^ myDataRelation = gcnew DataRelation( "custToOrders",myCustomerID,myID );
      myDataSet->Relations->Add( myDataRelation );
      DataRow^ myNewRow1;
      DataRow^ myNewRow2;

      // Create three customers in the Customers Table.
      for ( int i = 1; i < 5; i++ )
      {
         myNewRow1 = myCustomer->NewRow();
         myNewRow1[ "CustID" ] = i;
         myNewRow1[ "CustName" ] = "Item {0}",i;
         myNewRow1[ "Current" ] = true.ToString();
         
         // Add the row to the Customers table.
         myCustomer->Rows->Add( myNewRow1 );
      }

      // For each customer, create five rows in the Orders table.
      for ( int i = 1; i < 5; i++ )
      {
         for ( int j = 1; j < 6; j++ )
         {
            myNewRow2 = myOrders->NewRow();
            myNewRow2[ "CustID" ] = i;
            myNewRow2[ "OrderDate" ] = DateTime(2001,i,j * 2);
            myNewRow2[ "OrderAmount" ] = i * 10 + j * .1;
            
            // Add the row to the Orders table.
            myOrders->Rows->Add( myNewRow2 );
         }
      }
      AddCustomDataTableStyle();
   }

   void AddCustomDataTableStyle()
   {
      // Create a 'DataGridTableStyle'.
      DataGridTableStyle^ myTableStyle1 = gcnew DataGridTableStyle;

      // Map the table style.
      myTableStyle1->MappingName = "Customers";
      myTableStyle1->AlternatingBackColor = Color::LightGray;

      // Add a Name column style.
      DataGridColumnStyle^ myTextCol = gcnew DataGridTextBoxColumn;
      myTextCol->MappingName = "CustName";
      myTextCol->HeaderText = "Customer Name";
      myTextCol->Width = 100;
      myTableStyle1->GridColumnStyles->Add( myTextCol );

      // Add a Current column style.
      DataGridColumnStyle^ myBoolCol = gcnew DataGridBoolColumn;
      myBoolCol->MappingName = "Current";
      myBoolCol->HeaderText = "IsCurrent Customer";
      myBoolCol->Width = 125;
      myTableStyle1->GridColumnStyles->Add( myBoolCol );

      // Create the second table style with columns.
      DataGridTableStyle^ myTableStyle2 = gcnew DataGridTableStyle;
      myTableStyle2->MappingName = "Orders";
      myTableStyle2->AlternatingBackColor = Color::LightBlue;

      // Create Order Date Column Style.
      DataGridColumnStyle^ myOrderDate = gcnew DataGridTextBoxColumn;
      myOrderDate->MappingName = "OrderDate";
      myOrderDate->HeaderText = "Order Date";
      myOrderDate->Width = 100;
      myTableStyle2->GridColumnStyles->Add( myOrderDate );

      // Get the PropertyDescriptor of data set.
      PropertyDescriptorCollection^ myPCol = this->BindingContext[myDataSet, "Customers::custToOrders"]->GetItemProperties();

      // Create the Order Amount Column style.
      DataGridColumnStyle^ myOrderAmount = gcnew DataGridTextBoxColumn( myPCol[ "OrderAmount" ],"c",true );
      myOrderAmount->MappingName = "OrderAmount";
      myOrderAmount->HeaderText = "Total";
      myOrderAmount->Width = 100;
      myTableStyle2->GridColumnStyles->Add( myOrderAmount );

      // Add the DataGridTableStyle objects to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle1 );
      myDataGrid->TableStyles->Add( myTableStyle2 );
   }

   // <Snippet1>
private:
   void RemoveColumnStyle_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      DataGridTableStyle^ myTableStyle = myDataGrid->TableStyles[ 0 ];

      // Get the GridColumnStylesCollection of Data Grid.
      myColumns = myTableStyle->GridColumnStyles;
      int i;

      // Remove the CustName ColumnStyle from the data grid.
      if ( myColumns->Contains( "CustName" ) )
      {
         DataGridColumnStyle^ myDataColumnStyle = myColumns[ "CustName" ];
         i = myColumns->IndexOf( myDataColumnStyle );
         myColumns->RemoveAt( i );
      }
   }
   // </Snippet1>
};

int main()
{
   Application::Run( gcnew MyForm );
}
