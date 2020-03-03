// System::Windows::Forms::DataGridTextBoxColumn.DataGridTextBoxColumn(PropertyDescriptor*)
// System::Windows::Forms::DataGridTextBoxColumn.DataGridTextBoxColumn(PropertyDescriptor*, String*)

/*
The following program demonstrates various constructors of
'DataGridTextBoxColumn' class. An instance of 'DataGrid' class is constructed and
it is associated with data source. When the button S"Change Appearance" is clicked,
the format of the Date column in the grid is modified to a specific format.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyForm: public Form
{
private:
   System::ComponentModel::Container^ myComponents;
   Button^ myButton;
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
      this->myButton = gcnew Button;
      myButton->Location = Point(24,16);
      myButton->Size = System::Drawing::Size( 124, 30 );
      myButton->Text = "Change Appearance";
      myButton->Click += gcnew System::EventHandler( this, &MyForm::Button_Click );
      this->myDataGrid = gcnew DataGrid;
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 300, 200 );
      myDataGrid->CaptionText = "Microsoft DataGrid Control";
      this->Controls->Add( myButton );
      this->Controls->Add( myDataGrid );
   }

   void MyDataSource()
   {
      // Create a DataSet with one table
      CreateDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
   }

private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MyAddCustomDataTableStyle();
      myButton->Enabled = false;
   }

   // <Snippet1>
   // <Snippet2>
private:
   void MyAddCustomDataTableStyle()
   {
      // Get the currency manager for 'myDataSet'.
      CurrencyManager^ myCurrencyManger = dynamic_cast<CurrencyManager^>(this->BindingContext[ myDataSet ]);
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      myTableStyle->MappingName = "Customers";
      PropertyDescriptor^ proprtyDescriptorName = myCurrencyManger->GetItemProperties()[ "CustName" ];
      DataGridColumnStyle^ myCustomerNameStyle = gcnew DataGridTextBoxColumn( proprtyDescriptorName );
      myCustomerNameStyle->MappingName = "custName";
      myCustomerNameStyle->HeaderText = "Customer Name";
      myTableStyle->GridColumnStyles->Add( myCustomerNameStyle );

      // Add style for 'Date' column.
      PropertyDescriptor^ myDateDescriptor = myCurrencyManger->GetItemProperties()[ "Date" ];

      // 'G' is for MM/dd/yyyy HH:mm:ss date format.
      DataGridColumnStyle^ myDateStyle = gcnew DataGridTextBoxColumn( myDateDescriptor,"G" );
      myDateStyle->MappingName = "Date";
      myDateStyle->HeaderText = "Date";
      myDateStyle->Width = 150;
      myTableStyle->GridColumnStyles->Add( myDateStyle );

      // Add DataGridTableStyle instances to GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
   }
   // </Snippet2>
   // </Snippet1>

   void CreateDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create an instance of 'DataTable'.
      DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

      // Create two columns, and add them to the table.
      DataColumn^ myCustomerName = gcnew DataColumn( "CustName" );
      DataColumn^ myDate = gcnew DataColumn( "Date",System::DateTime::typeid );
      myCustomerTable->Columns->Add( myCustomerName );
      myCustomerTable->Columns->Add( myDate );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( myCustomerTable );

      // Create two customers in the Customers Table.
      DataRow^ myNewRow;
      for ( int i = 1; i < 3; i++ )
      {
         myNewRow = myCustomerTable->NewRow();
         
         // Add the row to the Customers table.
         myCustomerTable->Rows->Add( myNewRow );
      }

      // Populate customer name column.
      myCustomerTable->Rows[ 0 ][ "custName" ] = "Customer1";
      myCustomerTable->Rows[ 1 ][ "custName" ] = "Customer2";

      // Populate date column.
      myCustomerTable->Rows[ 0 ][ "Date" ] = System::DateTime::Now;
      myCustomerTable->Rows[ 1 ][ "Date" ] = System::DateTime::Today;
   }
};

int main()
{
   Application::Run( gcnew MyForm );
}
