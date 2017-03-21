   	private void ListView1_BeforeLabelEdit(object sender, 
		System.Windows.Forms.LabelEditEventArgs e)
	{
		// Allow all but the first two items of the list to 
		// be modified by the user.
		if (e.Item<2)
		{
			e.CancelEdit = true;
		}
	}