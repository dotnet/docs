// System::Windows::Forms::DataGridColumnStyle:HeaderTextChanged

/*
The following example demonstrates 'HeaderTextChanged' event of 'DataGridColumnStyle' class.
It adds a DataGrid and a Button and to a form.  When user clicks on the button, it changes the'HeaderText' property
to 'Amount in $'. This raises the 'HeaderTextChanged' event which calls user defined EventHandler function and
displays a message on form.
*/

#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>
#using <System.Xml.dll>

using namespace System;
using namespace System::ComponentModel;
using namespace System::Data;
using namespace System::Drawing;
using namespace System::Windows::Forms;

public ref class myDataForm: public Form
{
private:
   Button^ myButton;
   Label^ myLabel;
   DataGrid^ myDataGrid;
   DataSet^ myDataSet;
   bool * TablesAlreadyAdded;

public:
   myDataForm()
   {
      InitializeComponent();
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Orders" );
   }

private:
   void InitializeComponent()
   {
      Text = "HeaderTextChanged Example";
      myButton = gcnew Button;
      myDataGrid = gcnew DataGrid;
      ClientSize = System::Drawing::Size( 450, 330 );
      myButton->Location = Point(24,16);
      myButton->Size = System::Drawing::Size( 120, 24 );
      myButton->Text = "Currency Format";
      myButton->Click += gcnew EventHandler( this, &myDataForm::myButton_Click );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 170, 200 );
      myDataGrid->CaptionText = "DataGridColumnStyle";
      myLabel = gcnew Label;
      myLabel->Location = Point(24,270);
      myLabel->Width = 500;
      Controls->Add( myButton );
      Controls->Add( myDataGrid );
      Controls->Add( myLabel );
   }

private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( TablesAlreadyAdded )
      {
         return;
      }

      AddCustomDataTableStyle();
   }

   // <Snippet1>
private:
   void AddCustomDataTableStyle()
   {
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      
      // Map DataGridTableStyle to a DataTable.
      myTableStyle->MappingName = "Orders";
      
      // Get CurrencyManager Object*.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(BindingContext[myDataSet, "Orders"]);
      
      // Use the CurrencyManager to get the PropertyDescriptor for the column.
      PropertyDescriptor^ myPropertyDescriptor = myCurrencyManager->GetItemProperties()[ "Amount" ];
      
      // Change the HeaderText.
      DataGridColumnStyle^ myColumnStyle = gcnew DataGridTextBoxColumn( myPropertyDescriptor,"c",true );
      
      // Attach a event handler function with the 'HeaderTextChanged' event.
      myColumnStyle->HeaderTextChanged += gcnew EventHandler( this, &myDataForm::MyHeaderText_Changed );
      myColumnStyle->Width = 130;
      myColumnStyle->HeaderText = "Amount in $";
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      myDataGrid->TableStyles->Add( myTableStyle );
      TablesAlreadyAdded = (bool *)true;
   }

   void MyHeaderText_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myLabel->Text = "Header Descriptor Property of DataGridColumnStyle has changed";
   }
   // </Snippet1>

   void MakeDataSet()
   {
      // Create a DataSet.
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myTable = gcnew DataTable( "Orders" );
      DataColumn^ myColumn = gcnew DataColumn( "Amount",Decimal::typeid );
      myTable->Columns->Add( myColumn );
      myDataSet->Tables->Add( myTable );
      System::Data::DataRow^ newRow;
      for ( int j = 1; j < 15; j++ )
      {
         newRow = myTable->NewRow();
         newRow[ "Amount" ] = j * 10 + j * .1;
         myTable->Rows->Add( newRow );
      }
   }
};

int main()
{
   Application::Run( gcnew myDataForm );
}
