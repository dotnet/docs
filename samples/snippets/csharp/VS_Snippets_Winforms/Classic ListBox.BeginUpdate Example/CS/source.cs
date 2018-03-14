using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;

public class Form1: Form
{
 protected ListBox listBox1;
// <Snippet1>
public void AddToMyListBox()
{
   // Stop the ListBox from drawing while items are added.
   listBox1.BeginUpdate();

   // Loop through and add five thousand new items.
   for(int x = 1; x < 5000; x++)
   {
      listBox1.Items.Add("Item " + x.ToString());   
   }
   // End the update process and force a repaint of the ListBox.
   listBox1.EndUpdate();
}

// </Snippet1>
}
