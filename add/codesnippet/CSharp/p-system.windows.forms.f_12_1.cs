	private void Button1_Click(System.Object sender, System.EventArgs e)
	{
		// Set FontMustExist to true, which causes message box error
		// if the user enters a font that does not exist. 
		FontDialog1.FontMustExist = true;
		
		// Associate the method handling the Apply event with the event.
		FontDialog1.Apply += new System.EventHandler(FontDialog1_Apply);

		// Set a minimum and maximum size to be
		// shown in the FontDialog.
		FontDialog1.MaxSize = 32;
		FontDialog1.MinSize = 18;

		// Show the Apply button in the dialog.
		FontDialog1.ShowApply = true;

		// Do not show effects such as Underline
		// and Bold.
		FontDialog1.ShowEffects = false;
		
		// Save the existing font.
		System.Drawing.Font oldFont = this.Font;

		//Show the dialog, and get the result
		DialogResult result = FontDialog1.ShowDialog();
 
		// If the OK button in the Font dialog box is clicked, 
		// set all the controls' fonts to the chosen font by calling
		// the FontDialog1_Apply method.
		if (result == DialogResult.OK)
		{
			FontDialog1_Apply(this.Button1, new System.EventArgs());
		}
			// If Cancel is clicked, set the font back to
			// the original font.
		else if (result == DialogResult.Cancel)
		{
			this.Font = oldFont;
			foreach ( Control containedControl in this.Controls)
			{
				containedControl.Font = oldFont;
			}
		}
	}

	// Handle the Apply event by setting all controls' fonts to 
	// the chosen font. 
	private void FontDialog1_Apply(object sender, System.EventArgs e)
	{

		this.Font = FontDialog1.Font;
		foreach ( Control containedControl in this.Controls )
		{
			containedControl.Font = FontDialog1.Font;
		}
	}