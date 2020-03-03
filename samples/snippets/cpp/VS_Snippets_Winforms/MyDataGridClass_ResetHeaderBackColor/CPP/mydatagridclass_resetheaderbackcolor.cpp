// System::Windows::Forms::DataGrid::ResetHeaderBackColor
// System::Windows::Forms::DataGrid::ResetHeaderForeColor
// System::Windows::Forms::DataGrid::ResetHeaderFont
// System::Windows::Forms::DataGrid::Select
// System::Windows::Forms::DataGrid::IsSelected
// System::Windows::Forms::DataGrid::RowHeaderWidth

/* The following program demonstrates various methods and properties of
the 'DataGrid' class. It creates a 'GridControl', changes the
header background color, header foreground color, header font
and resets them. It also selects a row, checks weather the row is selected
and checks the 'ReadOnly'    and 'FlatMode' properties of the data grid.
Displays the 'RowHeaderWidth', depending on the selection of
buttons.
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

/// <summary>
/// Summary description for MyDataGridClass_ResetHeaderBackColor.
/// </summary>
public ref class MyDataGridClass_ResetHeaderBackColor: public Form
{
private:
   DataGrid^ myDataGrid;

   /// <summary>
   /// Required designer variable.
   /// </summary>
   System::ComponentModel::Container^ components;
   Button^ button1;
   Button^ button2;
   Button^ button3;
   Button^ button4;
   Button^ button5;
   Button^ button6;
   Button^ button7;
   Button^ button8;
   DataSet^ myDataSet;
   Button^ button9;
   Button^ button11;

public:
   MyDataGridClass_ResetHeaderBackColor()
   {
      components = nullptr;
      InitializeComponent();
      SetUp();
   }

public:

   /// <summary>
   /// Clean up any resources being used.
   /// </summary>
   ~MyDataGridClass_ResetHeaderBackColor()
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
      this->FormBorderStyle = ::FormBorderStyle::FixedDialog;
      this->button8 = gcnew Button;
      this->button9 = gcnew Button;
      this->button11 = gcnew Button;
      this->button4 = gcnew Button;
      this->button5 = gcnew Button;
      this->button6 = gcnew Button;
      this->button7 = gcnew Button;
      this->button1 = gcnew Button;
      this->button2 = gcnew Button;
      this->button3 = gcnew Button;
      this->myDataGrid = gcnew DataGrid;
      (dynamic_cast<ISupportInitialize^>(this->myDataGrid))->BeginInit();
      this->SuspendLayout();

      //
      // button8
      //
      this->button8->Location = Point(352,176);
      this->button8->Name = "button8";
      this->button8->Size = System::Drawing::Size( 96, 40 );
      this->button8->TabIndex = 8;
      this->button8->Text = "Display Status";
      this->button8->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button8_Click );

      //
      // button9
      //
      this->button9->Location = Point(24,216);
      this->button9->Name = "button9";
      this->button9->Size = System::Drawing::Size( 96, 40 );
      this->button9->TabIndex = 9;
      this->button9->Text = "Get Row Header Width";
      this->button9->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button9_Click );

      //
      // button11
      //
      this->button11->Location = Point(256,216);
      this->button11->Name = "button11";
      this->button11->Size = System::Drawing::Size( 96, 40 );
      this->button11->TabIndex = 7;
      this->button11->Text = "UnSelect Row";
      this->button11->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button11_Click );

      //
      // button4
      //
      this->button4->Location = Point(352,72);
      this->button4->Name = "button4";
      this->button4->Size = System::Drawing::Size( 96, 40 );
      this->button4->TabIndex = 4;
      this->button4->Text = "Reset Header Fore Color";
      this->button4->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button4_Click );

      //
      // button5
      //
      this->button5->Location = Point(352,128);
      this->button5->Name = "button5";
      this->button5->Size = System::Drawing::Size( 96, 40 );
      this->button5->TabIndex = 5;
      this->button5->Text = "Reset Header Font";
      this->button5->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button5_Click );

      //
      // button6
      //
      this->button6->Location = Point(256,128);
      this->button6->Name = "button6";
      this->button6->Size = System::Drawing::Size( 96, 40 );
      this->button6->TabIndex = 6;
      this->button6->Text = "Change Header Font";
      this->button6->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button6_Click );

      //
      // button7
      //
      this->button7->Location = Point(256,176);
      this->button7->Name = "button7";
      this->button7->Size = System::Drawing::Size( 96, 40 );
      this->button7->TabIndex = 7;
      this->button7->Text = "Select Row";
      this->button7->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button7_Click );

      //
      // button1
      //
      this->button1->Location = Point(256,24);
      this->button1->Name = "button1";
      this->button1->Size = System::Drawing::Size( 96, 40 );
      this->button1->TabIndex = 1;
      this->button1->Text = "Change Header Back Color";
      this->button1->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button1_Click );

      //
      // button2
      //
      this->button2->Location = Point(352,24);
      this->button2->Name = "button2";
      this->button2->Size = System::Drawing::Size( 96, 40 );
      this->button2->TabIndex = 2;
      this->button2->Text = "Reset Header Back Color";
      this->button2->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button2_Click );

      //
      // button3
      //
      this->button3->Location = Point(256,72);
      this->button3->Name = "button3";
      this->button3->Size = System::Drawing::Size( 96, 40 );
      this->button3->TabIndex = 3;
      this->button3->Text = "Change Header Fore Color";
      this->button3->Click += gcnew EventHandler( this, &MyDataGridClass_ResetHeaderBackColor::button3_Click );

      //
      // myDataGrid
      //
      this->myDataGrid->CaptionText = "My Grid Control";
      this->myDataGrid->DataMember = "";
      this->myDataGrid->Location = Point(8,32);
      this->myDataGrid->Name = "myDataGrid";
      this->myDataGrid->RowHeaderWidth = 50;
      this->myDataGrid->Size = System::Drawing::Size( 216, 152 );
      this->myDataGrid->TabIndex = 0;

      //
      // MyDataGridClass_ResetHeaderBackColor
      //
      this->AutoScale = false;
      this->ClientSize = System::Drawing::Size( 528, 273 );
      array<Control^>^temp0 = {this->button9,this->button8,this->button7,this->button6,this->button5,this->button4,this->button3,this->button2,this->button1,this->myDataGrid,this->button11};
      this->Controls->AddRange( temp0 );
      this->MaximizeBox = false;
      this->Name = "MyDataGridClass_ResetHeaderBackColor";
      this->Text = "Grid Control";
      (dynamic_cast<ISupportInitialize^>(this->myDataGrid))->EndInit();
      this->ResumeLayout( false );
   }

   void SetUp()
   {
      MakeDataSet();
      myDataGrid->SetDataBinding( myDataSet, "Customers" );
      myDataGrid->ReadOnly = true;
   }

   void MakeDataSet()
   {
      // Create a 'DataSet'.
      myDataSet = gcnew DataSet( "myDataSet" );

      // Create a 'DataTable'.
      DataTable^ myTable = gcnew DataTable( "Customers" );

      // Create two columns, and add them to the table.
      DataColumn^ myColumn1 = gcnew DataColumn( "CustID",int::typeid );
      DataColumn^ myColumn2 = gcnew DataColumn( "CustName" );
      myTable->Columns->Add( myColumn1 );
      myTable->Columns->Add( myColumn2 );

      // Add the table to the 'DataSet'.
      myDataSet->Tables->Add( myTable );

      // For the customer, create a 'DataRow' variable.
      DataRow^ newRow;

      // Create one customer in the customers table.
      for ( int i = 1; i < 2; i++ )
      {
         newRow = myTable->NewRow();
         newRow[ "custID" ] = i;

         // Add the row to the 'Customers' table.
         myTable->Rows->Add( newRow );
      }
      myTable->Rows[ 0 ][ "custName" ] = "Customer";
   }

   // <Snippet1>
private:
   void button1_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      ColorDialog^ myColorDialog = gcnew ColorDialog;

      // Disable selecting a custom color.
      myColorDialog->AllowFullOpen = false;

      // Enable the help button.
      myColorDialog->ShowHelp = true;

      // Set the initial color to the current color.
      myColorDialog->Color = myDataGrid->HeaderBackColor;

      // Show color dialog box.
      myColorDialog->ShowDialog();

      // Set the header background color.
      myDataGrid->HeaderBackColor = myColorDialog->Color;
   }

   // Reset the header background color.
   void button2_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->ResetHeaderBackColor();
   }
   // </Snippet1>

   // <Snippet2>
private:
   void button3_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      ColorDialog^ myColorDialog = gcnew ColorDialog;

      // Disable selecting a custom color.
      myColorDialog->AllowFullOpen = false;

      // Enable the help button.
      myColorDialog->ShowHelp = true;

      // Set the initial color to the current color.
      myColorDialog->Color = myDataGrid->HeaderForeColor;

      // Show color dialog box.
      myColorDialog->ShowDialog();

      // Set the header foreground color.
      myDataGrid->HeaderForeColor = myColorDialog->Color;
   }

   // Reset the header foregroundcolor.
   void button4_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->ResetHeaderForeColor();
   }
   // </Snippet2>

   // <Snippet3>
private:
   // Set the header font to Arial with size 20.
   void button6_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->HeaderFont = gcnew System::Drawing::Font( "Arial",20 );
   }

   // Reset the header font.
   void button5_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->ResetHeaderFont();
   }
   // </Snippet3>

   // <Snippet4>
   // Select the first row.
private:
   void button7_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->Select(0);
   }

   // <Snippet5>
   // Check if the first row is selected.
private:
   void button8_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      if ( myDataGrid->IsSelected( 0 ) )
      {
         MessageBox::Show( "Row selected", "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
      }
      else
      {
         MessageBox::Show( "Row not selected", "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
      }
   }

   // Deselect the first row.
   void button11_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      myDataGrid->UnSelect( 0 );
   }
   // </Snippet5>
   // </Snippet4>

   // <Snippet6>
   // Get the width of row header.
private:
   void button9_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Int32 myRowHeaderWidth = myDataGrid->RowHeaderWidth;
      MessageBox::Show( String::Concat( "Width of row headers is: ", myRowHeaderWidth ), "Message", MessageBoxButtons::OK, MessageBoxIcon::Exclamation );
   }
   // </Snippet6>
};

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
int main()
{
   Application::Run( gcnew MyDataGridClass_ResetHeaderBackColor );
}
