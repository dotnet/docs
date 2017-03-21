   void InitializeDataGridView()
   {
      this->Size = System::Drawing::Size( 600, 600 );
      dataGridView1->Size = System::Drawing::Size( 450, 400 );

      // Create an unbound DataGridView by declaring a column count.
      dataGridView1->ColumnCount = 4;
      dataGridView1->ColumnHeadersVisible = true;

      // Set the column header style.
      DataGridViewCellStyle ^ columnHeaderStyle = gcnew DataGridViewCellStyle;
      columnHeaderStyle->BackColor = Color::Aqua;
      columnHeaderStyle->Font = gcnew System::Drawing::Font( "Verdana",10,FontStyle::Bold );
      dataGridView1->ColumnHeadersDefaultCellStyle = columnHeaderStyle;

      // Set the column header names.
      dataGridView1->Columns[ 0 ]->Name = "Recipe";
      dataGridView1->Columns[ 1 ]->Name = "Category";
      dataGridView1->Columns[ 2 ]->Name = "Main Ingredients";
      dataGridView1->Columns[ 3 ]->Name = "Rating";

      // Populate the rows.
      array<String^>^row1 = gcnew array<String^>{
         "Meatloaf","Main Dish","ground beef","**"
      };
      array<String^>^row2 = gcnew array<String^>{
         "Key Lime Pie","Dessert","lime juice, evaporated milk","****"
      };
      array<String^>^row3 = gcnew array<String^>{
         "Orange-Salsa Pork Chops","Main Dish","pork chops, salsa, orange juice","****"
      };
      array<String^>^row4 = gcnew array<String^>{
         "Black Bean and Rice Salad","Salad","black beans, brown rice","****"
      };
      array<String^>^row5 = gcnew array<String^>{
         "Chocolate Cheesecake","Dessert","cream cheese","***"
      };
      array<String^>^row6 = gcnew array<String^>{
         "Black Bean Dip","Appetizer","black beans, sour cream","***"
      };
      array<Object^>^rows = {row1,row2,row3,row4,row5,row6};
      System::Collections::IEnumerator^ myEnum = rows->GetEnumerator();
      while ( myEnum->MoveNext() )
      {
         array<String^>^rowArray = safe_cast<array<String^>^>(myEnum->Current);
         dataGridView1->Rows->Add( rowArray );
      }
   }

   void Button1_Click( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Resize the height of the column headers. 
      dataGridView1->AutoResizeColumnHeadersHeight();

      // Resize all the row heights to fit the contents of all non-header cells.
      dataGridView1->AutoResizeRows(
            DataGridViewAutoSizeRowsMode::AllCellsExceptHeaders);
   }

   void InitializeContextMenu()
   {
      // Create the menu item.
      MenuItem^ getRecipe = gcnew MenuItem( "Search for recipe",gcnew System::EventHandler( this, &Form1::OnMenuClick ) );

      // Add the menu item to the shortcut menu.
      System::Windows::Forms::ContextMenuStrip^ recipeMenu = gcnew System::Windows::Forms::ContextMenuStrip();

      // Set the shortcut menu for the first column.
      dataGridView1->Columns[ 0 ]->ContextMenuStrip = recipeMenu;
   }

   void OnMenuClick( Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      if ( dataGridView1->CurrentCell != nullptr )
      {
         //Retrieve the recipe name.
         String^ recipeName = dynamic_cast<String^>(dataGridView1->CurrentCell->Value);

         //Search for the recipe.
         System::Diagnostics::Process::Start( String::Format( "http://search.msn.com/results.aspx?q={0}", recipeName ), nullptr );
      }
   }

private:
