// System::Windows::Forms::DataGridTableStyle::ResetForeColor

/*
The following example demonstrates 'ResetForeColor' method of 'DataGridTableStyle' class.
A DataGrid and two Buttons are added to the form. A 'DataGridTableStyle' instance is mapped to table of
'DataGrid'. When the user clicks on 'Set ForeColor' button foreground color is set to blue. When
'Reset ForeColor' button is clicked foreground color is reset to its default value.
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

namespace MyDataGridColumnStyle
{
   public ref class MyForm1: public Form
   {
   private:
      DataGrid^ myDataGrid;
      Button^ btnSetForeColor;
      Button^ btnResetForeColor;
      DataSet^ myDataSet;
      DataGridTableStyle^ myDataGridTableStyle;
      DataTable^ myDataTable;
      DataColumn^ myDataColumn1;

   public:
      MyForm1()
      {
         InitializeComponent();
         
         // Call 'SetUp' method to bind the controls.
         SetUp();
      }

   private:
      void InitializeComponent()
      {
         btnResetForeColor = gcnew Button;
         btnSetForeColor = gcnew Button;
         myDataGrid = gcnew DataGrid;
         
         // Initialize Buttons.
         btnSetForeColor->Location = Point(35,290);
         btnSetForeColor->Name = "btnSetForeColor";
         btnSetForeColor->Size = System::Drawing::Size( 110, 30 );
         btnSetForeColor->TabIndex = 1;
         btnSetForeColor->Text = "Set ForeColor";
         btnSetForeColor->Click += gcnew EventHandler( this, &MyForm1::BtnSetForeColor_Click );
         btnResetForeColor->Location = Point(155,290);
         btnResetForeColor->Name = "btnResetForeColor";
         btnResetForeColor->Size = System::Drawing::Size( 110, 30 );
         btnResetForeColor->TabIndex = 2;
         btnResetForeColor->Text = "Reset ForeColor";
         btnResetForeColor->Click += gcnew EventHandler( this, &MyForm1::BtnResetForeColor_Click );
         
         // Initialize DataGrid.
         myDataGrid->DataMember = "";
         myDataGrid->Location = Point(48,72);
         myDataGrid->Name = "myDataGrid";
         myDataGrid->Size = System::Drawing::Size( 200, 200 );
         myDataGrid->TabIndex = 0;
         ClientSize = System::Drawing::Size( 296, 389 );
         
         // Add the Buttons and the DataGrid to the Window.
         Controls->Add( myDataGrid );
         Controls->Add( btnSetForeColor );
         Controls->Add( btnResetForeColor );
         Name = "MyForm1";
         Text = "MyForm1";
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(myDataGrid))->EndInit();
         ResumeLayout( false );
      }


      // <Snippet1>
   private:
      void BtnSetForeColor_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Set the foreground color of table.
         myDataGridTableStyle->ForeColor = Color::Blue;
         myDataGrid->TableStyles->Add( myDataGridTableStyle );
      }

      void BtnResetForeColor_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         // Reset the foreground color of table to its default value.
         myDataGridTableStyle->ResetForeColor();
      }
      // </Snippet1>

      void AddCustomDataTableStyle()
      {
         myDataGridTableStyle = gcnew DataGridTableStyle;
         myDataGridTableStyle->MappingName = "Customers";
      }

      void SetUp()
      {
         MakeDataSet();
         
         // Bind the datagrid to the dataset.
         myDataGrid->SetDataBinding( myDataSet, "Customers" );
         AddCustomDataTableStyle();
      }

      void MakeDataSet()
      {
         
         // Create dataset.
         myDataSet = gcnew DataSet( "myDataSet" );
         myDataTable = gcnew DataTable( "Customers" );
         myDataColumn1 = gcnew DataColumn( "CustName" );
         myDataTable->Columns->Add( myDataColumn1 );
         
         // Add table to dataset.
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
}

int main()
{
   Application::Run( gcnew MyDataGridColumnStyle::MyForm1 );
}
