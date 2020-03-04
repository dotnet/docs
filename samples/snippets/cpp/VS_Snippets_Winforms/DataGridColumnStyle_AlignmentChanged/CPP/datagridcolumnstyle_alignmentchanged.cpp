// System::Windows::Forms::DataGridColumnStyle::AlignmentChanged

/*
The following example demonstrates the 'AlignmentChanged' event of 'DataGridColumnStyle' class.
It adds a DataGrid and a button to a form. Then it creates a 'DataGridColumnStyle' Object*  and
adds an eventhandler for the 'AlignmentChanged' event. When  user clicks the 'Change Alignment'
button it changes the alignment of the 'DataGridColumnStyle' and the 'AlignmentChanged' event is
raised.
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

public ref class Form1: public Form
{
private:
   Button^ myButton;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   DataGridColumnStyle^ myDataGridColumnStyle;

public:
   Form1()
   {
      myMessage = nullptr;
      InitializeComponent();
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
      AddCustomDataTableStyle();
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      this->myButton = gcnew Button;
      this->myDataGrid = gcnew DataGrid;
      this->Text = "DataGrid Control Sample";
      this->ClientSize = System::Drawing::Size( 450, 330 );
      myButton->Location = Point(150,16);
      myButton->Size = System::Drawing::Size( 120, 24 );
      myButton->Text = "Change Alignment";
      myButton->Click += gcnew EventHandler( this, &Form1::Button_Click );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 300, 200 );
      myDataGrid->CaptionText = "DataGridColumnStyle";
      this->Controls->Add( myButton );
      this->Controls->Add( myDataGrid );
   }

   String^ myMessage;

   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGridColumnStyle->Alignment = HorizontalAlignment::Center;
      MessageBox::Show( myMessage );
   }

   // <Snippet1>
private:
   void AlignmentChanged_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myMessage = "Alignment has been Changed";
   }

   void AddCustomDataTableStyle()
   {
      // Create a 'DataGridTableStyle'.
      DataGridTableStyle^ myDataTableStyle = gcnew DataGridTableStyle;
      myDataTableStyle->MappingName = "Customers";

      // Create a 'DataGridColumnStyle'.
      myDataGridColumnStyle = gcnew DataGridTextBoxColumn;
      myDataGridColumnStyle->MappingName = "CustName";
      myDataGridColumnStyle->HeaderText = "Customer Name";
      myDataGridColumnStyle->Width = 250;
      myDataGridColumnStyle->AlignmentChanged += gcnew EventHandler( this, &Form1::AlignmentChanged_Click );

      // Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
      myDataTableStyle->GridColumnStyles->Add( myDataGridColumnStyle );

      // Add the 'DataGridTableStyle' to 'DataGrid'.
      myDataGrid->TableStyles->Add( myDataTableStyle );
   }
   // </Snippet1>

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myTable = gcnew DataTable( "Customers" );
      DataColumn^ myColumn = gcnew DataColumn( "CustName",String::typeid );
      myTable->Columns->Add( myColumn );
      myDataSet->Tables->Add( myTable );
      DataRow^ newRow1;
      for ( int i = 0; i < 5; i++ )
      {
         newRow1 = myTable->NewRow();
         newRow1[ "CustName" ] = i;
         
         // Add the row to the Customers table.
         myTable->Rows->Add( newRow1 );
      }
      myTable->Rows[ 0 ][ "CustName" ] = "Jones";
      myTable->Rows[ 1 ][ "CustName" ] = "James";
      myTable->Rows[ 2 ][ "CustName" ] = "David";
      myTable->Rows[ 3 ][ "CustName" ] = "Robert";
      myTable->Rows[ 4 ][ "CustName" ] = "John";
   }
};

int main()
{
   Application::Run( gcnew Form1 );
}
