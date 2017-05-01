// System::Windows::Forms::DataGridTableStyle::LinkColor;
// System::Windows::Forms::DataGridTableStyle::HeaderFont;
// System::Windows::Forms::DataGridTableStyle::LinkColorChanged;
// System::Windows::Forms::DataGridTableStyle::HeaderFontChanged;

/* The following example demonstrates the properties 'LinkColor', 'HeaderFont'
and Events 'LinkColorChanged', 'HeaderFontChanged' of DataGridTableStyle.
The following program creates a Windows form, a DataSet containing two DataTable objects,
and a DataRelation that relates the two tables. A button on the form changes the appearance
of the grid by setting the linkcolor and headerfont.
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
      System::Windows::Forms::DataGridTableStyle^ myDataGridTableStyle2;
      DataSet^ myDataSet;
      System::Windows::Forms::Button^ btnApplyStyles;
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

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      void InitializeComponent()
      {
         this->btnApplyStyles = gcnew System::Windows::Forms::Button;
         this->myDataGrid = gcnew System::Windows::Forms::DataGrid;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->BeginInit();
         this->SuspendLayout();

         //
         // btnApplyStyles
         //
         this->btnApplyStyles->Font = gcnew System::Drawing::Font( "Arial",8.25F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
         this->btnApplyStyles->Location = System::Drawing::Point( 88, 208 );
         this->btnApplyStyles->Name = "btnApplyStyles";
         this->btnApplyStyles->Size = System::Drawing::Size( 144, 40 );
         this->btnApplyStyles->TabIndex = 1;
         this->btnApplyStyles->Text = "Apply Custom  Styles";
         this->btnApplyStyles->Click += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::btnApplyStyles_Click );

         //
         // myDataGrid
         //
         this->myDataGrid->BackColor = System::Drawing::SystemColors::Info;
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
         this->ClientSize = System::Drawing::Size( 440, 273 );
         array<System::Windows::Forms::Control^>^formControls = {this->btnApplyStyles,this->myDataGrid};
         this->Controls->AddRange( formControls );
         this->Name = "DataGridTableStyle_Sample";
         this->Text = "DataGridTableStyle_Sample";
         this->Load += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::DataGridTableStyle_Sample_Load );
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->EndInit();
         this->ResumeLayout( false );
      }

      void DataGridTableStyle_Sample_Load( Object^ /*sender*/, EventArgs^ /*e*/ ){}

      void SetUp()
      {
         // Create a DataSet with two tables and one relation.
         MakeDataSet();

         // Bind the DataGrid to the DataSet.
         myDataGrid->SetDataBinding( myDataSet, "Customers" );
      }

      // <Snippet1>
      // <Snippet2>
      // <Snippet3>
      // <Snippet4>
   private:
      void AddCustomDataTableStyle()
      {
         myDataGridTableStyle1 = gcnew DataGridTableStyle;
         myDataGridTableStyle2 = gcnew DataGridTableStyle;
         MessageBox::Show( String::Concat( "LinkColor Before : ", myDataGridTableStyle1->LinkColor ) );
         MessageBox::Show( String::Concat( "HeaderFont Before : ", myDataGridTableStyle1->HeaderFont ) );
         myDataGridTableStyle1->LinkColorChanged += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::LinkColorChanged_Handler );
         myDataGridTableStyle1->HeaderFontChanged += gcnew System::EventHandler( this, &DataGridTableStyle_Sample::HeaderFontChanged_Handler );
         myDataGridTableStyle1->MappingName = "Customers";

         // Set other properties.
         myDataGridTableStyle1->AlternatingBackColor = Color::LightGray;
         myDataGridTableStyle1->LinkColor = Color::Red;
         myDataGridTableStyle1->HeaderFont = gcnew System::Drawing::Font( "Verdana",8.25F,System::Drawing::FontStyle::Bold,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );

         // Add a GridColumnStyle and set its MappingName.
         DataGridColumnStyle^ myBoolCol = gcnew DataGridBoolColumn;
         myBoolCol->MappingName = "Current";
         myBoolCol->HeaderText = "IsCurrent Customer";
         myBoolCol->Width = 150;
         myDataGridTableStyle1->GridColumnStyles->Add( myBoolCol );

         // Add a second column style.
         DataGridColumnStyle^ myTextCol = gcnew DataGridTextBoxColumn;
         myTextCol->MappingName = "custName";
         myTextCol->HeaderText = "Customer Name";
         myTextCol->Width = 250;
         myDataGridTableStyle1->GridColumnStyles->Add( myTextCol );

         // Create new ColumnStyle objects
         DataGridColumnStyle^ cOrderDate = gcnew DataGridTextBoxColumn;
         cOrderDate->MappingName = "OrderDate";
         cOrderDate->HeaderText = "Order Date";
         cOrderDate->Width = 100;

         // PropertyDescriptor to create a formatted column.
         PropertyDescriptorCollection^ myPropertyDescriptorCollection = this->BindingContext[myDataSet, "Customers.custToOrders"]->GetItemProperties();
         DataGridColumnStyle^ csOrderAmount = gcnew DataGridTextBoxColumn( myPropertyDescriptorCollection[ "OrderAmount" ],"c",true );
         csOrderAmount->MappingName = "OrderAmount";
         csOrderAmount->HeaderText = "Total";
         csOrderAmount->Width = 100;

         // Add the DataGridTableStyle instances to GridTableStylesCollection.
         myDataGrid->TableStyles->Add( myDataGridTableStyle1 );
      }

      void LinkColorChanged_Handler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( "LinkColor changed to 'RED'", "DataGridTableStyle" );
      }

      void HeaderFontChanged_Handler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( "HeaderFont changed to 'VERDANA'", "DataGridTableStyle" );
      }
      // </Snippet4>
      // </Snippet3>
      // </Snippet2>
      // </Snippet1>

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

      void btnApplyStyles_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         AddCustomDataTableStyle();
         btnApplyStyles->Enabled = false;
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew SampleDataGridTableStyle::DataGridTableStyle_Sample );
}
