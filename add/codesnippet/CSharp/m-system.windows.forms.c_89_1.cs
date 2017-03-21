        private void WhatIsChecked_Click(object sender, System.EventArgs e) {
            // Display in a message box all the items that are checked.

            // First show the index and check state of all selected items.
            foreach(int indexChecked in checkedListBox1.CheckedIndices) {
                // The indexChecked variable contains the index of the item.
                MessageBox.Show("Index#: " + indexChecked.ToString() + ", is checked. Checked state is:" +
                                checkedListBox1.GetItemCheckState(indexChecked).ToString() + ".");
            }

            // Next show the object title and check state for each item selected.
            foreach(object itemChecked in checkedListBox1.CheckedItems) {

                // Use the IndexOf method to get the index of an item.
                MessageBox.Show("Item with title: \"" + itemChecked.ToString() + 
                                "\", is checked. Checked state is: " + 
                                checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() + ".");
            }

        }