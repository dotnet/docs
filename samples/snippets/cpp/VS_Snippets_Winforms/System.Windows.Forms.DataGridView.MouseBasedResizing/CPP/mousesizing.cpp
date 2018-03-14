
#using <System.dll>
#using <System.Drawing.dll>
#using <System.Windows.Forms.dll>

using namespace System;
using namespace System::Drawing;
using namespace System::Collections;
using namespace System::ComponentModel;
using namespace System::Windows::Forms;
public ref class MouseSizing: public Form
{
private:
   FlowLayoutPanel^ flowLayoutPanel1;
   System::Windows::Forms::Button^ button1;
   System::Windows::Forms::Button^ button2;
   System::Windows::Forms::Button^ button3;
   System::Windows::Forms::Button^ button4;
   System::Windows::Forms::Button^ button5;
   System::Windows::Forms::Button^ button6;
   System::Windows::Forms::Button^ button7;
   System::Windows::Forms::Button^ button8;
   System::Windows::Forms::Button^ button9;

public:
   MouseSizing()
   {
      InitializeComponent();
      this->Load += gcnew EventHandler( this, &MouseSizing::InitializeDataGridView );
      thirdColumnHeader = L"Main Ingredients";
      boringMeatloaf = L"ground beef";
      boringMeatloafRanking = L"*";
   }


#pragma region form set up 

private:
   void InitializeComponent()
   {
      this->flowLayoutPanel1 = gcnew FlowLayoutPanel;
      this->button4 = gcnew System::Windows::Forms::Button;
      this->button5 = gcnew System::Windows::Forms::Button;
      this->button6 = gcnew System::Windows::Forms::Button;
      this->button7 = gcnew System::Windows::Forms::Button;
      this->button8 = gcnew System::Windows::Forms::Button;
      this->button9 = gcnew System::Windows::Forms::Button;
      this->button1 = gcnew System::Windows::Forms::Button;
      this->button2 = gcnew System::Windows::Forms::Button;
      this->button3 = gcnew System::Windows::Forms::Button;
      this->flowLayoutPanel1->SuspendLayout();
      this->SuspendLayout();
      this->flowLayoutPanel1->Controls->Add( this->button4 );
      this->flowLayoutPanel1->Controls->Add( this->button5 );
      this->flowLayoutPanel1->Controls->Add( this->button6 );
      this->flowLayoutPanel1->Controls->Add( this->button7 );
      this->flowLayoutPanel1->Controls->Add( this->button8 );
      this->flowLayoutPanel1->Controls->Add( this->button9 );
      this->flowLayoutPanel1->FlowDirection = FlowDirection::TopDown;
      this->flowLayoutPanel1->Location = Point(492,103);
      this->flowLayoutPanel1->Name = L"flowLayoutPanel1";
      this->flowLayoutPanel1->AutoSize = true;
      this->flowLayoutPanel1->TabIndex = 1;
      this->button4->Location = System::Drawing::Point( 3, 3 );
      this->button4->Name = L"button4";
      this->button4->TabIndex = 3;
      this->button4->Text = L"button4";
      this->button5->Location = System::Drawing::Point( 3, 32 );
      this->button5->Name = L"button5";
      this->button5->TabIndex = 4;
      this->button5->Text = L"button5";
      this->button6->Location = System::Drawing::Point( 3, 61 );
      this->button6->Name = L"button6";
      this->button6->TabIndex = 5;
      this->button6->Text = L"button6";
      this->button7->Location = System::Drawing::Point( 3, 90 );
      this->button7->Name = L"button7";
      this->button7->TabIndex = 6;
      this->button7->Text = L"button7";
      this->button8->Location = System::Drawing::Point( 3, 119 );
      this->button8->Name = L"button8";
      this->button8->TabIndex = 7;
      this->button8->Text = L"button8";
      this->button9->Location = System::Drawing::Point( 3, 148 );
      this->button9->Name = L"button9";
      this->button9->TabIndex = 8;
      this->button9->Text = L"button9";
      this->button1->Location = System::Drawing::Point( 492, 3 );
      this->button1->Name = L"button1";
      this->button1->TabIndex = 0;
      this->button1->Text = L"button1";
      this->button2->Location = System::Drawing::Point( 492, 33 );
      this->button2->Name = L"button2";
      this->button2->TabIndex = 1;
      this->button2->Text = L"button2";
      this->button3->Location = System::Drawing::Point( 492, 63 );
      this->button3->Name = L"button3";
      this->button3->TabIndex = 2;
      this->button3->Text = L"button3";
      this->AutoSize = true;
      this->Controls->Add( this->flowLayoutPanel1 );
      this->Controls->Add( this->button1 );
      this->Controls->Add( this->button2 );
      this->Controls->Add( this->button3 );
      AddButton( button1, L"Reset" );
      AddButton( button2, L"Change Column 3 Header" );
      AddButton( button3, L"Change Meatloaf Recipe" );
      button1->Click += gcnew EventHandler( this, &MouseSizing::ResetToDisorder );
      button2->Click += gcnew EventHandler( this, &MouseSizing::ChangeColumn3Header );
      button3->Click += gcnew EventHandler( this, &MouseSizing::ChangeMeatloafRecipe );
      AddButtonsForAffectingMouseResizing();
      this->Name = L"MouseSizing";
      this->Text = L"Mouse Sizing";
      this->flowLayoutPanel1->ResumeLayout( false );
      this->ResumeLayout( false );
   }


#pragma endregion 

public:

   [STAThread]
   static void Main()
   {
      Application::EnableVisualStyles();
      Application::Run( gcnew MouseSizing );
   }


private:
   System::Drawing::Size startingSize;
   String^ thirdColumnHeader;
   String^ boringMeatloaf;
   String^ boringMeatloafRanking;
   bool boringRecipe;
   bool shortMode;
   DataGridView^ dataGridView1;
   void InitializeDataGridView( Object^ ignored, EventArgs^ ignoredToo )
   {
      this->dataGridView1 = gcnew DataGridView;
      this->Controls->Add( this->dataGridView1 );
      startingSize = System::Drawing::Size( 450, 400 );
      dataGridView1->Size = startingSize;
      SetUpColumns();
      PopulateRows();
      shortMode = false;
      boringRecipe = true;
   }

   void SetUpColumns()
   {
      dataGridView1->ColumnCount = 4;
      dataGridView1->ColumnHeadersVisible = true;
      DataGridViewCellStyle^ columnHeaderStyle = gcnew DataGridViewCellStyle;
      columnHeaderStyle->BackColor = Color::Aqua;
      columnHeaderStyle->Font = gcnew System::Drawing::Font( L"Verdana",10,FontStyle::Bold );
      dataGridView1->ColumnHeadersDefaultCellStyle = columnHeaderStyle;
      dataGridView1->Columns[ 0 ]->Name = L"Recipe";
      dataGridView1->Columns[ 1 ]->Name = L"Category";
      dataGridView1->Columns[ 2 ]->Name = thirdColumnHeader;
      dataGridView1->Columns[ 3 ]->Name = L"Rating";
   }

   void PopulateRows()
   {
      array<String^>^row1 = {L"Meatloaf",L"Main Dish",boringMeatloaf,boringMeatloafRanking};
      array<String^>^row2 = {L"Key Lime Pie",L"Dessert",L"lime juice,    evaporated milk",L"****"};
      array<String^>^row3 = {L"Orange-Salsa Pork Chops",L"Main Dish",L"pork chops, salsa, orange juice",L"****"};
      array<String^>^row4 = {L"Black Bean and Rice Salad",L"Salad",L"black beans, brown rice",L"****"};
      array<String^>^row5 = {L"Chocolate Cheesecake",L"Dessert",L"cream cheese",L"***"};
      array<String^>^row6 = {L"Black Bean Dip",L"Appetizer",L"black beans, sour cream",L"***"};
      array<Object^>^rows = gcnew array<Object^>{
         row1,row2,row3,row4,row5,row6
      };

        for each (array<String^>^ row in rows)
            dataGridView1->Rows->Add(row);
   }

   void AddButton( Button^ button, String^ buttonLabel )
   {
      button->Text = buttonLabel;
      button->AutoSize = true;
   }

   void ResetToDisorder( Object^ sender, EventArgs^ e )
   {
      Controls->Remove( dataGridView1 );
      dataGridView1->~DataGridView();
      InitializeDataGridView( nullptr, nullptr );
   }

   void ChangeColumn3Header( Object^ sender, EventArgs^ e )
   {
      Toggle(  &shortMode );
      if ( shortMode )
            dataGridView1->Columns[ 2 ]->HeaderText = L"S";
      else
            dataGridView1->Columns[ 2 ]->HeaderText = thirdColumnHeader;
   }

   void Toggle( interior_ptr<Boolean> toggleThis )
   {
       *toggleThis =  ! *toggleThis;
   }

   void ChangeMeatloafRecipe( Object^ sender, EventArgs^ e )
   {
      Toggle(  &boringRecipe );
      if ( boringRecipe )
            SetMeatloaf( boringMeatloaf, boringMeatloafRanking );
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
      dataGridView1->Rows[ 0 ]->Cells[ 2 ]->Value = recipe;
      dataGridView1->Rows[ 0 ]->Cells[ 3 ]->Value = rating;
   }


#pragma region " prevent mouse resizing " 
   void AddButtonsForAffectingMouseResizing()
   {
      AddButton( button4, L"Fix Column Header Height" );
      AddButton( button5, L"Fix Row Header Width" );
      AddButton( button6, L"Fix Third Column" );
      AddButton( button7, L"Allow Mouse Resizing of Third Column" );
      AddButton( button8, L"Default Sizing Behavior For Third Column" );
      AddButton( button9, L"Fix Fourth Row" );
      button4->Click += gcnew EventHandler( this, &MouseSizing::FixColumnHeaderHeight );
      button5->Click += gcnew EventHandler( this, &MouseSizing::FixRowHeadersWidth );
      button6->Click += gcnew EventHandler( this, &MouseSizing::FixThirdColumn );
      button7->Click += gcnew EventHandler( this, &MouseSizing::AllowThirdColumnToResize );
      button8->Click += gcnew EventHandler( this, &MouseSizing::FixFourthRow );
      button9->Click += gcnew EventHandler( this, &MouseSizing::SetThirdColumnToDefaultBehavior );
   }

   void FixColumnHeaderHeight( Object^ sender, EventArgs^ e )
   {
      
      //<snippet10>
      dataGridView1->ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode::DisableResizing;
      
      //</snippet10>
   }

   void FixRowHeadersWidth( Object^ sender, EventArgs^ e )
   {
      
      //<snippet11>
      dataGridView1->RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode::DisableResizing;
      
      //</snippet11>
   }

   void FixThirdColumn( Object^ sender, EventArgs^ e )
   {
      
      //<snippet12>
      dataGridView1->Columns[ 2 ]->Resizable = DataGridViewTriState::False;
      
      //</snippet12>
   }

   void AllowThirdColumnToResize( Object^ sender, EventArgs^ e )
   {
      
      //<snippet13>
      dataGridView1->Columns[ 2 ]->Resizable = DataGridViewTriState::True;
      
      //</snippet13>
   }

   void SetThirdColumnToDefaultBehavior( Object^ sender, EventArgs^ e )
   {
      
      //<snippet14>
      dataGridView1->Columns[ 2 ]->Resizable = DataGridViewTriState::NotSet;
      
      //</snippet14>
   }

   void FixFourthRow( Object^ sender, EventArgs^ e )
   {
      
      //<snippet15>
      dataGridView1->Rows[ 3 ]->Resizable = DataGridViewTriState::False;
      
      //</snippet15>
   }


#pragma endregion 

};

int main()
{
   MouseSizing::Main();
}

