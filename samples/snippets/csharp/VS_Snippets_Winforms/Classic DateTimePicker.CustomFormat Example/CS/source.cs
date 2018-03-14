using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1: Form
{
   protected DateTimePicker dateTimePicker1;
// <Snippet1>
public void SetMyCustomFormat()
{
   // Set the Format type and the CustomFormat string.
   dateTimePicker1.Format = DateTimePickerFormat.Custom;
   dateTimePicker1.CustomFormat = "MMMM dd, yyyy - dddd";
}

// </Snippet1>
}
