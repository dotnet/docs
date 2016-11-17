        Dim foundIndex As Integer
        Dim searchString As String
        searchString = SearchTextBox.Text
        ' Search for the string in the CustomerID field.
        foundIndex = CustomersBindingSource.Find("CustomerID",
         searchString)
        If foundIndex > -1 Then
            DataRepeater1.CurrentItemIndex = foundIndex
        Else
            MsgBox("Item " & searchString & " not found.")
        End If