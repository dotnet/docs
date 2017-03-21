    private void Status_ItemCommand(object sender, 
        ListCommandEventArgs e)
    {
        const string spec = "You now have {0} " + 
            "tasks done, {1} tasks scheduled, and " +
            "{2} tasks pending.";

        // Move selection to next status toward 'done'
        switch (e.ListItem.Value)
        {
            case "scheduled":
                schedCount -= 1;
                pendCount += 1;
                e.ListItem.Value = "pending";
                break;
            case "pending":
                pendCount -= 1;
                doneCount += 1;
                e.ListItem.Value = "done";
                break;
        }

        // Show the status of the current task
        Label1.Text = e.ListItem.Text + " is " +
            e.ListItem.Value;

        // Show current selection counts
        Label2.Text = String.Format(spec, doneCount, 
            schedCount, pendCount);
    }