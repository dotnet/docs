// System::Windows::Forms::DataGridBoolColumn::TrueValueChanged
// System::Windows::Forms::DataGridBoolColumn::AllowNullChanged
// System::Windows::Forms::DataGridBoolColumn::FalseValueChanged

/*
The following example demonstrates 'TrueValueChanged',
AllowNullChanged' and 'FalseValueChanged' events for the
'DataGridBoolColumn' class. This example had a 'DataGrid'
which is associated with three columns and a datasource 
created with the 'CreateSource' method. There are three
additional combo boxes each to change the 'TrueValue',
'FalseValue' and 'AllowNull' properties of the 'DataGridBoolColumn'.
The 'TrueValue' property is used to specify the Object* that
the 'DataGridBoolColumn' presumes to be a true value. The
'FalseValue' property has the same semantics. Changing
the value of these properties raises the corresponding 
events. Changing 'TrueValue' raises the 'TrueValueChanged', 
changing 'FalseValue' raises the 'FalseValueChanged' and
'AllowNull' changes the 'AllowNullChanged' events respectively.
*/

#using <System.dll>
#using <System.Xml.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>
#using <System.Data.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
using namespace System::Data;

public ref class MyForm: public System::Windows::Forms::Form
{
private:
   System::Windows::Forms::DataGrid^ myDataGrid;
   System::Windows::Forms::DataGridTableStyle^ myDataGridTableStyle;
   System::Windows::Forms::DataGridTextBoxColumn^ myDataGridTextBoxColumn1;
   System::Windows::Forms::DataGridTextBoxColumn^ myDataGridTextBoxColumn2;
   System::Windows::Forms::DataGridBoolColumn^ myDataGridBoolColumn;
   System::Windows::Forms::Label ^ myLabel1;
   System::Windows::Forms::ComboBox^ myComboBox1;
   System::Windows::Forms::Label ^ myLabel2;
   System::Windows::Forms::ComboBox^ myComboBox2;
   System::Windows::Forms::Label ^ myLabel3;
   System::Windows::Forms::ComboBox^ myComboBox3;
   System::ComponentModel::Container^ components;

public:
   MyForm()
   {
      components = nullptr;
      InitializeComponent();
   }

public:
   ~MyForm()
   {
      if ( components != nullptr )
      {
         delete components;
      }
   }

   ICollection^ CreateSource()
   {
      //Create a new 'DataTable' object.
      DataTable^ myDataTable = gcnew DataTable( "TestTable" );
      DataRow^ myDataRow;

      //Associate 'DataColumns' with the 'DataTable' object.
      myDataTable->Columns->Add( gcnew DataColumn( "IntegerValue",Int32::typeid ) );
      myDataTable->Columns->Add( gcnew DataColumn( "StringValue",String::typeid ) );
      myDataTable->Columns->Add( gcnew DataColumn( "CurrencyValue",double::typeid ) );
      myDataTable->Columns->Add( gcnew DataColumn( "BooleanValue",Boolean::typeid ) );
      int count = 1;
      bool even = false;

      //Insert new rows into the 'DataTable' object.
      for ( int i = -5; i < 5; i++ )
      {
         myDataRow = myDataTable->NewRow();
         myDataRow[ 0 ] = count;
         myDataRow[ 1 ] = String::Concat( "Item ", count );
         myDataRow[ 2 ] = 1.23 * (count + 1);

         // If 'even' insert a 'DBNull' into the table.
         if ( even )
         {
            myDataRow[ 3 ] = Convert::DBNull;
            even = false;
         }
         else
         {
            if ( i < 0 )
                        
            // If 'negative' insert a 'false' into the table.
            myDataRow[ 3 ] = (bool^)false; // If 'positive' insert a 'true' into the table.
            else
                        myDataRow[ 3 ] = true;
            even = true;
         }

         myDataTable->Rows->Add( myDataRow );
         count += 1;
      }

      //Create a new instance of 'DataView' from the 'DataTable' instance.
      DataView^ myDataView = gcnew DataView( myDataTable );
      return myDataView;
   }

private:
   void InitializeComponent()
   {
      System::Resources::ResourceManager^ resources = gcnew System::Resources::ResourceManager( MyForm::typeid );
      myDataGridTableStyle = gcnew System::Windows::Forms::DataGridTableStyle;
      myDataGridTextBoxColumn1 = gcnew System::Windows::Forms::DataGridTextBoxColumn;
      myDataGridTextBoxColumn2 = gcnew System::Windows::Forms::DataGridTextBoxColumn;
      myDataGridBoolColumn = gcnew System::Windows::Forms::DataGridBoolColumn;
      myLabel1 = gcnew System::Windows::Forms::Label;
      myLabel2 = gcnew System::Windows::Forms::Label;
      myDataGrid = gcnew System::Windows::Forms::DataGrid;
      myLabel3 = gcnew System::Windows::Forms::Label;
      myComboBox3 = gcnew System::Windows::Forms::ComboBox;
      myComboBox2 = gcnew System::Windows::Forms::ComboBox;
      myComboBox1 = gcnew System::Windows::Forms::ComboBox;
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(myDataGrid))->BeginInit();
      SuspendLayout();

      // 
      // myDataGridTableStyle
      // 
      myDataGridTableStyle->DataGrid = myDataGrid;
      array<System::Windows::Forms::DataGridColumnStyle^>^columnStyles = {myDataGridTextBoxColumn1,myDataGridTextBoxColumn2,myDataGridBoolColumn};
      myDataGridTableStyle->GridColumnStyles->AddRange( columnStyles );
      myDataGridTableStyle->MappingName = "TestTable";

      // 
      // myDataGridTextBoxColumn1
      // 
      myDataGridTextBoxColumn1->MappingName = "IntegerValue";

      // 
      // myDataGridTextBoxColumn2
      // 
      myDataGridTextBoxColumn2->MappingName = "StringValue";

      // 
      // myDataGridBoolColumn
      // 
      myDataGridBoolColumn->MappingName = "BooleanValue";
      myDataGridBoolColumn->TrueValue = true;
      myDataGridBoolColumn->FalseValue = (bool^)false;
      myDataGridBoolColumn->NullValue = Convert::DBNull;
      myDataGridBoolColumn->AllowNull = true;
      RegisterEventHandlers( myDataGridBoolColumn );

      // 
      // myLabel1
      //
      myLabel1->Location = System::Drawing::Point( 16, 232 );
      myLabel1->Size = System::Drawing::Size( 136, 24 );
      myLabel1->Text = "Change the TrueValue to:";

      // 
      // myLabel2
      //
      myLabel2->Location = System::Drawing::Point( 16, 264 );
      myLabel2->Size = System::Drawing::Size( 136, 24 );
      myLabel2->Text = "Change the FalseValue to:";

      // 
      // myDataGrid
      //
      myDataGrid->Location = System::Drawing::Point( 16, 0 );
      myDataGrid->Size = System::Drawing::Size( 296, 216 );
      myDataGrid->DataSource = CreateSource();
      array<System::Windows::Forms::DataGridTableStyle^>^tableStyles = {myDataGridTableStyle};
      myDataGrid->TableStyles->AddRange( tableStyles );

      // 
      // myLabel3
      //
      myLabel3->Location = System::Drawing::Point( 16, 296 );
      myLabel3->Size = System::Drawing::Size( 136, 24 );
      myLabel3->Text = "Allow 0 values to appear:";

      // 
      // myComboBox3
      //
      myComboBox3->Location = System::Drawing::Point( 168, 288 );
      myComboBox3->Size = System::Drawing::Size( 144, 21 );
      array<Object^>^myComboBox3Items = {true,(bool^)false};
      myComboBox3->Items->AddRange( myComboBox3Items );
      myComboBox3->SelectedIndexChanged += gcnew System::EventHandler( this, &MyForm::myComboBox3_SelectedIndexChanged );

      // 
      // myComboBox2
      //
      myComboBox2->Location = System::Drawing::Point( 168, 256 );
      myComboBox2->Size = System::Drawing::Size( 144, 21 );
      array<Object^>^myComboBox2Items = {true,(bool^)false};
      myComboBox2->Items->AddRange( myComboBox2Items );
      myComboBox2->SelectedIndexChanged += gcnew System::EventHandler( this, &MyForm::myComboBox2_SelectedIndexChanged );

      // 
      // myComboBox1
      //
      myComboBox1->Location = System::Drawing::Point( 168, 224 );
      myComboBox1->Size = System::Drawing::Size( 144, 21 );
      array<Object^>^myComboBox1Items = {true,(bool^)false};
      myComboBox1->Items->AddRange( myComboBox1Items );
      myComboBox1->SelectedIndexChanged += gcnew System::EventHandler( this, &MyForm::myComboBox1_SelectedIndexChanged );

      // 
      // MyForm
      //
      ClientSize = System::Drawing::Size( 336, 341 );
      array<System::Windows::Forms::Control^>^formControls = {myComboBox3,myLabel3,myComboBox2,myLabel2,myComboBox1,myLabel1,myDataGrid};
      Controls->AddRange( formControls );
      Name = "MyForm";
      Text = "MyForm";
      (dynamic_cast<System::ComponentModel::ISupportInitialize^>(myDataGrid))->EndInit();
      ResumeLayout( false );
   }

   // <Snippet1>
   // <Snippet2>
   // <Snippet3>
   void RegisterEventHandlers( DataGridBoolColumn^ myDataGridBoolColumn )
   {
      myDataGridBoolColumn->AllowNullChanged += gcnew System::EventHandler( this, &MyForm::myDataGridBoolColumn_AllowNullChanged );
      myDataGridBoolColumn->TrueValueChanged += gcnew System::EventHandler( this, &MyForm::myDataGridBoolColumn_TrueValueChanged );
      myDataGridBoolColumn->FalseValueChanged += gcnew System::EventHandler( this, &MyForm::myDataGridBoolColumn_FalseValueChanged );
   }

   // Event handler for event when 'TrueValue' is property changed.
   void myDataGridBoolColumn_TrueValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "The TrueValue property of the DataGridBoolColumn has been changed to ", myDataGridBoolColumn->TrueValue ) );
   }

   // Event handler for event when 'FalseValue' is property changed.
   void myDataGridBoolColumn_FalseValueChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "The FalseValue property of the DataGridBoolColumn has been changed to ", myDataGridBoolColumn->FalseValue ) );
   }

   // Event handler for event when 'AllowNull' is property changed.
   void myDataGridBoolColumn_AllowNullChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      MessageBox::Show( String::Concat( "The AllowNull property of DataGridBoolColumn has been changed to ", myDataGridBoolColumn->AllowNull ) );
   }
   // </Snippet3>
   // </Snippet2>
   // </Snippet1>

   // Change the value of 'TrueValue' property to what user specifies.
   void myComboBox1_SelectedIndexChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridBoolColumn->TrueValue = myComboBox1->Items[ myComboBox1->SelectedIndex ];
   }

   // Change the value of 'FalseValue' property to what user specifies.
   void myComboBox2_SelectedIndexChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridBoolColumn->FalseValue = myComboBox2->Items[ myComboBox2->SelectedIndex ];
   }

   // Change the value of 'AllowNull' property to what user specifies.
   void myComboBox3_SelectedIndexChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGridBoolColumn->AllowNull =  *dynamic_cast<bool^>(myComboBox3->Items[ myComboBox3->SelectedIndex ]);
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
