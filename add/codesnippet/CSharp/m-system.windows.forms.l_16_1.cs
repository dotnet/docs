      private void RemoveTopItems()
      {
         // Determine if the currently selected item in the ListBox 
         // is the item displayed at the top in the ListBox.
         if (listBox1.TopIndex != listBox1.SelectedIndex)
            // Make the currently selected item the top item in the ListBox.
            listBox1.TopIndex = listBox1.SelectedIndex;

         // Remove all items before the top item in the ListBox.
         for (int x = (listBox1.SelectedIndex -1); x >= 0; x--)
         {
            listBox1.Items.RemoveAt(x);
         }

         // Clear all selections in the ListBox.
         listBox1.ClearSelected();
      }