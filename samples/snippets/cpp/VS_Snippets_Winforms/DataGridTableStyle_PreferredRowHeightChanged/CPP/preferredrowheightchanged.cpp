// System::Windows::Forms::DataGridTableStyle::PreferredRowHeightChanged

/*
The following example demonstrates 'PreferredRowHeightChanged' Event of 'DataGridTableStyle' class.
A DataGrid, Button and TextBox are added to a form. The 'PreferredRowHeight' property of 'DataGridTableStyle'
class is set to the value entered by user in the textbox. When user clicks the set button,
it raises 'PreferredRowHeightChanged' Event which calls user defined  EventHandler function.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class MyDataForm: public Form
{
private:
   Button^ myButton;
   TextBox^ myTextBox;
   Label^ myLabel;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   DataGridTableStyle^ myTableStyle;

public:
   MyDataForm()
   {
      InitializeComponent();
      SetUp();
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      myButton = gcnew Button;
      myDataGrid = gcnew DataGrid;
      ClientSize = System::Drawing::Size( 450, 330 );
      myButton->Location = Point(70,16);
      myButton->Size = System::Drawing::Size( 200, 24 );
      myButton->Text = "Set Row Height(in pixels)";
      myButton->Click += gcnew EventHandler( this, &MyDataForm::myButton_Click );
      myTextBox = gcnew TextBox;
      myTextBox->Location = Point(24,16);
      myTextBox->Size = System::Drawing::Size( 40, 24 );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 120, 200 );
      myDataGrid->CaptionText = "DataGrid Control";
      myLabel = gcnew Label;
      myLabel->Location = Point(24,270);
      myLabel->Width = 500;
      Controls->Add( myButton );
      Controls->Add( myTextBox );
      Controls->Add( myDataGrid );
      Controls->Add( myLabel );
      Text = "PreferredRowHeightChanged example";
   }

   // <Snippet1>
   void SetUp()
   {
      // Create a DataSet with a table.
      MakeDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Orders" );
      myTableStyle = gcnew DataGridTableStyle;

      // Map 'DataGridTableStyle' instance to the DataTable.
      myTableStyle->MappingName = "Orders";

      // Add EventHandler function for 'PreferredRowHeightChanged' Event.
      myTableStyle->PreferredRowHeightChanged += gcnew EventHandler( this, &MyDataForm::RowHeight_Changed );
   }

   // Called when the PreferredRowHeight property of myTableStyle is modified
   void RowHeight_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "PreferredRowHeight property is changed" );
   }
   // </Snippet1>

private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      try
      {
         if ( myTextBox->Text->Trim()->Equals( "" ) )
         {
            MessageBox::Show( "Enter the height between 18 and 134" );
            return;
         }
         int myPreferredRowHeight = Convert::ToInt32( myTextBox->Text->Trim() );
         if ( myPreferredRowHeight < 18 || myPreferredRowHeight > 134 )
         {
            MessageBox::Show( "Enter the height between 18 and 134" );
            return;
         }
         
         // Set the 'PrefferedRowHeight' property of DataGridTableStyle instance.
         myTableStyle->PreferredRowHeight = myPreferredRowHeight;
         
         // Add the DataGridTableStyle instance to the GridTableStylesCollection.
         myDataGrid->TableStyles->Add( myTableStyle );
      }
      catch ( Exception^ ex ) 
      {
         
         // Handle raised Exception.
         if ( ex != nullptr )
         {
            MessageBox::Show( "Please enter a numeric value between 18 and 134" );
            myTextBox->Text = " ";
            bool val = myTextBox->Focus();
         }
      }
   }

   // Create a DataSet with a table and populate it.
private:
   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myTable = gcnew DataTable( "Orders" );
      DataColumn^ myColumn = gcnew DataColumn( "Amount",Decimal::typeid );
      myTable->Columns->Add( myColumn );

      // Add the table to the DataSet.
      myDataSet->Tables->Add( myTable );
      DataRow^ newRow;
      for ( int j = 1; j < 15; j++ )
      {
         newRow = myTable->NewRow();
         newRow[ "Amount" ] = j * 10;
         
         // Add the row to the Orders table.
         myTable->Rows->Add( newRow );
      }
   }
};

int main()
{
   Application::Run( gcnew MyDataForm );
}
