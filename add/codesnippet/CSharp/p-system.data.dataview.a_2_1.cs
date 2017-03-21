    private void EditRow(DataView view)
    {
        view.AllowEdit = true;
        view[0].BeginEdit();
        view[0]["FirstName"] = "Mary";
        view[0]["LastName"] = "Jones";
        view[0].EndEdit();
    }