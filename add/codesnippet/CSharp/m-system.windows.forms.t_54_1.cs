	//Handles the Enter key being pressed while TextBox1 has focus. 
	private void TextBox1_KeyDown(object sender, KeyEventArgs e)
	{
		TextBox1.HideSelection = false;
		if (e.KeyCode==Keys.Enter)
		{
			e.Handled = true;

			// Copy the text from TextBox1 to RichTextBox1, add a CRLF after 
			// the copied text, and keep the caret in view.
			RichTextBox1.SelectedText = TextBox1.Text + "\r\n";
			RichTextBox1.ScrollToCaret();
		}
	}