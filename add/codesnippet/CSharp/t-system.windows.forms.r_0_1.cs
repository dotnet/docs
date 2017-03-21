public void CreateMyRichTextBox()
{
    RichTextBox richTextBox1 = new RichTextBox();
    richTextBox1.Dock = DockStyle.Fill;


    richTextBox1.LoadFile("C:\\MyDocument.rtf");
    richTextBox1.Find("Text", RichTextBoxFinds.MatchCase);

    richTextBox1.SelectionFont = new Font("Verdana", 12, FontStyle.Bold);
    richTextBox1.SelectionColor = Color.Red;

    richTextBox1.SaveFile("C:\\MyDocument.rtf", RichTextBoxStreamType.RichText);

    this.Controls.Add(richTextBox1);
}
