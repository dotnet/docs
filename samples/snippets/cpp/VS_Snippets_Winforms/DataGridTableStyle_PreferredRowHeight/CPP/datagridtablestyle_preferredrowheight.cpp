// System::Windows::Forms::DataGridTableStyle::PreferredRowHeight

/*
The following example demonstrates 'PreferredRowHeight' property of 'DataGridTableStyle'
class. It adds a DataGrid, Button and a TextBox to a form. It changes the
'PreferredRowHeight' property by taking the value entered in the textbox.
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

public ref class myDataForm: public Form
{
private:
   Button^ myButton;
   TextBox^ myTextBox;
   Label^ myLabel;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   DataGridTableStyle^ myTableStyle;

public:
   myDataForm()
   {
      // Required for Windows Form Designer support.
      InitializeComponent();
      
      // Call SetUp to bind the controls.
      SetUp();
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      myButton = gcnew Button;
      myDataGrid = gcnew DataGrid;
      ClientSize = System::Drawing::Size( 450, 330 );
      myButton->Location = Point(100,16);
      myButton->Size = System::Drawing::Size( 200, 24 );
      myButton->Text = "Change Row Height";
      myButton->Click += gcnew EventHandler( this, &myDataForm::myButton_Click );
      myTextBox = gcnew TextBox;
      myTextBox->Location = Point(24,16);
      myTextBox->Size = System::Drawing::Size( 40, 24 );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 120, 200 );
      myDataGrid->CaptionText = "DataGridTableStyle Example";
      myLabel = gcnew Label;
      myLabel->Location = Point(24,270);
      myLabel->Width = 500;
      Controls->Add( myButton );
      Controls->Add( myTextBox );
      Controls->Add( myDataGrid );
      Controls->Add( myLabel );
      Text = "PreferredRowHeight example";
   }

   void SetUp()
   {
      // Create a DataSet with a table.
      MakeDataSet();

      // Bind the DataGrid to the DataSet.
      myDataGrid->SetDataBinding( myDataSet, "Orders" );

      // Create the DataGridTableStyle.
      myTableStyle = gcnew DataGridTableStyle;

      // Map DataGridTableStyle to a DataTable.
      myTableStyle->MappingName = "Orders";
   }

private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myTextBox->Text->Trim()->Equals( "" ) )
      {
         MessageBox::Show( "Enter the height between 18 and 134" );
         return;
      }

      try
      {
         // <Snippet1>
         int myPreferredRowHeight = Convert::ToInt32( myTextBox->Text->Trim() );
         if ( myPreferredRowHeight < 18 || myPreferredRowHeight > 134 )
         {
            MessageBox::Show( "Enter the height between 18 and 134" );
            return;
         }

         // Set the 'PreferredRowHeight' property of DataGridTableStyle instance.
         myTableStyle->PreferredRowHeight = myPreferredRowHeight;

         // Add the DataGridTableStyle instance to the GridTableStylesCollection.
         myDataGrid->TableStyles->Add( myTableStyle );
         // </Snippet1>
      }
      catch ( Exception^ ex ) 
      {
         MessageBox::Show( String::Concat( ex->Message, "Enter Integer only ." ) );
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
   Application::Run( gcnew myDataForm );
}
