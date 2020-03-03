// System::Windows::Forms::DataGridTableStyle::ResetGridLineColor

/*
The following example demonstrates the 'ResetGridLineColor'  method of 'DataGridTableStyle' class.
It adds a 'DataGrid' and two buttons to a form. Then it creates a 'DataGridTableStyle' and adds it to the 'DataGrid'.
When the user clicks, the 'Change the GridLineColor' button it changes the GridLineColor to 'blue'. If the user clicks
the 'Reset GridLineColor' button it changes the GridLineColor to  default color.
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
   Button^ myButton1;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   DataGridColumnStyle^ myDataGridColumnStyle;
   DataGridTableStyle^ myDataTableStyle;

public:
   Form1()
   {
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
      this->myButton1 = gcnew Button;
      this->myDataGrid = gcnew DataGrid;
      this->Text = "DataGridTableStyle Sample";
      this->ClientSize = System::Drawing::Size( 450, 330 );
      this->myButton->Location = Point(50,16);
      this->myButton->Name = "button1";
      this->myButton->Size = System::Drawing::Size( 176, 23 );
      this->myButton->TabIndex = 2;
      this->myButton->Text = "Change the GridLineColor";
      this->myButton->Click += gcnew EventHandler( this, &Form1::Button_Click );
      this->myButton1->Location = Point(230,16);
      this->myButton1->Name = "myButton";
      this->myButton1->Size = System::Drawing::Size( 140, 24 );
      this->myButton1->TabIndex = 0;
      this->myButton1->Text = "Reset GridLineColor";
      this->myButton1->Click += gcnew EventHandler( this, &Form1::Button1_Click );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 240, 150 );
      myDataGrid->CaptionText = "DataGridTableStyle";
      this->Controls->Add( myButton );
      this->Controls->Add( myDataGrid );
      this->Controls->Add( myButton1 );
   }

   // <Snippet1>
private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Change the 'GridLineColor'.
      myDataTableStyle->GridLineColor = Color::Blue;
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'GridLineColor' to its orginal color.
      myDataTableStyle->ResetGridLineColor();
   }
   // </Snippet1>

private:
   void AddCustomDataTableStyle()
   {
      // Create a 'DataGridTableStyle'.
      myDataTableStyle = gcnew DataGridTableStyle;
      myDataTableStyle->MappingName = "Customers";

      // Create a 'DataGridColumnStyle'.
      myDataGridColumnStyle = gcnew DataGridTextBoxColumn;
      myDataGridColumnStyle->MappingName = "CustName";
      myDataGridColumnStyle->HeaderText = "Customer Name";
      myDataGridColumnStyle->Width = 150;

      // Add the 'DataGridColumnStyle' to 'DataGridTableStyle'.
      myDataTableStyle->GridColumnStyles->Add( myDataGridColumnStyle );

      // Add the 'DataGridTableStyle' to 'DataGrid'.
      myDataGrid->TableStyles->Add( myDataTableStyle );
   }

   // Create a DataSet with two tables and populate it.
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
