using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
public void AddMyControls()
 {
    TextBox textBox1 = new TextBox();
    Label label1 = new Label();
    
    // Initialize the controls and their bounds.
    label1.Text = "First Name";
    label1.Location = new Point(48,48);
    label1.Size = new Size (104, 16);
    textBox1.Text = "";
    textBox1.Location = new Point(48, 64);
    textBox1.Size = new Size(104,16);
 
    // Add the TextBox control to the form's control collection.
    Controls.Add(textBox1);
    // Add the Label control to the form's control collection.
    Controls.Add(label1);
 }
 
// </Snippet1>
}
