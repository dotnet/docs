    public void CreateDataView(DataTable table) 
    {
        DataView view = new DataView(table, "", 
            "ContactName", DataViewRowState.CurrentRows);

        view.ListChanged  += new 
            System.ComponentModel.ListChangedEventHandler(
            OnListChanged);
    }

    private void OnListChanged(object sender, 
        System.ComponentModel.ListChangedEventArgs args)
    {
        Console.WriteLine("ListChanged:");
        Console.WriteLine("\table    Type = " + args.ListChangedType);
        Console.WriteLine("\tOldIndex = " + args.OldIndex);
        Console.WriteLine("\tNewIndex = " + args.NewIndex);
    }