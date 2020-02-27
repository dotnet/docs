// System::Windows::Forms::GridColumnStylesCollection::Clear
// System::Windows::Forms::GridColumnStylesCollection::get_Item(int)
// System::Windows::Forms::GridColumnStylesCollection::get_Item(String*)

/*
The following program demonstrates the Clear method , the get_Item(int) and get_Item(String*)
indexers for the 'GridColumnStylesCollection' class.
In this program the user can add custom styles and clear them. The information on the styles
is displayed depending on the option chosen by user.
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

public ref class MyForm: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Label^ myLabel;
   Button^ clearButton;
   Button^ addStylesButton;
   Button^ selectChoiceButton;
   System::Windows::Forms::RadioButton^ columnNameRadioButton;
   System::Windows::Forms::RadioButton^ indexRadioButton;
   System::Windows::Forms::Label ^ myLabel2;
   bool TablesAlreadyAdded;

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
      clearButton = gcnew System::Windows::Forms::Button;
      addStylesButton = gcnew System::Windows::Forms::Button;
      myDataGrid = gcnew System::Windows::Forms::DataGrid;
      myLabel = gcnew System::Windows::Forms::Label;
      selectChoiceButton = gcnew System::Windows::Forms::Button;
      columnNameRadioButton = gcnew System::Windows::Forms::RadioButton;
      indexRadioButton = gcnew System::Windows::Forms::RadioButton;
      myLabel2 = gcnew System::Windows::Forms::Label;
      clearButton->Location = System::Drawing::Point( 24, 16 );
      clearButton->Name = "clearButton";
      clearButton->Size = System::Drawing::Size( 120, 24 );
      clearButton->Text = "Clear Table Styles";
      clearButton->Click += gcnew System::EventHandler( this, &MyForm::Clear_Clicked );
      addStylesButton->Location = System::Drawing::Point( 150, 16 );
      addStylesButton->Name = "addStylesButton";
      addStylesButton->Size = System::Drawing::Size( 120, 24 );
      addStylesButton->Text = "Add Custom Styles";
      addStylesButton->Click += gcnew System::EventHandler( this, &MyForm::AddStyles_Clicked );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 300, 200 );
      myDataGrid->CaptionText = "Microsoft DataGrid Control";
      myLabel->Location = System::Drawing::Point( 48, 328 );
      myLabel->Name = "myLabel";
      myLabel->Size = System::Drawing::Size( 464, 90 );
      myLabel->TabIndex = 7;
      myLabel->Text = "Message.";
      myLabel2->Location = System::Drawing::Point( 412, 24 );
      myLabel2->Size = System::Drawing::Size( 100, 20 );
      myLabel2->Text = "Print info using:";
      selectChoiceButton->Location = System::Drawing::Point( 276, 16 );
      selectChoiceButton->Name = "selectChoiceButton";
      selectChoiceButton->Size = System::Drawing::Size( 120, 24 );
      selectChoiceButton->Text = "Print Info";
      selectChoiceButton->Click += gcnew System::EventHandler( this, &MyForm::SelectChoice_Clicked );
      columnNameRadioButton->Location = System::Drawing::Point( 432, 56 );
      columnNameRadioButton->Name = "columnNameRadioButton";
      columnNameRadioButton->Text = "ColumnName";
      indexRadioButton->Location = System::Drawing::Point( 432, 88 );
      indexRadioButton->Name = "indexRadioButton";
      indexRadioButton->Text = "Index";
      ClientSize = System::Drawing::Size( 600, 500 );
      Name = "MyForm";
      Text = "DataGrid Control Sample";
      Controls->Add( clearButton );
      Controls->Add( addStylesButton );
      Controls->Add( selectChoiceButton );
      Controls->Add( myDataGrid );
      Controls->Add( columnNameRadioButton );
      Controls->Add( indexRadioButton );
      Controls->Add( myLabel );
      Controls->Add( myLabel2 );
   }

   void SetUp()
   {
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
   }

   // Create a DataSet with two tables and populate it.
   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ customerTable = gcnew DataTable( "Customers" );
      DataTable^ ordersTable = gcnew DataTable( "Orders" );

      // Create two columns, add them to the first table.
      DataColumn^ customerID = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ customerName = gcnew DataColumn( "CustName" );
      DataColumn^ current = gcnew DataColumn( "Current",bool::typeid );
      customerTable->Columns->Add( customerID );
      customerTable->Columns->Add( customerName );
      customerTable->Columns->Add( current );

      // Create three columns, add them to the second table.
      DataColumn^ customerID2 = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ orderDate = gcnew DataColumn( "OrderDate",DateTime::typeid );
      DataColumn^ orderAmount = gcnew DataColumn( "OrderAmount",Decimal::typeid );
      ordersTable->Columns->Add( orderAmount );
      ordersTable->Columns->Add( customerID2 );
      ordersTable->Columns->Add( orderDate );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( customerTable );
      myDataSet->Tables->Add( ordersTable );

      // Create a DataRelation, add it to the DataSet.
      DataRelation^ myDataRelation = gcnew DataRelation( "custToOrders",customerID,customerID2 );
      myDataSet->Relations->Add( myDataRelation );
      DataRow^ newRow1;
      DataRow^ newRow2;

      // Create three customers in the Customers Table.
      for ( int index = 1; index < 5; index++ )
      {
         newRow1 = customerTable->NewRow();
         newRow1[ "CustID" ] = index;
         newRow1[ "CustName" ] = "Item " + index;
         newRow1[ "Current" ] = true.ToString();

         // Add the row to the Customers table.
         customerTable->Rows->Add( newRow1 );
      }

      // For each customer, create five rows in the Orders table.
      for ( int index = 1; index < 5; index++ )
      {
         for ( int j = 1; j < 6; j++ )
         {
            newRow2 = ordersTable->NewRow();
            newRow2[ "CustID" ] = index;
            newRow2[ "OrderDate" ] = DateTime(2001,index,j * 2);
            newRow2[ "OrderAmount" ] = index * 10 + j * .1;

            // Add the row to the Orders table.
            ordersTable->Rows->Add( newRow2 );
         }
      }
   }

   void AddStyles_Clicked( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myLabel->Text = "Styles added to the grid.";
      if ( TablesAlreadyAdded )
            return;

      AddCustomDataTableStyle();
   }

   void AddCustomDataTableStyle()
   {
      DataGridTableStyle^ tableStyle1 = gcnew DataGridTableStyle;
      tableStyle1->MappingName = "Customers";

      // Set other properties.
      tableStyle1->AlternatingBackColor = Color::LightGray;

      // Add a second column style.
      DataGridColumnStyle^ textBoxColumnStyle = gcnew DataGridTextBoxColumn;
      textBoxColumnStyle->MappingName = "CustName";
      textBoxColumnStyle->HeaderText = "Customer Name";
      textBoxColumnStyle->Width = 100;
      tableStyle1->GridColumnStyles->Add( textBoxColumnStyle );

      // Add a GridColumnStyle and set its MappingName to the name of a DataColumn in the DataTable.
      DataGridColumnStyle^ gridColumnStyle = gcnew DataGridBoolColumn;
      gridColumnStyle->MappingName = "Current";

      // Set the HeaderText and Width properties.
      gridColumnStyle->HeaderText = "IsCurrent Customer";
      gridColumnStyle->Width = 125;
      tableStyle1->GridColumnStyles->Add( gridColumnStyle );

      // Create the second table style with columns.
      DataGridTableStyle^ tableStyle2 = gcnew DataGridTableStyle;
      tableStyle2->MappingName = "Orders";

      // Set other properties.
      tableStyle2->AlternatingBackColor = Color::LightBlue;

      // Create new ColumnStyle Object*.
      DataGridColumnStyle^ orderDate = gcnew DataGridTextBoxColumn;
      orderDate->MappingName = "OrderDate";
      orderDate->HeaderText = "Order Date";
      orderDate->Width = 100;
      tableStyle2->GridColumnStyles->Add( orderDate );

      // Create a formatted column using a PropertyDescriptor.
      PropertyDescriptorCollection^ pcol =
         this->BindingContext[myDataSet, "Customers.custToOrders"]->GetItemProperties();
      DataGridColumnStyle^ csOrderAmount = gcnew DataGridTextBoxColumn( pcol[ "OrderAmount" ],"c",true );
      csOrderAmount->MappingName = "OrderAmount";
      csOrderAmount->HeaderText = "Total";
      csOrderAmount->Width = 100;
      tableStyle2->GridColumnStyles->Add( csOrderAmount );

      // Add the DataGridTableStyle objects to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( tableStyle1 );
      myDataGrid->TableStyles->Add( tableStyle2 );

      // Set the TablesAlreadyAdded to true so we don't try to do this again.
      TablesAlreadyAdded = true;
   }

   void SelectChoice_Clicked( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( columnNameRadioButton->Checked )
            PrintColumnInformationUsingColumnName();
      else
      if ( indexRadioButton->Checked )
            PrintColumnInformationUsingIndex();
   }

   // <Snippet1>
private:
   void Clear_Clicked( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // TablesAlreadyAdded set to false so that table styles can be added again.
      TablesAlreadyAdded = false;
      myLabel->Text = "All Table Styles Cleared.";

      // Clear all the column styles and also table style for the grid.
      IEnumerator^ myEnum = myDataGrid->TableStyles->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridTableStyle^ myTableStyle = safe_cast<DataGridTableStyle^>(myEnum->Current);
         GridColumnStylesCollection^ myColumns = myTableStyle->GridColumnStyles;
         myColumns->Clear();
      }

      myDataGrid->TableStyles->Clear();
   }
   // </Snippet1>

   // <Snippet2>
private:
   void PrintColumnInformationUsingColumnName()
   {
      myLabel->Text = "Table Styles info: No of Styles " + myDataGrid->TableStyles->Count;
      IEnumerator^ myEnum = myDataGrid->TableStyles->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridTableStyle^ myTableStyle = safe_cast<DataGridTableStyle^>(myEnum->Current);
         myLabel->Text = myLabel->Text + "\nTable Name : " + myTableStyle->MappingName;
         GridColumnStylesCollection^ myColumns = myTableStyle->GridColumnStyles;

         // 'myTableStyle->GridColumnStyles[index]->MappingName' specifies the column came for the table.
         for ( int index = 0; index < myColumns->Count; index++ )
            myLabel->Text = myLabel->Text + "\nMapping Name: " +
               myColumns[ myTableStyle->GridColumnStyles[ index ]->MappingName ]->MappingName;
      }
   }
   // </Snippet2>

   // <Snippet3>
private:
   void PrintColumnInformationUsingIndex()
   {
      myLabel->Text = "Table Styles info: No of Styles " + myDataGrid->TableStyles->Count;
      IEnumerator^ myEnum = myDataGrid->TableStyles->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridTableStyle^ myTableStyle = safe_cast<DataGridTableStyle^>(myEnum->Current);
         myLabel->Text = myLabel->Text + "\nTable Name : " + myTableStyle->MappingName;
         GridColumnStylesCollection^ myColumns = myTableStyle->GridColumnStyles;
         for ( int index = 0; index < myColumns->Count; index++ )
            myLabel->Text = myLabel->Text + "\nMapping Name: " + myColumns[ index ]->MappingName;
      }
   }
   // </Snippet3>
};

int main()
{
   Application::Run( gcnew MyForm );
}
