
	// Declare four textboxes.
	internal System.Windows.Forms.TextBox vertical;
	internal System.Windows.Forms.TextBox horizontal;
	internal System.Windows.Forms.TextBox both;
	internal System.Windows.Forms.TextBox none;

	private void SetFourDifferentScrollBars()
	{
		
		this.vertical = new System.Windows.Forms.TextBox();
		this.horizontal = new System.Windows.Forms.TextBox();
		this.both = new System.Windows.Forms.TextBox();
		this.none = new System.Windows.Forms.TextBox();

		// Create a string for the Text property.
		string startString = "The scroll bar style for my textbox is: ";

		// Set the location of the four textboxes.
		horizontal.Location = new Point(10, 10);
		vertical.Location = new Point(10, 70);
		none.Location = new Point(10, 170);
		both.Location = new Point(10, 110);

		// For horizonal scroll bars, the Multiline property must
		// be true and the WordWrap property must be false.
		// Increase the size of the Height property to ensure the 
		// scroll bar is visible.
		horizontal.ScrollBars = ScrollBars.Horizontal;
		horizontal.Multiline = true;
		horizontal.WordWrap = false;
		horizontal.Height = 40;
		horizontal.Text = startString + 
			ScrollBars.Horizontal.ToString();

		// For the vertical scroll bar, Multiline must be true.
		vertical.ScrollBars = ScrollBars.Vertical;
		vertical.Multiline = true;
		vertical.Text = startString + ScrollBars.Vertical.ToString();

		// For both scroll bars, the Multiline property 
		// must be true, and the WordWrap property must be false.
		// Increase the size of the Height property to ensure the 
		// scroll bar is visible.
		both.ScrollBars = ScrollBars.Both;
		both.Multiline = true;
		both.WordWrap = false;
		both.Height = 40;
		both.AcceptsReturn = true;
		both.Text = startString + ScrollBars.Both.ToString();

		// The none scroll bar does not require specific 
		// property settings.
		none.ScrollBars = ScrollBars.None;
		none.Text = startString + ScrollBars.None.ToString();

		// Add the textboxes to the form.
		this.Controls.Add(this.vertical);
		this.Controls.Add(this.horizontal);
		this.Controls.Add(this.both);
		this.Controls.Add(this.none);

	}