// System::Windows::Forms::DataGridTableStyle::PreferredColumnWidth

/*
The following example demonstrates the property 'PreferredColumnWidth'
of 'DataGridTableStyle' class.

It creates a 'Button' a 'TextBox' and 'DataGrid', attaches an employee table to
DataGrid and applies 'DataGridTableStyle' to it.
Event Handler has been attached to handle 'PreferredColumnWidthChanged' event.
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

namespace DataGridTableStyle_PreferredColumnWidthChanged
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::Button^ myButton;
      System::Windows::Forms::TextBox^ myColWidth;
      System::Windows::Forms::Label ^ myLabel;
      System::Windows::Forms::DataGrid^ myDataGrid;
      System::Windows::Forms::DataGridTableStyle^ myDataGridTableStyle;
      System::ComponentModel::Container^ components;

   public:
      ~Form1()
      {
         if ( components != nullptr )
         {
            delete components;
         }
      }

   private:
      void InitializeComponent()
      {
         this->myButton = gcnew System::Windows::Forms::Button;
         this->myLabel = gcnew System::Windows::Forms::Label;
         this->myColWidth = gcnew System::Windows::Forms::TextBox;
         this->SuspendLayout();

         //
         // myButton
         //
         this->myButton->Location = System::Drawing::Point( 136, 304 );
         this->myButton->Name = "myButton";
         this->myButton->TabIndex = 1;
         this->myButton->Text = "Apply";
         this->myButton->Click += gcnew System::EventHandler( this, &Form1::myButton_Click );

         //
         // myLabel
         //
         this->myLabel->Location = System::Drawing::Point( 96, 264 );
         this->myLabel->Name = "myLabel";
         this->myLabel->Size = System::Drawing::Size( 80, 16 );
         this->myLabel->TabIndex = 3;
         this->myLabel->Text = "Column width: ";

         //
         // myColWidth
         //
         this->myColWidth->Location = System::Drawing::Point( 184, 264 );
         this->myColWidth->Name = "myColWidth";
         this->myColWidth->TabIndex = 2;
         this->myColWidth->Text = "";

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 400, 397 );
         array<System::Windows::Forms::Control^>^formControls = {this->myLabel,this->myColWidth,this->myButton};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
         this->ResumeLayout( false );
      }

   public:
      Form1()
      {
         components = nullptr;
         myDataGrid = gcnew DataGrid;
         myDataGridTableStyle = gcnew DataGridTableStyle;
         InitializeComponent();
      }

      // <Snippet1>
   private:
      void CreateAndBindDataSet( DataGrid^ myDataGrid )
      {
         DataSet^ myDataSet = gcnew DataSet( "myDataSet" );
         DataTable^ myEmpTable = gcnew DataTable( "Employee" );

         // Create two columns, and add them to employee table.
         DataColumn^ myEmpID = gcnew DataColumn( "EmpID",int::typeid );
         DataColumn^ myEmpName = gcnew DataColumn( "EmpName" );
         myEmpTable->Columns->Add( myEmpID );
         myEmpTable->Columns->Add( myEmpName );

         // Add table to DataSet.
         myDataSet->Tables->Add( myEmpTable );

         // Populate table.
         DataRow^ newRow1;

         // Create employee records in employee Table.
         for ( int i = 1; i < 6; i++ )
         {
            newRow1 = myEmpTable->NewRow();
            newRow1[ "EmpID" ] = i;
            
            // Add row to Employee table.
            myEmpTable->Rows->Add( newRow1 );
         }
         myEmpTable->Rows[ 0 ][ "EmpName" ] = "Alpha";
         myEmpTable->Rows[ 1 ][ "EmpName" ] = "Beta";
         myEmpTable->Rows[ 2 ][ "EmpName" ] = "Omega";
         myEmpTable->Rows[ 3 ][ "EmpName" ] = "Gamma";
         myEmpTable->Rows[ 4 ][ "EmpName" ] = "Delta";

         // Bind DataGrid to DataSet.
         myDataGrid->SetDataBinding( myDataSet, "Employee" );
      }

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Set and Display myDataGrid.
         myDataGrid->DataMember = "";
         myDataGrid->Location = System::Drawing::Point( 72, 32 );
         myDataGrid->Name = "myDataGrid";
         myDataGrid->Size = System::Drawing::Size( 240, 200 );
         myDataGrid->TabIndex = 4;

         // Add it to controls.
         Controls->Add( myDataGrid );
         CreateAndBindDataSet( myDataGrid );
         myDataGridTableStyle->MappingName = "Employee";

         // Set other properties.
         myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

         // Add DataGridTableStyle instances to GridTableStylesCollection.
         myDataGridTableStyle->PreferredColumnWidth = 100;
         myColWidth->Text = "";
         myDataGrid->TableStyles->Add( myDataGridTableStyle );
         myDataGridTableStyle->PreferredColumnWidthChanged += gcnew EventHandler( this, &Form1::MyDelegatePreferredColWidthChanged );
      }

   private:
      void MyDelegatePreferredColWidthChanged( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( "Preferred Column width has changed" );
      }

   private:
      void myButton_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         try
         {
            if (  !myColWidth->Text->Equals( "" ) )
            {
               Int32 newwidth = myDataGridTableStyle->PreferredColumnWidth;
               myDataGridTableStyle->PreferredColumnWidth = Int32::Parse( myColWidth->Text );

               // Dispose datagrid and datagridtablestyle and then create.
               delete myDataGrid;
               delete myDataGridTableStyle;
               myDataGrid = gcnew DataGrid;
               myDataGridTableStyle = gcnew DataGridTableStyle;
               myDataGrid->DataMember = "";
               myDataGrid->Location = System::Drawing::Point( 72, 32 );
               myDataGrid->Name = "myDataGrid";
               myDataGrid->Size = System::Drawing::Size( 240, 200 );
               myDataGrid->TabIndex = 4;
               Controls->Add( myDataGrid );
               CreateAndBindDataSet( myDataGrid );
               myDataGridTableStyle->MappingName = "Employee";

               // Set other properties.
               myDataGridTableStyle->AlternatingBackColor = Color::LightGray;

               // Add DataGridTableStyle instances to GridTableStylesCollection.
               myDataGridTableStyle->PreferredColumnWidth = newwidth;
               myColWidth->Text = "";
               myDataGrid->TableStyles->Add( myDataGridTableStyle );
               myDataGridTableStyle->PreferredColumnWidthChanged += gcnew EventHandler( this, &Form1::MyDelegatePreferredColWidthChanged );
            }
            else
            {
               MessageBox::Show( "Please enter a number" );
            }
         }
         catch ( Exception^ ex ) 
         {
            MessageBox::Show( ex->Message );
         }
      }
      // </Snippet1>
   };
}

[STAThread]
int main()
{
   Application::Run( gcnew DataGridTableStyle_PreferredColumnWidthChanged::Form1 );
}
