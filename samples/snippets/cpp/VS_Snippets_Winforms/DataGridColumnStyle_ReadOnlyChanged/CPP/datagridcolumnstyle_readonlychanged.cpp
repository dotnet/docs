// System::Windows::Forms::DataGridColumnStyle::ReadOnlyChanged

/*
The following example demonstrates 'ReadOnlyChanged' Event of 'DataGridColumnStyle' class.
It adds DataGrid and Button to a form. When user clicks on button the 'ReadOnly'  property of 'DataGridColumnStyle'
is changed . This raises the 'ReadOnlyChanged' event which then calls the user defined EventHandler function .
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::Data;

public ref class MyForm1: public Form
{
private:
   DataGrid^ myDataGrid;
   Button^ myButton;
   DataSet^ myDataSet;
   DataGridTableStyle^ myDataGridTableStyle;
   DataGridColumnStyle^ myDataGridColumnStyle;
   DataTable^ myDataTable;
   DataColumn^ myDataColumn1;

public:
   MyForm1()
   {
      InitializeComponent();
      SetUp();
   }

private:
   void InitializeComponent()
   {
      myDataGrid = gcnew DataGrid;
      myDataGrid->Location = Point(52,32);
      myDataGrid->Size = System::Drawing::Size( 115, 125 );
      ClientSize = System::Drawing::Size( 215, 273 );
      myButton = gcnew Button;
      myButton->Location = Point(35,210);
      myButton->Size = System::Drawing::Size( 145, 24 );
      myButton->Text = "Make column read only";
      myButton->Click += gcnew EventHandler( this, &MyForm1::Button_Click );
      array<Control^>^temp0 = {myDataGrid,myButton};
      Controls->AddRange( temp0 );
      Name = "MyForm1";
      Text = "DataGridColumnStyle";
   }

   // <Snippet1>
private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myButton->Text->Equals( "Make column read/write" ) )
      {
         myDataGridColumnStyle->ReadOnly = false;
         myButton->Text = "Make column read only";
      }
      else
      {
         myDataGridColumnStyle->ReadOnly = true;
         myButton->Text = "Make column read/write";
      }
   }

   void AddCustomDataTableStyle()
   {
      myDataGridTableStyle = gcnew DataGridTableStyle;
      myDataGridTableStyle->MappingName = "Customers";
      myDataGridColumnStyle = gcnew DataGridTextBoxColumn;
      myDataGridColumnStyle->MappingName = "CustName";
      
      // Add EventHandler function for readonlychanged event.
      myDataGridColumnStyle->ReadOnlyChanged += gcnew EventHandler( this, &MyForm1::myDataGridColumnStyle_ReadOnlyChanged );
      myDataGridColumnStyle->HeaderText = "Customer";
      myDataGridTableStyle->GridColumnStyles->Add( myDataGridColumnStyle );
      
      // Add the 'DataGridTableStyle' instance to the 'DataGrid'.
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
   }

   void myDataGridColumnStyle_ReadOnlyChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "'Readonly' property is changed" );
   }
   // </Snippet1>

   void SetUp()
   {
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
      AddCustomDataTableStyle();
   }

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      myDataTable = gcnew DataTable( "Customers" );
      myDataColumn1 = gcnew DataColumn( "CustName" );
      myDataTable->Columns->Add( myDataColumn1 );
      myDataSet->Tables->Add( myDataTable );
      DataRow^ newRow1;
      for ( int i = 1; i < 4; i++ )
      {
         newRow1 = myDataTable->NewRow();
         
         // Add the row to the customers table.
         myDataTable->Rows->Add( newRow1 );

      }
      myDataTable->Rows[ 0 ][ "custName" ] = "Alpha";
      myDataTable->Rows[ 1 ][ "custName" ] = "Beta";
      myDataTable->Rows[ 2 ][ "custName" ] = "Omega";
   }
};

int main()
{
   Application::Run( gcnew MyForm1 );
}
