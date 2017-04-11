// System::Windows::Forms::DataGridColumnStyle::PropertyDescriptorChanged

/* The following example demonstrates 'PropertyDescriptorChanged' Event of 'DataGridColumnStyle' class.
A  DataGrid and Button are added to a form. When user clicks on the button, the 'PropertyDescriptor'Format of
'DataGridColumnStyle' is changed  to 'Currency' format . This raises 'PropertyDescriptorChanged' event,
which then calls user defined EventHandler function.
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
   bool TablesAlreadyAdded;

public:
   myDataForm()
   {
      InitializeComponent();
      SetUp();
   }

private:
   void InitializeComponent()
   {
      Text = "PropertyDescriptor Example";
      myButton = gcnew Button;
      myDataGrid = gcnew DataGrid;
      ClientSize = System::Drawing::Size( 450, 330 );
      myButton->Location = Point(24,16);
      myButton->Size = System::Drawing::Size( 120, 24 );
      myButton->Text = "Currency Format";
      myButton->Click += gcnew EventHandler( this, &myDataForm::myButton_Click );
      myDataGrid->Location = Point(24,50);
      myDataGrid->Size = System::Drawing::Size( 120, 200 );
      myDataGrid->CaptionText = "DataGrid Control";
      myLabel = gcnew Label;
      myLabel->Location = Point(24,270);
      myLabel->Width = 500;
      Controls->Add( myButton );
      Controls->Add( myDataGrid );
      Controls->Add( myLabel );
   }

   void SetUp()
   {
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Orders" );
   }

   // <Snippet1>
private:
   void myButton_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( TablesAlreadyAdded )
      {
         return;
      }

      AddCustomDataTableStyle();
   }

   void AddCustomDataTableStyle()
   {
      DataGridTableStyle^ myTableStyle = gcnew DataGridTableStyle;
      
      // Map DataGridTableStyle to a DataTable.
      myTableStyle->MappingName = "Orders";
      
      // Get CurrencyManager object.
      CurrencyManager^ myCurrencyManager = dynamic_cast<CurrencyManager^>(BindingContext[myDataSet, "Orders"]);
      
      // Use the CurrencyManager to get the PropertyDescriptor for column.
      PropertyDescriptor^ myPropertyDescriptor = myCurrencyManager->GetItemProperties()[ "Amount" ];
      
      // Construct a 'DataGridColumnStyle' object changing its format to 'Currency'.
      DataGridColumnStyle^ myColumnStyle = gcnew DataGridTextBoxColumn( myPropertyDescriptor,"c",true );
      
      // Add EventHandler function for PropertyDescriptorChanged Event.
      myColumnStyle->PropertyDescriptorChanged += gcnew System::EventHandler( this, &myDataForm::MyPropertyDescriptor_Changed );
      myTableStyle->GridColumnStyles->Add( myColumnStyle );
      
      // Add the DataGridTableStyle instance to the GridTableStylesCollection.
      myDataGrid->TableStyles->Add( myTableStyle );
      TablesAlreadyAdded = true;
   }

   void MyPropertyDescriptor_Changed( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myLabel->Text = "Property Descriptor Property of DataGridColumnStyle has changed";
   }
   // </Snippet1>

   void MakeDataSet()
   {
      myDataSet = gcnew DataSet( "myDataSet" );
      DataTable^ myTable = gcnew DataTable( "Orders" );
      DataColumn^ myColumn = gcnew DataColumn( "Amount",Decimal::typeid );
      myTable->Columns->Add( myColumn );
      myDataSet->Tables->Add( myTable );
      DataRow^ newRow;
      for ( int j = 1; j < 15; j++ )
      {
         newRow = myTable->NewRow();
         newRow[ "Amount" ] = j * 10;
         myTable->Rows->Add( newRow );
      }
   }
};

int main()
{
   Application::Run( gcnew myDataForm );
}
