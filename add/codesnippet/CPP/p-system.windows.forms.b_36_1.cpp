   Form1()
   {
      // Set up the form.
      this->Size = System::Drawing::Size( 800, 800 );
      this->Load += gcnew EventHandler( this, &Form1::Form1_Load );
      
      // Set up the RadioButton controls.
      this->allRadioBtn->Text = L"All";
      this->allRadioBtn->Checked = true;
      this->allRadioBtn->CheckedChanged += gcnew EventHandler(
         this, &Form1::allRadioBtn_CheckedChanged );
      this->allRadioBtn->Dock = DockStyle::Top;
      this->currentRadioBtn->Text = L"Current";
      this->currentRadioBtn->CheckedChanged += gcnew EventHandler(
         this, &Form1::currentRadioBtn_CheckedChanged );
      this->currentRadioBtn->Dock = DockStyle::Top;
      this->noneRadioBtn->Text = L"None";
      this->noneRadioBtn->CheckedChanged += gcnew EventHandler(
         this, &Form1::noneRadioBtn_CheckedChanged );
      this->noneRadioBtn->Dock = DockStyle::Top;
      this->buttonPanel->Controls->Add( this->allRadioBtn );
      this->buttonPanel->Controls->Add( this->currentRadioBtn );
      this->buttonPanel->Controls->Add( this->noneRadioBtn );
      this->buttonPanel->Dock = DockStyle::Bottom;
      this->Controls->Add( this->buttonPanel );
      
      // Set up the DataGridView control.
      this->customersDataGridView->AllowUserToAddRows = true;
      this->customersDataGridView->Dock = DockStyle::Fill;
      this->Controls->Add( customersDataGridView );
      
      // Add the StatusBar control to the form.
      this->Controls->Add( status );
      
      // Allow the user to add new items.
      this->customersBindingSource->AllowNew = true;
      
      // Attach an event handler for the AddingNew event.
      this->customersBindingSource->AddingNew +=
         gcnew AddingNewEventHandler(
            this, &Form1::customersBindingSource_AddingNew );
      
      // Attach an eventhandler for the ListChanged event.
      this->customersBindingSource->ListChanged +=
         gcnew ListChangedEventHandler(
            this, &Form1::customersBindingSource_ListChanged );
      
      // Set the initial value of the ItemChangedEventMode property
      // to report all ListChanged events.
      this->customersBindingSource->ItemChangedEventMode = 
        ItemChangedEventMode::All;
      
      // Attach the BindingSource to the DataGridView.
      this->customersDataGridView->DataSource =
         this->customersBindingSource;
   }