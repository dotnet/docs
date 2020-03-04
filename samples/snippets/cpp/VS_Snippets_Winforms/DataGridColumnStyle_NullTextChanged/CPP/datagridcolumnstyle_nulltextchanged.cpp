// System::Windows::Forms::DataGridColumnStyle::NullTextChanged

/*
The following example demonstrates the 'NullTextChanged' event of 'DataGridColumnStyle' class.
It adds  a DataGrid and a Button::to a 'Form'. When user clicks the 'Delete Column values' button,
the column becomes empty and  'NullTextChanged' event is raised  which is handled by event handler
function.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;

public ref class MyForm: public Form
{
private:
   DataGrid^ myDataGrid;
   Button^ myButton;
   DataSet^ myDataSet;
   DataGridTableStyle^ myTableStyle;
   DataGridCell myCell;
   DataGridColumnStyle^ myColumnStyle;
   CurrencyManager^ myCurrencyManager;

public:
   int myRowcount;
   MyForm()
   {
      InitializeComponent();
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "CustTable" );
      myCurrencyManager = dynamic_cast<CurrencyManager^>(this->BindingContext[myDataSet, "CustTable"]);
   }

private:
   void InitializeComponent()
   {
      myDataGrid = gcnew DataGrid;
      myCell = DataGridCell(0,0);
      myButton = gcnew Button;
      myDataGrid->Location = Point(24,24);
      myDataGrid->Name = "myDataGrid";
      myDataGrid->CaptionText = "DataGridColumn ";
      myDataGrid->Size = System::Drawing::Size( 130, 93 );
      myButton->Location = Point(60,208);
      myButton->Size = System::Drawing::Size( 130, 20 );
      myButton->Text = "Delete Column Values";
      myButton->Click += gcnew EventHandler( this, &MyForm::button_Click );
      ClientSize = System::Drawing::Size( 360, 273 );
      array<Control^>^temp0 = {myButton,myDataGrid};
      Controls->AddRange( temp0 );
      Text = "NullTextChanged ";
   }

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ custTable = gcnew DataTable( "CustTable" );
      DataColumn^ custName = gcnew DataColumn( "Customers" );
      custTable->Columns->Add( custName );
      
      // Add the tables to the DataSet.
      myDataSet->Tables->Add( custTable );
      
      // Create a DataRow variable.
      DataRow^ newRow1;
      for ( int i = 1; i < 4; i++ )
      {
         newRow1 = custTable->NewRow();
         newRow1[ "Customers" ] = i;
         
         // Add the row to the Customers table.
         custTable->Rows->Add( newRow1 );

      }
      custTable->Rows[ 0 ][ "Customers" ] = "Alpha";
      custTable->Rows[ 1 ][ "Customers" ] = "Beta";
      custTable->Rows[ 2 ][ "Customers" ] = "Omega";
      AddCustomColumnStyle();
   }

   // <Snippet1>
private:
   void AddCustomColumnStyle()
   {
      myTableStyle = gcnew DataGridTableStyle;
      myColumnStyle = gcnew DataGridTextBoxColumn;
      myColumnStyle->NullTextChanged += gcnew EventHandler( this, &MyForm::columnStyle_NullTextChanged );
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   // NullTextChanged event handler of DataGridColumnStyle.
   void columnStyle_NullTextChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      for ( int i = 0; i < myRowcount; i++ )
      {
         myCell.RowNumber = i;
         myDataGrid[ myCell ] = nullptr;

      }
      MessageBox::Show( "NullTextChanged Event is handled" );
   }
   // </Snippet1>

   void button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myRowcount = myCurrencyManager->Count;
      
      // Set the column to 0 reference.
      for ( int i = 0; i < myRowcount; i++ )
      {
         myCell.RowNumber = i;
         myDataGrid[ myCell ] = "";

      }
      myColumnStyle->NullText = nullptr;
   }
};

int main()
{
   Application::Run( gcnew MyForm );
}
