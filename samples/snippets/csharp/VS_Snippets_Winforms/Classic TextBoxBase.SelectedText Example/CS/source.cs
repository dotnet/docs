using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void Menu_Copy(System.Object sender, System.EventArgs e)
 {
    // Ensure that text is selected in the text box.   
    if(textBox1.SelectionLength > 0)
        // Copy the selected text to the Clipboard.
        textBox1.Copy();
 }
 
 private void Menu_Cut(System.Object sender, System.EventArgs e)
 {   
     // Ensure that text is currently selected in the text box.   
     if(textBox1.SelectedText.Length > 0)
        // Cut the selected text in the control and paste it into the Clipboard.
        textBox1.Cut();
 }
 
 private void Menu_Paste(System.Object sender, System.EventArgs e)
 {
    // Determine if there is any text in the Clipboard to paste into the text box.
    if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
    {
        // Determine if any text is selected in the text box.
        if(textBox1.SelectionLength > 0)
        {
          // Ask user if they want to paste over currently selected text.
          if(MessageBox.Show("Do you want to paste over current selection?", "Cut Example", MessageBoxButtons.YesNo) == DialogResult.No)
             // Move selection to the point after the current selection and paste.
             textBox1.SelectionStart = textBox1.SelectionStart + textBox1.SelectionLength;
        }
        // Paste current text in Clipboard into text box.
        textBox1.Paste();
    }
 }
 
 
 private void Menu_Undo(System.Object sender, System.EventArgs e)
 {
    // Determine if last operation can be undone in text box.   
    if(textBox1.CanUndo == true)
    {
       // Undo the last operation.
       textBox1.Undo();
       // Clear the undo buffer to prevent last action from being redone.
       textBox1.ClearUndo();
    }
 }
 
// </Snippet1>
}
