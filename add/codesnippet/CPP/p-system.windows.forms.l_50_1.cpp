   void InitializeListView()
   {
      this->ListView1 = gcnew System::Windows::Forms::ListView;
      
      // Set properties such as BackColor and DockStyle and Location.
      this->ListView1->BackColor = System::Drawing::SystemColors::Control;
      this->ListView1->Dock = System::Windows::Forms::DockStyle::Top;
      this->ListView1->Location = System::Drawing::Point( 0, 0 );
      this->ListView1->Size = System::Drawing::Size( 292, 130 );
      this->ListView1->View = System::Windows::Forms::View::Details;
      this->ListView1->HideSelection = false;
      
      // Allow the user to select multiple items.
      this->ListView1->MultiSelect = true;
      
      // Show CheckBoxes in the ListView.
      this->ListView1->CheckBoxes = true;
      
      //Set the column headers and populate the columns.
      ListView1->HeaderStyle = ColumnHeaderStyle::Nonclickable;
      ColumnHeader^ columnHeader1 = gcnew ColumnHeader;
      columnHeader1->Text = "Breakfast Choices";
      columnHeader1->TextAlign = HorizontalAlignment::Left;
      columnHeader1->Width = 146;
      ColumnHeader^ columnHeader2 = gcnew ColumnHeader;
      columnHeader2->Text = "Price Each";
      columnHeader2->TextAlign = HorizontalAlignment::Center;
      columnHeader2->Width = 142;
      this->ListView1->Columns->Add( columnHeader1 );
      this->ListView1->Columns->Add( columnHeader2 );
      array<String^>^foodList = {"Juice","Coffee","Cereal & Milk","Fruit Plate","Toast & Jelly","Bagel & Cream Cheese"};
      array<String^>^foodPrice = {"1.09","1.09","2.19","2.79","2.09","2.69"};
      int count;
      
      // Members are added one at a time, so call BeginUpdate to ensure 
      // the list is painted only once, rather than as each list item is added.
      ListView1->BeginUpdate();
      for ( count = 0; count < foodList->Length; count++ )
      {
         ListViewItem^ listItem = gcnew ListViewItem( foodList[ count ] );
         listItem->SubItems->Add( foodPrice[ count ] );
         ListView1->Items->Add( listItem );
      }
      
      //Call EndUpdate when you finish adding items to the ListView.
      ListView1->EndUpdate();
      this->Controls->Add( this->ListView1 );
   }