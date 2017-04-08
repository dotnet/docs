
//<snippet0>
#using <System.Drawing.dll>
#using <System.dll>
#using <system.windows.forms.dll>
#using <system.drawing.dll>

using namespace System::Drawing;
using namespace System::Windows::Forms;
using namespace System;
using namespace System::Collections;
public ref class DataGridViewBandDemo: public Form
{
private:

#pragma region S " form setup " 

public:
   DataGridViewBandDemo()
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
      InitializeComponent();
      thirdColumnHeader = L"Main Ingredients";
      boringMeatloaf = L"ground beef";
      boringMeatloafRanking = L"*";
      AddButton( Button1, L"Reset", gcnew EventHandler( this, &DataGridViewBandDemo::Button1_Click ) );
      AddButton( Button2, L"Change Column 3 Header", gcnew EventHandler( this, &DataGridViewBandDemo::Button2_Click ) );
      AddButton( Button3, L"Change Meatloaf Recipe", gcnew EventHandler( this, &DataGridViewBandDemo::Button3_Click ) );
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
#pragma region S " setup DataGridView " 
   String^ thirdColumnHeader;
   String^ boringMeatloaf;
   String^ boringMeatloafRanking;
   bool boringRecipe;
   Boolean shortMode;
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

      PostRowCreation();
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


   // Change the header in column three.
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


   // Change the meatloaf recipe.
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
      AddButton( Button4, L"Freeze First Row", gcnew EventHandler( this, &DataGridViewBandDemo::Button4_Click ) );
      AddButton( Button5, L"Freeze Second Column", gcnew EventHandler( this, &DataGridViewBandDemo::Button5_Click ) );
      AddButton( Button6, L"Hide Salad Row", gcnew EventHandler( this, &DataGridViewBandDemo::Button6_Click ) );
      AddButton( Button7, L"Disable First Column Resizing", gcnew EventHandler( this, &DataGridViewBandDemo::Button7_Click ) );
      AddButton( Button8, L"Make ReadOnly", gcnew EventHandler( this, &DataGridViewBandDemo::Button8_Click ) );
      AddButton( Button9, L"Style Using Tag", gcnew EventHandler( this, &DataGridViewBandDemo::Button9_Click ) );
   }

   void AdjustDataGridViewSizing()
   {
      dataGridView->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::AllCells;
      dataGridView->ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode::AutoSize;
   }


   //<snippet7>
   // Freeze the first row.
   void Button4_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      FreezeBand( dataGridView->Rows[ 0 ] );
   }

   void Button5_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      FreezeBand( dataGridView->Columns[ 1 ] );
   }

   void FreezeBand( DataGridViewBand^ band )
   {
      band->Frozen = true;
      DataGridViewCellStyle^ style = gcnew DataGridViewCellStyle;
      style->BackColor = Color::WhiteSmoke;
      band->DefaultCellStyle = style;
   }


   //</snippet7>   
   //<snippet9>
   // Hide a band of cells.
   void Button6_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      DataGridViewBand^ band = dataGridView->Rows[ 3 ];
      band->Visible = false;
   }


   //</snippet9>
   //<snippet10>
   // Turn off user's ability to resize a column.
   void Button7_Click( Object^ /*sender*/, EventArgs^ /*e*/ )
   {
      DataGridViewBand^ band = dataGridView->Columns[ 0 ];
      band->Resizable = DataGridViewTriState::False;
   }


   //</snippet10>
   //<snippet11>
   // Make the the entire DataGridView read only.
   void Button8_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      System::Collections::IEnumerator^ myEnum = dataGridView->Columns->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         DataGridViewBand^ band = safe_cast<DataGridViewBand^>(myEnum->Current);
         band->ReadOnly = true;
      }
   }


   //</snippet11>
   //<snippet12>
   void PostRowCreation()
   {
      SetBandColor( dataGridView->Columns[ 0 ], Color::CadetBlue );
      SetBandColor( dataGridView->Rows[ 1 ], Color::Coral );
      SetBandColor( dataGridView->Columns[ 2 ], Color::DodgerBlue );
   }

   void SetBandColor( DataGridViewBand^ band, Color color )
   {
      band->Tag = color;
   }


   // Color the bands by the value stored in their tag.
   void Button9_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      IEnumerator^ myEnum1 = dataGridView->Columns->GetEnumerator();
      while ( myEnum1->MoveNext() )
      {
         DataGridViewBand^ band = static_cast<DataGridViewBand^>(myEnum1->Current);
         if ( band->Tag != nullptr )
         {
            band->DefaultCellStyle->BackColor =  *dynamic_cast<Color^>(band->Tag);
         }
      }

      IEnumerator^ myEnum2 = safe_cast<IEnumerable^>(dataGridView->Rows)->GetEnumerator();
      while ( myEnum2->MoveNext() )
      {
         DataGridViewBand^ band = safe_cast<DataGridViewBand^>(myEnum2->Current);
         if ( band->Tag != nullptr )
         {
            band->DefaultCellStyle->BackColor =  *dynamic_cast<Color^>(band->Tag);
         }
      }
   }


   //</snippet12>
#pragma endregion 

public:
   static void Main()
   {
      Application::Run( gcnew DataGridViewBandDemo );
   }
};

int main()
{
   DataGridViewBandDemo::Main();
}

//</snippet0>