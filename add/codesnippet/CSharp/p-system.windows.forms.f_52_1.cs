
private void button1_Click(object sender, System.EventArgs e)
{
	// Sets the ShowApply property, then displays the dialog.

	fontDialog1.ShowApply = true;
	fontDialog1.ShowDialog();
}

private void fontDialog1_Apply(object sender, System.EventArgs e)
{
	// Applies the selected font to the selected text.
	richTextBox1.Font = fontDialog1.Font;
			
}