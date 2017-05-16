

//<snippet0>
#using <System.Windows.Forms.dll>
#using <System.dll>
#using <System.Drawing.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class ProgrammaticSizing: public System::Windows::Forms::Form
{
private:
   FlowLayoutPanel^ flowLayoutPanel1;
   Button^ button1;
   Button^ button2;
   Button^ button3;
   Button^ button4;
   Button^ button5;
   Button^ button6;
   Button^ button7;
   Button^ button8;
   Button^ button9;
   Button^ button10;
   Button^ button11;

public:
   ProgrammaticSizing()
   {
      button1 = gcnew Button;
      button2 = gcnew Button;
      button3 = gcnew Button;
      button4 = gcnew Button;
      button5 = gcnew Button;
      button6 = gcnew Button;
      button7 = gcnew Button;
      button8 = gcnew Button;
      button9 = gcnew Button;
      button10 = gcnew Button;
      button11 = gcnew Button;
      thirdColumnHeader = "Main Ingredients";
      boringMeatloaf = "ground beef";
      boringMeatloafRanking = "*";
      otherResturant = "Gomes's Saharan Sushi";
      InitializeComponent();
      AddDirections();
      this->Load += gcnew EventHandler( this, &ProgrammaticSizing::InitializeDataGridView );
      AddButton( button1, "Reset", gcnew EventHandler( this, &ProgrammaticSizing::ResetToDisorder ) );
      AddButton( button2, "Change Column 3 Header", gcnew EventHandler( this, &ProgrammaticSizing::ChangeColumn3Header ) );
      AddButton( button3, "Change Meatloaf Recipe", gcnew EventHandler( this, &ProgrammaticSizing::ChangeMeatloafRecipe ) );
      AddButton( button10, "Change Resturant 2", gcnew EventHandler( this, &ProgrammaticSizing::ChangeResturant ) );
      AddButtonsForProgrammaticResizing();
   }


private:
   void InitializeComponent()
   {
      this->flowLayoutPanel1 = gcnew FlowLayoutPanel;
      this->flowLayoutPanel1->FlowDirection = FlowDirection::TopDown;
      this->flowLayoutPanel1->Location = Point(492,0);
      this->flowLayoutPanel1->AutoSize = true;
      this->AutoSize = true;
      this->Controls->Add( this->flowLayoutPanel1 );
      this->Text = this->GetType()->Name;
   }

   void AddDirections()
   {
      Label^ directions = gcnew Label;
      directions->AutoSize = true;
      String^ newLine = Environment::NewLine;
      directions->Text = String::Format( "Press the buttons that start {0}with 'Change' to see how different sizing {1}modes deal with content changes.", newLine, newLine );
      flowLayoutPanel1->Controls->Add( directions );
   }

   System::Drawing::Size startingSize;
   String^ thirdColumnHeader;
   String^ boringMeatloaf;
   String^ boringMeatloafRanking;
   bool boringRecipe;
   bool shortMode;
   DataGridView^ dataGridView1;
   String^ otherResturant;
   void InitializeDataGridView( Object^ /*sender*/, EventArgs^ /*ignoredToo*/ )
   {
      this->dataGridView1 = gcnew DataGridView;
      this->dataGridView1->Location = Point(0,0);
      this->dataGridView1->Size = System::Drawing::Size( 292, 266 );
      this->Controls->Add( this->dataGridView1 );
      startingSize = System::Drawing::Size( 450, 400 );
      dataGridView1->Size = startingSize;
      AddColumns();
      PopulateRows();
      shortMode = false;
      boringRecipe = true;
   }

   void AddColumns()
   {
      dataGridView1->ColumnCount = 4;
      dataGridView1->ColumnHeadersVisible = true;
      DataGridViewCellStyle ^ columnHeaderStyle = gcnew DataGridViewCellStyle;
      columnHeaderStyle->BackColor = Color::Aqua;
      columnHeaderStyle->Font = gcnew System::Drawing::Font( "Verdana",10,FontStyle::Bold );
      dataGridView1->ColumnHeadersDefaultCellStyle = columnHeaderStyle;
      dataGridView1->Columns[ 0 ]->Name = "Recipe";
      dataGridView1->Columns[ 1 ]->Name = "Category";
      dataGridView1->Columns[ 2 ]->Name = thirdColumnHeader;
      dataGridView1->Columns[ 3 ]->Name = "Rating";
   }

   void PopulateRows()
   {
      array<String^>^row1 = {"Meatloaf","Main Dish",boringMeatloaf,boringMeatloafRanking};
      array<String^>^row2 = {"Key Lime Pie","Dessert","lime juice, evaporated milk","****"};
      array<String^>^row3 = {"Orange-Salsa Pork Chops","Main Dish","pork chops, salsa, orange juice","****"};
      array<String^>^row4 = {"Black Bean and Rice Salad","Salad","black beans, brown rice","****"};
      array<String^>^row5 = {"Chocolate Cheesecake","Dessert","cream cheese","***"};
      array<String^>^row6 = {"Black Bean Dip","Appetizer","black beans, sour cream","***"};
      array<Object^>^rows = {row1,row2,row3,row4,row5,row6};
      IEnumerator^ myEnum = rows->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         array<String^>^row = safe_cast<array<String^>^>(myEnum->Current);
         dataGridView1->Rows->Add( row );
      }

      IEnumerator^ myEnum1 = safe_cast<IEnumerable^>(dataGridView1->Rows)->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewRow ^ row = safe_cast<DataGridViewRow ^>(myEnum1->Current);
         if ( row->IsNewRow )
                  break;
         row->HeaderCell->Value = String::Format( "Resturant {0}", row->Index );
      }
   }

   void AddButton( Button^ button, String^ buttonLabel, EventHandler^ handler )
   {
      button->Text = buttonLabel;
      button->AutoSize = true;
      flowLayoutPanel1->Controls->Add( button );
      button->Click += handler;
   }

   void ResetToDisorder( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Controls->Remove( dataGridView1 );
      dataGridView1->Size = startingSize;
      dataGridView1->DataGridView::~DataGridView();
      InitializeDataGridView( nullptr, nullptr );
   }

   void ChangeColumn3Header( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Toggle(  &shortMode );
      if ( shortMode )
            dataGridView1->Columns[ 2 ]->HeaderText = "S";
      else
            dataGridView1->Columns[ 2 ]->HeaderText = thirdColumnHeader;
   }

   void Toggle( interior_ptr<Boolean> toggleThis )
   {
       *toggleThis =  ! *toggleThis;
   }

   void ChangeMeatloafRecipe( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Toggle(  &boringRecipe );
      if ( boringRecipe )
            SetMeatloaf( boringMeatloaf, boringMeatloafRanking );
      else
      {
         String^ greatMeatloafRecipe = "1 lb. lean ground beef, "
         "1/2 cup bread crumbs, 1/4 cup ketchup,"
         "1/3 tsp onion powder, "
         "1 clove of garlic, 1/2 pack onion soup mix "
         " dash of your favorite BBQ Sauce";
         SetMeatloaf( greatMeatloafRecipe, "***" );
      }
   }

   void SetMeatloaf( String^ recipe, String^ rating )
   {
      dataGridView1->Rows[ 0 ]->Cells[ 2 ]->Value = recipe;
      dataGridView1->Rows[ 0 ]->Cells[ 3 ]->Value = rating;
   }

   void ChangeResturant( Object^ /*sender*/, EventArgs^ /*ignored*/ )
   {
      if ( dataGridView1->Rows[ 2 ]->HeaderCell->Value == otherResturant )
            dataGridView1->Rows[ 2 ]->HeaderCell->Value = "Resturant 2";
      else
            dataGridView1->Rows[ 2 ]->HeaderCell->Value = otherResturant;
   }

   void AddButtonsForProgrammaticResizing()
   {
      AddButton( button4, "Size Third Column", gcnew EventHandler( this, &ProgrammaticSizing::SizeThirdColumnHeader ) );
      AddButton( button5, "Size Column Headers", gcnew EventHandler( this, &ProgrammaticSizing::SizeColumnHeaders ) );
      AddButton( button6, "Size All Columns", gcnew EventHandler( this, &ProgrammaticSizing::SizeAllColumns ) );
      AddButton( button7, "Size Third Row", gcnew EventHandler( this, &ProgrammaticSizing::SizeThirdRow ) );
      AddButton( button8, "Size First Row Header Using All Headers", gcnew EventHandler( this, &ProgrammaticSizing::SizeFirstRowHeaderToAllHeaders ) );
      AddButton( button9, "Size All Rows and Row Headers", gcnew EventHandler( this, &ProgrammaticSizing::SizeAllRowsAndTheirHeaders ) );
      AddButton( button11, "Size All Rows ", gcnew EventHandler( this, &ProgrammaticSizing::SizeAllRows ) );
   }


   //<snippet1>
   void SizeThirdColumnHeader( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->AutoResizeColumn(2, DataGridViewAutoSizeColumnMode::ColumnHeader);
   }


   //</snippet1>
   //<snippet2>
   void SizeColumnHeaders( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      int columnNumber;
      bool dontChangeColumnWidth;
      bool dontChangeRowHeadersWidth;
      dataGridView1->AutoResizeColumnHeadersHeight(2);
   }


   //</snippet2>
   //<snippet3>
   void SizeAllColumns( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->AutoResizeColumns( DataGridViewAutoSizeColumnsMode::AllCells );
   }


   //</snippet3>
   //<snippet4>
   void SizeThirdRow( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->AutoResizeRow(2, DataGridViewAutoSizeRowMode::AllCellsExceptHeader);
   }


   //</snippet4>
   //<snippet5>
   void SizeFirstRowHeaderToAllHeaders( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode::AutoSizeToAllHeaders);
   }


   //</snippet5>
   //<snippet6>
   void SizeAllRowsAndTheirHeaders( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->AutoResizeRows(DataGridViewAutoSizeRowsMode::AllCells);
   }


   //</snippet6>
   //<snippet7>
   void SizeAllRows( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->AutoResizeRows(DataGridViewAutoSizeRowsMode::AllCellsExceptHeaders);
   }

   //</snippet7>
};


[STAThread]
int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew ProgrammaticSizing );
}

//</snippet0>
