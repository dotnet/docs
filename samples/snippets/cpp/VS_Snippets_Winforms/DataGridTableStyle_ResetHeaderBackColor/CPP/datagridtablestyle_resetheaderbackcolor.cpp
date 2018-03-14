// System::Windows::Forms::DataGridTableStyle.ResetHeaderBackColor

/*
The following example demonstrates the 'ResetHeaderBackColor' method of 'DataGridTableStyle' class.
It adds a 'DataGrid' and two buttons to a form. Then it creates a 'DataGridTableStyle' and maps it to the table of
'DataGrid'. When the user clicks on  'Change the ResetHeaderBackColor' button it changes the Header Background
color to light pink. If the user clicks the 'ResetHeaderBackColor' button it changes the Header Background
Color to default color.
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
      myButton = gcnew Button;
      myButton1 = gcnew Button;
      myDataGrid = gcnew DataGrid;
      Text = "DataGridTableStyle Sample";
      ClientSize = System::Drawing::Size( 450, 330 );
      myButton->Location = Point(50,16);
      myButton->Name = "button1";
      myButton->Size = System::Drawing::Size( 176, 23 );
      myButton->TabIndex = 2;
      myButton->Text = "Change the HeaderBackColor";
      myButton->Click += gcnew EventHandler( this, &Form1::Button_Click );
      myButton1->Location = Point(230,16);
      myButton1->Name = "myButton";
      myButton1->Size = System::Drawing::Size( 140, 24 );
      myButton1->TabIndex = 0;
      myButton1->Text = "Reset HeaderBackColor";
      myButton1->Click += gcnew EventHandler( this, &Form1::Button1_Click );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 240, 150 );
      myDataGrid->CaptionText = "DataGridTableStyle";
      Controls->Add( myButton );
      Controls->Add( myDataGrid );
      Controls->Add( myButton1 );
   }

   // <Snippet1>
private:
   void Button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Change the color of 'HeaderBack'.
      myDataTableStyle->HeaderBackColor = Color::LightPink;
   }

   void Button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'HeaderBack' to its origanal color.
      myDataTableStyle->ResetHeaderBackColor();
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
