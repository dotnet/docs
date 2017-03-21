public void CopyAllMyText()
 {
    // Determine if any text is selected in the TextBox control.
    if(textBox1.SelectionLength == 0)
       // Select all text in the text box.
       textBox1.SelectAll();
    
    // Copy the contents of the control to the Clipboard.
    textBox1.Copy();
 }
