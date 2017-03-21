    private void AdCreated_Event(Object sender, AdCreatedEventArgs e)
    {
       Label2.Text = "Clicking the AdRotator control takes you to " + 
           e.NavigateUrl;
    }