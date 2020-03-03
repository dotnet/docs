// System::Windows::Forms::DataGrid::AllowNavigationChanged
// System::Windows::Forms::DataGrid::Navigate

/* The following program demonstrates the 'AllowNavigationChanged'
and 'Navigate' events of 'System::Windows::Forms::DataGrid' class.
It creates a DataGrid onto a form. This Datagrid is linked
to two tables, Person (parent) table and Detail (child) table
which are related together by a 'DataRelation'. User can look
for the details of a person by navigating along.
The S"Toggle Navigation" button is used to set the
'AllowNavigation' property by toggling. When a property is set,
an event associated with it occurs and is confirmed by the
message shown by the alert message box. */

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

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
      myButton->Text = "Toggle Navigation";
      myButton->Click += gcnew EventHandler( this, &MyDataGrid::myButton_Click );
      myDataGrid->Location = Point(20,70);
      myDataGrid->Size = System::Drawing::Size( 250, 180 );
      myDataGrid->CaptionText = "MS DataGrid Control";
      myDataGrid->ReadOnly = true;
      
      // Call the methods that instantiate the Event Handlers.
      CallAllowNavigationChanged();
      CallNavigate();
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

      // For each person, create a detail row in Detail table.
      for ( int i = 0; i < 5; i++ )
      {
         newRow2 = tDet->NewRow();
         newRow2[ "SSN" ] = tPer->Rows[ i ][ "SSN" ];
         newRow2[ "Phone" ] = 1000 + i;

         // Add the row to the 'Detail' table.
         tDet->Rows->Add( newRow2 );
      }
   }

   // <Snippet1>
private:
   // Create an instance of the 'AllowNavigationChanged' EventHandler.
   void CallAllowNavigationChanged()
   {
      myDataGrid->AllowNavigationChanged += gcnew EventHandler( this, &MyDataGrid::Grid_AllowNavChange );
   }

   // Set the 'AllowNavigation' property on click of a button.
private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->AllowNavigation == true )
            myDataGrid->AllowNavigation = false;
      else
            myDataGrid->AllowNavigation = true;
   }

   // Raise the event when 'AllowNavigation' property is changed.
private:
   void Grid_AllowNavChange( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myString = "AllowNavigationChanged event raised, Navigation ";
      bool myBool = myDataGrid->AllowNavigation;

      // Create appropriate alert message.
      myString = String::Concat( myString, myBool ? (String^)" is " : " is not ", "allowed" );

      // Show information about navigation.
      MessageBox::Show( myString, "Navigation information" );
   }
   // </Snippet1>

   // <Snippet2>
   // Instantiate the 'Navigate' NavigateEventHandler.
private:
   void CallNavigate()
   {
      myDataGrid->Navigate += gcnew NavigateEventHandler( this, &MyDataGrid::Grid_Navigate );
   }

   // Raise the event when navigating to another table.
private:
   void Grid_Navigate( Object^ /*sender*/, NavigateEventArgs^ /*e*/ )
   {
      // String variable used to show message.
      String^ myString = "Navigate event raised, moved to another table";
      
      // Show the message when navigating to another table.
      MessageBox::Show( myString, "Table navigation information" );
   }
   // </Snippet2>
};

// Main entry point for the application.
int main()
{
   Application::Run( gcnew MyDataGrid );
}
