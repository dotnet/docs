/*
System::Windows::Forms::DataGrid::ParentRowsLabelStyleChanged
System::Windows::Forms::DataGrid::ParentRowsVisibleChanged

The following program demonstrates the 'ParentRowsLabelStyleChanged', and
'ParentRowsVisibleChanged' events. It creates a DataGrid and
two DataTables, Person(parent) and Detail(child) which are related
together by a DataRelation, are linked to it. The S"Toggle LabelStyle" button
sets the 'ParentRowsLabelStyle' property and the S"Toggle Visible" button sets the
'ParentRowsVisible' property. When the events is raised a message will be displayed.
*/

#using <System.Xml.dll>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyForm: public Form
{
private:
   System::ComponentModel::Container^ components;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   Button^ toggleStyleButton;
   Button^ toggleVisibleButton;

public:
   MyForm()
   {
      components = nullptr;
      InitializeComponent();
      SetUp();
   }

public:

   // Clean up any resources being used.
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
      this->toggleStyleButton = gcnew Button;
      this->toggleVisibleButton = gcnew Button;
      this->myDataGrid = gcnew DataGrid;
      this->ClientSize = System::Drawing::Size( 292, 300 );
      this->Name = "DataGridForm";
      this->Text = "Testing DataGrid Events";
      this->MaximizeBox = false;
      toggleStyleButton->Location = Point(70,15);
      toggleStyleButton->Size = System::Drawing::Size( 130, 40 );
      toggleStyleButton->Text = "Toggle LabelStyle";
      toggleStyleButton->Click += gcnew EventHandler( this, &MyForm::ToggleStyle_Clicked );
      toggleVisibleButton->Location = Point(70,250);
      toggleVisibleButton->Size = System::Drawing::Size( 130, 40 );
      toggleVisibleButton->Text = "Toggle Visible";
      toggleVisibleButton->Click += gcnew EventHandler( this, &MyForm::ToggleVisible_Clicked );
      myDataGrid->Location = Point(20,70);
      myDataGrid->Size = System::Drawing::Size( 250, 170 );
      myDataGrid->CaptionText = "MS DataGrid Control";
      myDataGrid->ReadOnly = true;

      // Call the methods that instantiate the Event Handlers.
      CallParentRowsLabelStyleChanged();
      CallParentRowsVisibleChanged();
      this->Controls->Add( toggleStyleButton );
      this->Controls->Add( toggleVisibleButton );
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
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ personTable = gcnew DataTable( "Person" );
      DataTable^ detailTable = gcnew DataTable( "Detail" );
      DataColumn^ personID = gcnew DataColumn( "SSN",int::typeid );
      DataColumn^ personName = gcnew DataColumn( "PersonName" );
      personTable->Columns->Add( personID );
      personTable->Columns->Add( personName );
      DataColumn^ detailID = gcnew DataColumn( "SSN",int::typeid );
      DataColumn^ detailPhone = gcnew DataColumn( "Phone" );
      detailTable->Columns->Add( detailID );
      detailTable->Columns->Add( detailPhone );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( personTable );
      myDataSet->Tables->Add( detailTable );
      DataRow^ newRow1;
      DataRow^ newRow2;

      // Create a DataRelation, and add it to the DataSet.
      DataRelation^ myDataRelation = gcnew DataRelation( "PersonDetail",personID,detailID );
      myDataSet->Relations->Add( myDataRelation );
      for ( int i = 1; i < 4; i++ )
      {
         newRow1 = personTable->NewRow();
         newRow1[ "SSN" ] = i;
         personTable->Rows->Add( newRow1 );
      }      
      // Give each person a distinct name.
      personTable->Rows[ 0 ][ "PersonName" ] = "Robert";
      personTable->Rows[ 1 ][ "PersonName" ] = "Michael";
      personTable->Rows[ 2 ][ "PersonName" ] = "John";

      // For each person, create a detail row in 'Detail' table.
      for ( int i = 0; i < 3; i++ )
      {
         newRow2 = detailTable->NewRow();
         newRow2[ "SSN" ] = personTable->Rows[ i ][ "SSN" ];
         newRow2[ "Phone" ] = 1000 + i;
         
         // Add the row to the 'Detail' table.
         detailTable->Rows->Add( newRow2 );
      }
   }

   // <Snippet1>
private:
   void CallParentRowsLabelStyleChanged()
   {
      myDataGrid->ParentRowsLabelStyleChanged += gcnew EventHandler( this, &MyForm::DataGridParentRowsLabelStyleChanged_Clicked );
   }

   // Set the 'ParentRowsLabelStyle' property on click of a button.
   void ToggleStyle_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->ParentRowsLabelStyle.ToString()->Equals( "Both" ) )
            myDataGrid->ParentRowsLabelStyle = DataGridParentRowsLabelStyle::TableName;
      else
            myDataGrid->ParentRowsLabelStyle = DataGridParentRowsLabelStyle::Both;
   }

   // raise the event when 'ParentRowsLabelStyle' property is changed.
   void DataGridParentRowsLabelStyleChanged_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myMessage = "ParentRowsLabelStyleChanged event raised, LabelStyle is : ";
      
      // Get the state of 'ParentRowsLabelStyle' property.
      String^ myLabelStyle = myDataGrid->ParentRowsLabelStyle.ToString();
      myMessage = String::Concat( myMessage, myLabelStyle );
      MessageBox::Show( myMessage, "ParentRowsLabelStyle information" );
   }
   // </Snippet1>

   // <Snippet2>
private:
   void CallParentRowsVisibleChanged()
   {
      myDataGrid->ParentRowsVisibleChanged += gcnew EventHandler( this, &MyForm::DataGridParentRowsVisibleChanged_Clicked );
   }

   // Set the 'ParentRowsVisible' property on click of a button.
   void ToggleVisible_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->ParentRowsVisible == true )
            myDataGrid->ParentRowsVisible = false;
      else
            myDataGrid->ParentRowsVisible = true;
   }

   // raise the event when 'ParentRowsVisible' property is changed.
   void DataGridParentRowsVisibleChanged_Clicked( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ myMessage = "ParentRowsVisibleChanged event raised, Parent row is : ";
      bool visible = myDataGrid->ParentRowsVisible;
      myMessage = String::Concat( myMessage, visible ? (String^)" " : " NOT ", "visible" );
      MessageBox::Show( myMessage, "ParentRowsVisible information" );
   }
   // </Snippet2>
};

int main()
{
   Application::Run( gcnew MyForm );
}
