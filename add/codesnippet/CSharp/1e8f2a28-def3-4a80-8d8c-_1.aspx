        //Set the SelectedIndex to -1 so no items are selected.
        // The new item will be set as the selected item when it is added.
        DropDownList1.SelectedIndex = -1;
        // Add the selected item to DropDownList1.
        DropDownList1.Items.Add(ListBox1.SelectedItem);
        // Delete the selected item from ListBox1.
        ListBox1.Items.Remove(ListBox1.SelectedItem);