// System::Windows::Forms::DataGridColumnStyle.MappingNameChanged

/*
* The following example demonstrates the 'MappingNameChanged' event of 'DataGridColumnStyle' class.
It adds a DataGrid and a button to a Form. When the user clicks on the 'Change Mapping Name'
button, it changes  mapping name and generates 'MappingNameChanged' event.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;

public ref class MyForm: public Form
{
private:
   DataGrid^ myDataGrid;
   bool * flag;
   Button^ myButton;
   DataSet^ myDataSet;
   DataGridColumnStyle^ myColumnStyle;

public:
   MyForm()
   {
      InitializeComponent();
      SetUp();
   }

private:
   void InitializeComponent()
   {
      myDataGrid = gcnew DataGrid;
      myButton = gcnew Button;
      myDataGrid->Location = Point(24,24);
      myDataGrid->Name = "myDataGrid";
      myDataGrid->CaptionText = "DataGridColumn";
      myDataGrid->Height = 130;
      myDataGrid->Width = 150;
      myDataGrid->TabIndex = 0;
      myButton->Location = Point(60,208);
      myButton->Name = "myButton ";
      myButton->TabIndex = 3;
      myButton->Size = System::Drawing::Size( 140, 20 );
      myButton->Text = "Change Mapping Name";
      myButton->Click += gcnew EventHandler( this, &MyForm::button_Click );
      ClientSize = System::Drawing::Size( 292, 273 );
      array<Control^>^temp0 = {myButton,myDataGrid};
      Controls->AddRange( temp0 );
      Name = "Form1";
      Text = "MappingNameChanged Event";
      ResumeLayout( false );
   }

   void SetUp()
   {
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Orders" );
   }

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myTable = gcnew DataTable( "Orders" );
      DataColumn^ myColumn = gcnew DataColumn( "Amount",Decimal::typeid );
      DataColumn^ myColumn1 = gcnew DataColumn( "Orders",Decimal::typeid );
      myTable->Columns->Add( myColumn );
      myTable->Columns->Add( myColumn1 );
      myDataSet->Tables->Add( myTable );
      DataRow^ newRow;
      for ( int j = 1; j < 15; j++ )
      {
         newRow = myTable->NewRow();
         newRow[ "Amount" ] = j * 10;
         newRow[ "Orders" ] = 10;
         myTable->Rows->Add( newRow );
      }
      AddCustomColumnStyle();
   }

   // <Snippet1>
private:
   void AddCustomColumnStyle()
   {
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      myTableStyle->MappingName = "Orders";
      myColumnStyle = gcnew DataGridTextBoxColumn;
      myColumnStyle->MappingName = "Orders";
      myColumnStyle->HeaderText = "Orders";
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
      myColumnStyle->MappingNameChanged += gcnew EventHandler( this, &MyForm::columnStyle_MappingNameChanged );
      flag = (bool *)true;
   }

   // MappingNameChanged event handler of DataGridColumnStyle.
   void columnStyle_MappingNameChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( "Mapping Name changed" );
   }
   // </Snippet1>

   void button_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      // Change the Mapping name.
      if ( flag )
      {
         myColumnStyle = myDataGrid->TableStyles[ 0 ]->GridColumnStyles[ "Orders" ];
         myColumnStyle->MappingName = "Amount";
         myColumnStyle->HeaderText = "Amount";
         this->Refresh();
         flag = false;
      }
      else
      {
         myColumnStyle = myDataGrid->TableStyles[ 0 ]->GridColumnStyles[ "Amount" ];
         myColumnStyle->MappingName = "Orders";
         myColumnStyle->HeaderText = "Orders";
         this->Refresh();
         flag = (bool *)true;
      }
   }
};

int main()
{
   Application::Run( gcnew MyForm );
}
