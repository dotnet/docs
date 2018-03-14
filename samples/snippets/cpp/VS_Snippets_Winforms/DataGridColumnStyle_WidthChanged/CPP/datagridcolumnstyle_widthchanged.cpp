// System::Windows::Forms::DataGridColumnStyle::WidthChanged

/*
The following example demonstrates the 'WidthChanged' event of
the 'DataGridColumnStyle' class. In the example a message will be
displayed whenever the width of the 'Customer ID' column of the
data grid is changed.
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

public ref class MyForm: public Form
{
private:
   System::ComponentModel::Container^ components;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Button^ myButtonNone;
   Button^ myButtonSolid;
   Label^ myLabel;

public:
   MyForm()
   {
      components = nullptr;
      InitializeComponent();
      SetUp();
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
   void InitializeComponent()
   {
      try
      {
         // Create a Label.
         myLabel = gcnew Label;
         myLabel->Text = "Change width of 'Customer ID' column to see 'WidthChanged' event message.";
         myLabel->Location = Point(0,0);
         myLabel->Size = System::Drawing::Size( 400, 20 );
         myLabel->ForeColor = Color::Blue;

         // Create the first button.
         myButtonNone = gcnew Button;
         myButtonNone->Location = Point(24,21);
         myButtonNone->Size = System::Drawing::Size( 150, 24 );
         myButtonNone->Text = "Apply 'None' Line Style ";
         myButtonNone->Click += gcnew EventHandler( this, &MyForm::OnNoneButtonClick );

         // Create the second button.
         myButtonSolid = gcnew Button;
         myButtonSolid->Location = Point(180,21);
         myButtonSolid->Size = System::Drawing::Size( 150, 24 );
         myButtonSolid->Text = "Apply 'Solid' Line Style ";
         myButtonSolid->Click += gcnew EventHandler( this, &MyForm::OnSolidButtonClick );
         Text = "DataGridColumnStyle Sample";
         ClientSize = System::Drawing::Size( 400, 300 );

         // Create a data grid.
         myDataGrid = gcnew DataGrid;
         myDataGrid->Location = Point(24,55);
         myDataGrid->Size = System::Drawing::Size( 345, 200 );
         myDataGrid->CaptionText = "Microsoft DataGrid Control";

         // Create a data grid table style.
         DataGridTableStyle^ myDataGridTableStyle = gcnew DataGridTableStyle;
         myDataGridTableStyle->MappingName = "Customers";
         myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

         // <Snippet1>
         // Add the 'Customer ID' column style.
         DataGridColumnStyle^ myIDCol = gcnew DataGridTextBoxColumn;
         myIDCol->MappingName = "custID";
         myIDCol->HeaderText = "Customer ID";
         myIDCol->Width = 100;
         myIDCol->WidthChanged += gcnew EventHandler( this, &MyForm::MyIDColumnWidthChanged );
         myDataGridTableStyle->GridColumnStyles->Add( myIDCol );
         // </Snippet1>

         // Add the 'Customer Name' column style.
         DataGridColumnStyle^ myNameCol = gcnew DataGridTextBoxColumn;
         myNameCol->MappingName = "custName";
         myNameCol->HeaderText = "Customer Name";
         myNameCol->Width = 150;
         myDataGridTableStyle->GridColumnStyles->Add( myNameCol );
         myDataGrid->TableStyles->Add( myDataGridTableStyle );

         // Add the controls.
         Controls->Add( myLabel );
         Controls->Add( myButtonNone );
         Controls->Add( myButtonSolid );
         Controls->Add( myDataGrid );
      }
      catch ( Exception^ exc ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", exc->Source );
         Console::WriteLine( "Message : {0}", exc->Message );
      }
   }

   void SetUp()
   {
      try
      {
         // Create a DataSet with one table.
         MakeDataSet();
         
         // Bind the DataGrid to the DataSet.
         myDataGrid->SetDataBinding( myDataSet, "Customers" );
      }
      catch ( Exception^ exc ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", exc->Source );
         Console::WriteLine( "Message : {0}", exc->Message );
      }
   }

   void MakeDataSet()
   {
      try
      {
         // Create a DataSet.
         myDataSet = gcnew DataSet( "myDataSet" );
         
         // Create a DataTable.
         DataTable^ myCustTable = gcnew DataTable( "Customers" );
         
         // Create two columns and add them to the table.
         DataColumn^ cCustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cCustName = gcnew DataColumn( "CustName" );
         myCustTable->Columns->Add( cCustID );
         myCustTable->Columns->Add( cCustName );
         myDataSet->Tables->Add( myCustTable );
         DataRow^ newRow1;
         for ( int i = 1; i < 4; i++ )
         {
            newRow1 = myCustTable->NewRow();
            newRow1[ "custID" ] = i;
            
            // Add the row to the Customers table.
            myCustTable->Rows->Add( newRow1 );
         }
         myCustTable->Rows[ 0 ][ "custName" ] = "Alpha";
         myCustTable->Rows[ 1 ][ "custName" ] = "Beta";
         myCustTable->Rows[ 2 ][ "custName" ] = "Omega";
      }
      catch ( Exception^ exc ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", exc->Source );
         Console::WriteLine( "Message : {0}", exc->Message );
      }
   }

private:
   void MyIDColumnWidthChanged( Object^ /*obj*/, EventArgs^ /*e*/ )
   {
      try
      {
         // Get the changed width of the 'Customer ID' column and display.
         DataGridTableStyle^ myTableStyle = myDataGrid->TableStyles[ "Customers" ];
         int myWidth = myTableStyle->GridColumnStyles[ "custID" ]->Width;
         MessageBox::Show( String::Concat( "Width of 'Customer ID' column is changed to : ", myWidth, " pixels" ) );
      }
      catch ( Exception^ exc ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", exc->Source );
         Console::WriteLine( "Message : {0}", exc->Message );
      }
   }

   void OnNoneButtonClick( Object^ /*obj*/, EventArgs^ /*e*/ )
   {
      try
      {
         DataGridTableStyle^ myTableStyle = myDataGrid->TableStyles[ "Customers" ];
         myTableStyle->GridLineStyle = DataGridLineStyle::None;
      }
      catch ( Exception^ exc ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", exc->Source );
         Console::WriteLine( "Message : {0}", exc->Message );
      }
   }

   void OnSolidButtonClick( Object^ /*obj*/, EventArgs^ /*e*/ )
   {
      try
      {
         DataGridTableStyle^ myTableStyle = myDataGrid->TableStyles[ "Customers" ];
         myTableStyle->GridLineStyle = DataGridLineStyle::Solid;
      }
      catch ( Exception^ exc ) 
      {
         Console::WriteLine( "Exception caught!!!" );
         Console::WriteLine( "Source : {0}", exc->Source );
         Console::WriteLine( "Message : {0}", exc->Message );
      }
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
