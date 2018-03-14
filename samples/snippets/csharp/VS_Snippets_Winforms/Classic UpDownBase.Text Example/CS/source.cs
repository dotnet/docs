using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected NumericUpDown numericUpDown1;

// <Snippet1>
private void numericUpDown1_Leave(Object sender,
                                  EventArgs e)
{
   /* If the entered value is greater than Minimum or Maximum,
      select the text and open a message box. */
   if((System.Convert.ToInt32(numericUpDown1.Text) > numericUpDown1.Maximum) ||
      (System.Convert.ToInt32(numericUpDown1.Text) < numericUpDown1.Minimum))
   {
      MessageBox.Show("The value entered was not between the Minimum and" +
         "Maximum allowable values." + "\n" + "Please re-enter.");
      numericUpDown1.Focus();
      numericUpDown1.Select(0, numericUpDown1.Text.Length);
   }
}
   
private void button1_Click(Object sender,
                           EventArgs e)
{
   int varPrefHeight1;
   
   /* Capture the PreferredHeight before and after the Font
      is changed, and display the results in a message box. */
   varPrefHeight1 = numericUpDown1.PreferredHeight;
   numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif",
      12F, System.Drawing.FontStyle.Bold);
   MessageBox.Show("Before Font Change: " + varPrefHeight1.ToString() +
      "\n" + "After Font Change: " + numericUpDown1.PreferredHeight.ToString());
}

// </Snippet1>
}
