using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected TextBox textBox2;
// <Snippet1>
private void button1_Click(object sender, System.EventArgs e) {
    // Takes the selected text from a text box and puts it on the clipboard.
    if(textBox1.SelectedText != "")
       Clipboard.SetDataObject(textBox1.SelectedText);
    else
       textBox2.Text = "No text selected in textBox1";
 }
 
 private void button2_Click(object sender, System.EventArgs e) {
    // Declares an IDataObject to hold the data returned from the clipboard.
    // Retrieves the data from the clipboard.
    IDataObject iData = Clipboard.GetDataObject();
 
    // Determines whether the data is in a format you can use.
    if(iData.GetDataPresent(DataFormats.Text)) {
       // Yes it is, so display it in a text box.
       textBox2.Text = (String)iData.GetData(DataFormats.Text); 
    }
    else {
       // No it is not.
       textBox2.Text = "Could not retrieve data off the clipboard.";
    }
 }
 
// </Snippet1>
}
