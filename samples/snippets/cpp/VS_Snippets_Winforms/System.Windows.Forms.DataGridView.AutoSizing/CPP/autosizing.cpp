

//<snippet0>
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class AutoSizing: public System::Windows::Forms::Form
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
   AutoSizing()
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
      otherRestaurant = "Gomes's Saharan Sushi";
      currentLayoutName = "DataGridView.AutoSizeRowsMode is currently: ";
      InitializeComponent();
      this->Load += gcnew EventHandler( this, &AutoSizing::InitializeDataGridView );
      AddDirections();
      AddButton( button1, "Reset", gcnew EventHandler( this, &AutoSizing::ResetToDisorder ) );
      AddButton( button2, "Change Column 3 Header", gcnew EventHandler( this, &AutoSizing::ChangeColumn3Header ) );
      AddButton( button3, "Change Meatloaf Recipe", gcnew EventHandler( this, &AutoSizing::ChangeMeatloafRecipe ) );
      AddButton( button4, "Change Restaurant 2", gcnew EventHandler( this, &AutoSizing::ChangeRestaurant ) );
      AddButtonsForAutomaticResizing();
   }


private:
   void AddDirections()
   {
      Label^ directions = gcnew Label;
      directions->AutoSize = true;
      String^ newLine = Environment::NewLine;
      directions->Text = String::Format( "Press the buttons that start {0}with 'Change' to see how different sizing {1}modes deal with content changes.", newLine, newLine );
      flowLayoutPanel1->Controls->Add( directions );
   }

   void InitializeComponent()
   {
      flowLayoutPanel1 = gcnew FlowLayoutPanel;
      flowLayoutPanel1->FlowDirection = FlowDirection::TopDown;
      flowLayoutPanel1->Location = System::Drawing::Point( 492, 0 );
      flowLayoutPanel1->AutoSize = true;
      flowLayoutPanel1->TabIndex = 1;
      ClientSize = System::Drawing::Size( 674, 419 );
      Controls->Add( flowLayoutPanel1 );
      Text = this->GetType()->Name;
      AutoSize = true;
   }

   System::Drawing::Size startingSize;
   String^ thirdColumnHeader;
   String^ boringMeatloaf;
   String^ boringMeatloafRanking;
   bool boringRecipe;
   bool shortMode;
   DataGridView^ dataGridView1;
   String^ otherRestaurant;
   void InitializeDataGridView( Object^ /*ignored*/, EventArgs^ /*ignoredToo*/ )
   {
      dataGridView1 = gcnew System::Windows::Forms::DataGridView;
      Controls->Add( dataGridView1 );
      startingSize = System::Drawing::Size( 450, 400 );
      dataGridView1->Size = startingSize;
      dataGridView1->AutoSizeRowsModeChanged += gcnew DataGridViewAutoSizeModeEventHandler( this, &AutoSizing::WatchRowsModeChanges );
      AddLabels();
      SetUpColumns();
      PopulateRows();
      shortMode = false;
      boringRecipe = true;
   }

   void SetUpColumns()
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
         row->HeaderCell->Value = String::Format( "Restaurant {0}", row->Index );
      }
   }

   void AddButton( Button^ button, String^ buttonLabel, EventHandler^ handler )
   {
      button->Click += handler;
      button->Text = buttonLabel;
      button->AutoSize = true;
      button->TabIndex = flowLayoutPanel1->Controls->Count;
      flowLayoutPanel1->Controls->Add( button );
   }

   void ResetToDisorder( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      Controls->Remove( dataGridView1 );
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

   Boolean Toggle( interior_ptr<Boolean> toggleThis )
   {
       *toggleThis =  ! *toggleThis;
      return  *toggleThis;
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
         "1 clove of garlic, 1/2 pack onion soup mix,"
         " dash of your favorite BBQ Sauce";
         SetMeatloaf( greatMeatloafRecipe, "***" );
      }
   }

   void ChangeRestaurant( Object^ /*sender*/, EventArgs^ /*ignored*/ )
   {
      if ( dataGridView1->Rows[ 2 ]->HeaderCell->Value->ToString()->Equals( otherRestaurant ) )
            dataGridView1->Rows[ 2 ]->HeaderCell->Value = "Restaurant 2";
      else
            dataGridView1->Rows[ 2 ]->HeaderCell->Value = otherRestaurant;
   }

   void SetMeatloaf( String^ recipe, String^ rating )
   {
      dataGridView1->Rows[ 0 ]->Cells[ 2 ]->Value = recipe;
      dataGridView1->Rows[ 0 ]->Cells[ 3 ]->Value = rating;
   }

   String^ currentLayoutName;
   void AddLabels()
   {
      Label^ current = dynamic_cast<Label^>(flowLayoutPanel1->Controls[ currentLayoutName ]);
      if ( current == nullptr )
      {
         current = gcnew Label;
         current->AutoSize = true;
         current->Name = currentLayoutName;
         current->Text = String::Concat( currentLayoutName, dataGridView1->AutoSizeRowsMode );
         flowLayoutPanel1->Controls->Add( current );
      }
   }

   void AddButtonsForAutomaticResizing()
   {
      AddButton( button5, "Keep Column Headers Sized", gcnew EventHandler( this, &AutoSizing::ColumnHeadersHeightSizeMode ) );
      AddButton( button6, "Keep Row Headers Sized", gcnew EventHandler( this, &AutoSizing::RowHeadersWidthSizeMode ) );
      AddButton( button7, "Keep Rows Sized", gcnew EventHandler( this, &AutoSizing::AutoSizeRowsMode ) );
      AddButton( button8, "Keep Row Headers Sized with RowsMode", gcnew EventHandler( this, &AutoSizing::AutoSizeRowHeadersUsingAllHeadersMode ) );
      AddButton( button9, "Disable AutoSizeRowsMode", gcnew EventHandler( this, &AutoSizing::DisableAutoSizeRowsMode ) );
      AddButton( button10, "AutoSize third column by rows", gcnew EventHandler( this, &AutoSizing::AutoSizeOneColumn ) );
      AddButton( button11, "AutoSize third column by rows and headers", gcnew EventHandler( this, &AutoSizing::AutoSizeOneColumnIncludingHeaders ) );
   }


   //<snippet7>
   void ColumnHeadersHeightSizeMode( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode::AutoSize;
   }
   //</snippet7>
   //<snippet8>
   void RowHeadersWidthSizeMode( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      dataGridView1->RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode::AutoSizeToAllHeaders;
   }
   
   //</snippet8>
   //<snippet9>
   void AutoSizeRowsMode( Object^ /*sender*/, EventArgs^ /*es*/ )
   {
      dataGridView1->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::AllCells;
   }
   //</snippet9>
   void AutoSizeRowHeadersUsingAllHeadersMode( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      dataGridView1->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::AllHeaders;
   }


   //<snippet10>
   void WatchRowsModeChanges( Object^ /*sender*/, DataGridViewAutoSizeModeEventArgs^ modeEvent )
   {
      Label^ label = dynamic_cast<Label^>(flowLayoutPanel1->Controls[ currentLayoutName ]);
      if ( modeEvent->PreviousModeAutoSized )
      {
         label->Text = String::Format( "changed to a different {0}{1}", label->Name, dataGridView1->AutoSizeRowsMode );
      }
      else
      {
         label->Text = String::Concat( label->Name, dataGridView1->AutoSizeRowsMode );
      }
   }


   //</snippet10>
   void DisableAutoSizeRowsMode( Object^ /*sender*/, EventArgs^ /*modeEvent*/ )
   {
      dataGridView1->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::None;
   }


   //<snippet11>
   void AutoSizeOneColumn( Object^ /*sender*/, EventArgs^ /*theEvent*/ )
   {
      DataGridViewColumn^ column = dataGridView1->Columns[ 2 ];
      column->AutoSizeMode = DataGridViewAutoSizeColumnMode::DisplayedCellsExceptHeader;
   }


   //</snippet11>
   void AutoSizeOneColumnIncludingHeaders( Object^ /*sender*/, EventArgs^ /*theEvent*/ )
   {
      DataGridViewColumn^ column = dataGridView1->Columns[ 2 ];
      column->AutoSizeMode = DataGridViewAutoSizeColumnMode::AllCells;
   }

};


[STAThread]
int main()
{
   Application::EnableVisualStyles();
   Application::Run( gcnew AutoSizing );
}

//</snippet0>
