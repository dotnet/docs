using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox listBox1;

// <Snippet1>
public static void Main(string[] args) {
    // Starts the application.
    Application.Run(new Form1());
 }
 
 private void button1_Click(object sender, System.EventArgs e) {
    // Populates a list box with three numbers.
    int i = 3;
    for(int j=1; j<=i; j++) {
       listBox1.Items.Add(j);
    }
 
    /* Determines whether the user wants to exit the application.
     * If not, adds another number to the list box. */
    while (MessageBox.Show("Exit application?", "", MessageBoxButtons.YesNo) == 
       DialogResult.No) {
       // Increments the counter ands add the number to the list box.
       i++;
       listBox1.Items.Add(i);
    }
 
    // The user wants to exit the application. Close everything down.
    Application.Exit();
 }

// </Snippet1>
}
