

// <Snippet1>
#using <system.dll>
#using <system.data.dll>
#using <system.drawing.dll>
#using <system.windows.forms.dll>
#using <system.xml.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

#define null 0
public ref class Form1: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;
   Button^ button1;
   Button^ button2;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   bool TablesAlreadyAdded;

public:
   Form1()
   {
      // Required for Windows Form Designer support.
      InitializeComponent();

      // Call SetUp to bind the controls.
      SetUp();
   }

public:
   ~Form1()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      this->components = gcnew System::ComponentModel::Container;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->myDataGrid = gcnew DataGrid;
      this->Text = "DataGrid Control Sample";
      this->ClientSize = System::Drawing::Size( 450, 330 );
      button1->Location = System::Drawing::Point( 24, 16 );
      button1->Size = System::Drawing::Size( 120, 24 );
      button1->Text = "Change Appearance";
      button1->Click += gcnew System::EventHandler( this, &Form1::button1_Click );
      button2->Location = System::Drawing::Point( 150, 16 );
      button2->Size = System::Drawing::Size( 120, 24 );
      button2->Text = "Get Binding Manager";
      button2->Click += gcnew System::EventHandler( this, &Form1::button2_Click );
      myDataGrid->Location = System::Drawing::Point( 24, 50 );
      myDataGrid->Size = System::Drawing::Size( 300, 200 );
      myDataGrid->CaptionText = "Microsoft DataGrid Control";
      myDataGrid->MouseUp += gcnew MouseEventHandler( this, &Form1::Grid_MouseUp );
      this->Controls->Add( button1 );
      this->Controls->Add( button2 );
      this->Controls->Add( myDataGrid );
   }

   void SetUp()
   {
      // Create a DataSet with two tables and one relation.
      MakeDataSet();

      /* Bind the DataGrid to the DataSet. The dataMember
        specifies that the Customers table should be displayed.*/
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
   }

private:
   void button1_Click( Object^ sender, System::EventArgs^ e )
   {
      if ( TablesAlreadyAdded )
            return;

      AddCustomDataTableStyle();
   }

private:
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

      // Create new ColumnStyle objects
      DataGridColumnStyle^ cOrderDate = gcnew DataGridTextBoxColumn;
      cOrderDate->MappingName = "OrderDate";
      cOrderDate->HeaderText = "Order Date";
      cOrderDate->Width = 100;
      ts2->GridColumnStyles->Add( cOrderDate );

      /* Use a PropertyDescriptor to create a formatted
        column. First get the PropertyDescriptorCollection
        for the data source and data member. */
      PropertyDescriptorCollection^ pcol = this->BindingContext[myDataSet, "Customers.custToOrders"]->GetItemProperties();

      /* Create a formatted column using a PropertyDescriptor.
        The formatting character "c" specifies a currency format. */
      DataGridColumnStyle^ csOrderAmount = gcnew DataGridTextBoxColumn( pcol[ "OrderAmount" ],"c",true );
      csOrderAmount->MappingName = "OrderAmount";
      csOrderAmount->HeaderText = "Total";
      csOrderAmount->Width = 100;
      ts2->GridColumnStyles->Add( csOrderAmount );

      /* Add the DataGridTableStyle instances to 
        the GridTableStylesCollection. */
      myDataGrid->TableStyles->Add( ts1 );
      myDataGrid->TableStyles->Add( ts2 );

      // Sets the TablesAlreadyAdded to true so this doesn't happen again.
      TablesAlreadyAdded = true;
   }

private:
   void button2_Click( Object^ sender, System::EventArgs^ e )
   {
      BindingManagerBase^ bmGrid;
      bmGrid = BindingContext[myDataSet, "Customers"];
      MessageBox::Show( String::Concat( "Current BindingManager Position: ", bmGrid->Position )->ToString() );
   }

private:
   void Grid_MouseUp( Object^ sender, MouseEventArgs^ e )
   {
      // Create a HitTestInfo object using the HitTest method.
      // Get the DataGrid by casting sender.
      DataGrid^ myGrid = dynamic_cast<DataGrid^>(sender);
      DataGrid::HitTestInfo ^ myHitInfo = myGrid->HitTest( e->X, e->Y );
      Console::WriteLine( myHitInfo );
      Console::WriteLine( myHitInfo->Type );
      Console::WriteLine( myHitInfo->Row );
      Console::WriteLine( myHitInfo->Column );
   }

   // Create a DataSet with two tables and populate it.
   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create two DataTables.
      DataTable^ tCust = gcnew DataTable( "Customers" );
      DataTable^ tOrders = gcnew DataTable( "Orders" );

      // Create two columns, and add them to the first table.
      DataColumn^ cCustID = gcnew DataColumn( "CustID",__int32::typeid );
      DataColumn^ cCustName = gcnew DataColumn( "CustName" );
      DataColumn^ cCurrent = gcnew DataColumn( "Current",bool::typeid );
      tCust->Columns->Add( cCustID );
      tCust->Columns->Add( cCustName );
      tCust->Columns->Add( cCurrent );

      // Create three columns, and add them to the second table.
      DataColumn^ cID = gcnew DataColumn( "CustID",__int32::typeid );
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

      /* Populate the tables. For each customer and order, 
        create need two DataRow variables. */
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
      tCust->Rows[ 0 ][ "custName" ] = "Customer1";
      tCust->Rows[ 1 ][ "custName" ] = "Customer2";
      tCust->Rows[ 2 ][ "custName" ] = "Customer3";

      // Give the Current column a value.
      tCust->Rows[ 0 ][ "Current" ] = true;
      tCust->Rows[ 1 ][ "Current" ] = true;
      tCust->Rows[ 2 ][ "Current" ] = false;

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
};

int main()
{
   Application::Run( gcnew Form1 );
}
// </Snippet1>
