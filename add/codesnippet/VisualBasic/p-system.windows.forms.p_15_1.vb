
    'Declare a propertyGrid.
    Friend WithEvents propertyGrid1 As PropertyGrid

    'Initialize propertyGrid1.
    Private Sub InitializePropertyGrid()
        propertyGrid1 = New PropertyGrid
        propertyGrid1.Name = "PropertyGrid1"
        propertyGrid1.Location = New Point(185, 20)
        propertyGrid1.Size = New System.Drawing.Size(150, 300)
        propertyGrid1.TabIndex = 5

        'Set the sort to alphabetical and set Toolbar visible
        'to false, so the user cannot change the sort.
        propertyGrid1.PropertySort = PropertySort.Alphabetical
        propertyGrid1.ToolbarVisible = False
        propertyGrid1.Text = "Property Grid"

        ' Add the PropertyGrid to the form, but set its
        ' visibility to False so it will not appear when the form loads.
        propertyGrid1.Visible = False
        Me.Controls.Add(propertyGrid1)

    End Sub