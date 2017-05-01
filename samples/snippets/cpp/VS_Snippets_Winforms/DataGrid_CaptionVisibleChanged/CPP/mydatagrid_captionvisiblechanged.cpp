// System::Windows::Forms::DataGrid::CaptionVisibleChanged
// System::Windows::Forms::DataGrid::CurrentCellChanged
// System::Windows::Forms::DataGrid::Scroll

/* The following program demonstrates the 'CaptionVisibleChanged',
'CurrentCellChanged' and 'Scroll' events of
'System::Windows::Forms::DataGrid' class. It creates a DataGrid
onto a form. This Datagrid is linked to two tables,
Person (parent) table and Detail (child) table which are related
together by a 'DataRelation'. User can look for the details of a
person by navigating along. The "Toggle Caption" button is used
to set the 'CaptionVisible' property by toggling. When a property
is set, an event associated with it is raised which is confirmed
by the message shown by the alert message box. */

#using <System.Xml.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyDataGrid: public Form
{
private:
   System::ComponentModel::Container^ components;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Button^ myButton;

public:
   MyDataGrid()
   {
      components = nullptr;
      
      // Create form.
      InitializeComponent();
      
      // Call SetUp to bind the controls.
      SetUp();
   }

public:

   // Clean up any resources being used.
   ~MyDataGrid()
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
      this->myButton = gcnew Button;
      this->myDataGrid = gcnew DataGrid;
      this->ClientSize = System::Drawing::Size( 292, 300 );
      this->Name = "DataGridForm";
      this->Text = "Testing DataGrid Events";
      this->MaximizeBox = false;
      myButton->Location = Point(85,15);
      myButton->Size = System::Drawing::Size( 130, 40 );
      myButton->Text = "Toggle Caption";
      myButton->Click += gcnew EventHandler( this, &MyDataGrid::myButton_Click );
      myDataGrid->Location = Point(20,70);
      myDataGrid->Size = System::Drawing::Size( 250, 170 );
      myDataGrid->CaptionText = "MS DataGrid Control";
      myDataGrid->ReadOnly = true;

      // Call the methods that instantiate the Event Handlers.
      CallCaptionVisibleChanged();
      CallCurrentCellChanged();
      CallScroll();
      this->Controls->Add( myButton );
      this->Controls->Add( myDataGrid );
   }

   void SetUp()
   {
      // Create a DataSet with two tables and one relation.
      MakeDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Person" );
   }

   // Create a DataSet with two tables and populate it.
   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create a DataTable.
      DataTable^ tPer = gcnew DataTable( "Person" );
      DataTable^ tDet = gcnew DataTable( "Detail" );

      // Create two columns, and add them to the Person table.
      DataColumn^ cPerID = gcnew DataColumn( "SSN",int::typeid );
      DataColumn^ cPerName = gcnew DataColumn( "PersonName" );
      tPer->Columns->Add( cPerID );
      tPer->Columns->Add( cPerName );

      // Create three columns, and add them to the Detail table.
      DataColumn^ cDetID = gcnew DataColumn( "SSN",int::typeid );
      DataColumn^ cDetPh = gcnew DataColumn( "Phone" );
      tDet->Columns->Add( cDetID );
      tDet->Columns->Add( cDetPh );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( tPer );
      myDataSet->Tables->Add( tDet );

      // For each person create a DataRow variable.
      DataRow^ newRow1;
      DataRow^ newRow2;

      // Create a DataRelation, and add it to the DataSet.
      DataRelation^ dr = gcnew DataRelation( "PersonDetail",cPerID,cDetID );
      myDataSet->Relations->Add( dr );

      // Create nine persons in the 'Person' Table.
      for ( int i = 1; i < 10; i++ )
      {
         newRow1 = tPer->NewRow();
         newRow1[ "SSN" ] = i;

         // Add the row to the 'Person' table.
         tPer->Rows->Add( newRow1 );
      }

      // Give each person a distinct name.
      tPer->Rows[ 0 ][ "PersonName" ] = "Robert";
      tPer->Rows[ 1 ][ "PersonName" ] = "Michael";
      tPer->Rows[ 2 ][ "PersonName" ] = "John";
      tPer->Rows[ 3 ][ "PersonName" ] = "Walter";
      tPer->Rows[ 4 ][ "PersonName" ] = "Simon";
      tPer->Rows[ 5 ][ "PersonName" ] = "Wilson";
      tPer->Rows[ 6 ][ "PersonName" ] = "Donald";
      tPer->Rows[ 7 ][ "PersonName" ] = "Bill";
      tPer->Rows[ 8 ][ "PersonName" ] = "James";

      // For each person, create a detail row in 'Detail' table.
      for ( int i = 0; i < 9; i++ )
      {
         newRow2 = tDet->NewRow();
         newRow2[ "SSN" ] = tPer->Rows[ i ][ "SSN" ];
         newRow2[ "Phone" ] = 1000 + i;
         
         // Add the row to the 'Detail' table.
         tDet->Rows->Add( newRow2 );
      }
   }

   // <Snippet1>
   // Create an instance of the 'CaptionVisibleChanged' EventHandler.
private:
   void CallCaptionVisibleChanged()
   {
      myDataGrid->CaptionVisibleChanged += gcnew EventHandler( this, &MyDataGrid::Grid_CaptionVisibleChanged );
   }

   // Set the 'CaptionVisible' property on click of a button.
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->CaptionVisible == true )
            myDataGrid->CaptionVisible = false;
      else
            myDataGrid->CaptionVisible = true;
   }

   // Raise the event when 'CaptionVisible' property is changed.
   void Grid_CaptionVisibleChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "CaptionVisibleChanged event raised, caption is";

      // Get the state of 'CaptionVisible' property.
      bool myBool = myDataGrid->CaptionVisible;

      // Create appropriate alert message.
      myString = String::Concat( myString, myBool ? (String^)" " : " not ", "visible" );

      // Show information about caption of DataGrid.
      MessageBox::Show( myString, "Caption information" );
   }
   // </Snippet1>

   // <Snippet2>
   // Create an instance of the 'CurrentCellChanged' EventHandler.
private:
   void CallCurrentCellChanged()
   {
      myDataGrid->CurrentCellChanged += gcnew EventHandler( this, &MyDataGrid::Grid_CurCellChange );
   }

   // Raise the event when focus on DataGrid cell changes.
   void Grid_CurCellChange( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "CurrentCellChanged event raised, cell focus is at ";

      // Get the co-ordinates of the focussed cell.
      String^ myPoint = String::Concat( myDataGrid->CurrentCell.ColumnNumber, ", ", myDataGrid->CurrentCell.RowNumber );

      // Create the alert message.
      myString = String::Concat( myString, "(", myPoint, ")" );

      // Show Co-ordinates when CurrentCellChanged event is raised.
      MessageBox::Show( myString, "Current cell co-ordinates" );
   }
   // </Snippet2>

   // <Snippet3>
   // Create an instance of the 'Scroll' EventHandler.
private:
   void CallScroll()
   {
      myDataGrid->Scroll += gcnew EventHandler( this, &MyDataGrid::Grid_Scroll );
   }

   // Raise the event when DataGrid is scrolled.
   void Grid_Scroll( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "Scroll event raised, DataGrid is scrolled";

      // Show the message when scrolling is done.
      MessageBox::Show( myString, "Scroll information" );
   }
   // </Snippet3>
};

// Main entry point for the application.
int main()
{
   Application::Run( gcnew MyDataGrid );
}
