	public Form1()
	{
		// Set up the form.
		this.Size = new Size(800, 800);
		this.Load += new EventHandler(Form1_Load);

		// Set up the DataGridView control.
		this.customersDataGridView.AllowUserToAddRows = true;
		this.customersDataGridView.Dock = DockStyle.Fill;
		this.Controls.Add(customersDataGridView);

		// Add the StatusBar control to the form.
		this.Controls.Add(status);

		// Allow the user to add new items.
		this.customersBindingSource.AllowNew = true;

		// Attach an event handler for the AddingNew event.
		this.customersBindingSource.AddingNew +=
			new AddingNewEventHandler(customersBindingSource_AddingNew);

		// Attach an eventhandler for the ListChanged event.
		this.customersBindingSource.ListChanged +=
			new ListChangedEventHandler(customersBindingSource_ListChanged);

		
		// Attach the BindingSource to the DataGridView.
		this.customersDataGridView.DataSource =
			this.customersBindingSource;
	}