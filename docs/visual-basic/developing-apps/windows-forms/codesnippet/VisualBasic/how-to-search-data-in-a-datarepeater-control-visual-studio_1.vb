    Private Sub SearchButton_Click() Handles SearchButton.Click
        Dim foundIndex As Integer
        Dim searchString As String
        searchString = SearchTextBox.Text
        foundIndex = ProductsBindingSource.Find("ProductID", 
           searchString)
        If foundIndex > -1 Then
            DataRepeater1.CurrentItemIndex = foundIndex
        Else
            MsgBox("Item " & searchString & " not found.")
        End If
    End Sub