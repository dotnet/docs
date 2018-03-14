// System::Windows::Forms::DataGridTextBox::IsInEditOrNavigateMode

/* The following program demonstrates the 'IsInEditOrNavigateMode'
property of the 'System::Windows::Forms::DataGridTextBox' class.
It creates a form with 'DataGrid' that has a 'DataTable'.
A DataGridTextBox is shown which is bound to the DataSet that
contains the 'DataTable'. A button is used to display the state of
'IsInEditOrNavigateMode' property. Editing of the
'DataGridTextBox' changes the value of 'IsInEditOrNavigateMode'
from true to false. */

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System::ComponentModel;

public ref class MyDataGridTextBox: public Form
{
private:
   System::ComponentModel::Container^ components;
   DataGridTableStyle^ myDataGridTableStyle;
   DataGridTextBoxColumn^ myTextBoxColumn;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Button^ myButton;
   DataGridTextBox^ myDataGridTextBox;

public:
   MyDataGridTextBox()
   {
      components = nullptr;

      // Create the form.
      InitializeComponent();
      
      // Bind the controls.
      MakeDataSet();
   }

public:

   // Clean up any resources being used.
   ~MyDataGridTextBox()
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
      this->myDataGridTextBox = gcnew DataGridTextBox;
      this->myTextBoxColumn = gcnew DataGridTextBoxColumn;
      this->myDataGrid = gcnew DataGrid;
      this->myButton = gcnew Button;
      this->ClientSize = System::Drawing::Size( 292, 300 );
      this->Name = "DataGridForm";
      this->Text = "Testing DataGridTextBox";
      this->MaximizeBox = false;
      myDataGridTextBox->Location = Point(20,5);
      myDataGridTextBox->Size = System::Drawing::Size( 100, 65 );
      myDataGrid->Location = Point(20,70);
      myDataGrid->Size = System::Drawing::Size( 250, 170 );
      myDataGrid->CaptionText = "MS DataGrid Control";
      myButton->Location = Point(71,250);
      myButton->Size = System::Drawing::Size( 150, 40 );
      myButton->Text = " IsInEditOrNavigateMode";
      myButton->Click += gcnew EventHandler( this, &MyDataGridTextBox::Button_ClickEvent );
      this->Controls->Add( myDataGrid );
      this->Controls->Add( myDataGridTextBox );
      this->Controls->Add( myButton );

      // Create 'DataTableStyle' for the DataGrid.
      AddCustomDataTableStyle();

      // Set the properties of DataGridTextBox.
      myDataGridTextBox->ScrollBars = ScrollBars::Vertical;
      myDataGridTextBox->ForeColor = Color::Red;
      myDataGridTextBox->Multiline = true;
      myDataGridTextBox->WordWrap = true;
   }

   void AddCustomDataTableStyle()
   {
      // Map the DataGridTableStyle to the Table name.
      myDataGridTableStyle->MappingName = "Person";

      // Set other properties.
      myDataGridTableStyle->AlternatingBackColor = Color::LightGray;
      DataGridColumnStyle^ TextCol = gcnew DataGridTextBoxColumn;

      // Map the DataGridColumnStyle to the Column name of the Table.
      TextCol->MappingName = "PersonName";
      TextCol->HeaderText = "Person Name";
      TextCol->Width = 100;
      myDataGridTableStyle->GridColumnStyles->Add( TextCol );
      myDataGridTableStyle->GridLineColor = Color::Aquamarine;

      // Add the DataGridTableStyle to GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
   }

   // Create a DataSet with a table and populate it.
   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ tPer = gcnew DataTable( "Person" );
      DataColumn^ cPerName = gcnew DataColumn( "PersonName" );
      tPer->Columns->Add( cPerName );
      myDataSet->Tables->Add( tPer );
      DataRow^ newRow1;
      for ( int i = 1; i < 6; i++ )
      {
         newRow1 = tPer->NewRow();
         tPer->Rows->Add( newRow1 );
      }
      tPer->Rows[ 0 ][ "PersonName" ] = "Robert";
      tPer->Rows[ 1 ][ "PersonName" ] = "Michael";
      tPer->Rows[ 2 ][ "PersonName" ] = "John";
      tPer->Rows[ 3 ][ "PersonName" ] = "Walter";
      tPer->Rows[ 4 ][ "PersonName" ] = "Simon";

      // Bind the 'DataSet' to the 'DataGrid'.
      myDataGrid->SetDataBinding( myDataSet, "Person" );
      myDataGridTextBox->DataBindings->Add( "Text", myDataSet, "Person::PersonName" );

      // Set the DataGrid to the DataGridTextBox.
      myDataGridTextBox->SetDataGrid( myDataGrid );
   }

   // <Snippet1>
   // Handle event to show the state of 'IsInEditOrNavigateMode'.
private:
   void Button_ClickEvent( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGridTextBox->IsInEditOrNavigateMode )
      {
         // DataGridTextBox has not been edited.
         MessageBox::Show( "Editing of DataGridTextBox not begun, IsInEditOrNavigateMode = True" );
      }
      else
      {         
         // DataGridTextBox has been edited.
         MessageBox::Show( "Editing of DataGridTextBox begun, IsInEditOrNavigateMode = False" );
      }
   }
   // </Snippet1>
};

// Main entry point for the application.
int main()
{
   Application::Run( gcnew MyDataGridTextBox );
}
