// System::Windows::Forms::DataGridTableStyle::SelectionBackColorChanged
// System::Windows::Forms::DataGridTableStyle::SelectionBackColor
// System::Windows::Forms::DataGridTableStyle::ResetSelectionBackColor

/* The following program demonstrates the 'SelectionBackColorChanged'
event, 'SelectionBackColor' property and 'ResetSelectionBackColor'
method of the'DataGridTableStyle'class. It changes the BackColor
of the selected cells by raising the 'SelectionBackColorChanged'
event. The SelectionBackColor is reset to its default value with
the 'ResetSelectionBackColor' button.
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

public ref class MyForm: public System::Windows::Forms::Form
{
private:
   System::ComponentModel::Container^ components;
   System::Windows::Forms::Button^ myBackColorButton;
   System::Windows::Forms::Button^ myResetButton;
   DataGridTableStyle^ myGridTableStyle;
   DataGrid^ myDataGrid;

public:
   MyForm()
   {
      components = nullptr;
      myDataGrid = gcnew DataGrid;
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

private:

   /// <summary>
   /// Required method for Designer support - do not modify
   /// the contents of this method with the code editor.
   /// </summary>
   void InitializeComponent()
   {
      this->myBackColorButton = gcnew System::Windows::Forms::Button;
      this->myResetButton = gcnew System::Windows::Forms::Button;
      this->SuspendLayout();

      //
      // myBackColorButton
      //
      this->myBackColorButton->Location = System::Drawing::Point( 0, 352 );
      this->myBackColorButton->Name = "myBackColorButton";
      this->myBackColorButton->Size = System::Drawing::Size( 160, 23 );
      this->myBackColorButton->TabIndex = 0;
      this->myBackColorButton->Text = "Change SelectionBackColor";
      this->myBackColorButton->Click += gcnew System::EventHandler( this, &MyForm::MyBackColorButton_Click );

      //
      // myResetButton
      //
      this->myResetButton->Location = System::Drawing::Point( 160, 352 );
      this->myResetButton->Name = "myResetButton";
      this->myResetButton->Size = System::Drawing::Size( 152, 23 );
      this->myResetButton->TabIndex = 1;
      this->myResetButton->Text = "Reset SelectionBackColor";
      this->myResetButton->Click += gcnew System::EventHandler( this, &MyForm::MyResetButton_Click );

      //
      // MyForm
      //
      this->ClientSize = System::Drawing::Size( 316, 411 );
      array<System::Windows::Forms::Control^>^formControls = {this->myResetButton,this->myBackColorButton};
      this->Controls->AddRange( formControls );
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
      this->Name = "MyForm";
      this->Text = "MyForm";
      this->Load += gcnew System::EventHandler( this, &MyForm::MyForm_Load );
      this->ResumeLayout( false );
   }

   void MyForm_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      myDataGrid->CaptionText = "My Data Grid";
      myDataGrid->Height = 300;
      myDataGrid->Width = 300;
      myDataGrid->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      myDataGrid->SetDataBinding( MakeDataSet(), "Orders" );
      Controls->Add( myDataGrid );
      myGridTableStyle = gcnew DataGridTableStyle;
      myGridTableStyle->MappingName = "Orders";
      myGridTableStyle->SelectionForeColor = Color::Coral;
      myDataGrid->TableStyles->Add( myGridTableStyle );
      AttachSelectionBackColorChanged();
   }

   // <Snippet1>
public:
   void AttachSelectionBackColorChanged()
   {
      // Handle the 'SelectionBackColorChanged' event.
      myGridTableStyle->SelectionBackColorChanged += gcnew EventHandler( this, &MyForm::MyDataGrid_SelectedBackColorChanged );
   }

private:
   void MyDataGrid_SelectedBackColorChanged( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      MessageBox::Show( "SelectionBackColorChanged event was raised, Color changed to " + myGridTableStyle->SelectionBackColor );
   }
   // </Snippet1>

   void MyBackColorButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // <Snippet2>
      // Allow the user to select a Color.
      ColorDialog^ myColorDialog = gcnew ColorDialog;
      myColorDialog->AllowFullOpen = false;
      myColorDialog->ShowHelp = true;

      // Set the initial color select to the current color.
      myColorDialog->Color = myGridTableStyle->SelectionBackColor;

      // Show color dialog box.
      myColorDialog->ShowDialog();

      // Set the backcolor for the selected cells.
      myGridTableStyle->SelectionBackColor = myColorDialog->Color;
      // </Snippet2>

      myDataGrid->Invalidate();
   }

   void MyResetButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // <Snippet3>
      // Set the SelectionBackColor to the default color.
      myGridTableStyle->ResetSelectionBackColor();
      // </Snippet3>
   }

   DataSet^ MakeDataSet()
   {
      // Create a DataSet.
      DataSet^ myDataSet = gcnew DataSet( "myDataSet" );

      // Create two DataTables.
      DataTable^ myDataGrid = gcnew DataTable( "Customers" );
      DataTable^ tOrders = gcnew DataTable( "Orders" );

      // Create two columns, and add them to the first table.
      DataColumn^ cCustID = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ cCustName = gcnew DataColumn( "CustName" );
      DataColumn^ cCurrent = gcnew DataColumn( "Current",bool::typeid );
      myDataGrid->Columns->Add( cCustID );
      myDataGrid->Columns->Add( cCustName );
      myDataGrid->Columns->Add( cCurrent );

      // Create three columns, and add them to the second table.
      DataColumn^ cID = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ cOrderDate = gcnew DataColumn( "OrderDate",DateTime::typeid );
      DataColumn^ cOrderAmount = gcnew DataColumn( "OrderAmount",Decimal::typeid );
      tOrders->Columns->Add( cOrderAmount );
      tOrders->Columns->Add( cID );
      tOrders->Columns->Add( cOrderDate );

      // Add the tables to the DataSet.
      myDataSet->Tables->Add( myDataGrid );
      myDataSet->Tables->Add( tOrders );

      // Create a DataRelation, and add it to the DataSet.
      DataRelation^ dr = gcnew DataRelation( "custToOrders",cCustID,cID );
      myDataSet->Relations->Add( dr );

      // Populate the tables.
      // Create for each customer and order two DataRow variables.
      DataRow^ newRow1;
      DataRow^ newRow2;

      // Create three customers in the Customers Table.
      for ( int i = 1; i < 4; i++ )
      {
         newRow1 = myDataGrid->NewRow();
         newRow1[ "custID" ] = i;

         // Add the row to the Customers table.
         myDataGrid->Rows->Add( newRow1 );
      }
      myDataGrid->Rows[ 0 ][ "custName" ] = "Customer 1";
      myDataGrid->Rows[ 1 ][ "custName" ] = "Customer 2";
      myDataGrid->Rows[ 2 ][ "custName" ] = "Customer 3";

      // Give the Current column a value.
      myDataGrid->Rows[ 0 ][ "Current" ] = true.ToString();
      myDataGrid->Rows[ 1 ][ "Current" ] = true.ToString();
      myDataGrid->Rows[ 2 ][ "Current" ] = false.ToString();

      // For each customer, create five rows in the Orders table.
      for ( int i = 1; i < 4; i++ )
      {
         for ( int j = 1; j < 6; j++ )
         {
            newRow2 = tOrders->NewRow();
            newRow2[ "CustID" ] = i;
            newRow2[ "orderDate" ] = DateTime(2001,i,j * 2);
            newRow2[ "OrderAmount" ] = i * 10 + j * .1;

            // Add the row to the Orders table.
            tOrders->Rows->Add( newRow2 );
         }
      }
      return myDataSet;
   }
};

[STAThread]
int main()
{
   Application::Run( gcnew MyForm );
}
