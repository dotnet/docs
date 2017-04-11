using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
// <Snippet1>
public void InitializeMyForm()
 {
    this.BackColor = Color.Red;
    // Make the background color of form display transparently.
    this.TransparencyKey = BackColor;
 }
    
// </Snippet1>
}
