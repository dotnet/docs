        private void searchButton_Click(System.Object sender, System.EventArgs e)
        {
            int foundIndex;
            string searchString;
            searchString = searchTextBox.Text;
            foundIndex = productsBindingSource.Find("ProductID", searchString);
            if (foundIndex > -1)
            {
                dataRepeater1.CurrentItemIndex = foundIndex;
            }
            else
            {
                MessageBox.Show("Item " + searchString + " not found.");
            }
        }