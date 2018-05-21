        private void dataRepeater1_ItemsRemoved(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsEventArgs e)
        {
            Employees.RemoveAt(e.ItemIndex);
        }