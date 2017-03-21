	private void InitializeOpenFileDialog()
	{
		this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();

		// Set the file dialog to filter for graphics files.
		this.openFileDialog1.Filter = 
			"Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + 
			"All files (*.*)|*.*";

		// Allow the user to select multiple images.
		this.openFileDialog1.Multiselect = true;
		this.openFileDialog1.Title = "My Image Browser";
		
	}

	private void fileButton_Click(System.Object sender, System.EventArgs e)
	{
		openFileDialog1.ShowDialog();
	}
