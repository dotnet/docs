    Private Sub InitializeListView()

        ' Set up the inital values for the ListView and populate it.
        Me.ListView1 = New ListView
        Me.ListView1.Dock = DockStyle.Top
        Me.ListView1.Location = New System.Drawing.Point(0, 0)
        Me.ListView1.Size = New System.Drawing.Size(292, 130)
        Me.ListView1.View = View.Details
        Me.ListView1.FullRowSelect = True

        Dim breakfast() As String = New String() {"Continental Breakfast", "Pancakes and Sausage", _
       "Denver Omelet", "Eggs & Bacon", "Bagel & Cream Cheese"}

        Dim breakfastPrices() As String = New String() {"3.09", "4.09", "4.19", _
           "4.79", "2.09"}

        PopulateMenu("Breakfast", breakfast, breakfastPrices)
    End Sub

    Private Sub PopulateMenu(ByVal meal As String, _
        ByVal menuItems() As String, ByVal menuPrices() As String)
        Dim columnHeader1 As New ColumnHeader
        With columnHeader1
            .Text = meal & " Choices"
            .TextAlign = HorizontalAlignment.Left
            .Width = 146
        End With
        Dim columnHeader2 As New ColumnHeader
        With columnHeader2
            .Text = "Price"
            .TextAlign = HorizontalAlignment.Center
            .Width = 142
        End With
        Me.ListView1.Columns.Add(columnHeader1)
        Me.ListView1.Columns.Add(columnHeader2)

        Dim count As Integer

        For count = 0 To menuItems.Length - 1
            Dim listItem As New ListViewItem(menuItems(count))
            listItem.SubItems.Add(menuPrices(count))
            ListView1.Items.Add(listItem)
        Next

        ' Use the Selected property to select the first item on 
        ' the list.
        ListView1.Focus()
        ListView1.Items(0).Selected = True
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Create new values for the ListView, clear the list, 
        ' and repopulate it.
        Dim lunch() As String = New String() {"Hamburger", _ 
            "Grilled Cheese", "Soup & Salad", "Club Sandwich", "Hotdog"}

        Dim lunchPrices() As String = New String() {"4.09", "5.09", _
            "5.19", "4.79", "2.09"}

        ListView1.Clear()

        PopulateMenu("Lunch", lunch, lunchPrices)
        Button1.Enabled = False
    End Sub