
	// The following method displays the default font, 
	// background color and foreground color values for the ListBox  
	// control. The values are displayed in the ListBox, itself.

	private void Populate_ListBox()
	{
		ListBox1.Dock = DockStyle.Bottom;

		// Display the values in the read-only properties 
		// DefaultBackColor, DefaultFont, DefaultForecolor.
		ListBox1.Items.Add("Default BackColor: " + 
			ListBox.DefaultBackColor.ToString());
		ListBox1.Items.Add("Default Font: " + 
			ListBox.DefaultFont.ToString());
		ListBox1.Items.Add("Default ForeColor:" + 
			ListBox.DefaultForeColor.ToString());

	}