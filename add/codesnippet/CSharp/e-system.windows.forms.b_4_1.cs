	// This event handler detects changes in the BindingSource 
	// list or changes to items within the list.
	void customersBindingSource_ListChanged(
		object sender,
		ListChangedEventArgs e)
	{
		status.Text = e.ListChangedType.ToString();
	}