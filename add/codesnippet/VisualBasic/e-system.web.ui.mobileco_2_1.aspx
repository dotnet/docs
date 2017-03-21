    Private Sub AdCreated_Event(ByVal sender As Object, _
        ByVal e As AdCreatedEventArgs)
        
        Label2.Text = "Clicking the AdRotator control takes you to " + _
            e.NavigateUrl
    End Sub