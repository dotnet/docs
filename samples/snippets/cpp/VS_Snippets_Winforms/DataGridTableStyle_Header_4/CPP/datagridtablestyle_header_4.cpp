// System::Windows::Forms::DataGridTableStyle.HeaderForeColorChanged;System::Windows::Forms::DataGridTableStyle::HeaderForeColor
// System::Windows::Forms::DataGridTableStyle.HeaderBackColorChanged;System::Windows::Forms::DataGridTableStyle::HeaderBackColor

/*
The following program demonstrates the usage of properties 'HeaderBackColor',
'HeaderForeColor' and events 'HeaderBackColorChanged', 'HeaderForeColorChanged'.
A table is created and added to a datagrid with two coloumns.The table allows to change
Header's  background and foreground colors through selection of combobox values.
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
      System::Windows::Forms::Button^ button1;
      System::Windows::Forms::ComboBox^ comboBox1;
      System::Windows::Forms::ComboBox^ comboBox2;
      System::Windows::Forms::Button^ button2;
      System::ComponentModel::Container^ components;

   public:
      Form1()
      {
         components = nullptr;
         InitializeComponent();
      }

   public:

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
         this->comboBox1 = gcnew System::Windows::Forms::ComboBox;
         this->button1 = gcnew System::Windows::Forms::Button;
         this->dataGrid1 = gcnew System::Windows::Forms::DataGrid;
         this->comboBox2 = gcnew System::Windows::Forms::ComboBox;
         this->button2 = gcnew System::Windows::Forms::Button;
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->dataGrid1))->BeginInit();
         this->SuspendLayout();

         //
         // comboBox1
         //
         this->comboBox1->DropDownWidth = 136;
         array<Object^>^temp0 = {"Blue","Red","Yellow"};
         this->comboBox1->Items->AddRange( temp0 );
         this->comboBox1->Location = System::Drawing::Point( 56, 144 );
         this->comboBox1->Name = "comboBox1";
         this->comboBox1->Size = System::Drawing::Size( 136, 21 );
         this->comboBox1->Sorted = true;
         this->comboBox1->TabIndex = 2;
         this->comboBox1->DropDownStyle = ComboBoxStyle::DropDownList;

         //
         // button1
         //
         this->button1->Location = System::Drawing::Point( 232, 144 );
         this->button1->Name = "button1";
         this->button1->Size = System::Drawing::Size( 96, 32 );
         this->button1->TabIndex = 1;
         this->button1->Text = "Change Header Background";
         this->button1->Click += gcnew System::EventHandler( this, &Form1::OnHeaderBackColor_Click );

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
         // comboBox2
         //
         this->comboBox2->DropDownWidth = 136;
         array<Object^>^temp1 = {"Green","White","Violet"};
         this->comboBox2->Items->AddRange( temp1 );
         this->comboBox2->Location = System::Drawing::Point( 56, 192 );
         this->comboBox2->Name = "comboBox2";
         this->comboBox2->Size = System::Drawing::Size( 136, 21 );
         this->comboBox2->TabIndex = 3;
         this->comboBox2->DropDownStyle = ComboBoxStyle::DropDownList;

         //
         // button2
         //
         this->button2->Location = System::Drawing::Point( 232, 184 );
         this->button2->Name = "button2";
         this->button2->Size = System::Drawing::Size( 96, 32 );
         this->button2->TabIndex = 4;
         this->button2->Text = "Change Header ForeGround";
         this->button2->Click += gcnew System::EventHandler( this, &Form1::OnHeaderForeColor_Click );

         //
         // Form1
         //
         this->ClientSize = System::Drawing::Size( 536, 301 );
         array<System::Windows::Forms::Control^>^formControls = {this->button2,this->comboBox2,this->comboBox1,this->button1,this->dataGrid1};
         this->Controls->AddRange( formControls );
         this->Name = "Form1";
         this->Text = "Form1";
         this->Load += gcnew System::EventHandler( this, &Form1::Form1_Load );
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->dataGrid1))->EndInit();
         this->ResumeLayout( false );
      }

      // Declare objects of DataSet, DataGrid, DataTable.
      DataSet^ myDataSet;

   public:
      DataTable^ myCustomerTable;
      DataGridTableStyle^ myTableStyle;

   private:
      void Form1_Load( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         comboBox1->SelectedIndex = 0;
         comboBox2->SelectedIndex = 0;
         Create_Table();
      }

      // <Snippet1>
      // <Snippet2>
      // <Snippet3>
      // <Snippet4>
   private:
      void Create_Table()
      {
         // Create DataSet.
         myDataSet = gcnew DataSet( "myDataSet" );

         // Create DataTable.
         DataTable^ myCustomerTable = gcnew DataTable( "Customers" );

         // Create two columns, and add them to the table.
         DataColumn^ CustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ CustName = gcnew DataColumn( "CustName" );
         myCustomerTable->Columns->Add( CustID );
         myCustomerTable->Columns->Add( CustName );

         // Add table to DataSet.
         myDataSet->Tables->Add( myCustomerTable );
         dataGrid1->SetDataBinding( myDataSet, "Customers" );
         myTableStyle = gcnew DataGridTableStyle;
         myTableStyle->MappingName = "Customers";
         myTableStyle->HeaderBackColorChanged += gcnew System::EventHandler( this, &Form1::HeaderBackColorChangedHandler );
         myTableStyle->HeaderForeColorChanged += gcnew System::EventHandler( this, &Form1::HeaderForeColorChangedHandler );
      }

      // Change header background color.
      void OnHeaderBackColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         dataGrid1->TableStyles->Clear();
         String^ str = dynamic_cast<String^>(comboBox1->SelectedItem);
         if ( str->Equals( "Red" ) )
                  myTableStyle->ForeColor = Color::Red;
         else
         if ( str->Equals( "Yellow" ) )
                  myTableStyle->ForeColor = Color::Yellow;
         else
         if ( str->Equals( "Blue" ) )
                  myTableStyle->ForeColor = Color::Blue;

         myTableStyle->AlternatingBackColor = Color::LightGray;
         dataGrid1->TableStyles->Add( myTableStyle );
      }
      // </Snippet4>

      void HeaderBackColorChangedHandler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( String::Concat( "Changed Header Background color to : ", comboBox1->SelectedItem ), "Success", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
      }
      // </Snippet3>

      // Change header forecolor.
      void OnHeaderForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         dataGrid1->TableStyles->Clear();
         String^ str = dynamic_cast<String^>(comboBox1->SelectedItem);
         if ( str->Equals( "Green" ) )
                  myTableStyle->ForeColor = Color::Green;
         else
         if ( str->Equals( "White" ) )
                  myTableStyle->ForeColor = Color::White;
         else
         if ( str->Equals( "Violet" ) )
                  myTableStyle->ForeColor = Color::Violet;

         myTableStyle->AlternatingBackColor = Color::LightGray;
         dataGrid1->TableStyles->Add( myTableStyle );
      }
      // </Snippet2>

      void HeaderForeColorChangedHandler( Object^ /*sender*/, EventArgs^ /*e*/ )
      {
         MessageBox::Show( String::Concat( "Changed Header Fore color to : ", comboBox2->SelectedItem ), "Success", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
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
