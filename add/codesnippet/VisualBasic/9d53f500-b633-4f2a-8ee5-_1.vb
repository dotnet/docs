    Sub Page_Init(sender As Object, e As EventArgs)
        Dim myList As New ArrayList()
        Dim myColumnCollection As New DataGridColumnCollection(ItemsGrid, myList)
    End Sub 'Page_Init