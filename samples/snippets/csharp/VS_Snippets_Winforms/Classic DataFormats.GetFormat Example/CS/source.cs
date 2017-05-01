using System;
using System.IO;
using System.Data;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
 
// <Snippet1>
 private void GetMyFormatInfomation() {
    // Creates a DataFormats.Format for the Unicode data format.
    DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.UnicodeText);
 
    // Displays the contents of myFormat.
    textBox1.Text = "ID value: " + myFormat.Id + '\n' +
       "Format name: " + myFormat.Name;
 }
 
// </Snippet1>
}
