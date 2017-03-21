      private void SizeMyListBox()
      {
         // Add items to the ListBox.
         for(int x = 0; x < 20; x++)
         {
            listBox1.Items.Add("Item " + x.ToString());
         }
         // Set the height of the ListBox to the preferred height to display all items.
         listBox1.Height = listBox1.PreferredHeight;
      }