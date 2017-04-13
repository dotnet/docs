using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;

 protected int myCounter;
// <Snippet1>
protected DomainUpDown domainUpDown1;

private void MySub()
 {
    // Create and initialize the DomainUpDown control.
    domainUpDown1 = new System.Windows.Forms.DomainUpDown();
    
    // Add the DomainUpDown control to the form.
    Controls.Add(domainUpDown1);
 }
 
 private void button1_Click(System.Object sender, 
                           System.EventArgs e)
 {   
    // Add the text box contents and initial location in the collection
    // to the DomainUpDown control.
    domainUpDown1.Items.Add((textBox1.Text.Trim()) + " - " + myCounter);
    
    // Increment the counter variable.
    myCounter = myCounter + 1;
 
    // Clear the TextBox.
    textBox1.Text = "";
 }
 
 private void checkBox1_Click(System.Object sender, 
                             System.EventArgs e)
 {
    // If Sorted is set to true, set it to false; 
    // otherwise set it to true.
    if (domainUpDown1.Sorted)
    {
       domainUpDown1.Sorted = false;
    }
    else
    {
       domainUpDown1.Sorted = true;
    }
 }
 
 private void domainUpDown1_SelectedItemChanged(System.Object sender, 
                                               System.EventArgs e)
 {
    // Display the SelectedIndex and SelectedItem property values in a MessageBox.
    MessageBox.Show("SelectedIndex: " + domainUpDown1.SelectedIndex.ToString() 
       + "\n" + "SelectedItem: " + domainUpDown1.SelectedItem.ToString());
 }

// </Snippet1>
}
