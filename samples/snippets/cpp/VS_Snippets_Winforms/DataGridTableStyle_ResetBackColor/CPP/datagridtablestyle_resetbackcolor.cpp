// System::Windows::Forms::DataGridTableStyle::ResetBackColor

/*
The following example demonstrates the 'ResetBackColor' method of 'DataGridTableStyle' class.
A  DataGrid and  a button are added to 'Form'. The initial back color of the DataGridTableStyle is set to
pink. When the user clicks on 'ResetBackColor' button, then the value of DataGridBackColor is set to its
default value.
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
   Button^ myButton1;
   DataSet^ myDataSet;
   DataGridTableStyle^ myTableStyle;
   DataGridColumnStyle^ myColumnStyle;

public:
   MyForm()
   {
      InitializeComponent();
      
      // Create a DataSet with a table.
      MakeDataSet();
      
      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "customerTable" );
      AddCustomColumnStyle();
   }

private:

   // Initialilze form and its controls.
   void InitializeComponent()
   {
      myDataGrid = gcnew DataGrid;
      myTableStyle = gcnew DataGridTableStyle;
      myColumnStyle = gcnew DataGridTextBoxColumn;
      myButton1 = gcnew Button;
      myDataGrid->Location = Point(24,24);
      myDataGrid->Name = "myDataGrid";
      myDataGrid->CaptionText = "DataGridColumn ";
      myDataGrid->Size = System::Drawing::Size( 150, 153 );
      myDataGrid->TabIndex = 0;
      myButton1->Location = Point(16,184);
      myButton1->Name = "myButton1";
      myButton1->Size = System::Drawing::Size( 112, 23 );
      myButton1->TabIndex = 1;
      myButton1->Text = "Reset BackColor";
      myButton1->Click += gcnew EventHandler( this, &MyForm::myButton1_Click );
      ClientSize = System::Drawing::Size( 360, 273 );
      array<Control^>^temp0 = {myButton1,myDataGrid};
      Controls->AddRange( temp0 );
      Name = "Form1";
      Text = "Reset BackColor";
      ResumeLayout( false );
   }

   // <Snippet1>
private:
   void AddCustomColumnStyle()
   {
      // Set the TableStyle Mapping name.
      myTableStyle->MappingName = "customerTable";
      myTableStyle->BackColor = Color::Pink;
      
      // Set the ColumnStyle properties and add to TableStyle.
      myColumnStyle->MappingName = "Customers";
      myColumnStyle->HeaderText = "Customer Name";
      myColumnStyle->Width = 250;
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   void myButton1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the background color.
      myTableStyle->ResetBackColor();
   }
   // </Snippet1>

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ customerTable = gcnew DataTable( "customerTable" );
      DataColumn^ customerName = gcnew DataColumn( "Customers" );
      customerTable->Columns->Add( customerName );
      myDataSet->Tables->Add( customerTable );
      DataRow^ newRow1;
      for ( int i = 1; i < 6; i++ )
      {
         newRow1 = customerTable->NewRow();
         newRow1[ "Customers" ] = i;
         
         // Add the row to the Customers table.
         customerTable->Rows->Add( newRow1 );

      }
      customerTable->Rows[ 0 ][ "Customers" ] = "Alpha";
      customerTable->Rows[ 1 ][ "Customers" ] = "Beta";
      customerTable->Rows[ 2 ][ "Customers" ] = "Omega";
      customerTable->Rows[ 3 ][ "Customers" ] = "Cust1";
      customerTable->Rows[ 4 ][ "Customers" ] = "Cust2";
   }
};

int main()
{
   Application::Run( gcnew MyForm );
}
