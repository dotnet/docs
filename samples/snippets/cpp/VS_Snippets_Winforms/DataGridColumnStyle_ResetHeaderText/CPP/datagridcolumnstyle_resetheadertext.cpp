// System::Windows::Forms::DataGridColumnStyle::ResetHeaderText

/*
The following example demonstrates 'ResetHeaderText' method of 'DataGridColumnStyle' class.
A 'DataGrid' and two Buttons are added to a form. An instance of 'DataGridColumnStyle'
is mapped to column of 'DataGrid'.On clicking the set button, the Header Text is set. The
reset button resets the HeaderText to its default value.
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

public ref class DataGridColumnStyle_Header: public Form
{
private:
   DataGrid^ myDataGrid;
   Button^ resetButton;
   Button^ setButton;
   DataGridTableStyle^ myDataGridTableStyle;
   DataGridColumnStyle^ myDataGridColumnStyle;
   void InitializeComponent()
   {
      setButton = gcnew Button;
      resetButton = gcnew Button;
      myDataGrid = gcnew DataGrid;
      setButton->Location = Point(32,208);
      setButton->Size = System::Drawing::Size( 120, 23 );
      setButton->Text = "Set Header Text";
      setButton->Click += gcnew EventHandler( this, &DataGridColumnStyle_Header::SetHeaderText );
      resetButton->Location = Point(152,208);
      resetButton->Size = System::Drawing::Size( 120, 23 );
      resetButton->Text = "Reset Header Text";
      resetButton->Click += gcnew EventHandler( this, &DataGridColumnStyle_Header::ResetHeaderText );
      
      // Grid Initialisation.
      myDataGrid->DataMember = "";
      myDataGrid->Location = Point(56,32);
      myDataGrid->Name = "myDataGrid";
      myDataGrid->CaptionText = "DataGrid";
      myDataGrid->Size = System::Drawing::Size( 120, 130 );
      myDataGrid->TabIndex = 0;
      ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^temp0 = {myDataGrid,setButton};
      Controls->AddRange( temp0 );
      Name = "DataGridColumnStyle_Width";
      Text = "Change Header Text";
      Load += gcnew System::EventHandler( this, &DataGridColumnStyle_Header::DataGridColumnStyle_Reset_Header );
   }

public:
   DataGridColumnStyle_Header()
   {
      myDataGridTableStyle = gcnew DataGridTableStyle;
      myDataGridColumnStyle = gcnew DataGridTextBoxColumn;
      InitializeComponent();
      CreateDataSet();
   }

private:
   void CreateDataSet()
   {
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myEmpTable = gcnew DataTable( "Employee" );
      DataColumn^ myEmpID = gcnew DataColumn( "EmpID",int::typeid );
      myEmpTable->Columns->Add( myEmpID );
      myDataSet->Tables->Add( myEmpTable );
      DataRow^ newRow1;
      for ( int i = 1; i < 6; i++ )
      {
         newRow1 = myEmpTable->NewRow();
         newRow1[ "EmpID" ] = i;
         myEmpTable->Rows->Add( newRow1 );

      }
      myDataGrid->SetDataBinding( myDataSet, "Employee" );
   }

   void DataGridColumnStyle_Reset_Header( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridTableStyle->MappingName = "Employee";
      myDataGridColumnStyle->MappingName = "EmpID";
      myDataGridColumnStyle->Width = 50;
      myDataGridTableStyle->GridColumnStyles->Add( myDataGridColumnStyle );
      myDataGrid->TableStyles->Add( myDataGridTableStyle );
   }

   // <Snippet1>
private:
   void SetHeaderText( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Set the HeaderText property.
      myDataGridColumnStyle->HeaderText = "Emp ID";
      myDataGrid->Invalidate();
   }

   void ResetHeaderText( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Reset the HeaderText property to its default value.
      myDataGridColumnStyle->ResetHeaderText();
      myDataGrid->Invalidate();
   }
   // </Snippet1>
};

int main()
{
   Application::Run( gcnew DataGridColumnStyle_Header );
}
