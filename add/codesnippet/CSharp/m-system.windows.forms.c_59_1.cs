private void button1_Click(object sender, System.EventArgs e) {
    // Takes the selected text from a text box and puts it on the clipboard.
    if(textBox1.SelectedText != "")
       Clipboard.SetDataObject(textBox1.SelectedText, true);
    else
       textBox2.Text = "No text selected in textBox1";
 }