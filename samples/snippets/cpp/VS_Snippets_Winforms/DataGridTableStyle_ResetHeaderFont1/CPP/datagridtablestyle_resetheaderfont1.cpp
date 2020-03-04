// System::Windows::Forms::DataGridTableStyle:ResetHeaderFont

/* The following example demonstrates 'ResetHeaderFont' method of 'DataGridTableStyle' class.
A DataGrid and two Button's are added to a form. When user clicks 'Set Header Font' button the Header Font of
DataGrid is changed. The HeaderFont is reset to its default value when the 'Reset Header Font' button is clicked.
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
   Button^ mySetButton;
   Button^ myResetButton;
   Label^ myLabel;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   DataGridTableStyle^ myTableStyle;

public:
   myDataForm()
   {
      InitializeComponent();
      SetUp();
   }

private:
   void InitializeComponent()
   {
      // Create the form and its controls.
      mySetButton = gcnew Button;
      myDataGrid = gcnew DataGrid;
      ClientSize = System::Drawing::Size( 450, 330 );
      mySetButton->Location = Point(24,16);
      mySetButton->Size = System::Drawing::Size( 220, 24 );
      mySetButton->Text = "Set Header Font To 'Impact'";
      mySetButton->Click += gcnew EventHandler( this, &myDataForm::MySetButton_Click );
      myResetButton = gcnew Button;
      myResetButton->Location = Point(250,16);
      myResetButton->Size = System::Drawing::Size( 130, 24 );
      myResetButton->Text = "Reset Header Font";
      myResetButton->Click += gcnew EventHandler( this, &myDataForm::MyResetButton_Click );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 120, 200 );
      myDataGrid->CaptionText = "DataGrid Control";
      myLabel = gcnew Label;
      myLabel->Location = Point(24,270);
      myLabel->Width = 500;
      Controls->Add( mySetButton );
      Controls->Add( myResetButton );
      Controls->Add( myDataGrid );
      Controls->Add( myLabel );
      Text = "ResetHeaderFont example";
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

   // <Snippet1>
private:
   void MySetButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Set the 'HeaderFont' property of the DataGridTableStyle instance.
      myTableStyle->HeaderFont = gcnew System::Drawing::Font( "Impact",10 );

      // Add the DataGridTableStyle instance to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
   }

   void MyResetButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Reset the Header Font to its default value.
      myTableStyle->ResetHeaderFont();
   }
   // </Snippet1>

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
