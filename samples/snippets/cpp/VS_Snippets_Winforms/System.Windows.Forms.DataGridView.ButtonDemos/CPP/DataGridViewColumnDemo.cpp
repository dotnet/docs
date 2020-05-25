
//<snippet100>
#using <System.Drawing.dll>
#using <System.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
using namespace System::Collections;
public ref class DataGridViewColumnDemo: public Form
{
private:

#pragma region S "set up form" 

public:
   DataGridViewColumnDemo()
   {
      Button1 = gcnew Button;
      Button2 = gcnew Button;
      Button3 = gcnew Button;
      Button4 = gcnew Button;
      Button5 = gcnew Button;
      Button6 = gcnew Button;
      Button7 = gcnew Button;
      Button8 = gcnew Button;
      Button9 = gcnew Button;
      Button10 = gcnew Button;
      FlowLayoutPanel1 = gcnew FlowLayoutPanel;
      thirdColumnHeader = L"Main Ingredients";
      boringMeatloaf = L"ground beef";
      boringMeatloafRanking = L"*";
      toolStripItem1 = gcnew ToolStripMenuItem;
      InitializeComponent();
      AddButton( Button1, L"Reset", gcnew EventHandler( this, &DataGridViewColumnDemo::ResetToDisorder ) );
      AddButton( Button2, L"Change Column 3 Header", gcnew EventHandler( this, &DataGridViewColumnDemo::ChangeColumn3Header ) );
      AddButton( Button3, L"Change Meatloaf Recipe", gcnew EventHandler( this, &DataGridViewColumnDemo::ChangeMeatloafRecipe ) );
      AddAdditionalButtons();
      InitializeDataGridView();
   }

   DataGridView^ dataGridView;
   Button^ Button1;
   Button^ Button2;
   Button^ Button3;
   Button^ Button4;
   Button^ Button5;
   Button^ Button6;
   Button^ Button7;
   Button^ Button8;
   Button^ Button9;
   Button^ Button10;
   FlowLayoutPanel^ FlowLayoutPanel1;

private:
   void InitializeComponent()
   {
      FlowLayoutPanel1->Location = Point(454,0);
      FlowLayoutPanel1->AutoSize = true;
      FlowLayoutPanel1->FlowDirection = FlowDirection::TopDown;
      AutoSize = true;
      ClientSize = System::Drawing::Size( 614, 360 );
      FlowLayoutPanel1->Name = L"flowlayoutpanel";
      Controls->Add( this->FlowLayoutPanel1 );
      Text = this->GetType()->Name;
   }


#pragma endregion 
#pragma region S " set up DataGridView " 
   String^ thirdColumnHeader;
   String^ boringMeatloaf;
   String^ boringMeatloafRanking;
   bool boringRecipe;
   bool shortMode;
   void InitializeDataGridView()
   {
      dataGridView = gcnew System::Windows::Forms::DataGridView;
      Controls->Add( dataGridView );
      dataGridView->Size = System::Drawing::Size( 300, 200 );
      
      // Create an unbound DataGridView by declaring a
      // column count.
      dataGridView->ColumnCount = 4;
      AdjustDataGridViewSizing();
      
      // Set the column header style.
      DataGridViewCellStyle^ columnHeaderStyle = gcnew DataGridViewCellStyle;
      columnHeaderStyle->BackColor = Color::Aqua;
      columnHeaderStyle->Font = gcnew System::Drawing::Font( L"Verdana",10,FontStyle::Bold );
      dataGridView->ColumnHeadersDefaultCellStyle = columnHeaderStyle;
      
      // Set the column header names.
      dataGridView->Columns[ 0 ]->Name = L"Recipe";
      dataGridView->Columns[ 1 ]->Name = L"Category";
      dataGridView->Columns[ 2 ]->Name = thirdColumnHeader;
      dataGridView->Columns[ 3 ]->Name = L"Rating";
      criteriaLabel = L"Column 3 sizing criteria: ";
      PostColumnCreation();
      
      // Populate the rows.
      array<String^>^row1 = gcnew array<String^>{
         L"Meatloaf",L"Main Dish",boringMeatloaf,boringMeatloafRanking
      };
      array<String^>^row2 = gcnew array<String^>{
         L"Key Lime Pie",L"Dessert",L"lime juice, evaporated milk",L"****"
      };
      array<String^>^row3 = gcnew array<String^>{
         L"Orange-Salsa Pork Chops",L"Main Dish",L"pork chops, salsa, orange juice",L"****"
      };
      array<String^>^row4 = gcnew array<String^>{
         L"Black Bean and Rice Salad",L"Salad",L"black beans, brown rice",L"****"
      };
      array<String^>^row5 = gcnew array<String^>{
         L"Chocolate Cheesecake",L"Dessert",L"cream cheese",L"***"
      };
      array<String^>^row6 = gcnew array<String^>{
         L"Black Bean Dip",L"Appetizer",L"black beans, sour cream",L"***"
      };
      array<Object^>^rows = gcnew array<Object^>{
         row1,row2,row3,row4,row5,row6
      };
      System::Collections::IEnumerator^ myEnum = rows->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         array<String^>^rowArray = safe_cast<array<String^>^>(myEnum->Current);
         dataGridView->Rows->Add( rowArray );
      }

      shortMode = false;
      boringRecipe = true;
   }

   void AddButton( Button^ button, String^ buttonLabel, EventHandler^ handler )
   {
      FlowLayoutPanel1->Controls->Add( button );
      button->TabIndex = FlowLayoutPanel1->Controls->Count;
      button->Text = buttonLabel;
      button->AutoSize = true;
      button->Click += handler;
   }

   void ResetToDisorder( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Controls->Remove( dataGridView );
      dataGridView->~DataGridView();
      InitializeDataGridView();
   }

   void ChangeColumn3Header( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Toggle(  &shortMode );
      if ( shortMode )
      {
         dataGridView->Columns[ 2 ]->HeaderText = L"S";
      }
      else
      {
         dataGridView->Columns[ 2 ]->HeaderText = thirdColumnHeader;
      }
   }

   void Toggle( interior_ptr<Boolean> toggleThis )
   {
       *toggleThis =  ! *toggleThis;
   }

   void ChangeMeatloafRecipe( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Toggle(  &boringRecipe );
      if ( boringRecipe )
      {
         SetMeatloaf( boringMeatloaf, boringMeatloafRanking );
      }
      else
      {
         String^ greatMeatloafRecipe = L"1 lb. lean ground beef, "
         L"1/2 cup bread crumbs, 1/4 cup ketchup,"
         L"1/3 tsp onion powder, "
         L"1 clove of garlic, 1/2 pack onion soup mix "
         L" dash of your favorite BBQ Sauce";
         SetMeatloaf( greatMeatloafRecipe, L"***" );
      }
   }

   void SetMeatloaf( String^ recipe, String^ rating )
   {
      dataGridView->Rows[ 0 ]->Cells[ 2 ]->Value = recipe;
      dataGridView->Rows[ 0 ]->Cells[ 3 ]->Value = rating;
   }


#pragma endregion 

public:
   static void Main()
   {
      Application::Run( gcnew DataGridViewColumnDemo );
   }


#pragma region S " demonstration code " 

private:
   void PostColumnCreation()
   {
      AddContextLabel();
      AddCriteriaLabel();
      CustomizeCellsInThirdColumn();
      AddContextMenu();
      SetDefaultCellInFirstColumn();
      ToolTips();
      dataGridView->CellMouseEnter += gcnew DataGridViewCellEventHandler( this, &DataGridViewColumnDemo::dataGridView_CellMouseEnter );
      dataGridView->AutoSizeColumnModeChanged += gcnew DataGridViewAutoSizeColumnModeEventHandler( this, &DataGridViewColumnDemo::dataGridView_AutoSizeColumnModeChanged );
   }

   String^ criteriaLabel;
   void AddCriteriaLabel()
   {
      AddLabelToPanelIfNotAlreadyThere( criteriaLabel, String::Concat( criteriaLabel, dataGridView->Columns[ 2 ]->AutoSizeMode, L"." ) );
   }

   void AddContextLabel()
   {
      String^ labelName = L"label";
      AddLabelToPanelIfNotAlreadyThere( labelName, L"Use shortcut menu to change cell color." );
   }

   void AddLabelToPanelIfNotAlreadyThere( String^ labelName, String^ labelText )
   {
      Label^ label;
      if ( FlowLayoutPanel1->Controls[ labelName ] == nullptr )
      {
         label = gcnew Label;
         label->AutoSize = true;
         label->Name = labelName;
         label->BackColor = Color::Bisque;
         FlowLayoutPanel1->Controls->Add( label );
      }
      else
      {
         label = dynamic_cast<Label^>(FlowLayoutPanel1->Controls[ labelName ]);
      }

      label->Text = labelText;
   }


   //<snippet120>
   void CustomizeCellsInThirdColumn()
   {
      int thirdColumn = 2;
      DataGridViewColumn^ column = dataGridView->Columns[ thirdColumn ];
      DataGridViewCell^ cell = gcnew DataGridViewTextBoxCell;
      cell->Style->BackColor = Color::Wheat;
      column->CellTemplate = cell;
   }


   //</snippet120>
   //<snippet130>
   ToolStripMenuItem^ toolStripItem1;
   void AddContextMenu()
   {
      toolStripItem1->Text = L"Redden";
      toolStripItem1->Click += gcnew EventHandler( this, &DataGridViewColumnDemo::toolStripItem1_Click );
      System::Windows::Forms::ContextMenuStrip^ strip = gcnew System::Windows::Forms::ContextMenuStrip;
      IEnumerator^ myEnum = dataGridView->Columns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewColumn^ column = safe_cast<DataGridViewColumn^>(myEnum->Current);
         column->ContextMenuStrip = strip;
         column->ContextMenuStrip->Items->Add( toolStripItem1 );
      }
   }

   DataGridViewCellEventArgs^ mouseLocation;

   // Change the cell's color.
   void toolStripItem1_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      dataGridView->Rows[ mouseLocation->RowIndex ]->Cells[ mouseLocation->ColumnIndex ]->Style->BackColor = Color::Red;
   }


   // Deal with hovering over a cell.
   void dataGridView_CellMouseEnter( Object^ /*sender*/, DataGridViewCellEventArgs^ location )
   {
      mouseLocation = location;
   }


   //</snippet130>
   //<snippet140>
   void SetDefaultCellInFirstColumn()
   {
      DataGridViewColumn^ firstColumn = dataGridView->Columns[ 0 ];
      DataGridViewCellStyle^ cellStyle = gcnew DataGridViewCellStyle;
      cellStyle->BackColor = Color::Thistle;
      firstColumn->DefaultCellStyle = cellStyle;
   }


   //</snippet140>
   //<snippet145>
   void ToolTips()
   {
      DataGridViewColumn^ firstColumn = dataGridView->Columns[ 0 ];
      DataGridViewColumn^ thirdColumn = dataGridView->Columns[ 2 ];
      firstColumn->ToolTipText = L"This column uses a default cell.";
      thirdColumn->ToolTipText = L"This column uses a template cell."
      L" Style changes to one cell apply to all cells.";
   }


   //</snippet145>
   void AddAdditionalButtons()
   {
      AddButton( Button4, L"Set Minimum Width of Column Two", gcnew EventHandler( this, &DataGridViewColumnDemo::Button4_Click ) );
      AddButton( Button5, L"Set Width of Column One", gcnew EventHandler( this, &DataGridViewColumnDemo::Button5_Click ) );
      AddButton( Button6, L"Autosize Third Column", gcnew EventHandler( this, &DataGridViewColumnDemo::Button6_Click ) );
      AddButton( Button7, L"Add Thick Vertical Edge", gcnew EventHandler( this, &DataGridViewColumnDemo::Button7_Click ) );
      AddButton( Button8, L"Style and Number Columns", gcnew EventHandler( this, &DataGridViewColumnDemo::Button8_Click ) );
      AddButton( Button9, L"Change Column Header Text", gcnew EventHandler( this, &DataGridViewColumnDemo::Button9_Click ) );
      AddButton( Button10, L"Swap First and Last Columns", gcnew EventHandler( this, &DataGridViewColumnDemo::Button10_Click ) );
   }

   void AdjustDataGridViewSizing()
   {
      dataGridView->ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode::AutoSize;
   }


   //<snippet107>
   //Set the minimum width.
   void Button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewColumn^ column = dataGridView->Columns[ 1 ];
      column->MinimumWidth = 40;
   }


   //</snippet107> 
   //<snippet108>
   // Set the width.
   void Button5_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewColumn^ column = dataGridView->Columns[ 0 ];
      column->Width = 60;
   }


   //</snippet108>
   //<snippet109>
   // AutoSize the third column.
   void Button6_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewColumn^ column = dataGridView->Columns[ 2 ];
      column->AutoSizeMode = DataGridViewAutoSizeColumnMode::DisplayedCells;
   }


   //</snippet109>
   //<snippet110>
   // Set the vertical edge.
   void Button7_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      int thirdColumn = 2;
      
      //        int edgeThickness = 5;
      DataGridViewColumn^ column = dataGridView->Columns[ thirdColumn ];
      column->DividerWidth = 10;
   }


   //</snippet110>
   //<snippet150>
   // Style and number columns.
   void Button8_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      DataGridViewCellStyle^ style = gcnew DataGridViewCellStyle;
      style->Alignment = DataGridViewContentAlignment::MiddleCenter;
      style->ForeColor = Color::IndianRed;
      style->BackColor = Color::Ivory;
      IEnumerator^ myEnum1 = dataGridView->Columns->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewColumn^ column = safe_cast<DataGridViewColumn^>(myEnum1->Current);
         column->HeaderCell->Value = column->Index.ToString();
         column->HeaderCell->Style = style;
      }
   }


   //</snippet150>
   //<snippet160>
   // Change the text in the column header.
   void Button9_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      IEnumerator^ myEnum2 = dataGridView->Columns->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DataGridViewColumn^ column = safe_cast<DataGridViewColumn^>(myEnum2->Current);
         column->HeaderText = String::Concat( L"Column ", column->Index.ToString() );
      }
   }


   //</snippet160>
   //<snippet170>
   // Swap the last column with the first.
   void Button10_Click( Object^ /*sender*/, EventArgs^ /*args*/ )
   {
      DataGridViewColumnCollection^ columnCollection = dataGridView->Columns;
      DataGridViewColumn^ firstDisplayedColumn = columnCollection->GetFirstColumn( DataGridViewElementStates::Visible );
      DataGridViewColumn^ lastDisplayedColumn = columnCollection->GetLastColumn( DataGridViewElementStates::Visible, DataGridViewElementStates::None );
      int firstColumn_sIndex = firstDisplayedColumn->DisplayIndex;
      firstDisplayedColumn->DisplayIndex = lastDisplayedColumn->DisplayIndex;
      lastDisplayedColumn->DisplayIndex = firstColumn_sIndex;
   }


   //</snippet170>
   //<snippet180>
   // Updated the criteria label.
   void dataGridView_AutoSizeColumnModeChanged( Object^ /*sender*/, DataGridViewAutoSizeColumnModeEventArgs^ args )
   {
      args->Column->DataGridView->Parent->Controls[ L"flowlayoutpanel" ]->Controls[ criteriaLabel ]->Text = String::Concat( criteriaLabel, args->Column->AutoSizeMode );
   }
   //</snippet180>
#pragma endregion 

};

int main()
{
   DataGridViewColumnDemo::Main();
}

//</snippet100>
