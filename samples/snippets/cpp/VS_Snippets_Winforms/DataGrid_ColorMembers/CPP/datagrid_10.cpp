// System::Windows::Forms::DataGrid.SelectionBackColor
// System::Windows::Forms::DataGrid.SelectionForeColor
// System::Windows::Forms::DataGrid.ResetSelectionBackColor
// System::Windows::Forms::DataGrid.ResetSelectionForeColor
// System::Windows::Forms::DataGrid.ResetBackColor
// System::Windows::Forms::DataGrid.ResetForeColor
// System::Windows::Forms::DataGrid.ForeColor
// System::Windows::Forms::DataGrid.ResetAlternatingBackColor
// System::Windows::Forms::DataGrid.ResetLinkColor
// System::Windows::Forms::DataGrid.ResetGridLineColor

/* The following program demonstrates various members of
'System::Windows::Forms::DataGrid class' relating to Color. 
It creates a windows form, a 'DataSet' containing two 'DataTable' 
objects, and a 'DataRelation' that relates the two tables. To 
display the data, a 'DataGrid' control is then bound to the 
'DataSet' through the 'SetDataBinding' method. 
Ten buttons are provided on form to demonstrate each property.
Effet of each property can be seen on 'DataGrid'.
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

namespace DataGridSample
{
   /// <summary>
   /// Summary description for DatGridClass.
   /// </summary>
   public ref class DatGridClass: public System::Windows::Forms::Form
   {
   private:
      System::Windows::Forms::GroupBox^ groupBox1;
      System::Windows::Forms::GroupBox^ groupBox2;
      DataSet^ myDataSet;
      System::Windows::Forms::DataGrid^ myDataGrid;
      System::Windows::Forms::Button^ btnResetSelectionBkColor;
      System::Windows::Forms::Button^ btnSeSelectiontBkColor;
      System::Windows::Forms::Button^ btnSetSelectionForeColor;
      System::Windows::Forms::Button^ btnResetSelectionForeColor;
      System::Windows::Forms::Button^ btnSetForeColor;
      System::Windows::Forms::Button^ btnResetForeColor;
      System::Windows::Forms::Button^ btnSetBkColor;
      System::Windows::Forms::Button^ btnResetBkColor;
      System::Windows::Forms::GroupBox^ groupBox3;
      System::Windows::Forms::Button^ btnResetLinkColor;
      System::Windows::Forms::Button^ btnResetAlternatingBackColor;
      System::Windows::Forms::Button^ btnSetLinkColor;
      System::Windows::Forms::Button^ btnSetAlternatingBkColor;
      System::Windows::Forms::GroupBox^ groupBox4;
      System::Windows::Forms::Button^ btnResetGridLineColor;
      System::Windows::Forms::Button^ btnSetGridLineColor;

      /// <summary>
      /// Required designer variable.
      /// </summary>
      System::ComponentModel::Container^ components;

   public:
      DatGridClass()
      {
         //
         // Required for Windows Form Designer support
         //
         InitializeComponent();
         
         // Setup GridControl data.
         SetUp();
      }

   public:

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      ~DatGridClass()
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
         this->btnResetBkColor = gcnew Button;
         this->btnSetBkColor = gcnew Button;
         this->btnResetForeColor = gcnew Button;
         this->groupBox1 = gcnew GroupBox;
         this->btnSeSelectiontBkColor = gcnew Button;
         this->btnResetSelectionBkColor = gcnew Button;
         this->btnSetSelectionForeColor = gcnew Button;
         this->btnResetSelectionForeColor = gcnew Button;
         this->groupBox2 = gcnew GroupBox;
         this->btnSetForeColor = gcnew Button;
         this->groupBox3 = gcnew GroupBox;
         this->btnSetAlternatingBkColor = gcnew Button;
         this->btnSetLinkColor = gcnew Button;
         this->btnResetAlternatingBackColor = gcnew Button;
         this->btnResetLinkColor = gcnew Button;
         this->groupBox4 = gcnew GroupBox;
         this->btnSetGridLineColor = gcnew Button;
         this->btnResetGridLineColor = gcnew Button;
         this->myDataGrid = gcnew DataGrid;
         this->groupBox1->SuspendLayout();
         this->groupBox2->SuspendLayout();
         this->groupBox3->SuspendLayout();
         this->groupBox4->SuspendLayout();
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->BeginInit();
         this->SuspendLayout();

         // 
         // btnResetBkColor
         //
         this->btnResetBkColor->Location = System::Drawing::Point( 120, 56 );
         this->btnResetBkColor->Name = "btnResetBkColor";
         this->btnResetBkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnResetBkColor->TabIndex = 3;
         this->btnResetBkColor->Text = "Reset background color";
         this->btnResetBkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetBkColor_Click );

         // 
         // btnSetBkColor
         //
         this->btnSetBkColor->Location = System::Drawing::Point( 120, 24 );
         this->btnSetBkColor->Name = "btnSetBkColor";
         this->btnSetBkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnSetBkColor->TabIndex = 2;
         this->btnSetBkColor->Text = "Set background color";
         this->btnSetBkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetBkColor_Click );

         // 
         // btnResetForeColor
         //
         this->btnResetForeColor->Location = System::Drawing::Point( 16, 56 );
         this->btnResetForeColor->Name = "btnResetForeColor";
         this->btnResetForeColor->Size = System::Drawing::Size( 104, 32 );
         this->btnResetForeColor->TabIndex = 1;
         this->btnResetForeColor->Text = "Reset foreground color";
         this->btnResetForeColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetForeColor_Click );

         // 
         // groupBox1
         // 
         array<System::Windows::Forms::Control^>^groupBox1Controls = {this->btnSeSelectiontBkColor,this->btnResetSelectionBkColor,this->btnSetSelectionForeColor,this->btnResetSelectionForeColor};
         this->groupBox1->Controls->AddRange( groupBox1Controls );
         this->groupBox1->Location = System::Drawing::Point( 296, 24 );
         this->groupBox1->Name = "groupBox1";
         this->groupBox1->Size = System::Drawing::Size( 248, 96 );
         this->groupBox1->TabIndex = 4;
         this->groupBox1->TabStop = false;

         // 
         // btnSeSelectiontBkColor
         //
         this->btnSeSelectiontBkColor->Location = System::Drawing::Point( 125, 24 );
         this->btnSeSelectiontBkColor->Name = "btnSeSelectiontBkColor";
         this->btnSeSelectiontBkColor->Size = System::Drawing::Size( 112, 32 );
         this->btnSeSelectiontBkColor->TabIndex = 0;
         this->btnSeSelectiontBkColor->Text = "Set selection  background color";
         this->btnSeSelectiontBkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetSelectionBkColor_Click );

         // 
         // btnResetSelectionBkColor
         //
         this->btnResetSelectionBkColor->Location = System::Drawing::Point( 125, 56 );
         this->btnResetSelectionBkColor->Name = "btnResetSelectionBkColor";
         this->btnResetSelectionBkColor->Size = System::Drawing::Size( 112, 32 );
         this->btnResetSelectionBkColor->TabIndex = 1;
         this->btnResetSelectionBkColor->Text = "Reset selection background color";
         this->btnResetSelectionBkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetSelectionBkColor_Click );

         // 
         // btnSetSelectionForeColor
         //
         this->btnSetSelectionForeColor->Location = System::Drawing::Point( 13, 24 );
         this->btnSetSelectionForeColor->Name = "btnSetSelectionForeColor";
         this->btnSetSelectionForeColor->Size = System::Drawing::Size( 112, 32 );
         this->btnSetSelectionForeColor->TabIndex = 2;
         this->btnSetSelectionForeColor->Text = "Set selection  foreground color";
         this->btnSetSelectionForeColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetSelectionForeColor_Click );

         // 
         // btnResetSelectionForeColor
         //
         this->btnResetSelectionForeColor->Location = System::Drawing::Point( 13, 56 );
         this->btnResetSelectionForeColor->Name = "btnResetSelectionForeColor";
         this->btnResetSelectionForeColor->Size = System::Drawing::Size( 112, 32 );
         this->btnResetSelectionForeColor->TabIndex = 3;
         this->btnResetSelectionForeColor->Text = "Reset selection  foreground color";
         this->btnResetSelectionForeColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetSelectionForeColor_Click );

         // 
         // groupBox2
         // 
         array<System::Windows::Forms::Control^>^groupBox2Controls = {this->btnResetBkColor,this->btnSetBkColor,this->btnResetForeColor,this->btnSetForeColor};
         this->groupBox2->Controls->AddRange( groupBox2Controls );
         this->groupBox2->Font = gcnew System::Drawing::Font( "Microsoft Sans Serif",8.25F,System::Drawing::FontStyle::Regular,System::Drawing::GraphicsUnit::Point,((System::Byte)(0)) );
         this->groupBox2->Location = System::Drawing::Point( 296, 128 );
         this->groupBox2->Name = "groupBox2";
         this->groupBox2->Size = System::Drawing::Size( 248, 96 );
         this->groupBox2->TabIndex = 5;
         this->groupBox2->TabStop = false;

         // 
         // btnSetForeColor
         //
         this->btnSetForeColor->Location = System::Drawing::Point( 16, 24 );
         this->btnSetForeColor->Name = "btnSetForeColor";
         this->btnSetForeColor->Size = System::Drawing::Size( 104, 32 );
         this->btnSetForeColor->TabIndex = 0;
         this->btnSetForeColor->Text = "Set foreground color";
         this->btnSetForeColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetForeColor_Click );

         // 
         // groupBox3
         // 
         array<System::Windows::Forms::Control^>^groupBox3Controls = {this->btnSetAlternatingBkColor,this->btnSetLinkColor,this->btnResetAlternatingBackColor,this->btnResetLinkColor};
         this->groupBox3->Controls->AddRange( groupBox3Controls );
         this->groupBox3->Location = System::Drawing::Point( 296, 224 );
         this->groupBox3->Name = "groupBox3";
         this->groupBox3->Size = System::Drawing::Size( 248, 96 );
         this->groupBox3->TabIndex = 7;
         this->groupBox3->TabStop = false;

         // 
         // btnSetAlternatingBkColor
         //
         this->btnSetAlternatingBkColor->Location = System::Drawing::Point( 121, 24 );
         this->btnSetAlternatingBkColor->Name = "btnSetAlternatingBkColor";
         this->btnSetAlternatingBkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnSetAlternatingBkColor->TabIndex = 5;
         this->btnSetAlternatingBkColor->Text = "Set alternating back color";
         this->btnSetAlternatingBkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetAlternatingBkColor_Click );

         // 
         // btnSetLinkColor
         //
         this->btnSetLinkColor->Location = System::Drawing::Point( 17, 24 );
         this->btnSetLinkColor->Name = "btnSetLinkColor";
         this->btnSetLinkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnSetLinkColor->TabIndex = 4;
         this->btnSetLinkColor->Text = "Set link color";
         this->btnSetLinkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetLinkColor_Click );

         // 
         // btnResetAlternatingBackColor
         //
         this->btnResetAlternatingBackColor->Location = System::Drawing::Point( 121, 56 );
         this->btnResetAlternatingBackColor->Name = "btnResetAlternatingBackColor";
         this->btnResetAlternatingBackColor->Size = System::Drawing::Size( 104, 32 );
         this->btnResetAlternatingBackColor->TabIndex = 3;
         this->btnResetAlternatingBackColor->Text = "Reset alternating back color";
         this->btnResetAlternatingBackColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetAlternatingBackColor_Click );

         // 
         // btnResetLinkColor
         //
         this->btnResetLinkColor->Location = System::Drawing::Point( 17, 56 );
         this->btnResetLinkColor->Name = "btnResetLinkColor";
         this->btnResetLinkColor->Size = System::Drawing::Size( 104, 32 );
         this->btnResetLinkColor->TabIndex = 1;
         this->btnResetLinkColor->Text = "Reset link color";
         this->btnResetLinkColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetLinkColor_Click );

         // 
         // groupBox4
         // 
         array<System::Windows::Forms::Control^>^groupBox4Controls = {this->btnSetGridLineColor,this->btnResetGridLineColor};
         this->groupBox4->Controls->AddRange( groupBox4Controls );
         this->groupBox4->Location = System::Drawing::Point( 164, 226 );
         this->groupBox4->Name = "groupBox4";
         this->groupBox4->Size = System::Drawing::Size( 124, 93 );
         this->groupBox4->TabIndex = 8;
         this->groupBox4->TabStop = false;

         // 
         // btnSetGridLineColor
         //
         this->btnSetGridLineColor->Location = System::Drawing::Point( 8, 16 );
         this->btnSetGridLineColor->Name = "btnSetGridLineColor";
         this->btnSetGridLineColor->Size = System::Drawing::Size( 104, 32 );
         this->btnSetGridLineColor->TabIndex = 3;
         this->btnSetGridLineColor->Text = "Set grid line color";
         this->btnSetGridLineColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnSetGridLineColor_Click );

         // 
         // btnResetGridLineColor
         //
         this->btnResetGridLineColor->Location = System::Drawing::Point( 8, 48 );
         this->btnResetGridLineColor->Name = "btnResetGridLineColor";
         this->btnResetGridLineColor->Size = System::Drawing::Size( 104, 32 );
         this->btnResetGridLineColor->TabIndex = 0;
         this->btnResetGridLineColor->Text = "Reset grid line color";
         this->btnResetGridLineColor->Click += gcnew System::EventHandler( this, &DatGridClass::btnResetGridLineColor_Click );

         // 
         // myDataGrid
         // 
         this->myDataGrid->DataMember = "";
         this->myDataGrid->ForeColor = System::Drawing::Color::Blue;
         this->myDataGrid->Location = System::Drawing::Point( 12, 32 );
         this->myDataGrid->Name = "myDataGrid";
         this->myDataGrid->Size = System::Drawing::Size( 272, 192 );
         this->myDataGrid->TabIndex = 6;
         this->myDataGrid->ReadOnly = true;

         // 
         // DatGridClass
         //
         this->ClientSize = System::Drawing::Size( 560, 333 );
         array<System::Windows::Forms::Control^>^dataGridClassControls = {this->groupBox4,this->groupBox3,this->myDataGrid,this->groupBox2,this->groupBox1};
         this->Controls->AddRange( dataGridClassControls );
         this->Name = "DatGridClass";
         this->Text = "Sample Program";
         this->groupBox1->ResumeLayout( false );
         this->groupBox2->ResumeLayout( false );
         this->groupBox3->ResumeLayout( false );
         this->groupBox4->ResumeLayout( false );
         (dynamic_cast<System::ComponentModel::ISupportInitialize^>(this->myDataGrid))->EndInit();
         this->ResumeLayout( false );
      }

      void SetUp()
      {
         // Create a 'DataSet' with two tables and one relation.
         MakeDataSet();

         // Bind the 'DataGrid' to the 'DataSet'. The data member
         // specifies that the 'Customers Table' should be displayed.
         myDataGrid->SetDataBinding( myDataSet, "Customers" );
      }

      // Create a 'DataSet' with two tables and populate it.
      void MakeDataSet()
      {
         // Create a 'DataSet'.
         myDataSet = gcnew DataSet( "myDataSet" );

         // Create two 'DataTables'.
         DataTable^ tCust = gcnew DataTable( "Customers" );
         DataTable^ tOrders = gcnew DataTable( "Orders" );

         // Create two columns, and add them to the first table.
         DataColumn^ cCustID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cCustName = gcnew DataColumn( "CustName" );
         DataColumn^ cCurrent = gcnew DataColumn( "Current",bool::typeid );
         tCust->Columns->Add( cCustID );
         tCust->Columns->Add( cCustName );
         tCust->Columns->Add( cCurrent );

         // Create three columns and add them to the second table.
         DataColumn^ cID = gcnew DataColumn( "CustID",int::typeid );
         DataColumn^ cOrderDate = gcnew DataColumn( "OrderDate",DateTime::typeid );
         DataColumn^ cOrderAmount = gcnew DataColumn( "OrderAmount",String::typeid );
         tOrders->Columns->Add( cID );
         tOrders->Columns->Add( cOrderAmount );
         tOrders->Columns->Add( cOrderDate );

         // Add the tables to the 'DataSet'.
         myDataSet->Tables->Add( tCust );
         myDataSet->Tables->Add( tOrders );

         // Create a 'DataRelation' and add it to the 'DataSet'.
         DataRelation^ dr = gcnew DataRelation( "custToOrders",cCustID,cID );
         myDataSet->Relations->Add( dr );

         // Populate the tables. For each customer and order, 
         // create need two 'DataRow' variables. 
         DataRow^ newRow1;
         DataRow^ newRow2;

         // Create three customers in the 'Customers Table'.
         for ( int i = 1; i < 4; i++ )
         {
            newRow1 = tCust->NewRow();
            newRow1[ "custID" ] = i;

            // Add the row to the 'Customers Table'.
            tCust->Rows->Add( newRow1 );
         }
         tCust->Rows[ 0 ][ "custName" ] = "Alpha";
         tCust->Rows[ 1 ][ "custName" ] = "Beta";
         tCust->Rows[ 2 ][ "custName" ] = "Omega";

         // Give the current column a value.
         tCust->Rows[ 0 ][ "Current" ] = true.ToString();
         tCust->Rows[ 1 ][ "Current" ] = true.ToString();
         tCust->Rows[ 2 ][ "Current" ] = false.ToString();

         // For each customer, create five rows in the orders table.
         double myNumber = 0;
         String^ myString;
         for ( int i = 1; i < 4; i++ )
         {
            for ( int j = 1; j < 6; j++ )
            {
               newRow2 = tOrders->NewRow();
               newRow2[ "CustID" ] = i;
               newRow2[ "orderDate" ] = DateTime(2001,i,j * 2);
               myNumber = i * 10 + j * .1;
               myString = "$ ";
               myString = String::Concat( myString, myNumber );
               newRow2[ "OrderAmount" ] = myString;
               
               // Add the row to the orders table.
               tOrders->Rows->Add( newRow2 );
            }
         }
      }

      void btnSetSelectionBkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet1> 
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Keep the user from selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help.
         myColorDialog->ShowHelp = true;

         // Set the initial color select to the current color.
         myColorDialog->Color = myDataGrid->SelectionBackColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set selection background color to selected color.
         myDataGrid->SelectionBackColor = myColorDialog->Color;
         // </Snippet1>
      }

      void btnResetSelectionBkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet2>
         // String variable used to show message.
         String^ myString = "Selection backgound color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->SelectionBackColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset selection background color to default.
         myDataGrid->ResetSelectionBackColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->SelectionBackColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Selection background color information" );
         // </Snippet2>
      }

      void btnSetSelectionForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet3>
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Disable selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Enable the help button.
         myColorDialog->ShowHelp = true;

         // Set the initial color to the current color.
         myColorDialog->Color = myDataGrid->SelectionForeColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set selection foreground color to selected color.
         myDataGrid->SelectionForeColor = myColorDialog->Color;
         // </Snippet3>           
      }

      void btnResetSelectionForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet4>
         // String variable used to show message.   
         String^ myString = "Selection foreground color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->SelectionForeColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset selection foreground color to default.
         myDataGrid->ResetSelectionForeColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->SelectionForeColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Selection foreground color information" );
         // </Snippet4>
      }

      void btnSetForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet5>
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Disable selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Enable the help button. 
         myColorDialog->ShowHelp = true;

         // Set the initial color to the current color.
         myColorDialog->Color = myDataGrid->ForeColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set foreground color to selected color.
         myDataGrid->ForeColor = myColorDialog->Color;
         // </Snippet5>
      }

      void btnResetForeColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet6>
         // String variable used to show message.   
         String^ myString = "Foreground color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->ForeColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset foreground color to default.
         myDataGrid->ResetForeColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->ForeColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Foreground color information" );
         // </Snippet6>
      }

      void btnSetBkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Create a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Disable selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help. 
         myColorDialog->ShowHelp = true;

         // Set the initial color to the current color.
         myColorDialog->Color = myDataGrid->BackColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set background color to selected color.
         myDataGrid->BackColor = myColorDialog->Color;
      }

      void btnResetBkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet7>
         // String variable used to show message.   
         String^ myString = "Backgound color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->BackColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset background color to default.
         myDataGrid->ResetBackColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->BackColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Background color information" );
         // </Snippet7>
      }

      void btnResetGridLineColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet8>
         // String variable used to show message.   
         String^ myString = "Grid line color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->GridLineColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset grid line color to default.
         myDataGrid->ResetGridLineColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->GridLineColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Grid line color information" );
         // </Snippet8>
      }

      void btnResetLinkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet9>
         // String variable used to show message.   
         String^ myString = "Link color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->LinkColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset link color to default.
         myDataGrid->ResetLinkColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->LinkColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Link line color information" );
         // </Snippet9>
      }

      void btnResetAlternatingBackColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // <Snippet10>
         // String variable used to show message.   
         String^ myString = "Alternating back color changed from: ";

         // Store current foreground color of selected cells.
         Color myCurrentColor = myDataGrid->AlternatingBackColor;
         myString = String::Concat( myString, myCurrentColor.ToString() );

         // Reset alternating back color to default.
         myDataGrid->ResetAlternatingBackColor();
         myString = String::Concat( myString, " to " );
         myString = String::Concat( myString, myDataGrid->AlternatingBackColor.ToString() );

         // Show information about changes in color setting.  
         MessageBox::Show( myString, "Alternating back color information" );
         // </Snippet10>
      }

      void btnSetGridLineColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Disable selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help. 
         myColorDialog->ShowHelp = true;

         // Set the initial color to the current color.
         myColorDialog->Color = myDataGrid->GridLineColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set grid line color to selected color.
         myDataGrid->GridLineColor = myColorDialog->Color;
      }

      void btnSetLinkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Disable selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help. 
         myColorDialog->ShowHelp = true;

         // Set the initial color to the current color.
         myColorDialog->Color = myDataGrid->LinkColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set link color to selected color.
         myDataGrid->LinkColor = myColorDialog->Color;
      }

      void btnSetAlternatingBkColor_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
      {
         // Creates a common color dialog box.
         ColorDialog^ myColorDialog = gcnew ColorDialog;

         // Disable selecting a custom color.
         myColorDialog->AllowFullOpen = false;

         // Allow the user to get help. 
         myColorDialog->ShowHelp = true;

         // Set the initial color to the current color.
         myColorDialog->Color = myDataGrid->AlternatingBackColor;

         // Show color dialog box.
         myColorDialog->ShowDialog();

         // Set alternating background color to selected color.
         myDataGrid->AlternatingBackColor = myColorDialog->Color;
      }
   };
}

/// <summary>
/// The main entry point for the application.
/// </summary>

[STAThread]
void main()
{
   Application::Run( gcnew DataGridSample::DatGridClass );
}
