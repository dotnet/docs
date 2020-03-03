// System::Windows::Forms::GridColumnStylesCollection::ResetPropertyDescriptors()

/*
The following program demonstrates the 'ResetPropertyDecriptors()'
method of 'GridColumnStylesCollection' class. An instance of DataGrid is
created and associate the data source to DataGrid. Then
column styles are added to the data grid. A Reset button is
provided to reset the property descriptors of the DataGrid
columns.
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

public ref class MyForm: public Form
{
private:
   System::ComponentModel::Container^ myComponents;
   Button^ resetButton;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;

public:
   MyForm()
   {
      // Required for Windows Form Designer support.
      InitializeComponent();

      // Call MyDataSource to bind the controls.
      MyDataSource();
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      this->myComponents = gcnew System::ComponentModel::Container;
      this->Text = "DataGrid Control Sample";
      this->resetButton = gcnew Button;
      resetButton->Location = Point(24,16);
      resetButton->Size = System::Drawing::Size( 124, 30 );
      resetButton->Text = "Reset Property Descriptor";
      resetButton->Click += gcnew System::EventHandler( this, &MyForm::ResetButton_Click );
      this->myDataGrid = gcnew DataGrid;
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 300, 200 );
      myDataGrid->CaptionText = "Microsoft DataGrid Control";
      this->Controls->Add( resetButton );
      this->Controls->Add( myDataGrid );
   }

   void MyDataSource()
   {
      // Create a DataSet with one table
      MakeDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
   }

   // <Snippet1>
private:
   void ResetButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      DataGridTableStyle^ myTableStyle = myDataGrid->TableStyles[ 0 ];
      GridColumnStylesCollection^ myColumns = myTableStyle->GridColumnStyles;

      // Reset the property descriptor of column styles collection.
      myColumns->ResetPropertyDescriptors();
   }
   // </Snippet1>

private:
   void AddCustomDataTableStyle()
   {
      // Get the currency manager for 'myDataSet' data source.
      CurrencyManager^ myCurrencyManger = dynamic_cast<CurrencyManager^>(this->BindingContext[ myDataSet ]);

      // Associate the 'DataGridTableStyle' to the 'myDataSet' data source.
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      myTableStyle->MappingName = "Customers";

      // Add style for 'Name' column.
      PropertyDescriptor^ pdName = myCurrencyManger->GetItemProperties()[ "CustName" ];

      // Create an instance of 'DataGridColumnStyle'.
      DataGridColumnStyle^ myCustomerNameStyle = gcnew DataGridTextBoxColumn( pdName );
      myCustomerNameStyle->MappingName = "custName";
      myCustomerNameStyle->HeaderText = "Customer Name";
      myTableStyle->GridColumnStyles->Add( myCustomerNameStyle );

      // Add style for 'Date' column.
      PropertyDescriptor^ myDateDescriptor = myCurrencyManger->GetItemProperties()[ "Date" ];
      DataGridColumnStyle^ myDateStyle = gcnew DataGridTextBoxColumn( myDateDescriptor,"G" );
      myDateStyle->MappingName = "Date";
      myDateStyle->HeaderText = "Date";
      myDateStyle->Width = 150;
      myTableStyle->GridColumnStyles->Add( myDateStyle );

      // Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

      // Create two columns, and add them to the table.
      DataColumn^ myCustomerName = gcnew DataColumn( "CustName" );
      DataColumn^ myDate = gcnew DataColumn( "Date",System::DateTime::typeid );
      myCustomerTable->Columns->Add( myCustomerName );
      myCustomerTable->Columns->Add( myDate );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( myCustomerTable );
      DataRow^ myNewRow;
      for ( int i = 1; i < 3; i++ )
      {
         myNewRow = myCustomerTable->NewRow();

         // Add the row to the Customers table.
         myCustomerTable->Rows->Add( myNewRow );
      }

      myCustomerTable->Rows[ 0 ][ "custName" ] = "Customer1";
      myCustomerTable->Rows[ 1 ][ "custName" ] = "Customer2";
      myCustomerTable->Rows[ 0 ][ "Date" ] = System::DateTime::Now;
      myCustomerTable->Rows[ 1 ][ "Date" ] = System::DateTime::Today;

      // Add column style collections.
      AddCustomDataTableStyle();
   }
};

int main()
{
   Application::Run( gcnew MyForm );
}
