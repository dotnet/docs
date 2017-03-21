    void ContactsListView_ItemUpdated(Object sender, ListViewUpdatedEventArgs e)
    {
        if (e.Exception != null)
        {
            if (e.AffectedRows == 0)
            {
                e.KeepInEditMode = true;
                Message.Text = "An exception occurred updating the contact. " +
                                    "Please verify your values and try again.";
            }
            else
                Message.Text = "An exception occurred updating the contact. " +
                                    "Please verify the values in the recently updated item.";

            e.ExceptionHandled = true;
        }
    }