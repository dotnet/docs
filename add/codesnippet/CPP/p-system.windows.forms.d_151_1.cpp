   void SetUpDataGridView()
   {
      this->Controls->Add( dataGridView1 );
      dataGridView1->ColumnCount = 5;
      DataGridViewCellStyle^ style = dataGridView1->ColumnHeadersDefaultCellStyle;
      style->BackColor = Color::Navy;
      style->ForeColor = Color::White;
      style->Font = gcnew System::Drawing::Font( dataGridView1->Font,FontStyle::Bold );
      dataGridView1->EditMode = DataGridViewEditMode::EditOnEnter;
      dataGridView1->Name = "dataGridView1";
      dataGridView1->Location = Point(8,8);
      dataGridView1->Size = System::Drawing::Size( 500, 300 );
      dataGridView1->AutoSizeRowsMode = DataGridViewAutoSizeRowsMode::DisplayedCellsExceptHeaders;
      dataGridView1->ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle::Raised;
      dataGridView1->CellBorderStyle = DataGridViewCellBorderStyle::Single;
      dataGridView1->GridColor = SystemColors::ActiveBorder;
      dataGridView1->RowHeadersVisible = false;
      dataGridView1->Columns[ 0 ]->Name = "Release Date";
      dataGridView1->Columns[ 1 ]->Name = "Track";
      dataGridView1->Columns[ 1 ]->DefaultCellStyle->Alignment = DataGridViewContentAlignment::MiddleCenter;
      dataGridView1->Columns[ 2 ]->Name = "Title";
      dataGridView1->Columns[ 3 ]->Name = "Artist";
      dataGridView1->Columns[ 4 ]->Name = "Album";

      // Make the font italic for row four.
      dataGridView1->Columns[ 4 ]->DefaultCellStyle->Font = gcnew System::Drawing::Font( DataGridView::DefaultFont,FontStyle::Italic );
      dataGridView1->SelectionMode = DataGridViewSelectionMode::FullRowSelect;
      dataGridView1->MultiSelect = false;
      dataGridView1->BackgroundColor = Color::Honeydew;
      dataGridView1->Dock = DockStyle::Fill;
      dataGridView1->CellFormatting += gcnew DataGridViewCellFormattingEventHandler( this, &Form1::dataGridView1_CellFormatting );
      dataGridView1->CellParsing += gcnew DataGridViewCellParsingEventHandler( this, &Form1::dataGridView1_CellParsing );
      addNewRowButton->Click += gcnew EventHandler( this, &Form1::addNewRowButton_Click );
      deleteRowButton->Click += gcnew EventHandler( this, &Form1::deleteRowButton_Click );
      ledgerStyleButton->Click += gcnew EventHandler( this, &Form1::ledgerStyleButton_Click );
      dataGridView1->CellValidating += gcnew DataGridViewCellValidatingEventHandler( this, &Form1::dataGridView1_CellValidating );
   }