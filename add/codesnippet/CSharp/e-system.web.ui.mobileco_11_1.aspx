    private void Status_DataBinding(object sender, 
        ListDataBindEventArgs e)
    {
        // Increment initial counts
        switch (e.ListItem.Value)
        {
            case "done":
                doneCount += 1;
                break;
            case "scheduled":
                schedCount += 1;
                break;
            case "pending":
                pendCount += 1;
                break;
        }
    }