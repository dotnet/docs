
//<snippet200>
#using <System.Drawing.dll>
#using <System.dll>
#using <system.windows.forms.dll>

using namespace System;
using namespace System::Windows::Forms;
using namespace System::Drawing;
public ref class DataGridViewRowDemo: public Form
{
private:

#pragma region S " form setup " 

public:
   DataGridViewRowDemo()
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
      ratingColumn = 3;
	  AddButton( Button1, L"Reset", gcnew EventHandler( this, &DataGridViewRowDemo::Button1_Click ) );
      AddButton( Button2, L"Change Column 3 Header", gcnew EventHandler( this, &DataGridViewRowDemo::Button2_Click ) );
      AddButton( Button3, L"Change Meatloaf Recipe", gcnew EventHandler( this, &DataGridViewRowDemo::Button3_Click ) );
	  InitializeComponent();
      InitializeDataGridView();
	  AddAdditionalButtons();
   }


private:
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
#pragma region S " setup DataGridView " 
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
      dataGridView->ColumnHeadersVisible = true;
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


   // Reset columns to initial disorderly arrangement.
   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      Controls->Remove( dataGridView );
      dataGridView->~DataGridView();
      InitializeDataGridView();
   }


   // Change column 3 header.
   void Button2_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
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


   // Change meatloaf recipe.
   void Button3_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
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
#pragma region S " demonstration code " 
   void AddAdditionalButtons()
   {
      AddButton( Button4, L"Set Row Two Minimum Height", gcnew EventHandler( this, &DataGridViewRowDemo::Button4_Click ) );
      AddButton( Button5, L"Set Row One Height", gcnew EventHandler( this, &DataGridViewRowDemo::Button5_Click ) );
      AddButton( Button6, L"Label Rows", gcnew EventHandler( this, &DataGridViewRowDemo::Button6_Click ) );
      AddButton( Button7, L"Turn on Extra Edge", gcnew EventHandler( this, &DataGridViewRowDemo::Button7_Click ) );
      AddButton( Button8, L"Give Cheesecake an Excellent Rating", gcnew EventHandler( this, &DataGridViewRowDemo::Button8_Click ) );
   }

   void AdjustDataGridViewSizing()
   {
      dataGridView->ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode::AutoSize;
      dataGridView->Columns[ ratingColumn ]->Width = 50;
   }


   //<snippet207>
   // Set minimum height.
   void Button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      int secondRow = 1;
      DataGridViewRow^ row = dataGridView->Rows[ secondRow ];
      row->MinimumHeight = 40;
   }


   //</snippet207> 
   //<snippet208>
   // Set height.
   void Button5_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewRow^ row = dataGridView->Rows[ 0 ];
      row->Height = 15;
   }


   //</snippet208>
   //<snippet209>
   // Set row labels.
   void Button6_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {

      int rowNumber = 1;
      System::Collections::IEnumerator^ myEnum = safe_cast<System::Collections::IEnumerable^>(dataGridView->Rows)->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewRow^ row = safe_cast<DataGridViewRow^>(myEnum->Current);
         if ( row->IsNewRow )
                  continue;
         row->HeaderCell->Value = String::Format( L"Row {0}", rowNumber );

         rowNumber = rowNumber + 1;
      }

      dataGridView->AutoResizeRowHeadersWidth( DataGridViewRowHeadersWidthSizeMode::AutoSizeToAllHeaders );
   }


   //</snippet209>
   //<snippet210>
   // Set a thick horizontal edge.
   void Button7_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      int secondRow = 1;
      int edgeThickness = 3;
      DataGridViewRow^ row = dataGridView->Rows[ secondRow ];
      row->DividerHeight = 10;
   }


   //</snippet210>
   //<snippet211>
   // Give cheescake excellent rating.
   void Button8_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      UpdateStars( dataGridView->Rows[ 4 ], L"******************" );
   }

   int ratingColumn;
   void UpdateStars( DataGridViewRow^ row, String^ stars )
   {
      row->Cells[ ratingColumn ]->Value = stars;
      
      // Resize the column width to account for the new value.
      row->DataGridView->AutoResizeColumn( ratingColumn, DataGridViewAutoSizeColumnMode::DisplayedCells );
   }


   //</snippet211>
#pragma endregion 

public:
   static void Main()
   {
      Application::Run( gcnew DataGridViewRowDemo );
   }

};

int main()
{
   DataGridViewRowDemo::Main();
}

//</snippet200>
