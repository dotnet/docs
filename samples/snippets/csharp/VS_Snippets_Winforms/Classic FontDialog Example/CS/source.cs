using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 protected FontDialog fontDialog1;
// <Snippet1>
private void button1_Click(object sender, System.EventArgs e)
 {
    fontDialog1.ShowColor = true;

    fontDialog1.Font = textBox1.Font;
    fontDialog1.Color = textBox1.ForeColor;

    if(fontDialog1.ShowDialog() != DialogResult.Cancel )
    {
       textBox1.Font = fontDialog1.Font ;
       textBox1.ForeColor = fontDialog1.Color;
    }
 }
 
// </Snippet1>
}
