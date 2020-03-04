// System::Windows::Forms::DataGridTableStyle::ForeColor

/*
The following program demonstrates the property 'ForeColor' of class 'DataGridTableStyle'.
A table with 2 columns is created and attached to grid. A listbox allows selection of forecolors
for the grid.
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

namespace Datagrid
{
   public ref class Form1: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::DataGrid^ dataGrid1;
      System::Windows::Forms::ComboBox^ myComboBox;
      System::Windows::Forms::Button^ button2;

      // Declare objects of DataSet, DataGrid, DataTable.
      DataSet^ myDataSet;

   public:
      DataTable^ myCustomerTable;
      DataGridTableStyle^ myTableStyle;

   private:
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;
         InitializeComponent();
      }

   protected:

      // Clean up resources.
      ~Form1()
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
         this->myComboBox = gcnew System::Windows::Forms::ComboBox;
         this->dataGrid1 = gcnew System::Windows::Forms::DataGrid;
         this->button2 = gcnew System::Windows::Forms::Button;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->dataGrid1))->BeginInit();
         this->SuspendLayout();

         //
         // myComboBox
         //
         this->myComboBox->DropDownWidth = 136;
         array<Object^>^temp0 = {"Green","Red","Violet"};
         this->myComboBox->Items->AddRange( temp0 );
         this->myComboBox->Location = System::Drawing::Point( 64, 160 );
         this->myComboBox->Name = "myComboBox";
         this->myComboBox->Size = System::Drawing::Size( 136, 21 );
         this->myComboBox->TabIndex = 3;
         this->myComboBox->DropDownStyle = ComboBoxStyle::DropDownList;

         //
         // dataGrid1
         //
         this->dataGrid1->CaptionText = "DataGrid";
         this->dataGrid1->DataMember = "";
         this->dataGrid1->Location = System::Drawing::Point( 56, 48 );
         this->dataGrid1->Name = "dataGrid1";
         this->dataGrid1->Size = System::Drawing::Size( 272, 80 );
         this->dataGrid1->TabIndex = 0;

         //
         // button2
         //
         this->button2->Location = System::Drawing::Point( 232, 160 );
         this->button2->Name = "button2";
         this->button2->Size = System::Drawing::Size( 96, 32 );
         this->button2->TabIndex = 4;
         this->button2->Text = "Change ForeGround";
         this->button2->Click += gcnew System::EventHandler( this, &Form1::OnForeColor_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 536, 301 );
         array<System::Windows::Forms::Control^>^formControls = {this->button2,this->myComboBox,this->dataGrid1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->dataGrid1))->EndInit();
         this->ResumeLayout( false );
      }

      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         myComboBox->SelectedIndex = 0;
         Create_Table();
      }

      // <Snippet1>
   private:
      void Create_Table()
      {
         // Create a DataSet.
         myDataSet = gcnew DataSet( "myDataSet" );

         // Create DataTable.
         DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

         // Create two columns, and add to the table.
         DataColumn^ CustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ CustName = gcnew DataColumn( "CustName" );
         myCustomerTable->Columns->Add( CustID );
         myCustomerTable->Columns->Add( CustName );
         DataRow^ newRow1;

         // Create three customers in the Customers Table.
         for ( int i = 1; i < 3; i++ )
         {
            newRow1 = myCustomerTable->NewRow();
            newRow1[ "custID" ] = i;

            // Add row to the Customers table.
            myCustomerTable->Rows->Add( newRow1 );
         }
         myCustomerTable->Rows[ 0 ][ "custName" ] = "Alpha";
         myCustomerTable->Rows[ 1 ][ "custName" ] = "Beta";

         // Add table to DataSet.
         myDataSet->Tables->Add( myCustomerTable );
         dataGrid1->SetDataBinding( myDataSet, "Customers" );
         myTableStyle = gcnew DataGridTableStyle;
         myTableStyle->MappingName = "Customers";
         myTableStyle->ForeColor = Color::DarkMagenta;
         dataGrid1->TableStyles->Add( myTableStyle );
      }

      // Set table's forecolor.
      void OnForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         dataGrid1->TableStyles->Clear();
         String^ str = dynamic_cast<String^>(myComboBox->SelectedItem);
         if ( str->Equals( "Green" ) )
                  myTableStyle->ForeColor = Color::Green;
         else
         if ( str->Equals( "Red" ) )
                  myTableStyle->ForeColor = Color::Red;
         else
         if ( str->Equals( "Violet" ) )
                  myTableStyle->ForeColor = Color::Violet;

         dataGrid1->TableStyles->Add( myTableStyle );
      }
      // </Snippet1>
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew Datagrid::Form1 );
}
