using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox listBox1;
 protected RadioButton radioButton1;
 protected RadioButton radioButton2;
// <Snippet1>
 private void ClickMyRadioButton()
 {
    // If Item1 is selected and radioButton2 
    // is checked, click radioButton1.
    if (listBox1.Text == "Item1" && radioButton2.Checked)
    {
       radioButton1.PerformClick();
    }
 }
 
// </Snippet1>
}
