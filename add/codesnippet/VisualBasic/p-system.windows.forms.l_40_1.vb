
    ' Declare the Listview object.
    Friend WithEvents myListView As System.Windows.Forms.ListView

    ' Initialize the ListView object with subitems of a different
    ' style than the default styles for the ListView.
    Private Sub InitializeListView()

        ' Set the Location, View and Width properties for the 
        ' ListView object. 
        myListView = New ListView
        With (myListView)
            .Location = New System.Drawing.Point(20, 20)

            ' The View property must be set to Details for the 
            ' subitems to be visible.
            .View = View.Details
            .Width = 250
        End With

        ' Each SubItem object requires a column, so add three columns.
        Me.myListView.Columns.Add("Key", 50, HorizontalAlignment.Left)
        Me.myListView.Columns.Add("A", 100, HorizontalAlignment.Left)
        Me.myListView.Columns.Add("B", 100, HorizontalAlignment.Left)

        ' Add a ListItem object to the ListView.
        Dim entryListItem As ListViewItem = myListView.Items.Add("Items")

        ' Set UseItemStyleForSubItems property to false to change 
        ' look of subitems.
        entryListItem.UseItemStyleForSubItems = False

        ' Add the expense subitem.
        Dim expenseItem As ListViewItem.ListViewSubItem = _
            entryListItem.SubItems.Add("Expense")

        ' Change the expenseItem object's color and font.
        expenseItem.ForeColor = System.Drawing.Color.Red
        expenseItem.Font = New System.Drawing.Font _
            ("Arial", 10, System.Drawing.FontStyle.Italic)

        ' Add a subitem called revenueItem 
        Dim revenueItem As ListViewItem.ListViewSubItem = _
            entryListItem.SubItems.Add("Revenue")

        ' Change the revenueItem object's color and font.
        revenueItem.ForeColor = System.Drawing.Color.Blue
        revenueItem.Font = New System.Drawing.Font _
            ("Times New Roman", 10, System.Drawing.FontStyle.Bold)

        ' Add the ListView to the form.
        Me.Controls.Add(Me.myListView)
    End Sub