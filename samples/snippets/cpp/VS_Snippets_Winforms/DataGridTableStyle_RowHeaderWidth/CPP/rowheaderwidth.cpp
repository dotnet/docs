// System::Windows::Forms::DataGridTableStyle::RowHeaderWidth
// System::Windows::Forms::DataGridTableStyle::RowHeaderWidthChanged

/* The following program demonstrates the 'RowHeaderWidth'
method and 'RowHeaderWidthChanged' event of 'DataGridTableStyle'
class. It changes the row header width on button click
and resets the row header width. */

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

public ref class DataGridTableStyle_RowHeaderWidth: public Form
{
private:
   System::ComponentModel::Container^ components;
   Button^ button2;
   DataGridColumnStyle^ IdCol;
   DataGridColumnStyle^ TextCol;
   DataGridTableStyle^ myDataGridTableStyle;
   Button^ button1;
   DataGrid^ myDataGrid;

public:
   ~DataGridTableStyle_RowHeaderWidth()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      this->myDataGrid = gcnew DataGrid;
      this->button1 = gcnew Button;
      this->button2 = gcnew Button;
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->BeginInit();
      this->SuspendLayout();

      //
      // myDataGrid
      //
      this->myDataGrid->DataMember = "";
      this->myDataGrid->LinkColor = SystemColors::Desktop;
      this->myDataGrid->Location = Point(56,40);
      this->myDataGrid->Name = "myDataGrid";
      this->myDataGrid->Size = System::Drawing::Size( 224, 144 );
      this->myDataGrid->TabIndex = 0;

      //
      // button1
      //
      this->button1->Location = Point(168,208);
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 152, 23 );
      this->button1->TabIndex = 1;
      this->button1->Text = " Change RowHeader Width";
      this->button1->Click += gcnew EventHandler( this, &DataGridTableStyle_RowHeaderWidth::button1_Click );

      //
      // button2
      //
      this->button2->Location = Point(16,208);
      this->button2->Name = "button2";
      this->button2->Size = System::Drawing::Size( 152, 23 );
      this->button2->TabIndex = 1;
      this->button2->Text = "Display RowHeader Width";
      this->button2->Click += gcnew EventHandler( this, &DataGridTableStyle_RowHeaderWidth::button2_Click );

      //
      // DataGridTableStyle_RowHeaderWidth
      //
      this->ClientSize = System::Drawing::Size( 344, 261 );
      array<Control^>^temp0 = {this->myDataGrid,this->button2};
      this->Controls->AddRange( temp0 );
      this->Name = "DataGridTableStyle_RowHeaderWidth";
      this->Text = "Change Row Width";
      CallEventLoader();
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->EndInit();
      this->ResumeLayout( false );
   }

public:
   DataGridTableStyle_RowHeaderWidth()
   {
      components = nullptr;
      IdCol = gcnew DataGridTextBoxColumn;
      TextCol = gcnew DataGridTextBoxColumn;
      myDataGridTableStyle = gcnew DataGridTableStyle;
      InitializeComponent();

      // Create and bind DataSet to DataGrid.
      CreateNBindDataSet();
   }

private:
   void CreateNBindDataSet()
   {
      // Create a DataSet with one table.
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );

      // Create a DataTable.
      DataTable^ myEmpTable = gcnew DataTable( "Employee" );

      // Create two columns, and add them to the employee table.
      DataColumn^ myEmpID = gcnew DataColumn( "EmpID",int::typeid );
      DataColumn^ myEmpName = gcnew DataColumn( "EmpName" );
      myEmpTable->Columns->Add( myEmpID );
      myEmpTable->Columns->Add( myEmpName );

      // Add the table to the DataSet.
      myDataSet->Tables->Add( myEmpTable );

      // Populate the table.
      DataRow^ newRow1;

      // Create employee records in the employee table.
      for ( int i = 1; i < 6; i++ )
      {
         newRow1 = myEmpTable->NewRow();
         newRow1[ "EmpID" ] = i;
         
         // Add the row to the Employee table.
         myEmpTable->Rows->Add( newRow1 );
      }

      // Give each employee a distinct name.
      myEmpTable->Rows[ 0 ][ "EmpName" ] = "Gary";
      myEmpTable->Rows[ 1 ][ "EmpName" ] = "Harry";
      myEmpTable->Rows[ 2 ][ "EmpName" ] = "Mary";
      myEmpTable->Rows[ 3 ][ "EmpName" ] = "Larry";
      myEmpTable->Rows[ 4 ][ "EmpName" ] = "Robert";

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Employee" );
   }

   void DataGridTableStyle_RowHeaderWidth_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridTableStyle->MappingName = "Employee";

      // Set other properties.
      myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

      // Set MappingName to the DataColumn name in the DataTable.
      IdCol->MappingName = "EmpID";

      // Set the HeaderText and Width properties.
      IdCol->HeaderText = "Emp ID";
      IdCol->Width = 50;

      // Add a GridColumnStyle.
      myDataGridTableStyle->GridColumnStyles->Add( IdCol );
      myDataGridTableStyle->RowHeaderWidth = 10;

      // Add a second column style.
      TextCol->MappingName = "EmpName";
      TextCol->HeaderText = "Emp Name";
      TextCol->Width = 100;
      myDataGridTableStyle->GridColumnStyles->Add( TextCol );

      // Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
      myDataGridTableStyle->GridLineColor = Color::Red;
      AttachRowHeaderWidthChanged();
   }

   // <Snippet1>
   // <Snippet2>
private:
   void CallEventLoader()
   {
      this->Load += gcnew EventHandler( this, &DataGridTableStyle_RowHeaderWidth::DataGridTableStyle_RowHeaderWidth_Load );
   }

public:
   void AttachRowHeaderWidthChanged()
   {
      myDataGridTableStyle->RowHeaderWidthChanged +=
         gcnew EventHandler( this, &DataGridTableStyle_RowHeaderWidth::MyDelegateRowHeaderChanged );
   }

private:
   void MyDelegateRowHeaderChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "Row header width is changed" );
   }

   void button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridTableStyle->RowHeaderWidth = 30;
   }

   void button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "Row header width is: ", myDataGridTableStyle->RowHeaderWidth ) );
   }
   // </Snippet2>
   // </Snippet1>
};

[STAThread]
int main()
{
   Application::Run( gcnew DataGridTableStyle_RowHeaderWidth );
}
