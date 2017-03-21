
	// When the calendar drops down, display a MessageBox indicating 
	// that DateTimePicker will not accept dates before MinDateTime or 
	// after MaxDateTime. Use a StringBuilder object to build the string
	// for efficiency.
	private void DateTimePicker1_DropDown(object sender, 
		System.EventArgs e)
	{

		System.Text.StringBuilder messageBuilder = 
			new System.Text.StringBuilder();
		messageBuilder.Append("Choose a date after: ");
		messageBuilder.Append
			(DateTimePicker.MinDateTime.ToShortDateString());
		messageBuilder.Append(" and a date before: ");
		messageBuilder.Append
			(DateTimePicker.MaxDateTime.ToShortDateString());
		MessageBox.Show(messageBuilder.ToString());
	}