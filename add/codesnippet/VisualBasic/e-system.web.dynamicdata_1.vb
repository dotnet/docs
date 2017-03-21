    ' Handle the filter change event.
    Protected Sub OnFilterSelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        ' Reset the index of the page to display after 
        ' the data filter value has been changed.
        GridView1.PageIndex = 0

    End Sub