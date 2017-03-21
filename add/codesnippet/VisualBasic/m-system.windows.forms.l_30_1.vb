    Private Sub InitializeListView()
        Me.ListView1 = New System.Windows.Forms.ListView

        ' Set properties such as BackColor, Location and Size
        Me.ListView1.BackColor = System.Drawing.SystemColors.Control
        Me.ListView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Size = New System.Drawing.Size(292, 130)
        Me.ListView1.View = System.Windows.Forms.View.Details
        Me.ListView1.HideSelection = False

        ' Allow user to select multiple items.
        Me.ListView1.MultiSelect = True

        ' Show check boxes in the ListView.
        Me.ListView1.CheckBoxes = True

        'Set the column headers and populate the columns.
        ListView1.HeaderStyle = ColumnHeaderStyle.Nonclickable
        Dim columnHeader1 As New ColumnHeader
        With columnHeader1
            .Text = "Breakfast Choices"
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

        Dim foodPrice() As String = New String() {"1.09", "1.09", "2.19", _
            "2.79", "2.09", "2.69"}
        Dim count As Integer

        ' Members are added one at a time, so call BeginUpdate to ensure 
        ' the list is painted only once, rather than as each list item is added.
        ListView1.BeginUpdate()

        For count = 0 To foodList.Length - 1
            Dim listItem As New ListViewItem(foodList(count))
            listItem.SubItems.Add(foodPrice(count))
            ListView1.Items.Add(listItem)
        Next

        'Call EndUpdate when you finish adding items to the ListView.
        ListView1.EndUpdate()
        Me.Controls.Add(Me.ListView1)
    End Sub