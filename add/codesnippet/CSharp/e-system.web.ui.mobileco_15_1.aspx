    // Count items in each department
    private void List1_ItemDataBind(object sender, ObjectListDataBindEventArgs e)
    {
        switch (((GroceryItem)e.DataItem).Department)
        {
            case "Bakery":
                bakeryCount++;
                break;
            case "Dairy":
                dairyCount++;
                break;
            case "Produce":
                produceCount++;
                break;
        }
    }