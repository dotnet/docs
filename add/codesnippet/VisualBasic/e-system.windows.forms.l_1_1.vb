    'This event handler enables search functionality, and is called
    'for every search request when in Virtual mode.
    Private Sub listView1_SearchForVirtualItem(ByVal sender As Object, ByVal e As SearchForVirtualItemEventArgs) Handles listView1.SearchForVirtualItem
        'We've gotten a search request.
        'In this example, finding the item is easy since it's
        'just the square of its index.  We'll take the square root
        'and round.
        Dim x As Double = 0
        If [Double].TryParse(e.Text, x) Then 'check if this is a valid search
            x = Math.Sqrt(x)
            x = Math.Round(x)
            e.Index = Fix(x)
        End If
        'Note that this only handles simple searches over the entire
        'list, ignoring any other settings.  Handling Direction, StartIndex,
        'and the other properties of SearchForVirtualItemEventArgs is up
        'to this handler.
    End Sub