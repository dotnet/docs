        Public Sub New()
            With Me
                .RowTemplate = New DataGridViewCustomRow()
                .Columns.Add(New DataGridViewCustomColumn())
                .Columns.Add(New DataGridViewCustomColumn())
                .Columns.Add(New DataGridViewCustomColumn())
                .RowCount = 4
                .EnableHeadersVisualStyles = False
                .AutoSize = True
            End With
        End Sub