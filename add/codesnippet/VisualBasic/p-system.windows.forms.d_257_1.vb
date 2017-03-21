    Private Sub AddLinkColumn()

        Dim links As New DataGridViewLinkColumn()
        With links
            .UseColumnTextForLinkValue = True
            .HeaderText = ColumnName.ReportsTo.ToString()
            .DataPropertyName = ColumnName.ReportsTo.ToString()
            .ActiveLinkColor = Color.White
            .LinkBehavior = LinkBehavior.SystemDefault
            .LinkColor = Color.Blue
            .TrackVisitedState = True
            .VisitedLinkColor = Color.YellowGreen
        End With
        DataGridView1.Columns.Add(links)
    End Sub