using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected TextBox textBox1;
// <Snippet1>
private void button1_Click(object sender, System.EventArgs e)
{
   // Create an instance of the ListBox.
   ListBox listBox1 = new ListBox();
   // Set the size and location of the ListBox.
   listBox1.Size = new System.Drawing.Size(200, 100);
   listBox1.Location = new System.Drawing.Point(10,10);
   // Add the ListBox to the form.
   this.Controls.Add(listBox1);
   // Set the ListBox to display items in multiple columns.
   listBox1.MultiColumn = true;
   // Set the selection mode to multiple and extended.
   listBox1.SelectionMode = SelectionMode.MultiExtended;
 
   // Shutdown the painting of the ListBox as items are added.
   listBox1.BeginUpdate();
   // Loop through and add 50 items to the ListBox.
   for (int x = 1; x <= 50; x++)
   {
      listBox1.Items.Add("Item " + x.ToString());
   }
   // Allow the ListBox to repaint and display the new items.
   listBox1.EndUpdate();
      
   // Select three items from the ListBox.
   listBox1.SetSelected(1, true);
   listBox1.SetSelected(3, true);
   listBox1.SetSelected(5, true);

   // Display the second selected item in the ListBox to the console.
   System.Diagnostics.Debug.WriteLine(listBox1.SelectedItems[1].ToString());
   // Display the index of the first selected item in the ListBox.
   System.Diagnostics.Debug.WriteLine(listBox1.SelectedIndices[0].ToString());             
}

// </Snippet1>
}
