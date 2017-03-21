    ' Count items in each department
    Private Sub List1_ItemDataBind(ByVal sender As Object, ByVal e As ObjectListDataBindEventArgs)
        Select Case CType(e.DataItem, GroceryItem).Department
            Case "Bakery"
                bakeryCount += 1
            Case "Dairy"
                dairyCount += 1
            Case "Produce"
                produceCount += 1
        End Select
    End Sub