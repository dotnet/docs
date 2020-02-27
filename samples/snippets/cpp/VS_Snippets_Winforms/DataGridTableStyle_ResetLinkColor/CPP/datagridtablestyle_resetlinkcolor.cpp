// System::Windows::Forms::DataGridTableStyle::ResetLinkColor

/* The following program demonstrates the 'ResetLinkColor'
of 'System::Windows::Forms::DataGridTableStyle' class.
It creates a windows form, a 'DataSet' containing two 'DataTable'
objects, and a 'DataRelation' that relates the two tables. To
display the data, a 'DataGrid' control is then bound to the
'DataSet' through the 'SetDataBinding' method.
DataGridTableStyle is attached to one of 'DataTable'.
Buttons are provided on form to demonstrate setting link color
and 'ResetLinkColor' method.
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

namespace DataGridSample
{

   /// <summary>
   /// Summary description for DatGridClass.
   /// </summary>
   public ref class DatGridClass: public System::Windows::Forms::Form
   {
   private:
      DataSet^ myDataSet;
      System::Windows::Forms::DataGrid^ myDataGrid;
      System::Windows::Forms::GroupBox^ groupBox3;
      System::Windows::Forms::Button^ btnResetLinkColor;
      System::Windows::Forms::Button^ btnSetLinkColor;
      DataGridTableStyle^ myDataGridTableStyle;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      DatGridClass()
      {
         components = nullptr;
         myDataGridTableStyle = gcnew DataGridTableStyle;
         
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         
         // Setup GridControl data.
         SetUp();
      }

   public:

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      ~DatGridClass()
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
         this->btnSetLinkColor = gcnew System::Windows::Forms::Button;
         this->myDataGrid = gcnew System::Windows::Forms::DataGrid;
         this->btnResetLinkColor = gcnew System::Windows::Forms::Button;
         this->groupBox3 = gcnew System::Windows::Forms::GroupBox;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->BeginInit();
         this->groupBox3->SuspendLayout();
         this->SuspendLayout();

         //
         // btnSetLinkColor
         //
         this->btnSetLinkColor->Location = System::Drawing::Point( 16, 16 );
         this->btnSetLinkColor->Name = "btnSetLinkColor";
         this->btnSetLinkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnSetLinkColor->TabIndex = 4;
         this->btnSetLinkColor->Text = "Set Link Color";
         this->btnSetLinkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetLinkColor_Click );

         //
         // myDataGrid
         //
         this->myDataGrid->DataMember = "";
         this->myDataGrid->ForeColor = System::Drawing::Color::Blue;
         this->myDataGrid->Location = System::Drawing::Point( 12, 32 );
         this->myDataGrid->Name = "myDataGrid";
         this->myDataGrid->ReadOnly = true;
         this->myDataGrid->Size = System::Drawing::Size( 272, 192 );
         this->myDataGrid->TabIndex = 6;

         //
         // btnResetLinkColor
         //
         this->btnResetLinkColor->Location = System::Drawing::Point( 16, 48 );
         this->btnResetLinkColor->Name = "btnResetLinkColor";
         this->btnResetLinkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnResetLinkColor->TabIndex = 1;
         this->btnResetLinkColor->Text = "Reset Link Color";
         this->btnResetLinkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetLinkColor_Click );

         //
         // groupBox3
         //
         array<System::Windows::Forms::Control^>^groupBox3Controls = {this->btnSetLinkColor,this->btnResetLinkColor};
         this->groupBox3->Controls->AddRange( groupBox3Controls );
         this->groupBox3->Location = System::Drawing::Point( 80, 232 );
         this->groupBox3->Name = "groupBox3";
         this->groupBox3->Size = System::Drawing::Size( 136, 88 );
         this->groupBox3->TabIndex = 7;
         this->groupBox3->TabStop = false;

         //
         // DatGridClass
         //
         this->ClientSize = System::Drawing::Size( 312, 341 );
         array<System::Windows::Forms::Control^>^formControls = {this->groupBox3,this->myDataGrid};
         this->Controls->AddRange( formControls );
         this->Name = "DatGridClass";
         this->Text = "Sample Program";
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->EndInit();
         this->groupBox3->ResumeLayout( false );
         this->ResumeLayout( false );
      }

      void SetUp()
      {
         // Create a 'DataSet' with two tables and one relation.
         MakeDataSet();
         
         // Bind the 'DataGrid' to the 'DataSet'.
         myDataGrid->SetDataBinding( myDataSet, "Customers" );
      }

      // Create a 'DataSet' with two tables and populate it.
      void MakeDataSet()
      {
         // Create a 'DataSet'.
         myDataSet = gcnew DataSet( "myDataSet" );
         
         // Create two 'DataTables'.
         DataTable^ tCust = gcnew DataTable( "Customers" );
         DataTable^ tOrders = gcnew DataTable( "Orders" );

         // Create two columns, and add them to the first table.
         DataColumn^ cCustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cCustName = gcnew DataColumn( "CustName" );
         DataColumn^ cCurrent = gcnew DataColumn( "Current",bool::typeid );
         tCust->Columns->Add( cCustID );
         tCust->Columns->Add( cCustName );
         tCust->Columns->Add( cCurrent );

         // Map 'myDataGridTableStyle' to 'Customers' table.
         myDataGridTableStyle->MappingName = "Customers";

         // Add the DataGridTableStyle objects to the collection.
         myDataGrid->TableStyles->Add( myDataGridTableStyle );

         // Create three columns and add them to the second table.
         DataColumn^ cID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cOrderDate = gcnew DataColumn( "OrderDate",DateTime::typeid );
         DataColumn^ cOrderAmount = gcnew DataColumn( "OrderAmount",String::typeid );
         tOrders->Columns->Add( cID );
         tOrders->Columns->Add( cOrderAmount );
         tOrders->Columns->Add( cOrderDate );

         // Add the tables to the 'DataSet'.
         myDataSet->Tables->Add( tCust );
         myDataSet->Tables->Add( tOrders );

         // Create a 'DataRelation' and add it to the 'DataSet'.
         DataRelation^ dr = gcnew DataRelation( "custToOrders",cCustID,cID );
         myDataSet->Relations->Add( dr );

         // Populate the tables.
         // Create two 'DataRow' variables for customer and order.
         DataRow^ newRow1;
         DataRow^ newRow2;

         // Create three customers in the 'Customers Table'.
         for ( int i = 1; i < 4; i++ )
         {
            newRow1 = tCust->NewRow();
            newRow1[ "custID" ] = i;
            
            // Add the row to the 'Customers Table'.
            tCust->Rows->Add( newRow1 );
         }
         tCust->Rows[ 0 ][ "custName" ] = "Customer1";
         tCust->Rows[ 1 ][ "custName" ] = "Customer2";
         tCust->Rows[ 2 ][ "custName" ] = "Customer3";

         // Give the current column a value.
         tCust->Rows[ 0 ][ "Current" ] = true.ToString();
         tCust->Rows[ 1 ][ "Current" ] = true.ToString();
         tCust->Rows[ 2 ][ "Current" ] = false.ToString();

         // For each customer, create five rows in the orders table.
         double myNumber = 0;
         String^ myString;
         for ( int i = 1; i < 4; i++ )
         {
            for ( int j = 1; j < 6; j++ )
            {
               newRow2 = tOrders->NewRow();
               newRow2[ "CustID" ] = i;
               newRow2[ "orderDate" ] = DateTime(2001,i,j * 2);
               myNumber = i * 10 + j * .1;
               myString = String::Concat( "$ ", myNumber.ToString() );
               newRow2[ "OrderAmount" ] = myString;
               
               // Add the row to the orders table.
               tOrders->Rows->Add( newRow2 );
            }
         }
      }

      void btnResetLinkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet1>
         // String variable used to show message.
         String^ myString = "Link color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGridTableStyle->LinkColor;
         myString = String::Concat( myString, myCurrentColor );

         // Reset link color to default.
         myDataGridTableStyle->ResetLinkColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGridTableStyle->LinkColor );

         // Show information about changes in color setting.
         MessageBox::Show( myString, "Link line color information" );
         // </Snippet1>
      }

      void btnSetLinkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help.
         myColorDialog->ShowHelp = true;

         // Set the initial color select to the current color.
         myColorDialog->Color = myDataGridTableStyle->LinkColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set link color to selected color.
         myDataGridTableStyle->LinkColor = myColorDialog->Color;
      }
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew DataGridSample::DatGridClass );
}
