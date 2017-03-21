    ' This method adds two columns to the ListView, setting the Text 
    ' and TextAlign, and Width properties of each ColumnHeader.  The 
    ' HeaderStyle property is set to NonClickable since the ColumnClick 
    ' event is not handled.  Finally the method adds ListViewItems and 
    ' SubItems to each column.
    Private Sub InitializeListView()
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.ListView1.BackColor = System.Drawing.SystemColors.Control
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(292, 130)
        Me.ListView1.TabIndex = 0
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.MultiSelect = True
        Me.ListView1.HideSelection = False
        ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
        Dim columnHeader1 As New ColumnHeader
        With columnHeader1
            .Text = "Breakfast Item"
            .TextAlign = HorizontalAlignment.Left
            .Width = 146
        End With
        Dim columnHeader2 As New ColumnHeader
        With columnHeader2
            .Text = "Price Each"
            .TextAlign = HorizontalAlignment.Center
            .Width = 142
        End With

        Me.ListView1.Columns.Add(columnHeader1)
        Me.ListView1.Columns.Add(columnHeader2)
        Dim foodList() As String = New String() {"Juice", "Coffee", _
            "Cereal & Milk", "Fruit Plate", "Toast & Jelly", _
            "Bagel & Cream Cheese"}
        Dim foodPrice() As String = New String() {"1.09", "1.09", _
            "2.19", "2.49", "1.49", "1.49"}
        Dim count As Integer
        For count = 0 To foodList.Length - 1
            Dim listItem As New ListViewItem(foodList(count))
            listItem.SubItems.Add(foodPrice(count))
            ListView1.Items.Add(listItem)
        Next
        Me.Controls.Add(Me.ListView1)
    End Sub