using System;
using System.Windows.Forms;

public class Form1: Form
{
 protected MonthCalendar monthCalendar1;
 protected TextBox textBox1;
 protected TextBox textBox2;

// <Snippet1>
private void button1_Click(object sender,
                           EventArgs e)
{
   // Set the SelectionRange with start and end dates from text boxes.
   try
   {
      monthCalendar1.SelectionRange = new SelectionRange(
        DateTime.Parse(textBox1.Text),
        DateTime.Parse(textBox2.Text));
   }
   catch(Exception ex)
   {
      MessageBox.Show(ex.Message);
   }
}
// </Snippet1>
}
