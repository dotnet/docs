using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected ComboBox comboBox1;
 protected ComboBox comboBox2;
 protected NumericUpDown numericUpDown1;
// <Snippet1>
private void comboBox1_SelectedIndexChanged(Object sender, 
                                             EventArgs e)
 {
      // Set the BorderStyle property.
     switch(comboBox1.Text)
     {
         case "Fixed3D":
             numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
             break;
         case "None":
             numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.None;
             break;
         case "FixedSingle":
             numericUpDown1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
             break;
     }
 }
 
 private void comboBox2_SelectedIndexChanged(Object sender, 
                                             EventArgs e)
 {
      // Set the TextAlign property.    
     switch (comboBox2.Text)
     {
         case "Right":
             numericUpDown1.TextAlign = HorizontalAlignment.Right;
             break;
         case "Left":
             numericUpDown1.TextAlign = HorizontalAlignment.Left;
             break;
         case "Center":
             numericUpDown1.TextAlign = HorizontalAlignment.Center;
             break;
     }
 }
 
 private void checkBox1_Click(Object sender, 
                              EventArgs e)
 {
      // Evaluate and toggle the ReadOnly property.
     if (numericUpDown1.ReadOnly)
     {
         numericUpDown1.ReadOnly = false;
     }
     else
     {
         numericUpDown1.ReadOnly = true;
     }
 }
 
 private void checkBox2_Click(Object sender, 
                              EventArgs e)
 {
      // Evaluate and toggle the InterceptArrowKeys property.
     if (numericUpDown1.InterceptArrowKeys)
     {  
         numericUpDown1.InterceptArrowKeys = false;
     }
     else
     {
         numericUpDown1.InterceptArrowKeys = true;
     }
 }
 
 private void checkBox3_Click(Object sender, 
                              EventArgs e)
 {
      // Evaluate and toggle the UpDownAlign property.
     if (numericUpDown1.UpDownAlign == LeftRightAlignment.Left)
     {
         numericUpDown1.UpDownAlign = LeftRightAlignment.Right;
     }
     else
     {
         numericUpDown1.UpDownAlign = LeftRightAlignment.Left;
     }
 }
 
// </Snippet1>
}
