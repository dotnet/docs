// System::Windows::Forms::DataGridTableStyle::ReadOnlyChanged

/*
The following example demonstrates the 'ReadOnlyChanged' event of 'DataGridTableStyle' class.
It adds a DataGrid and checkbox to a Form. When  the Check box is checked, the 'ReadOnly' property of
'DataGridTableStyle' is changed.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class Form1: public Form
{
private:
   DataSet^ myDataSet1;
   CheckBox^ myCheckBox1;
   DataGrid^ myDataGrid1;
   DataGridTableStyle^ myDataGridTableStyle;

public:
   Form1()
   {
      InitializeComponent();
      MakeDataSet();
      AddTableStyle();
   }

private:
   void InitializeComponent()
   {
      myDataGrid1 = gcnew DataGrid;
      myCheckBox1 = gcnew CheckBox;
      SuspendLayout();
      myDataGrid1->DataMember = "";
      myDataGrid1->Location = Point(72,64);
      myDataGrid1->Name = "myDataGrid1";
      myDataGrid1->Size = System::Drawing::Size( 208, 128 );
      myDataGrid1->TabIndex = 0;
      myCheckBox1->Location = Point(304,112);
      myCheckBox1->Name = "myCheckBox1";
      myCheckBox1->TabIndex = 1;
      myCheckBox1->Text = "Read Only";
      myCheckBox1->CheckedChanged += gcnew EventHandler( this, &Form1::myCheckBox1_CheckedChanged );
      ClientSize = System::Drawing::Size( 472, 273 );
      array<Control^>^temp0 = {myCheckBox1,myDataGrid1};
      Controls->AddRange( temp0 );
      Name = "Form1";
      Text = "Test \'ReadOnleChanged\' Event of \'DataGridTableStyle\' class";
      ResumeLayout( false );
   }

   // Create a DataSet with a table and populate it.
   void MakeDataSet()
   {
      myDataSet1 = gcnew DataSet( "myDataSet" );
      DataTable^ customerTable = gcnew DataTable( "Customers" );

      // Create two columns, and add them to the first table.
      DataColumn^ myColumn = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ myColumn1 = gcnew DataColumn( "CustName" );
      customerTable->Columns->Add( myColumn );
      customerTable->Columns->Add( myColumn1 );

      // Add the tables to the DataSet.
      myDataSet1->Tables->Add( customerTable );

      // Create three customers in the Customers Table.
      DataRow^ newRow1;
      for ( int i = 1; i < 4; i++ )
      {
         newRow1 = customerTable->NewRow();
         newRow1[ "custID" ] = i;
         
         // Add the row to the Customers table.
         customerTable->Rows->Add( newRow1 );
      }
      customerTable->Rows[ 0 ][ "CustName" ] = "Alpha";
      customerTable->Rows[ 1 ][ "CustName" ] = "Beta";
      customerTable->Rows[ 2 ][ "CustName" ] = "Omega";

      // Add Unique Key constraint to the CustID column.
      UniqueConstraint^ idKeyRestraint = gcnew UniqueConstraint( myColumn );
      customerTable->Constraints->Add( idKeyRestraint );
      myDataSet1->EnforceConstraints = true;
   }

   // <Snippet1>
protected:
   void AddTableStyle()
   {
      
      // Create a new DataGridTableStyle.
      myDataGridTableStyle = gcnew DataGridTableStyle;
      myDataGridTableStyle->MappingName = myDataSet1->Tables[ 0 ]->TableName;
      myDataGrid1->DataSource = myDataSet1->Tables[ 0 ];
      myDataGridTableStyle->ReadOnlyChanged += gcnew EventHandler( this, &Form1::MyReadOnlyChangedEventHandler );
      myDataGrid1->TableStyles->Add( myDataGridTableStyle );
   }

private:
   // Handle the 'ReadOnlyChanged' event.
   void MyReadOnlyChangedEventHandler( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "ReadOnly property is changed" );
   }

   // Handle the check box's CheckedChanged event
   void myCheckBox1_CheckedChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGridTableStyle->ReadOnly )
      {
         myDataGridTableStyle->ReadOnly = false;
      }
      else
      {
         myDataGridTableStyle->ReadOnly = true;
      }
   }
   // </Snippet1>
};

int main()
{
   Application::Run( gcnew Form1 );
}
