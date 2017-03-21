      private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
      {
         // Get the currently selected item in the ListBox.
         string curItem = listBox1.SelectedItem.ToString();

         // Find the string in ListBox2.
         int index = listBox2.FindString(curItem);
         // If the item was not found in ListBox 2 display a message box, otherwise select it in ListBox2.
         if(index == -1)
            MessageBox.Show("Item is not available in ListBox2");
         else
            listBox2.SetSelected(index,true);
      }