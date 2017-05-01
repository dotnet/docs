// System::Windows::Forms::DataGrid::ReadOnlyChanged
// System::Windows::Forms::DataGrid::FlatModeChanged

/* The following program demonstrates the methods 'ReadOnlyChanged' and
'FlatModeChanged' of the 'DataGrid' class. It creates a
'GridControl' and checks the properties 'ReadOnly' and 'FlatMode'
of data grid, depending on the selection of buttons.
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

public ref class MyDataGridClass_FlatMode_ReadOnly: public Form
{
private:
   DataGrid^ myDataGrid;
   Button^ button1;
   Button^ button2;
   DataSet^ myDataSet;
   System::ComponentModel::Container^ components;

public:
   MyDataGridClass_FlatMode_ReadOnly()
   {
      components = nullptr;
      InitializeComponent();
      SetUp();
   }

public:
   ~MyDataGridClass_FlatMode_ReadOnly()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->FormBorderStyle = ::FormBorderStyle::FixedDialog;
      this->myDataGrid = gcnew DataGrid;
      this->button1 = gcnew Button;
      this->button2 = gcnew Button;
      (dynamic_cast<ISupportInitialize^>(this->myDataGrid))->BeginInit();
      this->SuspendLayout();

      //
      // myDataGrid
      //
      this->myDataGrid->CaptionText = "My Grid Control";
      this->myDataGrid->DataMember = "";
      this->myDataGrid->Location = Point(16,16);
      this->myDataGrid->Name = "myDataGrid";
      this->myDataGrid->Size = System::Drawing::Size( 168, 112 );
      this->myDataGrid->TabIndex = 0;
      AttachFlatModeChanged();
      AttachReadOnlyChanged();

      //
      // button1
      //
      this->button1->Location = Point(24,160);
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 72, 40 );
      this->button1->TabIndex = 1;
      this->button1->Text = "Toggle Flat Mode";
      this->button1->Click += gcnew EventHandler( this, &MyDataGridClass_FlatMode_ReadOnly::button1_Click );

      //
      // button2
      //
      this->button2->Location = Point(96,160);
      this->button2->Name = "button2";
      this->button2->Size = System::Drawing::Size( 72, 40 );
      this->button2->TabIndex = 1;
      this->button2->Text = "Toggle Read Only";
      this->button2->Click += gcnew EventHandler( this, &MyDataGridClass_FlatMode_ReadOnly::button2_Click );

      //
      // MyDataGridClass_FlatMode_ReadOnly
      //
      this->ClientSize = System::Drawing::Size( 208, 205 );
      array<Control^>^temp0 = {this->button1,this->myDataGrid,this->button2};
      this->Controls->AddRange( temp0 );
      this->MaximizeBox = false;
      this->Name = "MyDataGridClass_FlatMode_ReadOnly";
      this->Text = "Grid Control";
      (dynamic_cast<ISupportInitialize^>(this->myDataGrid))->EndInit();
      this->ResumeLayout( false );
   }

   void SetUp()
   {
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
   }

   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create a DataTable.
      DataTable^ myTable = gcnew DataTable( "Customers" );

      // Create two columns, and add them to the table.
      DataColumn^ myColumn1 = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ myColumn2 = gcnew DataColumn( "CustName" );
      myTable->Columns->Add( myColumn1 );
      myTable->Columns->Add( myColumn2 );

      // Add the table to the DataSet.
      myDataSet->Tables->Add( myTable );

      // For the customer, create a 'DataRow' variable.
      DataRow^ newRow;

      // Create one customer in the customers table.
      for ( int i = 1; i < 2; i++ )
      {
         newRow = myTable->NewRow();
         newRow[ "custID" ] = i;
         
         // Add the row to the 'Customers' table.
         myTable->Rows->Add( newRow );
      }
      myTable->Rows[ 0 ][ "custName" ] = "Customer";
   }

   // <Snippet1>
   // Attach to event handler.
private:
   void AttachFlatModeChanged()
   {
      this->myDataGrid->FlatModeChanged +=
            gcnew EventHandler( this, &MyDataGridClass_FlatMode_ReadOnly::myDataGrid_FlatModeChanged );
   }

   // Check if the 'FlatMode' property is changed.
   void myDataGrid_FlatModeChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ strMessage = "false";
      if ( myDataGrid->FlatMode == true )
            strMessage = "true";

      MessageBox::Show( "Flat mode changed to " + strMessage, "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
   }

   // Toggle the 'FlatMode'.
   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->FlatMode == true )
            myDataGrid->FlatMode = false;
      else
            myDataGrid->FlatMode = true;
   }
   // </Snippet1>

   // <Snippet2>
   // Attach to event handler.
private:
   void AttachReadOnlyChanged()
   {
      this->myDataGrid->ReadOnlyChanged += gcnew EventHandler( this, &MyDataGridClass_FlatMode_ReadOnly::myDataGrid_ReadOnlyChanged );
   }

   // Check if the 'ReadOnly' property is changed.
   void myDataGrid_ReadOnlyChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      String^ strMessage = "false";
      if ( myDataGrid->ReadOnly == true )
            strMessage = "true";

      MessageBox::Show( "Read only changed to " + strMessage, "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
   }

   // Toggle the 'ReadOnly' property.
   void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->ReadOnly == true )
            myDataGrid->ReadOnly = false;
      else
            myDataGrid->ReadOnly = true;
   }
   // </Snippet2>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew MyDataGridClass_FlatMode_ReadOnly );
}
