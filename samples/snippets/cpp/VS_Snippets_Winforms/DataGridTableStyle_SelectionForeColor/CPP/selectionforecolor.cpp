// System::Windows::Forms::DataGridTableStyle::SelectionForeColor
// System::Windows::Forms::DataGridTableStyle::ResetSelectionForeColor

/* The following program demonstrates the use of 'SelectionForeColor'
property  and 'ResetSelectionForeColor' method of
'System::Windows::Forms::DataGridTableStyle'.
It creates a windows form, a 'DataSet' containing one 'DataTable'
Object*. A 'DataGridTableStyle' is attached to 'DataTable'.
To display the data, a 'DataGrid' control is then bound to the
'DataSet' through the 'SetDataBinding' method.
Two button are provided on form to show 'SelectionForeColor' and
'ResetSelectionForeColor'.
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

namespace MyDataGridNamespace
{
   public ref class MyForm: public System::Windows::Forms::Form
   {
   private:
      System::ComponentModel::Container^ components;
      DataGridTableStyle^ customersStyle;
      System::Windows::Forms::GroupBox^ groupBox1;
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::Button^ button2;
      System::Windows::Forms::DataGrid^ myDataGrid;

   public:
      MyForm()
      {
         components = nullptr;
         customersStyle = gcnew DataGridTableStyle;
         InitializeComponent();
      }

   public:
      ~MyForm()
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
         this->myDataGrid = gcnew System::Windows::Forms::DataGrid;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->button2 = gcnew System::Windows::Forms::Button;
         this->groupBox1 = gcnew System::Windows::Forms::GroupBox;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->BeginInit();
         this->groupBox1->SuspendLayout();
         this->SuspendLayout();

         //
         // myDataGrid
         //
         this->myDataGrid->DataMember = "";
         this->myDataGrid->Location = System::Drawing::Point( 32, 16 );
         this->myDataGrid->Name = "dataGrid1";
         this->myDataGrid->Size = System::Drawing::Size( 232, 144 );
         this->myDataGrid->TabIndex = 0;

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 16, 16 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 144, 24 );
         this->button1->TabIndex = 0;
         this->button1->Text = "SetSelectionForeColor";
         this->button1->Click += gcnew System::EventHandler( this, &MyForm::button1_Click );

         //
         // button2
         //
         this->button2->Location = System::Drawing::Point( 16, 40 );
         this->button2->Name = "button2";
         this->button2->Size = System::Drawing::Size( 144, 24 );
         this->button2->TabIndex = 1;
         this->button2->Text = "ResetSelectionForeColor";
         this->button2->Click += gcnew System::EventHandler( this, &MyForm::button2_Click );

         //
         // groupBox1
         //
         array<System::Windows::Forms::Control^>^groupBox1Controls = {this->button2,this->button1};
         this->groupBox1->Controls->AddRange( groupBox1Controls );
         this->groupBox1->Location = System::Drawing::Point( 64, 168 );
         this->groupBox1->Name = "groupBox1";
         this->groupBox1->Size = System::Drawing::Size( 176, 80 );
         this->groupBox1->TabIndex = 1;
         this->groupBox1->TabStop = false;

         //
         // MyForm
         //
         this->ClientSize = System::Drawing::Size( 320, 266 );
         array<System::Windows::Forms::Control^>^formControls = {this->groupBox1,this->myDataGrid};
         this->Controls->AddRange( formControls );
         this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
         this->Name = "MyForm";
         this->Text = "MyForm";
         this->Load += gcnew System::EventHandler( this, &MyForm::MyFormLoad );
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->EndInit();
         this->groupBox1->ResumeLayout( false );
         this->ResumeLayout( false );
      }

      void MyFormLoad( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         myDataGrid->SetDataBinding( MakeDataSet(), "Customers" );
         
         // Add data grid control to form.
         Controls->Add( myDataGrid );
      }

      DataSet^ MakeDataSet()
      {
         // Create a DataSet.
         DataSet^ myDataSet = gcnew DataSet( "myDataSet" );

         // Create two DataTables.
         DataTable^ tCustomers = gcnew DataTable( "Customers" );

         // Map 'CustomersStyle' to 'Customers' table.
         customersStyle->MappingName = "Customers";

         // Add the DataGridTableStyle objects to the collection.
         myDataGrid->TableStyles->Add( customersStyle );

         // Create two columns and add them to the first table.
         DataColumn^ cCustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cCustName = gcnew DataColumn( "CustName" );
         DataColumn^ cCurrent = gcnew DataColumn( "Current",bool::typeid );
         tCustomers->Columns->Add( cCustID );
         tCustomers->Columns->Add( cCustName );
         tCustomers->Columns->Add( cCurrent );

         // Create three columns, and add them to the second table.
         DataColumn^ cID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cOrderDate = gcnew DataColumn( "orderDate",DateTime::typeid );
         DataColumn^ cOrderAmount = gcnew DataColumn( "OrderAmount",Decimal::typeid );

         // Add the tables to the DataSet.
         myDataSet->Tables->Add( tCustomers );

         // Populate the tables.
         // Create two DataRow variables for each customer and order.
         DataRow^ newRow1;

         // Create three customers in the Customers Table.
         for ( int i = 1; i < 4; i++ )
         {
            newRow1 = tCustomers->NewRow();
            newRow1[ "custID" ] = i;
            
            // Add the row to the Customers table.
            tCustomers->Rows->Add( newRow1 );
         }
         tCustomers->Rows[ 0 ][ "custName" ] = "Customer 1";
         tCustomers->Rows[ 1 ][ "custName" ] = "Customer 2";
         tCustomers->Rows[ 2 ][ "custName" ] = "Customer 3";

         // Give the Current column a value.
         tCustomers->Rows[ 0 ][ "Current" ] = true.ToString();
         tCustomers->Rows[ 1 ][ "Current" ] = true.ToString();
         tCustomers->Rows[ 2 ][ "Current" ] = false.ToString();
         return myDataSet;
      }

      void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet1>
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help.
         myColorDialog->ShowHelp = true;

         // Set the initial color select to the current color.
         myColorDialog->Color = customersStyle->SelectionForeColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set selection fore color to selected color.
         customersStyle->SelectionForeColor = myColorDialog->Color;
         // </Snippet1>
      }

      void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet2>
         // String variable used to show message.
         String^ myString = "Fore color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = customersStyle->SelectionForeColor;
         myString = String::Concat( myString, myCurrentColor );

         // Reset selection fore color to default.
         customersStyle->ResetSelectionForeColor();
         myString = String::Concat( myString, "  to " );
         myString = String::Concat( myString, customersStyle->SelectionForeColor );

         // Show information about changes in color setting.
         MessageBox::Show( myString, "Selection fore color information" );
         // </Snippet2>
      }
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew MyDataGridNamespace::MyForm );
}
