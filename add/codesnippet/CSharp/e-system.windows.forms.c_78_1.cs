	private void textBox1_Validating(object sender, 
		System.ComponentModel.CancelEventArgs e)
	{
		// If nothing is entered,
		// an ArgumentException is caught; if an invalid directory is entered, 
		// a DirectoryNotFoundException is caught. An appropriate error message 
		// is displayed in either case.
		try
		{
			System.IO.DirectoryInfo directory = 
				new System.IO.DirectoryInfo(textBox1.Text);
			directory.GetFiles();
			errorProvider1.SetError(textBox1, "");

		}
		catch(System.ArgumentException ex1)
		{
			errorProvider1.SetError(textBox1, "Please enter a directory");

		}
		catch(System.IO.DirectoryNotFoundException ex2)
		{
			errorProvider1.SetError(textBox1, "The directory does not exist." +
				"Try again with a different directory.");
		}

	}

	// This method handles the LostFocus event for textBox1 by setting the 
	// dialog's InitialDirectory property to the text in textBox1.
	private void textBox1_LostFocus(object sender, System.EventArgs e)
	{
		openFileDialog1.InitialDirectory = textBox1.Text;
	}

	// This method demonstrates using the ErrorProvider.GetError method 
	// to check for an error before opening the dialog box.
	private void button1_Click(System.Object sender, System.EventArgs e)
	{
		//If there is no error, then open the dialog box.
		if (errorProvider1.GetError(textBox1)=="")
		{
			DialogResult dialogResult = openFileDialog1.ShowDialog();
		}
	}