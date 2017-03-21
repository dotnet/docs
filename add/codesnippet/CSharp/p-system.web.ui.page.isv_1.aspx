    private void ValidateBtn_Click(Object Sender, EventArgs E)
    {
        Page.Validate();
        if (Page.IsValid == true)
            lblOutput.Text = "Page is Valid!";
        else
            lblOutput.Text = "Some required fields are empty.";
    }