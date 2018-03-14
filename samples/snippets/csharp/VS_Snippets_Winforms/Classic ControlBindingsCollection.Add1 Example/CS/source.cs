using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

public class Form1 : Form {

    protected TextBox textBox1;

// <Snippet1>
private void BindTextBoxProperties()
{
   // Clear the collection before adding new Binding objects.
   textBox1.DataBindings.Clear();

   // Create a DataTable containing Color objects.
   DataTable t = MakeTable();

   /* Bind the Text, BackColor, and ForeColor properties
   to columns in the DataTable. */
   textBox1.DataBindings.Add("Text", t, "Text");
   textBox1.DataBindings.Add("BackColor", t, "BackColor");
   textBox1.DataBindings.Add("ForeColor", t, "ForeColor");
}

private DataTable MakeTable()
{
   /* Create a DataTable with three columns.
   Two of the columns contain Color objects. */

   DataTable t = new DataTable("Control");
   t.Columns.Add("BackColor", typeof(Color));
   t.Columns.Add("ForeColor", typeof(Color));
   t.Columns.Add("Text");

   // Add three rows to the table.
   DataRow r;

   r = t.NewRow();
   r["BackColor"] = Color.Blue;
   r["ForeColor"] = Color.Yellow;
   r["Text"] = "Yellow on Blue";
   t.Rows.Add(r);

   r = t.NewRow();
   r["BackColor"] = Color.White;
   r["ForeColor"] = Color.Green;
   r["Text"] = "Green on white";
   t.Rows.Add(r);

   r = t.NewRow();
   r["BackColor"] = Color.Orange;
   r["ForeColor"] = Color.Black;
   r["Text"] = "Black on Orange";
   t.Rows.Add(r);

   return t;
}
// </Snippet1>

}
