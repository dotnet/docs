// System::Windows::Forms::DataGridTableStyle::AllowSorting;
// System::Windows::Forms::DataGridTableStyle::AllowSortingChanged;

/* The following example demonstrates the property
'AllowSorting' and event 'AllowSortingChanged' of class DataGridTableStyle.
The following program creates a Windows form, a DataSet containing
two DataTable objects, and a DataRelation that relates the two tables.
A button on the form toggles sorting availability on the grid.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

namespace SampleDataGridTableStyle
{
   public ref class DataGridTableStyle_Sample: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::DataGrid^ myDataGrid;
      System::Windows::Forms::DataGridTableStyle^ myDataGridTableStyle1;
      DataSet^ myDataSet;
      System::Windows::Forms::Button^ btnApplyStyles;
      System::Windows::Forms::Label ^ mylabel;
      System::ComponentModel::Container^ components;

   public:
      DataGridTableStyle_Sample()
      {
         components = nullptr;
         InitializeComponent();

         // Call SetUp to bind the controls.
         SetUp();
      }

   public:
      ~DataGridTableStyle_Sample()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         this->btnApplyStyles = gcnew System::Windows::Forms::Button;
         this->mylabel = gcnew System::Windows::Forms::Label;
         this->myDataGrid = gcnew System::Windows::Forms::DataGrid;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->BeginInit();
         this->SuspendLayout();

         //
         // btnApplyStyles
         //
         this->btnApplyStyles->Font = gcnew System::Drawing::Font( "Arial",8.25F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
         this->btnApplyStyles->Location = System::Drawing::Point( 216, 192 );
         this->btnApplyStyles->Name = "btnApplyStyles";
         this->btnApplyStyles->Size = System::Drawing::Size( 144, 40 );
         this->btnApplyStyles->TabIndex = 1;
         this->btnApplyStyles->Text = "Apply Sorting";
         this->btnApplyStyles->Click += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::btnApplyStyles_Click );

         //
         // mylabel
         //
         this->mylabel->Font = gcnew System::Drawing::Font( "Verdana",8.25F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
         this->mylabel->Location = System::Drawing::Point( 48, 208 );
         this->mylabel->Name = "mylabel";
         this->mylabel->Size = System::Drawing::Size( 160, 23 );
         this->mylabel->TabIndex = 2;
         this->mylabel->Text = "Sorting Status";

         //
         // myDataGrid
         //
         this->myDataGrid->CaptionText = "Microsoft DataGrid Control";
         this->myDataGrid->DataMember = "";
         this->myDataGrid->LinkColor = System::Drawing::Color::Gray;
         this->myDataGrid->Location = System::Drawing::Point( 48, 32 );
         this->myDataGrid->Name = "myDataGrid";
         this->myDataGrid->Size = System::Drawing::Size( 312, 128 );
         this->myDataGrid->TabIndex = 0;

         //
         // DataGridTableStyle_Sample
         //
         this->ClientSize = System::Drawing::Size( 416, 261 );
         array<System::Windows::Forms::Control^>^formControls = {this->mylabel,this->btnApplyStyles,this->myDataGrid};
         this->Controls->AddRange( formControls );
         this->Name = "DataGridTableStyle_Sample";
         this->Text = "DataGridTableStyle_Sample";
         this->Load += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::DataGridTableStyle_Sample_Load );
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->EndInit();
         this->ResumeLayout( false );
      }

      void SetUp()
      {
         // Create a DataSet with two tables and one relation.
         MakeDataSet();

         // Bind DataGrid to the DataSet.
         myDataGrid->SetDataBinding( myDataSet, "Customers" );
      }

      // Create a DataSet with two tables and populate it.
      void MakeDataSet()
      {
         // Create a DataSet.
         myDataSet = gcnew DataSet( "myDataSet" );

         // Create Customer DataTables.
         DataTable^ tCust = gcnew DataTable( "Customers" );

         // Create two columns, and add them to the first table.
         DataColumn^ cCustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cCustName = gcnew DataColumn( "CustName" );
         DataColumn^ cCurrent = gcnew DataColumn( "Current",bool::typeid );
         tCust->Columns->Add( cCustID );
         tCust->Columns->Add( cCustName );
         tCust->Columns->Add( cCurrent );

         // Create Customer order table.
         DataTable^ tOrders = gcnew DataTable( "Orders" );

         // Create three columns, and add them to the second table.
         DataColumn^ cID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cOrderDate = gcnew DataColumn( "orderDate",DateTime::typeid );
         DataColumn^ cOrderAmount = gcnew DataColumn( "OrderAmount",Decimal::typeid );
         tOrders->Columns->Add( cOrderAmount );
         tOrders->Columns->Add( cID );
         tOrders->Columns->Add( cOrderDate );

         // Add the tables to the DataSet.
         myDataSet->Tables->Add( tCust );
         myDataSet->Tables->Add( tOrders );

         // Create a DataRelation, and add it to the DataSet.
         DataRelation^ dr = gcnew DataRelation( "custToOrders",cCustID,cID );
         myDataSet->Relations->Add( dr );

         // Populate the tables.
         DataRow^ newRow1;
         DataRow^ newRow2;

         // Create three customers in the Customers Table.
         for ( int i = 1; i < 4; i++ )
         {
            newRow1 = tCust->NewRow();
            newRow1[ "custID" ] = i;
            
            // Add the row to the Customers table.
            tCust->Rows->Add( newRow1 );
         }
         tCust->Rows[ 0 ][ "custName" ] = "Alpha";
         tCust->Rows[ 1 ][ "custName" ] = "Beta";
         tCust->Rows[ 2 ][ "custName" ] = "Gamma";

         // Give the Current column a value.
         tCust->Rows[ 0 ][ "Current" ] = true.ToString();
         tCust->Rows[ 1 ][ "Current" ] = true.ToString();
         tCust->Rows[ 2 ][ "Current" ] = false.ToString();

         // For each customer, create five rows in the Orders table.
         for ( int i = 1; i < 4; i++ )
         {
            for ( int j = 1; j < 6; j++ )
            {
               newRow2 = tOrders->NewRow();
               newRow2[ "CustID" ] = i;
               newRow2[ "orderDate" ] = DateTime(2001,i,j * 2);
               newRow2[ "OrderAmount" ] = i * 10 + j * .1;
               
               // Add the row to the Orders table.
               tOrders->Rows->Add( newRow2 );
            }
         }
      }

      // <Snippet1>
      // <Snippet2>
   private:
      void DataGridTableStyle_Sample_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         myDataGridTableStyle1 = gcnew DataGridTableStyle;
         mylabel->Text = String::Concat( "Sorting Status : ", myDataGridTableStyle1->AllowSorting );
         if ( myDataGridTableStyle1->AllowSorting == true )
         {
            btnApplyStyles->Text = "Remove Sorting";
         }
         else
         {
            btnApplyStyles->Text = "Apply Sorting";
         }

         myDataGridTableStyle1->AllowSortingChanged += gcnew System::EventHandler(
            this, &DataGridTableStyle_Sample::AllowSortingChanged_Handler );
         myDataGridTableStyle1->MappingName = "Customers";
      }

      void AllowSortingChanged_Handler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         mylabel->Text = String::Concat( "Sorting Status : ", myDataGridTableStyle1->AllowSorting );
      }

      void btnApplyStyles_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         if ( myDataGridTableStyle1->AllowSorting == true )
         {
            // Remove sorting.
            myDataGridTableStyle1->AllowSorting = false;
            btnApplyStyles->Text = "Allow Sorting";
         }
         else
         {
            // Allow sorting.
            myDataGridTableStyle1->AllowSorting = true;
            btnApplyStyles->Text = "Remove Sorting";
         }

         mylabel->Text = String::Concat( "Sorting Status : ", myDataGridTableStyle1->AllowSorting );

         // Add the DataGridTableStyle to DataGrid.
         myDataGrid->TableStyles->Add( myDataGridTableStyle1 );
      }
      // </Snippet2>
      // </Snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew SampleDataGridTableStyle::DataGridTableStyle_Sample );
}
