// System::Windows::Forms::DataGridTableStyle::RowHeadersVisibleChanged
// System::Windows::Forms::DataGridTableStyle::RowHeadersVisible

/* The following program demonstrates the 'RowHeadersVisible'
method and 'RowHeadersVisibleChanged' event of
'System::Windows::Forms::DataGridTableStyle' class. It makes the
row headers visible or invisible on button click */

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyDataGridTableStyle_RowHeadersVisibleChanged: public Form
{
private:
   System::ComponentModel::Container^ components;
   DataGridTableStyle^ myDataGridTableStyle;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Button^ myButton;

public:
   MyDataGridTableStyle_RowHeadersVisibleChanged()
   {
      components = nullptr;

      // Create the form.
      InitializeComponent();

      // Bind the controls to the DataGrid.
      MakeDataSet();
   }

public:

   // Clean up any resources being used.
   ~MyDataGridTableStyle_RowHeadersVisibleChanged()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      this->myDataGridTableStyle = gcnew DataGridTableStyle;
      this->myDataGrid = gcnew DataGrid;
      this->myButton = gcnew Button;
      this->ClientSize = System::Drawing::Size( 292, 300 );
      this->Name = "DataGridForm";
      this->Text = "Testing DataGridTableStyle";
      this->MaximizeBox = false;
      myButton->Location = Point(80,15);
      myButton->Size = System::Drawing::Size( 130, 40 );
      myButton->Text = "Toggle Row Headers";
      myButton->Click += gcnew EventHandler( this, &MyDataGridTableStyle_RowHeadersVisibleChanged::myButton_Click );
      myDataGrid->Location = Point(20,70);
      myDataGrid->Size = System::Drawing::Size( 250, 170 );
      myDataGrid->CaptionText = "MS DataGrid Control";
      myDataGrid->ReadOnly = false;
      this->Controls->Add( myButton );
      this->Controls->Add( myDataGrid );
      this->Load += gcnew System::EventHandler( this, &MyDataGridTableStyle_RowHeadersVisibleChanged::DataGridTableStyle_RowHeadersVisible_Load );
   }

   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create a DataTable.
      DataTable^ tPer = gcnew DataTable( "Person" );

      // Create two columns, and add them to the Person table.
      DataColumn^ cPerID = gcnew DataColumn( "SSN",int::typeid );
      DataColumn^ cPerName = gcnew DataColumn( "PersonName" );
      tPer->Columns->Add( cPerID );
      tPer->Columns->Add( cPerName );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( tPer );

      // For each person create a DataRow variable.
      DataRow^ newRow1;

      // Create five persons in the Person Table.
      for ( int i = 1; i < 6; i++ )
      {
         newRow1 = tPer->NewRow();
         newRow1[ "SSN" ] = i;
         
         // Add the row to the Person table.
         tPer->Rows->Add( newRow1 );
      }
      
      // Give each person a distinct name.
      tPer->Rows[ 0 ][ "PersonName" ] = "Robert";
      tPer->Rows[ 1 ][ "PersonName" ] = "Michael";
      tPer->Rows[ 2 ][ "PersonName" ] = "John";
      tPer->Rows[ 3 ][ "PersonName" ] = "Walter";
      tPer->Rows[ 4 ][ "PersonName" ] = "Simon";
      myDataGrid->SetDataBinding( myDataSet, "Person" );
   }

   void DataGridTableStyle_RowHeadersVisible_Load( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGridTableStyle->MappingName = "Person";

      // Set other properties.
      myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

      // Create DataGridColumnStyle
      DataGridColumnStyle^ IdCol = gcnew DataGridTextBoxColumn;
      DataGridColumnStyle^ TextCol = gcnew DataGridTextBoxColumn;

      // Set MappingName to DataColumn name in DataTable.
      IdCol->MappingName = "SSN";

      // Set the HeaderText and Width properties.
      IdCol->HeaderText = "SSN";
      IdCol->Width = 50;

      // Add a second column style.
      TextCol->MappingName = "PersonName";
      TextCol->HeaderText = "Person Name";
      TextCol->Width = 150;

      // Add the GridColumnStyles to DataGridTableStyle.
      myDataGridTableStyle->GridColumnStyles->Add( IdCol );
      myDataGridTableStyle->GridColumnStyles->Add( TextCol );

      // Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
      myDataGridTableStyle->GridLineColor = Color::Aquamarine;
      AttachRowHeaderVisibleChanged();
   }

   // <Snippet1>
   // <Snippet2>
   // Instantiate the EventHandler.
public:
   void AttachRowHeaderVisibleChanged()
   {
      myDataGridTableStyle->RowHeadersVisibleChanged += gcnew EventHandler( this, &MyDataGridTableStyle_RowHeadersVisibleChanged::MyDelegateRowHeadersVisibleChanged );
   }

   // raise the event when RowHeadersVisible property is changed.
private:
   void MyDelegateRowHeadersVisibleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myString = "'RowHeadersVisibleChanged' event raised, Row Headers are";
      if ( myDataGridTableStyle->RowHeadersVisible )
            myString = String::Concat( myString, " visible" );
      else
            myString = String::Concat( myString, " not visible" );

      MessageBox::Show( myString, "RowHeader information" );
   }

   // raise the event when a button is clicked.
   void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( myDataGridTableStyle->RowHeadersVisible )
            myDataGridTableStyle->RowHeadersVisible = false;
      else
            myDataGridTableStyle->RowHeadersVisible = true;
   }
   // </Snippet2>
   // </Snippet1>
};

// Main entry point for the application.
int main()
{
   Application::Run( gcnew MyDataGridTableStyle_RowHeadersVisibleChanged );
}
