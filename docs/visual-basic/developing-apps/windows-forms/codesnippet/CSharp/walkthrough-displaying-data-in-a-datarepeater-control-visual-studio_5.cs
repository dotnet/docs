            int foundIndex;
            string searchString;
            searchString = searchTextBox.Text;
            // Search for the string in the CustomerID field.
            foundIndex = customersBindingSource.Find("CustomerID", searchString);
            if (foundIndex > -1)
            {
                dataRepeater1.CurrentItemIndex = foundIndex;
            }
            else
            {
                MessageBox.Show("Item " + searchString + " not found.");
            }