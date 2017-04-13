using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected Button button2;
 protected int myVar;
// <Snippet1>
private void button1_Click (Object sender, 
                               EventArgs e)
 {
    // If myVar is an even number, click Button2.
    if(myVar %2 == 0)
    {
       button2.PerformClick();
       // Display the status of Button2's Click event.
       MessageBox.Show("button2 was clicked ");
    }
    else
    {
       // Display the status of Button2's Click event.
       MessageBox.Show("button2 was NOT clicked");
    }
    // Increment myVar.   
    myVar = myVar + 1;
 }
 
// </Snippet1>
}
