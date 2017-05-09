// System::Windows::Forms::DataGridTableStyle::ResetAlternatingBackColor

/*
The following example demonstrates the 'ResetAlternatingBackColor' method of 'DataGridTableStyle' class.
It adds a 'DataGrid' and two buttons to a form. The instance of 'DataGridTableStyle' is mapped
to a table of DataGrid. One button sets the Alternating background color of 'DataGrid' and other resets
it to its default value.
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

public ref class DataGridTableStyle_resetcolor: public Form
{
private:
   DataGridTableStyle^ myDataGridTableStyle;
   DataGrid^ myDataGrid;
   Button^ myButton1;
   Button^ myButton2;
   void InitializeComponent()
   {
      myButton1 = gcnew Button;
      myButton2 = gcnew Button;
      myDataGrid = gcnew DataGrid;
      myButton1->Location = Point(56,184);
      myButton1->Size = System::Drawing::Size( 176, 24 );
      myButton1->Text = "Alternating back color ";
      myButton1->Click += gcnew EventHandler( this, &DataGridTableStyle_resetcolor::myButton1_Click );
      myButton2->Location = Point(56,224);
      myButton2->Size = System::Drawing::Size( 184, 24 );
      myButton2->Text = "Reset";
      myButton2->Click += gcnew EventHandler( this, &DataGridTableStyle_resetcolor::myButton2_Click );
      myDataGrid->LinkColor = SystemColors::Desktop;
      myDataGrid->Location = Point(56,32);
      myDataGrid->Name = "myDataGrid";
      myDataGrid->Size = System::Drawing::Size( 168, 144 );
      myDataGrid->TabIndex = 1;
      ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^temp0 = {myButton2,myDataGrid,myButton1};
      Controls->AddRange( temp0 );
      Text = "Test DataGridTableStyle::ResetAlternatingBackColor method";
      Load += gcnew EventHandler( this, &DataGridTableStyle_resetcolor::DataGridTableStyle_Reset_color );
   }

public:
   DataGridTableStyle_resetcolor()
   {
      myDataGridTableStyle = gcnew DataGridTableStyle;
      InitializeComponent();

      // Create and bind DataSet to DataGrid.
      CreateDataSet();
   }

private:
   void CreateDataSet()
   {
      // Create a DataSet
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );

      // Create a DataTable.
      DataTable^ myEmpTable = gcnew DataTable( "Employee" );
      DataColumn^ myEmpID = gcnew DataColumn( "EmpID",int::typeid );
      myEmpTable->Columns->Add( myEmpID );

      // Add the table to the DataSet.
      myDataSet->Tables->Add( myEmpTable );
      DataRow^ newRow1;
      for ( int i = 1; i < 6; i++ )
      {
         newRow1 = myEmpTable->NewRow();
         newRow1[ "EmpID" ] = i;
         
         // Add the row to the Employee table.
         myEmpTable->Rows->Add( newRow1 );
      }
      
      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Employee" );
   }

   void DataGridTableStyle_Reset_color( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGridTableStyle->MappingName = "Employee";
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
   }

   // <Snippet1>
private:
   void myButton1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      //Set the 'AlternatingBackColor'.
      myDataGridTableStyle->AlternatingBackColor = Color::Blue;
   }

   void myButton2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the 'AlternatingBackColor'.
      myDataGridTableStyle->ResetAlternatingBackColor();
   }
   // </Snippet1>
};

int main()
{
   Application::Run( gcnew DataGridTableStyle_resetcolor );
}
