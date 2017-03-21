internal:
   // Declare the Listview object.
   System::Windows::Forms::ListView^ myListView;

private:

   // Initialize the ListView object with subitems of a different
   // style than the default styles for the ListView.
   void InitializeListView()
   {
      // Set the Location, View and Width properties for the 
      // ListView object. 
      myListView = gcnew ListView;
      myListView->Location = System::Drawing::Point( 20, 20 );
      myListView->Width = 250;
      
      // The View property must be set to Details for the 
      // subitems to be visible.
      myListView->View = View::Details;
      
      // Each SubItem object requires a column, so add three columns.
      this->myListView->Columns->Add( "Key", 50, HorizontalAlignment::Left );
      this->myListView->Columns->Add( "A", 100, HorizontalAlignment::Left );
      this->myListView->Columns->Add( "B", 100, HorizontalAlignment::Left );
      
      // Add a ListItem object to the ListView.
      ListViewItem^ entryListItem = myListView->Items->Add( "Items" );
      
      // Set UseItemStyleForSubItems property to false to change 
      // look of subitems.
      entryListItem->UseItemStyleForSubItems = false;
      
      // Add the expense subitem.
      ListViewItem::ListViewSubItem ^ expenseItem = entryListItem->SubItems->Add( "Expense" );
      
      // Change the expenseItem object's color and font.
      expenseItem->ForeColor = System::Drawing::Color::Red;
      expenseItem->Font = gcnew System::Drawing::Font( "Arial",10,System::Drawing::FontStyle::Italic );
      
      // Add a subitem called revenueItem 
      ListViewItem::ListViewSubItem ^ revenueItem = entryListItem->SubItems->Add( "Revenue" );
      
      // Change the revenueItem object's color and font.
      revenueItem->ForeColor = System::Drawing::Color::Blue;
      revenueItem->Font = gcnew System::Drawing::Font( "Times New Roman",10,System::Drawing::FontStyle::Bold );
      
      // Add the ListView to the form.
      this->Controls->Add( this->myListView );
   }

   void Button1_Click( System::Object^ /*sender*/, System::EventArgs^ /*e*/ )
   {
      // Use the ListView.TopItem property to access the SubItems
      // and then reset their appearance.
      myListView->TopItem->SubItems[ 1 ]->ResetStyle();
      myListView->TopItem->SubItems[ 2 ]->ResetStyle();
   }