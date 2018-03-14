using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
public void CreateMyBorderlessWindow()
 {
    this.FormBorderStyle = FormBorderStyle.None;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    // Remove the control box so the form will only display client area.
    this.ControlBox = false;
 }
 
// </Snippet1>
}
